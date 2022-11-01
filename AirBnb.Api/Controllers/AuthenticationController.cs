using AirBnb.BL.DTOs.EmployeeDTOs;
using AirBnb.BL.DTOs.UserDTOs;
using AirBnb.BL.Managers.ManageEmployee;
using AirBnb.DAL.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AirBnb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IEmployeeManager _employeeManager;
        public AuthenticationController(IEmployeeManager _employeeManager)
        {
            this._employeeManager = _employeeManager;
                
        }
        [HttpPost("CreateEmployee")]
        public async Task<ActionResult<EmployeeReadDTO>> CreateAsync(EmployeeRegisterDTO model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result= await _employeeManager.AddNewEmployee(model);
            if(result.Errors != string.Empty) { 
                return BadRequest(result.Errors);
            }
            return Ok(result);

        }
    }
}
