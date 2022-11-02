using AirBnb.BL.DTOs.PropertyDTOs;
using AirBnb.BL.DTOs.ReservationDTOs;
using AirBnb.BL.DTOs.ReviewDTOs;
using AirBnb.BL.DTOs.UserDTOs;
using AirBnb.BL.Managers.ManageUser;
using AirBnb.DAL.Data.Models;
using AirBnb.DAL.Repository.Non_Generic.PropertyRepo;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirBnb.BL.Managers.ManageProperty
{
    public class PropertyManager:IPropertyManager
    {
        private readonly IPropertyRepository _propertyRepository;
        private readonly IMapper _mapper;
        private readonly IUserManager _usermanager;
        public PropertyManager(IPropertyRepository propertyRepository,IMapper map,IUserManager manager)
        {
            _propertyRepository = propertyRepository;
            _mapper = map;
            _usermanager = manager;
        }

        //Getting Section implementation:
        public async Task<PropertyReadDto> GetPropertyById(Guid id)
        {
            Property myProperty = await _propertyRepository.GetByIdAsync(id);
            if(myProperty == null)
            {
                return null;
            }
            PropertyReadDto myProp = _mapper.Map<PropertyReadDto>(myProperty);
            return myProp;
        }

        public async Task<IEnumerable<PropertyReadDto>> GetAllProperties()
        {
            IEnumerable<Property> myProps = await _propertyRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<PropertyReadDto>>(myProps);
        }
        //Filtering Section implementation:
        public Task<IEnumerable<PropertyReadDto>> FilterByEssentials(params string[] Essentials)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PropertyReadDto>> FilterByLanguages(params string[] languages)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PropertyReadDto>> FilterByNumberOfRooms(double numberOfRooms)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PropertyReadDto>> FilterByPrice(double minPrice, double maxPrice)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PropertyReadDto>> FilterByPropertyType(string type)
        {
            throw new NotImplementedException();
        }
        //Adding Section Implementation:

        public async Task<PropertyReadDto> AddProperty(PropertyAddDto model)
        {
            UserReadDTO myUser = await _usermanager.GetUserById(model.HosterId);
            
            if(myUser == null)
            {
                return new PropertyReadDto { Errors = "Invalid Hoster" };
            }
            Property newProperty = _mapper.Map<Property>(model);
            newProperty.Id = Guid.NewGuid();            
             _propertyRepository.Add(newProperty);
            _propertyRepository.Save();
            return _mapper.Map<PropertyReadDto>(newProperty);
        }
        //Delete section implementation:
        public Task<PropertyReadDto> DeleteProperty(Guid id)
        {
            throw new NotImplementedException();
        }

        //Update section implementation:
        public Task<PropertyReadDto> UpdateProperty(PropertyUpdateDto model)
        {
            throw new NotImplementedException();
        }
        //Getting all reservations for the selected property
        public Task<IEnumerable<ReservationReadDto>> GetAllReservationsAsync(Guid PropertyId)
        {
            throw new NotImplementedException();
        }
        //Getting all reviews regarding this property
        public Task<IEnumerable<ReviewReadDto>> GetAllReviewsAsync(Guid PropertyId)
        {
            throw new NotImplementedException();
        }


    }
}
