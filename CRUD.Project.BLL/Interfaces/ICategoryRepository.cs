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
    }
}
