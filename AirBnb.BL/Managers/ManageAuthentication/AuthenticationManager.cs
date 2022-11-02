using AirBnb.BL.DTOs.AuthenticationDTOs;
using AirBnb.BL.DTOs.UserDTOs;
using AirBnb.BL.Helpers;
using AirBnb.BL.Managers.ManageEmployee;
using AirBnb.BL.Managers.ManageUser;
using AirBnb.DAL.Data.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AirBnb.BL.Managers.ManageAuthentication
{
    public class AuthenticationManager:IAuthenticationManager
    {
        //Implementing user login and user regesteration
        //Here we are injecting both user and employees in order to handle users and employees login to the website
        private readonly UserManager<User> _userManager;
        private readonly UserManager<Employee> _employeemanager;
        private IConfiguration _config;
        public AuthenticationManager(IConfiguration config,UserManager<Employee> employeemanager,UserManager<User> usermanager)
        {
            _config = config;
            _employeemanager = employeemanager;
            _userManager = usermanager;
        }
        //Generating The token
        public string GenerateToken(IEnumerable<Claim> myClaims, SigningCredentials credentials)
        {
            var jwt = new JwtSecurityToken(
                    claims: myClaims,
                    signingCredentials: credentials,
                    expires: DateTime.Now.AddMinutes(15),
                    notBefore: DateTime.Now
                );
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.WriteToken(jwt);
            return token;
        }
        //Logging in the user and sending back the token to the client
        public async Task<TokenDto> LoginUser(UserLoginDTO model)
        {
            TokenDto? myUserData = new TokenDto();
            var EmailExtension = model.Email.Split('@')[1];
            IList<Claim> claims;
            if(EmailExtension==EmailExtensionHelper.EmailExtension)
            {
                var emp = await _employeemanager.FindByEmailAsync(model.Email);
                if(emp==null)
                {
                    myUserData.Message = "Invalid Email or Password!";
                    return myUserData;
                }
                claims = await _employeemanager.GetClaimsAsync(emp);
                if (!await _employeemanager.CheckPasswordAsync(emp, model.Password))
                {
                    myUserData.Message = "Invalid Email or password, Form more info contact IT adminstrator";
                    return myUserData;
                }
            }
            else
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user == null)
                {
                    myUserData.Message = "Invalid Email or Password!";
                    return myUserData;
                }
                claims = await _userManager.GetClaimsAsync(user);
                if (!await _userManager.CheckPasswordAsync(user, model.Password))
                {
                    myUserData.Message = "Invalid Email or password!";
                    return myUserData;
                }
            }
            myUserData.Token = GenerateToken(claims, JWTHelper.getCredentials(_config));
            myUserData.ExpiryDuration = JWTHelper.GetExpiryDuration(_config);
            myUserData.Message = "Success";
            return myUserData;

        }

    }
}
