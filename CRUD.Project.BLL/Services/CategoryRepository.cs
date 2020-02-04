using CRUD.Project.BLL.Helpers;
using CRUD.Project.BLL.Interfaces;
using CRUD.Project.DAL.Entities;
using CRUD.Project.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Project.BLL.Services
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DatabaseContext _context;
        public CategoryRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetCategories()
        {
            return await _context.Category.ToListAsync();
        }
        public async Task<Category> GetCategory(int id)
        {
            return await _context.Category.FindAsync(id);
        }
        public async Task<Category> CreateCategory(Category model)
        {
            _context.Category.Add(model);
           
            await _context.SaveChangesAsync();

            return await GetCategory(model.Id);
        }
        public async Task<Category> UpdateCategory(int id, Category model)
        {
            _context.Entry(model).State = EntityState.Modified;
            
            await _context.SaveChangesAsync();

            return await GetCategory(id);
        }
        public async Task<Category> DeleteCategory(int id)
        {
            var category = await _context.Category.FindAsync(id);

            if(category == null)
            {
                return null;
            }

            _context.Category.Remove(category);
            await _context.SaveChangesAsync();

            return category;
        }
        
    }
}
