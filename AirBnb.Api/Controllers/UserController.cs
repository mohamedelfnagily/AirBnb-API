using AirBnb.BL.DTOs.UserDTOs;
using AirBnb.BL.Helpers;
using AirBnb.BL.Managers.ManageUser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AirBnb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserManager _userManager;
        public UserController(IUserManager _userManager)
        {
            this._userManager = _userManager;

        }
        //Get all Users
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<UserRegisterDTO>>> GetAll()
        {
            var result = await _userManager.GetAllUsers();
            if (result == null)
            {
                return Ok();
            }
            return Ok(result);

        }
        // Get User By id
        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<UserRegisterDTO>> GetById(string id)
        {
            var result = await _userManager.GetUserById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);

        }


        // Create User
        [AllowAnonymous]
        [HttpPost("CreateUser")]
        public async Task<ActionResult<UserRegisterDTO>> CreateAsync([FromForm]UserRegisterDTO model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            var result = await _userManager.AddNewUser(model);
            if (result.Errors != string.Empty)
            {
                return BadRequest(result.Errors);
            }
            return Ok(result);

        }


        [HttpDelete("Delete/{id}")]
        // Delete User
        public async Task<ActionResult<UserRegisterDTO>> DeleteAsync(string id)
        {
            if (id == null)
                return BadRequest();
            var result = await _userManager.DeleteUser(id);
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

        // Update User
        [HttpPut]
        public async Task<ActionResult<UserRegisterDTO>> UpdateAsync([FromForm]UserUpdateDTO userUpdateDTO)
        {
            if (userUpdateDTO.Id == null)
            {
                return BadRequest();
            }
            var result = await _userManager.UpdateUser(userUpdateDTO);
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
        //Banning a user
        [HttpPut("BanUser")]
        public async Task<ActionResult<UserReadDTO>> BanUser(UserBanDTO model)
        {
            if(model == null)
            {
                return BadRequest();
            }
            var result = await _userManager.BanUser(model);
            if(result.Errors!=String.Empty)
            {
                return BadRequest(result.Errors);
            }
            return Ok(result);

        }
       
    }
}
