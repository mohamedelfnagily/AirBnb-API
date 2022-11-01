using AirBnb.BL.DTOs.PropertyDTOs;
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
        Task<PropertyManager> GetPropertyByName(string name);

    }
}
