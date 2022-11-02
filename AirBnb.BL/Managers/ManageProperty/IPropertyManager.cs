using AirBnb.BL.DTOs.PropertyDTOs;
using AirBnb.BL.DTOs.ReservationDTOs;
using AirBnb.BL.DTOs.ReviewDTOs;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirBnb.BL.Managers.ManageProperty
{
    public interface IPropertyManager
    {
        //This interface is responsible for all the property methods(operations) that will be exposed to the contoller
        //Getting section:
        Task<PropertyReadDto> GetPropertyById(Guid id);
        Task<IEnumerable<PropertyReadDto>> GetAllProperties();
        //Filteration section:
        Task<IEnumerable<PropertyReadDto>> FilterByNumberOfRooms(double numberOfRooms);
        Task<IEnumerable<PropertyReadDto>> FilterByPrice(double minPrice, double maxPrice);
        Task<IEnumerable<PropertyReadDto>> FilterByPropertyType(string type);
        Task<IEnumerable<PropertyReadDto>> FilterByEssentials(params string[] Essentials);
        Task<IEnumerable<PropertyReadDto>> FilterByLanguages(params string[] languages);
        //Getting dependencies:
        Task<IEnumerable<ReviewReadDto>> GetAllReviewsAsync(Guid PropertyId);
        Task<IEnumerable<ReservationReadDto>> GetAllReservationsAsync(Guid PropertyId);
        //Adding Section:
        Task<PropertyReadDto> AddProperty(PropertyAddDto model);
        //Deleting Section:
        Task<PropertyReadDto> DeleteProperty(Guid id);
        //Updating Section:
        Task<PropertyReadDto> UpdateProperty(PropertyUpdateDto model);



    }
}
