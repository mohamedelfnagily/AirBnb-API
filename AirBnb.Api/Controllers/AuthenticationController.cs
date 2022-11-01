using AirBnb.BL.DTOs.AuthenticationDTOs;
using AirBnb.BL.DTOs.EmployeeDTOs;
using AirBnb.BL.DTOs.UserDTOs;
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
        private readonly IAuthenticationManager _authentactionmanager;
        public AuthenticationController(IAuthenticationManager authentactionmanager)
        {
            _authentactionmanager = authentactionmanager;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<TokenDto>> Login(UserLoginDTO model)
        {
            if(model==null)
            {
                return BadRequest();
            }
            TokenDto myToken = await _authentactionmanager.LoginUser(model);
            if(myToken.Message!="Success")
            {
                return BadRequest(myToken.Message);
            }
            return Ok(myToken);
        }
    }
}
