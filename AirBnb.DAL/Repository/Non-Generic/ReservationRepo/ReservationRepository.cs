using AirBnb.DAL.Data.Context;
using AirBnb.DAL.Data.Models;
using AirBnb.DAL.Repository.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirBnb.DAL.Repository.Non_Generic.ReservationRepo
{
    public class ReservationRepository:BaseRepository<Reservation>,IReservationRepository
    {
        private readonly ApplicationDbContext _context;
        public ReservationRepository(ApplicationDbContext context):base(context)
        {
            _context = context;
        }

        public async Task<Reservation> CreateReservationToAUser(Reservation reservation)
        {
            _context.Reservations.Add(reservation); 
            return reservation;
        }

        public async Task<IEnumerable<Reservation>> GetActiveReservations(string hosterId)
        {
            DateTime todaysDate = DateTime.Today;
            IEnumerable<Reservation> hosterResevations = await GetSpecificHosterReservations(hosterId);

            return hosterResevations.Where(e=>e.StartDate <= todaysDate && e.EndDate >= todaysDate).ToList();
        }

        public async Task<double> GetAllReservationsBalance(string hosterId, DateTime? startDate, DateTime? endDate)
        {
            IEnumerable<Reservation> propertyReservations;
            if (startDate == null || endDate == null)
            {
                propertyReservations = await _context.Reservations.Include(e => e.Property).Where(e => e.UserId == hosterId).ToListAsync();
            }
            else
            {
                propertyReservations = await _context.Reservations.Where(e => e.UserId == hosterId && e.StartDate >= startDate && e.EndDate <= endDate).ToListAsync();
            }
            double balance = 0;
            if (propertyReservations.Count() == 0)
            {
                return 0;
            }
            foreach (var reservation in propertyReservations)
            {
                balance += reservation.TotalPrice;
            }

            return balance;
        }

        public async Task<IEnumerable<Reservation>> GetAllUserReservations(string userId)
        {
            return await _context.Reservations.Include(e => e.Property).Include(e => e.Review).Where(e => e.UserId == userId).ToListAsync();
        }

        public async Task<IEnumerable<Reservation>> GetFutureReservations(string hosterId)
        {
            DateTime todaysDate = DateTime.Today;
            IEnumerable<Reservation> hosterResevations = await GetSpecificHosterReservations(hosterId);

            return hosterResevations.Where(e=> e.StartDate > todaysDate).ToList();
        }

        public async Task<IEnumerable<Reservation>> GetHistoryReservations(string hosterId)
        {
            DateTime todaysDate = DateTime.Today;
            IEnumerable<Reservation> hosterResevations = await GetSpecificHosterReservations(hosterId);
            return hosterResevations.Where(e=> e.StartDate < todaysDate&&e.EndDate<todaysDate).ToList();
        }

        public async Task<Reservation> GetPropertyActiveReservation(Guid propertyId)
        {
            DateTime todaysDate = DateTime.Today;
            var myProperty =await _context.Properties.Include(e=>e.Reservations).FirstOrDefaultAsync(e => e.Id == propertyId);
            var reservation = myProperty.Reservations.FirstOrDefault(e => e.StartDate.Date <= todaysDate && e.EndDate.Date >= todaysDate);
            var property = await _context.Reservations.Include(p => p.Property).Include(e => e.Review).FirstOrDefaultAsync(e=>e.Id==reservation.Id);
            return property;
        }

        public async Task<IEnumerable<Reservation>> GetPropertyFutureReservations(Guid propertyId)
        {
            DateTime todaysDate = DateTime.Today;
            return await _context.Reservations.Include(e => e.Property).Include(e => e.Review).Where(e => e.StartDate > todaysDate).ToListAsync();
        }

        public async Task<IEnumerable<Reservation>> GetPropertyHistoryReservations(Guid propertyId)
        {
            DateTime todaysDate = DateTime.Today;
            return await _context.Reservations.Include(e => e.Property).Include(e => e.Review).Where(e => e.StartDate < todaysDate&& e.EndDate < todaysDate).ToListAsync();
        }

        public async Task<Reservation> GetReservationById(Guid id)
        {
            return await _context.Reservations.Include(e => e.Property).Include(e => e.Review).FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<Reservation>> GetReservationsOnProperty(Guid propertyId)
        {
            return await _context.Reservations.Include(e => e.Property).Include(e => e.Review).Where(e => e.PropertyId == propertyId).ToListAsync();
        }

        public async Task<double> GetSpecificPropertyReservationsBalance(Guid propertyId, DateTime? startDate=null, DateTime? endDate=null)
        {
            IEnumerable<Reservation> propertyReservations;
            if (startDate == null||endDate==null)
            {
                propertyReservations = await GetReservationsOnProperty(propertyId);
            }
            else
            {
                propertyReservations = await _context.Reservations.Where(e => e.PropertyId == propertyId && e.StartDate >= startDate && e.EndDate <= endDate).ToListAsync();
            }
            double balance = 0;
            if(propertyReservations.Count()==0)
            {
                return 0;
            }
            foreach (var reservation in propertyReservations)
            {
                balance += reservation.TotalPrice;
            }

            return balance;
        }

        public async Task<Reservation> GetSpecificReservationToAUser(string userId, Guid reservationId)
        {
            return await _context.Reservations.Include(e => e.Property).Include(e => e.Review).FirstOrDefaultAsync(d => d.UserId == userId && d.Id == reservationId);
        }

        public async Task<IEnumerable<Reservation>> GetSpecificHosterReservations(string hosterId)
        {
            var hosterProperties = await _context.Properties.Include(e=>e.Reservations).Where(e => e.HosterId == hosterId).ToListAsync();
            List<Reservation> hosterReservations = new List<Reservation>();
            foreach (var property in hosterProperties)
            {
                if(property.Reservations.Count>0)
                {
                    foreach(var reservation in property.Reservations)
                    {
                        hosterReservations.Add(reservation);
                    }
                }
            }
            return hosterReservations;
        }
    }
}
