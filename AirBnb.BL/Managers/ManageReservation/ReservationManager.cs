using AirBnb.BL.DTOs.PropertyDTOs;
using AirBnb.BL.DTOs.ReservationDTOs;
using AirBnb.BL.Managers.ManageProperty;
using AirBnb.DAL.Data.Models;
using AirBnb.DAL.Repository.Non_Generic.ReservationRepo;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirBnb.BL.Managers.ManageReservation
{
    public class ReservationManager:IReservationManager
    {
        private readonly IMapper _mapper;
        private readonly IReservationRepository _reservationrepository;
        private readonly IPropertyManager _propertymanager;
        public ReservationManager(IMapper mapper, IReservationRepository reservationrepository,IPropertyManager propmanager)
        {
            _mapper = mapper;
            _reservationrepository = reservationrepository;
            _propertymanager = propmanager;
        }
        //Getting specific reservation using the reservation id
        public async Task<ReservationReadDto> GetReservationById(Guid reservationId)
        {
            Reservation reserv = await _reservationrepository.GetReservationById(reservationId);
            if(reserv == null)
            {
                return new ReservationReadDto { Errors = "Reservation not found!" };
            }
            return _mapper.Map<ReservationReadDto>(reserv);
        }

        //getting all reservations for a specific hoster
        public async Task<IEnumerable<ReservationReadDto>> GetSpecificHosterReservations(string hosterId)
        {
            IEnumerable<Reservation> hosterReservations = await _reservationrepository.GetSpecificHosterReservations(hosterId);
            return _mapper.Map<IEnumerable<ReservationReadDto>>(hosterReservations);
        }
        //Getting all reservations on a specific property

        public async Task<IEnumerable<ReservationReadDto>> GetReservationsOnProperty(Guid propertyId)
        {
            IEnumerable<Reservation> propertyReservations = await _reservationrepository.GetReservationsOnProperty(propertyId);
            return _mapper.Map<IEnumerable<ReservationReadDto>>(propertyReservations);
        }
        //Getting active reservations for hoster
        public async Task<IEnumerable<ReservationReadDto>> GetActiveReservations(string hosterId)
        {
            IEnumerable<Reservation> HosterActiveReservations = await _reservationrepository.GetActiveReservations(hosterId);
            return _mapper.Map<IEnumerable<ReservationReadDto>>(HosterActiveReservations);
        }
        //Getting active reservation on a property
        public async Task<ReservationReadDto> GetPropertyActiveReservation(Guid propertyId)
        {
            Reservation reserv = await _reservationrepository.GetPropertyActiveReservation(propertyId);
            if (reserv == null)
            {
                return new ReservationReadDto { Errors = "No active reservation on this property" };
            }
            return _mapper.Map<ReservationReadDto>(reserv);
        }
        //Getting future reservations for a hoster
        public async Task<IEnumerable<ReservationReadDto>> GetFutureReservations(string hosterId)
        {
            IEnumerable<Reservation> HosterFutureReservations = await _reservationrepository.GetFutureReservations(hosterId);
            return _mapper.Map<IEnumerable<ReservationReadDto>>(HosterFutureReservations);
        }
        //Getting future reservations for a specific property
        public async Task<IEnumerable<ReservationReadDto>> GetPropertyFutureReservations(Guid propertyId)
        {
            IEnumerable<Reservation> PropertyFutureReservations = await _reservationrepository.GetPropertyFutureReservations(propertyId);
            return _mapper.Map<IEnumerable<ReservationReadDto>>(PropertyFutureReservations);
        }

        //Getting the reservations of the hoster in the past

        public async Task<IEnumerable<ReservationReadDto>> GetHistoryReservations(string hosterId)
        {
            IEnumerable<Reservation> PropertyFutureReservations = await _reservationrepository.GetHistoryReservations(hosterId);
            return _mapper.Map<IEnumerable<ReservationReadDto>>(PropertyFutureReservations);
        }
        //Getting the reservations of the property in the past
        public async Task<IEnumerable<ReservationReadDto>> GetPropertyHistoryReservations(Guid propertyId)
        {
            IEnumerable<Reservation> PropertyFutureReservations = await _reservationrepository.GetPropertyHistoryReservations(propertyId);
            return _mapper.Map<IEnumerable<ReservationReadDto>>(PropertyFutureReservations);
        }
        //Getting the total balance of the hoster reservations
        public async Task<double> GetAllReservationsBalance(ReservationHosterBalanceDto model)
        {
            if(model.StartDate==null||model.EndDate==null)
            {
                return await _reservationrepository.GetAllReservationsBalance(model.Id,null,null);
            }
            return await _reservationrepository.GetAllReservationsBalance(model.Id, model.StartDate, model.EndDate);
        }
        //Getting the total balance of the reservations on a property

        public async Task<double> GetSpecificPropertyReservationsBalance(ReservationPropertyBalanceDto model)
        {
            if (model.StartDate == null || model.EndDate == null)
            {
                return await _reservationrepository.GetSpecificPropertyReservationsBalance(model.Id, null, null);
            }
            return await _reservationrepository.GetSpecificPropertyReservationsBalance(model.Id, model.StartDate, model.EndDate);

        }
        //Creating user reservation
        public async Task<ReservationReadDto> CreateReservationToAUser(ReservationAddDto model)
        {
            Reservation reserv = _mapper.Map<Reservation>(model);
            PropertyReadDto prop = await _propertymanager.GetPropertyById(reserv.PropertyId);
            //here we want to check if there is any reservation in this time or not
            var reservations = await _reservationrepository.GetAllAsync();
            var reservationCheck = reservations.Where(e => e.PropertyId==reserv.PropertyId&&e.StartDate.DayOfYear <=reserv.StartDate.DayOfYear && e.EndDate.DayOfYear >= reserv.EndDate.DayOfYear).ToList();
            if(reservationCheck.Count > 0)
            {
                return new ReservationReadDto { Errors = "There is another reservation on this property" };
            }
            reserv.TotalPrice = (reserv.EndDate.Day - reserv.StartDate.Day) * prop.Price;
            reserv.Id = Guid.NewGuid();

            Reservation createdReservation = await _reservationrepository.CreateReservationToAUser(reserv);
            if (reserv == null)
            {
                return new ReservationReadDto { Errors = "Reservation failed to be created" };
            }
            ReservationReadDto reservationCreated = _mapper.Map<ReservationReadDto>(reserv);
            _reservationrepository.Save();
            return reservationCreated;
            
        }
    }
}
