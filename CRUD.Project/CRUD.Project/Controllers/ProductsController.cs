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
using Microsoft.AspNetCore.Authorization;

namespace CRUD.Project.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productService;
        private readonly ICategoryRepository _categoryService;
        public ProductsController(IProductRepository productService, ICategoryRepository categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetProducts()
        {
            var data = await _productService.GetProducts();

            return Ok(data);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var data = await _productService.GetProduct(id);

            return Ok(data);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateProduct([FromBody] Product model)
        {
            var status = await CheckIfCategoryExists(model.CategoryId);

            if (!status)
            {
                return BadRequest();
            }

            var data = await _productService.CreateProduct(model);


            return Ok(data);
        }

        [HttpPost("Update/{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] Product model)
        {
            var status = await CheckIfCategoryExists(model.CategoryId);

            if (!status || id != model.Id) 
            {
                return BadRequest();
            }
            
            var data = await _productService.UpdateProduct(id, model);

            return Ok(data);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var data = await _productService.DeleteProduct(id);

            return Ok(data);
        }

        private async Task<bool> CheckIfCategoryExists(int categoryId)
        {
            var category = await _categoryService.GetCategory(categoryId);

            if (category == null)
            {
                return false;
            }

            return true;
        }
    }
}
