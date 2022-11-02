using AirBnb.BL.DTOs.CategoryDTOs;
using AirBnb.BL.DTOs.EmployeeDTOs;
using AirBnb.BL.Managers.ManageCategories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AirBnb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryManager _categoryManager;
        public CategoryController(ICategoryManager categoryManager)
        {
            _categoryManager = categoryManager;

        }
        //Get all Categories
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<CategoryReadDTO>>> GetAll()
        {
            var result = await _categoryManager.GetAllCategories();
            if (result == null)
            {
                return Ok();
            }
            return Ok(result);

        }

        // Get category By id
        [HttpGet("GetById{id}")]
        public async Task<ActionResult<CategoryReadDTO>> GetById(Guid id)
        {
            var result = await _categoryManager.GetCategoryById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);

        }

        // Get category By name
        [HttpGet("GetByName")]
        public async Task<ActionResult<CategoryReadDTO>> GetByname(string name)
        {
            var result = await _categoryManager.GetCategoryByName(name);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);

        }
        // add category 
        [HttpPost("addCategory")]
        public async Task<ActionResult<CategoryReadDTO>> addCategory(CategoryAddDTO model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            var result = await _categoryManager.AddNewCategory(model);
            if (result.Errors != string.Empty)
            {
                return BadRequest(result.Errors);
            }

            return Ok(result);

        }


        [HttpDelete("DeleteCategory{id}")]
        // Delete Category
        public async Task<ActionResult<EmployeeReadDTO>> DeleteCategoryasync(Guid id)
        {
            if (id == null)
                return BadRequest();
            var result = await _categoryManager.DeleteCategory(id);
            if (result == null)
            {
                return NotFound();
            }
            if (result.Errors != string.Empty)
            {
                return BadRequest(result.Errors);
            }

            return Ok(result);
        }

        // Update Category
        [HttpPut("UpdateCategory")]
        public async Task<ActionResult<CategoryReadDTO>> UpdateCategoryAsync(CategoryUpdateDTO model)
        {
            CategoryReadDTO result = await _categoryManager.UpdateCategory(model);
            if (result == null)
            {
                return BadRequest();
            }
            if (result.Errors != string.Empty)
            {
                return BadRequest(result.Errors);
            }
            return Ok(result);
        }


    
}
}
