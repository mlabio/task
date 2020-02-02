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
        private readonly DatabaseContext _dbContext;
        public CategoryRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Category>> GetCategories()
        {
            await _dbContext.Database.OpenConnectionAsync();

            using (var cmd = _dbContext.Database.GetDbConnection().CreateCommand())
            {
                cmd.CommandText = "GetCategories";
                cmd.CommandType = CommandType.StoredProcedure;

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    if (reader.HasRows)
                    {
                        var response = await reader.MapToList<Category>();

                        return response;
                    }
                }
            }

            return null;
        }
    }
}
