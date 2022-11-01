﻿using AirBnb.BL.DTOs.EmployeeDTOs;
using AirBnb.BL.DTOs.UserDTOs;
using AirBnb.BL.Emails.Services;
using AirBnb.DAL.Data.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AirBnb.BL.Managers.ManageUser
{
    public class UserManage:IUserManager
    {
        private readonly UserManager<User> _usermanager;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public UserManage(UserManager<User> usermanager, IMapper mapper,IEmailService emailService)
        {
            _usermanager = usermanager;
            _mapper = mapper;
            _emailService = emailService;
        }
        //Getting section implementation
        public async Task<UserReadDTO> GetUserByEmail(string email)
        {
            User user = await _usermanager.FindByEmailAsync(email);
            if (user == null)
            {
                return null;
            }
            UserReadDTO neededUser = _mapper.Map<UserReadDTO>(user);
            return neededUser;
        }

        public async Task<UserReadDTO> GetUserById(string id)
        {
            User user = await _usermanager.FindByIdAsync(id);
            if (user == null)
            {
                return null;
            }
            UserReadDTO neededUser = _mapper.Map<UserReadDTO>(user);
            return neededUser;
        }

        public async Task<UserReadDTO> GetUserByUsername(string username)
        {
            User user = await _usermanager.FindByNameAsync(username);
            if (user == null)
            {
                return null;
            }
            UserReadDTO neededUser = _mapper.Map<UserReadDTO>(user);
            return neededUser;
        }

        public async Task<IEnumerable<UserReadDTO>> GetAllUsers()
        {
            IEnumerable<User> myUsers = await _usermanager.Users.ToListAsync();
            if (myUsers == null)
            {
                return null;
            }
            IEnumerable<UserReadDTO> users = _mapper.Map<IEnumerable<UserReadDTO>>(myUsers);

            return users;
        }
        //Adding Section:
        public async Task<UserReadDTO> AddNewUser(UserRegisterDTO model)
        {
            var errors = string.Empty;
            User myUser = _mapper.Map<User>(model);
            if (myUser == null)
            {
                return null;
            }
            var result = await _usermanager.CreateAsync(myUser, model.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                    errors += $"{error.Description},";
                return new UserReadDTO { Errors = errors };
            }
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,myUser.Id),
            };
            await _usermanager.AddClaimsAsync(myUser, claims);
            UserReadDTO AddedUSer = _mapper.Map<UserReadDTO>(myUser);
            // Setting Html Welcome Email Body
            // C:\Users\Dell\source\repos\AirBnb-API\AirBnb.Api\Template\EmailTemplate.html'
            var currentDirector = Directory.GetCurrentDirectory().Replace($"AirBnb.Api", "AirBnb.BL");
            var filePath = $"{currentDirector}\\Emails\\Template\\EmailTemplate.html";
            var str = new StreamReader(filePath);
            var MailText = str.ReadToEnd();
            str.Close();
            MailText = MailText.Replace("[name]", model.FirstName + " " + model.LastName).Replace("[email]", model.Email).Replace("[password]", model.Password);
            await _emailService.SendEmailAsync(model.Email, "Welcome On Board", MailText);
            return AddedUSer;
        }
        //Deleting Section
        public async Task<UserReadDTO> DeleteUser(string id)
        {
            var errors = string.Empty;
            User user = await _usermanager.FindByIdAsync(id);
            if (user == null)
            {
                return null;
            }
            var result = await _usermanager.DeleteAsync(user);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                    errors += $"{error.Description},";
                return new UserReadDTO { Errors = errors };
            }
            UserReadDTO deletedUser = _mapper.Map<UserReadDTO>(user);
            return deletedUser;
        }
        //Updating section:
        public async Task<UserReadDTO> UpdateUser(UserUpdateDTO model)
        {
            var errors = string.Empty;
            User user = await _usermanager.FindByIdAsync(model.Id);
            if (user == null)
            {
                return null;
            }
            _mapper.Map(model, user);
            var result = await _usermanager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                    errors += $"{error.Description},";
                return new UserReadDTO { Errors = errors };
            }
            UserReadDTO updatedUser = _mapper.Map<UserReadDTO>(user);
            return updatedUser;
        }

    }
}
