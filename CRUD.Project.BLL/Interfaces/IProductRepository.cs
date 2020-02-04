using CRUD.Project.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Project.BLL.Interfaces
{
    public interface IProductRepository
    {
        Task<List<ProductResponse>> GetProducts();
        Task<ProductResponse> GetProduct(int id);
        Task<ProductResponse> CreateProduct(Product model);
        Task<ProductResponse> UpdateProduct(int id, Product model);
        Task<Product> DeleteProduct(int id);
    }
}
