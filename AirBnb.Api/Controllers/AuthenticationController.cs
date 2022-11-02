using AirBnb.BL.DTOs.CategoryDTOs;
using AirBnb.BL.DTOs.AuthenticationDTOs;
using AirBnb.BL.DTOs.EmployeeDTOs;
using AirBnb.BL.DTOs.UserDTOs;
using AirBnb.BL.Managers.ManageCategories;
using AirBnb.BL.Managers.ManageAuthentication;
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
        private readonly IAuthenticationManager _authenticationmanager;
        public AuthenticationController(IAuthenticationManager manager)
        {
            _authenticationmanager = manager;
        }
        [HttpPost("Login")]
        public async Task<ActionResult<TokenDto>> LoginUser(UserLoginDTO model)
        {
            if(model==null)
            {
                return BadRequest();
            }
            TokenDto token = await _authenticationmanager.LoginUser(model);
            if(token.Message!="Success")
            {
                return BadRequest(token.Message);
            }
            return Ok(token);
        }
        
    }
}
