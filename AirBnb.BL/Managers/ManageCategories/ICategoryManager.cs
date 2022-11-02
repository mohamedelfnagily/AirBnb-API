using AirBnb.BL.DTOs.CategoryDTOs;
using AirBnb.BL.DTOs.CategoryProperties;
using AirBnb.BL.DTOs.EmployeeDTOs;
using AirBnb.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AirBnb.BL.Managers.ManageCategories
{
    public interface ICategoryManager
    {
        //This interface is responsible for all the Category operations like getting , adding, removing Category

        //Getting section:
        Task<CategoryReadDTO> GetCategoryById(Guid id);
        Task<CategoryReadDTO> GetCategoryByName(string name);
        Task<IEnumerable<CategoryReadDTO>> GetAllCategories();

        //Adding new Category
        Task<CategoryReadDTO> AddNewCategory(CategoryAddDTO model);

        //Deleting Category
        Task<CategoryReadDTO> DeleteCategory(Guid id);

        //update existing Category
        Task<CategoryReadDTO> UpdateCategory(CategoryUpdateDTO model);
   

       
    }
}
