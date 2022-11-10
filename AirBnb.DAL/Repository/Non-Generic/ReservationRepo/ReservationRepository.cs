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
        public async Task<IEnumerable<Reservation>> GetUserReservations(string userId)
        {
            return await _context.Reservations.Include(e=>e.Review).Where(e => e.UserId == userId).ToListAsync();
        }

        public async Task<Reservation> CreateReservationToAUser(Reservation reservation)
        {
            _context.Reservations.Add(reservation); 
            return reservation;
        }

        public async Task<IEnumerable<Reservation>> GetActiveReservations(string hosterId)
        {
            DateTime todaysDate = DateTime.Today.Date;
            IEnumerable<Reservation> hosterResevations = await GetSpecificHosterReservations(hosterId);
             
             hosterResevations.Where(e=>e.StartDate <= todaysDate && e.EndDate >= todaysDate).ToList();
            return hosterResevations.Where(e => (DateTime.Compare(e.StartDate.Date, todaysDate) == 0 || DateTime.Compare(e.StartDate.Date, todaysDate) == -1) && (DateTime.Compare(e.EndDate.Date, todaysDate) == 0 || DateTime.Compare(e.EndDate.Date, todaysDate) == 1));
        }

        public async Task<double> GetAllReservationsBalance(string hosterId, DateTime? startDate, DateTime? endDate)
        {
            
            // get all propertiesID that belongs to host with hostid = hosterId
            var HostProperties = await _context.Properties.Where(e => e.HosterId == hosterId).Select(e=>e.Id).ToListAsync();
            List<Reservation> propertiesReservation = new List<Reservation>();
            if (startDate == null && endDate == null) // all time intervall
            {
                 propertiesReservation = await _context.Reservations.Where(e => HostProperties.Contains(e.PropertyId)).ToListAsync();

            }
            else if(startDate == null)  // get all reservation that belongs to this properties where it was reserved ( start date) between  ( property creation & the given end date) 
            {
                 propertiesReservation = await _context.Reservations.Where(e => HostProperties.Contains(e.PropertyId) && (DateTime.Compare(e.StartDate.Date, endDate.Value.Date) == 0 || DateTime.Compare(e.StartDate.Date, endDate.Value.Date) == -1)).ToListAsync();
                
            }
            else if(endDate == null)// get all reservation that belongs to this properties where it was reserved ( start date) between ( the given start date & and any time forward)
            {
                 propertiesReservation = await _context.Reservations.Where(e => HostProperties.Contains(e.PropertyId) && (DateTime.Compare(e.StartDate.Date, startDate.Value.Date) == 0 || DateTime.Compare(e.StartDate.Date, startDate.Value.Date) == 1)).ToListAsync();
                
            }
            else    // get all reservation that belongs to this properties where it was reserved ( start date) in any time between the given interval 

            {
                 propertiesReservation = await _context.Reservations.Where(e => HostProperties.Contains(e.PropertyId) && (DateTime.Compare(e.StartDate.Date, startDate.Value.Date) == 0 || DateTime.Compare(e.StartDate.Date, startDate.Value.Date) == -1) && (DateTime.Compare(e.StartDate.Date, endDate.Value.Date) == 0 || DateTime.Compare(e.StartDate.Date, endDate.Value.Date) == -1)).ToListAsync();
            } 
            double balance = 0;
            foreach (var reservation in propertiesReservation)
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
            DateTime todaysDate = DateTime.Today.Date;
            IEnumerable<Reservation> hosterResevations = await GetSpecificHosterReservations(hosterId);

            return hosterResevations.Where(e=> (DateTime.Compare(e.StartDate.Date, todaysDate) == 1)).ToList();
            
        }

        public async Task<IEnumerable<Reservation>> GetHistoryReservations(string hosterId)
        {
            DateTime todaysDate = DateTime.Today.Date;
            IEnumerable<Reservation> hosterResevations = await GetSpecificHosterReservations(hosterId);
            return hosterResevations.Where(e=> (DateTime.Compare(e.StartDate.Date, todaysDate) == -1) && (DateTime.Compare(e.EndDate.Date, todaysDate) == -1)).ToList();
         
        }

        public async Task<Reservation> GetPropertyActiveReservation(Guid propertyId)
        {
            DateTime todaysDate = DateTime.Today.Date;
            var myProperty =await _context.Properties.Include(e=>e.Reservations).FirstOrDefaultAsync(e => e.Id == propertyId);
            var reservation = myProperty.Reservations.FirstOrDefault(e => (DateTime.Compare(e.StartDate.Date, todaysDate) == -1 || DateTime.Compare(e.StartDate.Date, todaysDate) == 0) && (DateTime.Compare(e.EndDate.Date, todaysDate) == 1 || DateTime.Compare(e.EndDate.Date, todaysDate) == 0));
            

            var property = await _context.Reservations.Include(p => p.Property).Include(e => e.Review).FirstOrDefaultAsync(e=>e.Id==reservation.Id);
            return property;
        }

        public async Task<IEnumerable<Reservation>> GetPropertyFutureReservations(Guid propertyId)
        {
        
            DateTime todaysDate = DateTime.Today.Date;
            return await _context.Reservations.Include(e => e.Property).Include(e => e.Review).Where(e => e.PropertyId == propertyId && DateTime.Compare(e.StartDate.Date, todaysDate) == 1).ToListAsync();
        }

        public async Task<IEnumerable<Reservation>> GetPropertyHistoryReservations(Guid propertyId)
        { // same logic zy al fo2 bs fr2 al dates
            DateTime todaysDate = DateTime.Today.Date;
            return await _context.Reservations.Include(e => e.Property).Include(e => e.Review).Where(e => e.PropertyId == propertyId && (DateTime.Compare(e.StartDate.Date, todaysDate) == -1) && (DateTime.Compare(e.EndDate.Date, todaysDate) == -1)).ToListAsync();
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
        {  // nfs moshklt al dates lma ntf2 3la logic nb2a nshof hn3dl fl logic dh wla l2
            IEnumerable<Reservation> propertyReservations;
            if (startDate == null||endDate==null)
            {
                propertyReservations = await GetReservationsOnProperty(propertyId);
            }
            else if(startDate ==null)
            {
                propertyReservations = await _context.Reservations.Where(e => e.PropertyId == propertyId && (DateTime.Compare(e.StartDate.Date, endDate.Value.Date) == 0 || DateTime.Compare(e.StartDate.Date, endDate.Value.Date) == -1)).ToListAsync();
            }
            else if(endDate == null)
            {
                propertyReservations = await _context.Reservations.Where(e => e.PropertyId == propertyId && (DateTime.Compare(e.StartDate.Date, startDate.Value.Date) == 0 || DateTime.Compare(e.StartDate.Date, startDate.Value.Date) == 1)).ToListAsync();
            }
            else
            {
                propertyReservations = await _context.Reservations.Where(e => e.PropertyId == propertyId && (DateTime.Compare(e.StartDate.Date, startDate.Value.Date) == 0 || DateTime.Compare(e.StartDate.Date, startDate.Value.Date) == -1) && (DateTime.Compare(e.StartDate.Date, endDate.Value.Date) == 0 || DateTime.Compare(e.StartDate.Date, endDate.Value.Date) == -1)).ToListAsync();
            }
            double balance = 0;
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
