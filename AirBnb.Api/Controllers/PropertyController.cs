using AirBnb.BL.DTOs.PropertyDTOs;
using AirBnb.BL.Managers.ManageProperty;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AirBnb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
            if(myProp.Errors!=null)
            {
                return BadRequest(myProp.Errors);
            }
            return Ok(myProp);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PropertyReadDto>>> GetAllProperties()
        {
            IEnumerable<PropertyReadDto> myProps = await _propertymanager.GetAllProperties();
            return Ok(myProps);
        }

    }
}
