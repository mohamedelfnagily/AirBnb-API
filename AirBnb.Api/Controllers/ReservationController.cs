using AirBnb.BL.DTOs.ReservationDTOs;
using AirBnb.BL.Managers.ManageReservation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AirBnb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationManager _reservationmanager;
        public ReservationController(IReservationManager reservationmanager)
        {
            _reservationmanager = reservationmanager;
        }
        //Getting reservation by its id
        [HttpGet("GetReservationById/{id}")]
        public async Task<ActionResult<ReservationReadDto>> GetReservationById(Guid id)
        {
            ReservationReadDto reservation = await _reservationmanager.GetReservationById(id);
            if(reservation.Errors!=String.Empty)
            {
                return BadRequest(reservation.Errors);
            }
            return Ok(reservation);
        }
        //Getting userReservation by its id
        [HttpGet("GetUserReservations/{id}")]
        public async Task<ActionResult<IEnumerable<ReservationReadDto>>> GetUserReservations(string id)
        {
            if(id==null)
            {
                return BadRequest();
            }
            IEnumerable<ReservationReadDto> reservation = await _reservationmanager.GetSpecificUserReservations(id);
            return Ok(reservation);
        }
        //Getting all reservations of hoster
        [HttpGet("GetHosterReservations/{id}")]
        public async Task<ActionResult<IEnumerable<ReservationReadDto>>> GetHosterReservations(string id)
        {
            if(id==null)
            {
                return BadRequest();
            }
            IEnumerable< ReservationReadDto> reservations = await _reservationmanager.GetSpecificHosterReservations(id);
            return Ok(reservations);
        }
        //Getting reservations on specific property
        [HttpGet("GetPropertyReservations/{propId}")]
        public async Task<ActionResult<IEnumerable<ReservationReadDto>>> GetPropertyReservations(Guid propId)
        {
            if (propId == null)
            {
                return BadRequest();
            }
            IEnumerable<ReservationReadDto> reservations = await _reservationmanager.GetReservationsOnProperty(propId);
            return Ok(reservations);
        }
        //Getting active reservations for hoster
        [HttpGet("GetHosterActiveReservations/{hosterId}")]
        public async Task<ActionResult<IEnumerable<ReservationReadDto>>> GetActiveHosterReservations(string hosterId)
        {
            if (hosterId == null)
            {
                return BadRequest();
            }
            IEnumerable<ReservationReadDto> reservations = await _reservationmanager.GetActiveReservations(hosterId);
            return Ok(reservations);
        }
        //Getting active reservation on the property
        [HttpGet("GetPropertyActiveReservation/{id}")]
        public async Task<ActionResult<ReservationReadDto>> GetPropertyActiveReservation(Guid id)
        {
            ReservationReadDto reservation = await _reservationmanager.GetPropertyActiveReservation(id);
            if (reservation.Errors != String.Empty)
            {
                return BadRequest(reservation.Errors);
            }
            return Ok(reservation);
        }
        //Getting future reservations for a hoster

        [HttpGet("GetHosterFutureReservations/{hosterId}")]
        public async Task<ActionResult<IEnumerable<ReservationReadDto>>> GetHosterFutureReservations(string hosterId)
        {
            if (hosterId == null)
            {
                return BadRequest();
            }
            IEnumerable<ReservationReadDto> reservations = await _reservationmanager.GetFutureReservations(hosterId);
            return Ok(reservations);
        }
        //Getting future reservations on a property
        [HttpGet("GetPropertyFutureReservations/{propertyId}")]
        public async Task<ActionResult<IEnumerable<ReservationReadDto>>> GetPropertyFutureReservations(Guid propertyId)
        {
            if (propertyId == null)
            {
                return BadRequest();
            }
            IEnumerable<ReservationReadDto> reservations = await _reservationmanager.GetPropertyFutureReservations(propertyId);
            return Ok(reservations);
        }
        //Getting the hoster past reservations
        [HttpGet("GetHosterHistoryReservations/{hosterId}")]
        public async Task<ActionResult<IEnumerable<ReservationReadDto>>> GetPropertyHistoryReservations(string hosterId)
        {
            if (hosterId == null)
            {
                return BadRequest();
            }
            IEnumerable<ReservationReadDto> reservations = await _reservationmanager.GetHistoryReservations(hosterId);
            return Ok(reservations);
        }
        //Getting the hoster past reservations
        [HttpGet("GetPropertyHistoryReservations/{propertyId}")]
        public async Task<ActionResult<IEnumerable<ReservationReadDto>>> GetPropertyHistoryReservations(Guid propertyId)
        {
            if (propertyId == null)
            {
                return BadRequest();
            }
            IEnumerable<ReservationReadDto> reservations = await _reservationmanager.GetPropertyHistoryReservations(propertyId);
            return Ok(reservations);
        }
        //Getting the total balance of hoster reservations
        [HttpPost("GetHosterReservationsBalance")]
        public async Task<ActionResult<double>> GetHosterReservationsBalance(ReservationHosterBalanceDto model)
        {
            if(model==null)
            {
                return BadRequest();
            }
            return await _reservationmanager.GetAllReservationsBalance(model);
        }
        //Getting the total balance of reservations in a property
        [HttpPost("GetPropertyReservationsBalance")]
        public async Task<ActionResult<double>> GetPropertyReservationsBalance(ReservationPropertyBalanceDto model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            return await _reservationmanager.GetSpecificPropertyReservationsBalance(model);
        }
        //Creating reservation
        [HttpPost("CreateReservation")]
        public async Task<ActionResult<ReservationReadDto>> CreateReservation(ReservationAddDto model)
        {
            ReservationReadDto reservation = await _reservationmanager.CreateReservationToAUser(model);
            if(reservation.Errors!=String.Empty)
            {
                return BadRequest(reservation.Errors);
            }
            return Ok(reservation);
        }
    }
}
