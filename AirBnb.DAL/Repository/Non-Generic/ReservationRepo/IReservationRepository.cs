using AirBnb.DAL.Data.Models;
using AirBnb.DAL.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirBnb.DAL.Repository.Non_Generic.ReservationRepo
{
    public interface IReservationRepository:IBaseRepository<Reservation>
    {
        //This repository is responsible for all reservation operattions
        //This section is responsible for the hoster managing property reservations
        //Get spicific reservation
        Task<Reservation> GetReservationById(Guid reservationId);
        //Get all reservations of the hoster
        Task<IEnumerable<Reservation>> GetSpecificUserReservations(string hosterId);
        //get reservations on specific property
        Task<IEnumerable<Reservation>> GetReservationsOnProperty(Guid propertyId);
        //get the current active reservations
        //Active means that the property is reserved now
        //Active reservations for all properties to a specific hoster
        Task<IEnumerable<Reservation>> GetActiveReservations(string hosterId);
        //Active reservation for specific property
        Task<Reservation> GetPropertyActiveReservation(Guid propertyId);
        //get the future reservations
        //Active means that the property is reserved now
        //future reservations for all properties to a specific hoster
        Task<IEnumerable<Reservation>> GetFutureReservations(string hosterId);
        //future reservations for specific property
        Task<IEnumerable<Reservation>> GetPropertyFutureReservations(Guid propertyId);
        //get the reservation history
        //history means the past reservations
        //history reservations for all properties to a specific hoster
        Task<IEnumerable<Reservation>> GetHistoryReservations(string hosterId);
        //future reservations for specific property
        Task<IEnumerable<Reservation>> GetPropertyHistoryReservations(Guid propertyId);
        //Get the balance of reservations
        //Getting the total balance of all properties to a specific user
        //if there is no date or time sent
        Task<double> GetAllReservationsBalance(string hosterId, DateTime? startDate, DateTime? endDate);
        //Getting specific property balance
        Task<double> GetSpecificPropertyReservationsBalance(Guid propertyId, DateTime? startDate, DateTime? endDate);
        //user section
        //Getting all reservations for a user
        Task<IEnumerable<Reservation>> GetAllUserReservations(string userId);
        //Getting user specific eservation
        Task<Reservation> GetSpecificReservationToAUser(string userId,Guid reservationId);
        //Create new reservation for a user
        Task<Reservation> CreateReservationToAUser(string userId,Guid propertyId,DateTime startDate, DateTime endDate);





    }
}
