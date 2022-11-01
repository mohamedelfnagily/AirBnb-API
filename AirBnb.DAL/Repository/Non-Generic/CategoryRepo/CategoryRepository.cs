using AirBnb.DAL.Data.Context;
using AirBnb.DAL.Data.Models;
using AirBnb.DAL.Repository.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirBnb.DAL.Repository.Non_Generic.CategoryRepo
{
    public class CategoryRepository:BaseRepository<Category>,ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<Category> GetCategoryByName(string name)
        {
            Category Category= await _context.Categories.FirstOrDefaultAsync(e => e.Name == name);
            return Category;
        }
    }
}
