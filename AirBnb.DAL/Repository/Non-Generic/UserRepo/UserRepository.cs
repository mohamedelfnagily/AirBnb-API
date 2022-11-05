using AirBnb.DAL.Data.Context;
using AirBnb.DAL.Data.Models;
using AirBnb.DAL.Repository.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirBnb.DAL.Repository.Non_Generic.UserRepo
{
    public class UserRepository : BaseRepository<User>,IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context) :base(context)
        {
            _context = context;
        }

        public async Task<User> GetUserWithLanguageById(string id)
        {
            var user =await  _context.Users.Include(e => e.userLanguages).FirstOrDefaultAsync(e => e.Id == id);
            return user;

        }
    }
}
