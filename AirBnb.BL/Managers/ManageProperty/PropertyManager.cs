using AirBnb.BL.DTOs.PropertyDTOs;
using AirBnb.BL.DTOs.PropertyPicsDTOs;
using AirBnb.BL.DTOs.ReservationDTOs;
using AirBnb.BL.DTOs.UserDTOs;
using AirBnb.BL.Managers.ManageCategories;
using AirBnb.BL.Managers.ManageUser;
using AirBnb.DAL.Data.Models;
using AirBnb.DAL.Repository.Non_Generic.PropertyRepo;
using AirBnb.DAL.Repository.Non_Generic.UserRepo;
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
        private readonly ICategoryManager _categoryManager;

        public PropertyManager(IPropertyRepository propertyRepository,IMapper map,IUserManager manager,ICategoryManager categoryManager)
        {
            _propertyRepository = propertyRepository;
            _mapper = map;
            _usermanager = manager;
            _categoryManager = categoryManager;
        }

        //Getting Section implementation:
        public async Task<PropertyReadDto> GetPropertyById(Guid id)
        {
            Property myProperty = await _propertyRepository.GetPropertyByIdIncludingPics(id);
            
            if(myProperty == null)
            {
                return null;
            }
            UserReadDTO myUser = await _usermanager.GetUserById(myProperty.HosterId);
            if (myUser == null)
            {
                return null;
            }
            PropertyReadDto myProp = _mapper.Map<PropertyReadDto>(myProperty);
            myProp.Hoster = myUser;
            return myProp;
        }
        //This method is responsible for getting All properties of a specifi user
        public async Task<IEnumerable<PropertyReadDto>> GetAllPropertiesOfSpecificUser(string userId)
        {
            IEnumerable<Property> AllProperties =await _propertyRepository.GetAllPropertiesByIdIncludingPics();
            IEnumerable<Property> userAllProperties = AllProperties.Where(e => e.HosterId == userId).ToList();
            return _mapper.Map<IEnumerable<PropertyReadDto>>(userAllProperties);

        }

        public async Task<IEnumerable<PropertyReadDto>> GetAllProperties()
        {
            IEnumerable<Property> myProps = await _propertyRepository.GetAllPropertiesByIdIncludingPics();
            var myListOfProps = myProps.ToList();
            IEnumerable<PropertyReadDto> AllPropsIncludingHosters = _mapper.Map<IEnumerable<PropertyReadDto>>(myProps);
            var myListOfPropReadDto = AllPropsIncludingHosters.ToList();
            for (int i = 0; i < myProps.Count(); i++)
            {
                UserReadDTO myUser = await _usermanager.GetUserById(myListOfProps[i].HosterId);
                if (myUser != null)
                {
                    myListOfPropReadDto[i].Hoster = myUser;
                }
            }

            return myListOfPropReadDto;
        }
        //Filtering Section implementation:
        public async Task<IEnumerable<PropertyReadDto>> FilterByEssentials(params string[] Essentials)
        {
            if (Essentials == null)
            {
                return null;
            }
            var properties = await _propertyRepository.GetPropertiesByEssentials(Essentials);
            return _mapper.Map<IEnumerable<PropertyReadDto>>(properties);

        }

        public async Task<IEnumerable<PropertyReadDto>> FilterByLanguages(params string[] languages)
        {
            if (languages == null)
            {
                return null;
            }
            var properties = await _propertyRepository.GetPropertiesByLanguage(languages);
            return _mapper.Map<IEnumerable<PropertyReadDto>>(properties);
        }

        public async Task<IEnumerable<PropertyReadDto>> FilterByNumberOfRooms(int numberOfRooms)
        {
            var properties = await _propertyRepository.GetPropertiesByNumberOfRooms(numberOfRooms);
            return _mapper.Map<IEnumerable<PropertyReadDto>>(properties);   
        }

        public async Task<IEnumerable<PropertyReadDto>> FilterByPrice(double minPrice, double maxPrice)
        {
            var properties = await _propertyRepository.GetPropertiesByPrice(minPrice, maxPrice);
            return _mapper.Map<IEnumerable<PropertyReadDto>>(properties);
        }

        public async Task<IEnumerable<PropertyReadDto>> FilterByPropertyType(string type)
        {
            var properties = await _propertyRepository.GetPropertiesByType(type);
            return _mapper.Map<IEnumerable<PropertyReadDto>>(properties);
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
            //Managing pictures
            if (model.Pictures.Count() > 0)
            {
                foreach (var picture in model.Pictures)
                {
                    using var dataStream = new MemoryStream();
                    await picture.CopyToAsync(dataStream);
                    newProperty.Pictures.Add(new PropertyPicture { Id = Guid.NewGuid(), Picture = dataStream.ToArray(), PropertyId = newProperty.Id });
                }
            }
            _propertyRepository.Add(newProperty);
            _propertyRepository.Save();
            return _mapper.Map<PropertyReadDto>(newProperty);
        }
        //Delete section implementation:
        public  PropertyReadDto DeleteProperty(Guid id)
        {
           var property = _propertyRepository.Delete(id);
            if (property == null)
                return null;
            _propertyRepository.Save();
            return   _mapper.Map<PropertyReadDto>(property);
        }

        //Update section implementation:
        public PropertyReadDto UpdateProperty(PropertyUpdateDto model)
        {
            var property = _propertyRepository.GetById(model.Id);
            if (property == null)
            {
                return new PropertyReadDto { Errors = "Property Doesn't Exists" };
            }
            _mapper.Map(model, property);
            _propertyRepository.Save();
            return _mapper.Map<PropertyReadDto>(property);
        }
        //Getting all reservations for the selected property
        public Task<IEnumerable<ReservationReadDto>> GetAllReservationsAsync(Guid PropertyId)
        {
            throw new NotImplementedException();
        }
        //Getting all reviews regarding this property
        public Task<IEnumerable<ReservationReviewReadDto>> GetAllReviewsAsync(Guid PropertyId)
        {
            throw new NotImplementedException();
        }


    }
}
