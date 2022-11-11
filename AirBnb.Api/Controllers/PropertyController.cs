using AirBnb.BL.DTOs.PropertyDTOs;
using AirBnb.BL.Managers.ManageProperty;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AirBnb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PropertyController : ControllerBase
    {
        private readonly IPropertyManager _propertymanager;
        public PropertyController(IPropertyManager propertymanager)
        {
            _propertymanager = propertymanager;
        }
        [HttpGet("GetPropertyById/{id}")]
        public async Task<ActionResult<PropertyReadDto>> GetPropertyById(Guid id)
        {
            if(id==null)
            {
                return BadRequest();
            }
            PropertyReadDto myProp = await _propertymanager.GetPropertyById(id);
            if(myProp.Errors!=String.Empty)
            {
                return BadRequest(myProp.Errors);
            }
            return Ok(myProp);
        }
        [HttpGet("GetUserProperties/{id}")]
        public async Task<ActionResult<PropertyReadDto>> GetUserProperties(string id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            IEnumerable<PropertyReadDto> myProps = await _propertymanager.GetAllPropertiesOfSpecificUser(id);
            return Ok(myProps);
        }
        [HttpGet("GetAllProperties")]
        public async Task<ActionResult<IEnumerable<PropertyReadDto>>> GetAllProperties()
        {
            IEnumerable<PropertyReadDto> myProps = await _propertymanager.GetAllProperties();
            return Ok(myProps);
        }
        // Filtering Section
        [HttpPost("GetByNumberOfRooms")]
        public async Task<ActionResult<IEnumerable<PropertyReadDto>>> GetByNumberOfRooms([FromBody] int rooms)
        {
            var properties = await _propertymanager.FilterByNumberOfRooms(rooms);
            return Ok(properties);
        }
        [HttpPost("GetByPriceRange")]
        public async Task<ActionResult<IEnumerable<PropertyReadDto>>> GetByPriceRange(FilterByPriceDTO model )
        {
            var properties = await _propertymanager.FilterByPrice(model.MinPrice,model.MaxPrice);
            return Ok(properties);
        }
        [HttpPost("GetByPropertyType")]
        public async Task<ActionResult<IEnumerable<PropertyReadDto>>> GetByPropertyType([FromBody] string Type)
        {
            var properties = await _propertymanager.FilterByPropertyType(Type);
            return Ok(properties);
        }
        [HttpPost("GetByEssentials")]
        public async Task<ActionResult<IEnumerable<PropertyReadDto>>> GetByEssentials(string[] Essentials)
        {
            var properties = await _propertymanager.FilterByEssentials(Essentials);
            return Ok(properties);
        }
        [HttpPost("GetByLanguages")]
        public async Task<ActionResult<IEnumerable<PropertyReadDto>>> GetByLanguages(string[] Languages)
        {
            var properties = await _propertymanager.FilterByLanguages(Languages);
            return Ok(properties);
        }
        // Add Property
        [HttpPost("AddProperty")]
        public async Task<ActionResult<PropertyReadDto>> AddProperty([FromForm]PropertyAddDto model)
        {
            if(model==null)
            {
                return BadRequest();
            }
            PropertyReadDto myProp = await _propertymanager.AddProperty(model);
            if (myProp.Errors != String.Empty)
            {
                return BadRequest(myProp.Errors);
            }
            return Ok(myProp);
        }
        // Increment property's Views
        [HttpGet("IncrementViews/{PropertyId}")]
        public async Task<ActionResult<PropertyReadDto>> UpdateProperty(Guid PropertyId)
        {
            if (PropertyId == Guid.Empty)
            {
                return BadRequest();
            }
            PropertyReadDto myProp = await _propertymanager.IncrementViews(PropertyId);
            if (myProp == null)
            {
                return NotFound();
            }
            return Ok(myProp);

        }

        // update property 
        [HttpPut("UpdateProperty")]
        public ActionResult<PropertyReadDto> UpdateProperty(PropertyUpdateDto model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            PropertyReadDto myProp = _propertymanager.UpdateProperty(model);
            if (myProp.Errors != null)
            {
                return BadRequest(myProp.Errors);
            }
            return Ok(myProp);

        }
        // Delete Property 
        [HttpDelete("DeleteProperty/{id}")]
        public ActionResult<PropertyReadDto> DeleteProperty(Guid id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var property = _propertymanager.DeleteProperty(id);
            if (property == null)
            {
                return NotFound();
            }
            return Ok(property);

        }

    }
}
