using AirBnb.DAL.Repository.Non_Generic.ReservationRepo;
using AutoMapper;
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
        public ReservationManager(IMapper mapper, IReservationRepository reservationrepository)
        {
            _mapper = mapper;
            _reservationrepository = reservationrepository;
        }
    }
}
