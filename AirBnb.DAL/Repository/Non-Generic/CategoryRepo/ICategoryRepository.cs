using AirBnb.DAL.Data.Models;
using AirBnb.DAL.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirBnb.DAL.Repository.Non_Generic.CategoryRepo
{
    public interface ICategoryRepository: IBaseRepository<Category>
    {
        Task<Category> GetCategoryByName(string name);
        Category? GetCategoryByPropertyId(Guid id);
        Category? GetCategoryByPropertyName(string Name);
       // Task<IEnumerable<Property>> GetPropertiesByCategoryId(Guid id);
    }

   
}
