using AirBnb.BL.DTOs.PropertyDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirBnb.BL.Managers.ManageProperty
{
    public class PropertyManager:IPropertyManager
    {
        private readonly IPropertyManager _PropertyManager;
        public PropertyManager(IPropertyManager propertyManager)
        {
            _PropertyManager = propertyManager;
        }

        public Task<PropertyReadDto> GetPropertyById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<PropertyManager> GetPropertyByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
