using AirBnb.BL.DTOs.UserDTOs;
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
        public UserManage(UserManager<User> usermanager, IMapper mapper)
        {
            _usermanager = usermanager;
            _mapper = mapper;
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
            User myUser = _mapper.Map<User>(model);
            if (myUser == null)
            {
                return null;
            }
            var AddedUser = await _usermanager.CreateAsync(myUser, model.Password);
            if (!AddedUser.Succeeded)
            {
                return null;
            }
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,myUser.Id),
                new Claim(ClaimTypes.Role,"Customer")
            };
            var result = await _usermanager.AddClaimsAsync(myUser, claims);
            UserReadDTO AddedUSer = _mapper.Map<UserReadDTO>(myUser);
            return AddedUSer;
        }
        //Deleting Section
        public async Task<UserReadDTO> DeleteUser(string id)
        {
            User user = await _usermanager.FindByIdAsync(id);
            if (user == null)
            {
                return null;
            }
            var result = await _usermanager.DeleteAsync(user);
            if (!result.Succeeded)
            {
                return null;
            }
            UserReadDTO deletedUser = _mapper.Map<UserReadDTO>(user);
            return deletedUser;
        }
        //Updating section:
        public async Task<UserReadDTO> UpdateUser(UserUpdateDTO model, string id)
        {
            User user = await _usermanager.FindByIdAsync(id);
            if (user == null)
            {
                return null;
            }
            _mapper.Map(model, user);
            var result = await _usermanager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                return null;
            }
            UserReadDTO updatedUser = _mapper.Map<UserReadDTO>(user);
            return updatedUser;
        }

    }
}
