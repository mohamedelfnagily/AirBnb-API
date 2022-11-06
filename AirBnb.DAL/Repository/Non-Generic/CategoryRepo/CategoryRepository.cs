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

        public Category GetCategoryByPropertyId(Guid id)
        {
           // var myCategory = _context.Categories.Include(e => e.Properties).ToList(); 
            var property = _context.Properties.Include(e=>e.Category).Where(e=>e.Id== id).FirstOrDefault();
            var category = property.Category;

            return category;
        }

  

        public async Task<IEnumerable<Property>> GetPropertiesByCategoryName(string name)
        {
           var category =  await GetCategoryByName(name);
            if (category == null)
                return null;
           var properties = await  _context.Properties.Include(e=>e.Pictures).Where(e => e.CategoryId == category.Id).ToListAsync();
           return properties;
        }


        //    public IEnumerable<Property> GetPropertiesByCategoryId(Guid id)
        //    {
        //        Property Properties= await _context.Properties.Include(e=>e.Category).FirstOrDefault(e => e.Id == id);
        //        return Properties;
        //    }

        //    public Task<IEnumerable<Property>> AddPropertiesToCategory(List<Property> properties, Guid id)
        //    {
        //        var myCategory = _context.Categories.Where(e => e.Id == id);



        //    }
    }
}
