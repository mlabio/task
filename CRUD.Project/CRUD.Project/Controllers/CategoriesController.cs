using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CRUD.Project.DAL.Entities;
using CRUD.Project.DAL.Models;
using CRUD.Project.BLL.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace CRUD.Project.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryService;
        public CategoriesController(ICategoryRepository categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetCategory()
        {
            var data = await _categoryService.GetCategories();

            return Ok(data);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var data = await _categoryService.GetCategory(id);

            return Ok(data);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateCategory([FromBody] Category model) 
        {
            var data = await _categoryService.CreateCategory(model);

            return Ok(data);
        }

        [HttpPost("Update/{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] Category model)
        {
            if(id != model.Id)
            {
                return BadRequest();
            }

            var data = await _categoryService.UpdateCategory(id, model);

            return Ok(data);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var data = await _categoryService.DeleteCategory(id);

            return Ok(data);
        }
    }
}
