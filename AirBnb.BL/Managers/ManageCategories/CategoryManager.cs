using AirBnb.BL.DTOs.CategoryDTOs;
using AirBnb.DAL.Data.Models;
using AirBnb.DAL.Repository.Non_Generic.CategoryRepo;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AirBnb.BL.Managers.ManageCategories
{
    public class CategoryManager : ICategoryManager
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;


        public CategoryManager(ICategoryRepository categoryRepository,IMapper mapper)
        {
           _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CategoryReadDTO>> GetAllCategories()
        {
            IEnumerable<Category> Categories = await _categoryRepository.GetAllAsync();
            if (Categories == null)
            {
                return null;
            }
            IEnumerable<CategoryReadDTO> MyCategories = _mapper.Map<IEnumerable<CategoryReadDTO>>(Categories);
            return MyCategories;
        }

        public async Task<CategoryReadDTO> GetCategoryById(Guid id)
        {
           Category category = await _categoryRepository.GetByIdAsync(id);
            if(category==null)
            {
                return null;
            }
            CategoryReadDTO myCategory = _mapper.Map<CategoryReadDTO>(category);
            return myCategory;
        }

        public async Task<CategoryReadDTO> GetCategoryByName(string name)
        {
            Category category = await _categoryRepository.GetCategoryByName(name);
            if (category == null)
            {
                return null;
            }
            CategoryReadDTO myCategory = _mapper.Map<CategoryReadDTO>(category);
            return myCategory;
        }

        public async Task<CategoryReadDTO> AddNewCategory(CategoryAddDTO model)
        {
            Category newCategory = new Category();
            newCategory = _mapper.Map<Category>(model);
            if (newCategory == null)
            {
                return null;
            }
            newCategory.Id =Guid.NewGuid();
            await _categoryRepository.AddAsync(newCategory);
            _categoryRepository.Save();
            CategoryReadDTO AddedCategory = _mapper.Map<CategoryReadDTO>(newCategory);
            if (AddedCategory == null)
            {
                return null;
            }
            return AddedCategory;
        }

        public async Task<CategoryReadDTO> DeleteCategory(Guid id)
        {
            Category deletedCategory = _categoryRepository.Delete(id) ;
            if (deletedCategory == null)
            {
                return null;
            }
            _categoryRepository.Save();
            CategoryReadDTO category = _mapper.Map<CategoryReadDTO>(deletedCategory);
            return category;
        }

       

        public async Task<CategoryReadDTO> UpdateCategory(CategoryUpdateDTO model)
        {
            Category category = _categoryRepository.GetById(model.id);
            _mapper.Map(model, category);
            if (category == null)
            {
                return null;
            }
            _categoryRepository.Save();
            CategoryReadDTO UpdatedCategory = _mapper.Map<CategoryReadDTO>(category);
            return UpdatedCategory;
        }

      
    }
}
