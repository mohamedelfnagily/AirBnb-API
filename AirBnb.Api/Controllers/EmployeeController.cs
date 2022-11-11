using AirBnb.BL.DTOs.EmployeeDTOs;
using AirBnb.BL.Managers.ManageEmployee;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AirBnb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeManager _employeeManager;
        public EmployeeController(IEmployeeManager _employeeManager)
        {
            this._employeeManager = _employeeManager;

        }
        //Get all Employees
        [Authorize(Policy = "CEO")]
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<EmployeeReadDTO>>> GetAll()
        {
            var result = await _employeeManager.GetAllEmployees();
            if (result == null)
            {
                return Ok();
            }
            return Ok(result);

        }
        // Get Employee By id
        [Authorize(Policy = "CEO")]
        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<EmployeeReadDTO>> GetById(string id)
        {
            var result = await _employeeManager.GetEmployeeById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);

        }


        // Create Employee 
        [Authorize(Policy = "CEO")]
        [HttpPost("CreateEmployee")]
        public async Task<ActionResult<EmployeeReadDTO>> CreateAsync(EmployeeRegisterDTO model)
        {
            if (model == null)
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

        [Authorize(Policy = "CEO")]
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

        // Update Employee
        [Authorize(Policy = "Manager")]
        [HttpPut]
        public async Task<ActionResult<EmployeeReadDTO>> UpdateAsync([FromForm]EmployeeUpdateDTO model)
        {
            if (model.Id == null)
            {
                return BadRequest();
            }
            var result = await _employeeManager.UpdateEmployee(model);
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
