using AirBnb.BL.DTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirBnb.BL.Managers.ManageUser
{
    public interface IUserManager
    {
        //This interface is responsible for all the user operations like getting , adding, removing user
        //Getting section:
        Task<UserReadDTO> GetUserById(string id);
        Task<UserReadDTO> GetUserByEmail(string email);
        Task<UserReadDTO> GetUserByUsername(string username);
        Task<IEnumerable<UserReadDTO>> GetAllUsers();
        //Adding new user
        Task<UserReadDTO> AddNewUser(UserRegisterDTO model);
        //Deleting user
        Task<UserReadDTO> DeleteUser(string id);
        //update existing user
        Task<UserReadDTO> UpdateUser(UserUpdateDTO model, string id);
    }
}
