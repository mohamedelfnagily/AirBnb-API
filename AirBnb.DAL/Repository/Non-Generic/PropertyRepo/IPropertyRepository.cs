using AirBnb.DAL.Data.Models;
using AirBnb.DAL.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirBnb.DAL.Repository.Non_Generic.PropertyRepo
{
    public interface IPropertyRepository:IBaseRepository<Property>
    {
        Task<IEnumerable<Review>> GetAllReviewsAsync(Guid PropertyId);
        Task<IEnumerable<Reservation>> GetAllReservationsAsync(Guid PropertyId);

        //Those methods will be used in the filteration of the client
        Task<IEnumerable<Property>> GetPropertiesByNumberOfRooms(int num);
        Task<IEnumerable<Property>> GetPropertiesByPrice(double minPrice, double maxPrice);
        Task<IEnumerable<Property>> GetPropertiesByEssentials(params string[] Essentials);
        Task<IEnumerable<Property>> GetPropertiesByType(string type);
        Task<IEnumerable<Property>> GetPropertiesByLanguage(params string[] language);


    }
}
