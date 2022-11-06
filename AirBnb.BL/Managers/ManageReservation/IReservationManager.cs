using AirBnb.BL.DTOs.ReservationDTOs;
using AirBnb.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirBnb.BL.Managers.ManageReservation
{
    public interface IReservationManager
    {
        Task<ReservationReadDto> GetReservationById(Guid reservationId);
        Task<IEnumerable<ReservationReadDto>> GetSpecificHosterReservations(string hosterId);
        Task<IEnumerable<ReservationReadDto>> GetReservationsOnProperty(Guid propertyId);
        Task<IEnumerable<ReservationReadDto>> GetActiveReservations(string hosterId);
        Task<ReservationReadDto> GetPropertyActiveReservation(Guid propertyId);
        Task<IEnumerable<ReservationReadDto>> GetFutureReservations(string hosterId);
        Task<IEnumerable<ReservationReadDto>> GetPropertyFutureReservations(Guid propertyId);
        Task<IEnumerable<ReservationReadDto>> GetHistoryReservations(string hosterId);
        Task<IEnumerable<ReservationReadDto>> GetPropertyHistoryReservations(Guid propertyId);
        Task<double> GetAllReservationsBalance(ReservationHosterBalanceDto model);
        Task<double> GetSpecificPropertyReservationsBalance(ReservationPropertyBalanceDto model);

        //Creating user reservation
        Task<ReservationReadDto> CreateReservationToAUser(ReservationAddDto model);




    }
}
