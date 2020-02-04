using CRUD.Project.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Project.BLL.Interfaces
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetCategories();
        Task<Category> GetCategory(int id);
        Task<Category> CreateCategory(Category model);
        Task<Category> UpdateCategory(int id, Category model);
        Task<Category> DeleteCategory(int id);
    }
}
