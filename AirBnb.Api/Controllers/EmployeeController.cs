using AirBnb.BL.DTOs.EmployeeDTOs;
using AirBnb.BL.Managers.ManageEmployee;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AirBnb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeManager _employeeManager;
        public EmployeeController(IEmployeeManager _employeeManager)
        {
            this._employeeManager = _employeeManager;

        }
        // Create Employee 
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
            var result = await _employeeManager.AddNewEmployee(model);
            if (result.Errors != string.Empty)
            {
                return BadRequest(result.Errors);
            }
            return Ok(result);

        }


        [HttpDelete("DeleteEmployee/{id}")]
        // Delete Employee
        public async Task<ActionResult<EmployeeReadDTO>> DeleteAsync(string id)
        {
            if (id == null)
                return BadRequest();
            var result = await _employeeManager.DeleteEmployee(id);
            if (result == null)
            {
                return NotFound();
            }
            if (result.Errors != string.Empty)
            {
                return BadRequest(result.Errors);
            }
            return Ok(result);
        }
    }
}
