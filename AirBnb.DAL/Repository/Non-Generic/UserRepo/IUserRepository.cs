using AirBnb.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirBnb.DAL.Repository.Non_Generic.UserRepo
{
    public interface IUserRepository
    {
        Task<User> GetUserWithLanguageById(string id);
    }
}
