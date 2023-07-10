using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Restaurant_Reservation_Management_System_Api.Data;
using Restaurant_Reservation_Management_System_Api.Dto.User.Reservation;
using Restaurant_Reservation_Management_System_Api.Dto.User.Table;
using Restaurant_Reservation_Management_System_Api.Model;

namespace Restaurant_Reservation_Management_System_Api.Services.User.ReservationService
{
    public class ReservationServicesUser : IReservationServicesUser
    {
        private readonly RestaurantDbContext _context;

        private readonly IMapper _mapper;

        public ReservationServicesUser(RestaurantDbContext context , IMapper mapper)
        {
            _context = context;
            _mapper = mapper;   

        }

        public async Task<ServiceResponse<GetReservationDtoUser>> PostReservation(CreateReservationDtoUser createReservationDtoUser)
        {
            var serviceResponse =  new ServiceResponse<GetReservationDtoUser>();

            try
            {

                var findTable = await _context.Tables.FirstOrDefaultAsync(t => t.TableNumber == createReservationDtoUser.TableNumber);

                var tableId = findTable.TableId;

               // var reservationDate = createReservationDtoUser.ReservationDate;
               // DateTime dateOnly = reservationDate.Date;

                if(findTable.IsOccupied == true)
                {
                    serviceResponse.Message = "Table is Already Booked!";
                    serviceResponse.Success = false;
                    return serviceResponse;
                }

                if(createReservationDtoUser.NumberOfGuests > findTable.Capacity)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "The Number Of Guest are higher than the Table Capacity";
                    return serviceResponse;
                }
            
                var newReservation = new Reservation()
                {
                    CustomerId = 2,
                    TableId = tableId,
                    ReservationDate = createReservationDtoUser.ReservationDate.Date,
                    StartTime = createReservationDtoUser.StartTime,
                    EndTime = createReservationDtoUser.EndTime,
                    NumberOfGuests = createReservationDtoUser.NumberOfGuests,
                    

                };

                findTable.IsOccupied = true; 
              

                _context.Reservations.Add(newReservation);

                await _context.SaveChangesAsync();

              

                var customer = await _context.Customers.FirstOrDefaultAsync(c => c.CustomerId == newReservation.CustomerId);

                var customerName = customer?.Name;

                var reservationDto = new GetReservationDtoUser()
                {
                    CustomerId = newReservation.CustomerId,
                    CustomerName = newReservation.Customer.Name,
                    TableId = newReservation.TableId,
                    TableNumber = newReservation.Table.TableNumber,
                    ReservationDate = newReservation.ReservationDate,
                    StartTime = newReservation.StartTime,
                    EndTime = newReservation.EndTime,
                    NumberOfGuests = newReservation.NumberOfGuests
                };

                serviceResponse.Data = reservationDto;
                serviceResponse.Message = "Table Reserved Successfully";
                serviceResponse.Success = true;
            }
            catch(Exception ex)
            {
                serviceResponse.Message += ex.ToString();
                serviceResponse.Success = false;
            }

            return serviceResponse;

        }

        public async Task<ServiceResponse<string>> DeleteReservation(int id)
        {
            var serviceResponse = new ServiceResponse<string>();
            try
            {
                var reservation = await _context.Reservations.FindAsync(id);

                if(reservation == null)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = $"Reservation Not Found With Id {id}";
                    return serviceResponse;
                }

                _context.Reservations.Remove(reservation);
                await _context.SaveChangesAsync();
                serviceResponse.Success = true;
                serviceResponse.Message = "Deleted the Reservation Successfully";

            }
            catch(Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
                
            }
            return serviceResponse;

        }


        public async Task<ServiceResponse<List<GetTableDtoUser>>> GetAvailableTables(GetReservationDetailsForTableDtoUser getReservationDetailsForTableDtoUser)
        {
            var response = new ServiceResponse<List<GetTableDtoUser>>();


            try
            {
                // Retrieve all tables from the database
                var allTables = await _context.Tables.Where(table => table.Capacity >= getReservationDetailsForTableDtoUser.NumberOfGuests)
                    .OrderBy(table => Math.Abs(table.Capacity - getReservationDetailsForTableDtoUser.NumberOfGuests))
                    .ToListAsync();

                if(allTables == null)
                {
                    response.Success = false;
                    response.Message = "No Tables Available For this Slot";
                    return response;
                }

                // Filter the tables based on the reservation date and time range
                var availableTables = new List<GetTableDtoUser>();

                foreach (var table in allTables)
                {
                    // Check if the table is not occupied during the specified reservation period
                    if (!IsTableOccupied(table.TableId, getReservationDetailsForTableDtoUser.ReservationDate, getReservationDetailsForTableDtoUser.StartTime, getReservationDetailsForTableDtoUser.EndTime))
                    {
                        availableTables.Add(new GetTableDtoUser
                        {
                            TableId = table.TableId,
                            TableNumber = table.TableNumber
                        });
                    }
                }

                response.Data = availableTables;
                response.Message = "Available tables retrieved successfully";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Error retrieving available tables: " + ex.Message;
            }

            return response;

        }

        private bool IsTableOccupied(int tableId, DateTime reservationDate, DateTime startTime, DateTime endTime)
        {
            // Retrieve reservations for the specified table and date from the database
            var reservationsForTable = _context.Reservations
                .Where(r => r.TableId == tableId && r.ReservationDate.Date == reservationDate.Date)
                .ToList();

            foreach (var reservation in reservationsForTable)
            {
                // Check if the reservation overlaps with the specified period
                if (reservation.StartTime <= endTime && reservation.EndTime >= startTime)
                {
                    return true; // Table is occupied
                }
            }

            return false; // Table is available
        }



    }
}
