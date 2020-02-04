using CRUD.Project.BLL.Interfaces;
using CRUD.Project.DAL.Entities;
using CRUD.Project.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace CRUD.Project.BLL.Services
{
    public class ProductRepository : IProductRepository
    {
        private readonly DatabaseContext _context;
        public ProductRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<ProductResponse>> GetProducts()
        {
            return await GetAllProducts();
        }
        public async Task<ProductResponse> GetProduct(int id)
        {
            return await GetProductById(id);
        }
        public async Task<ProductResponse> CreateProduct(Product model)
        {
            _context.Product.Add(model);

            await _context.SaveChangesAsync();

            return await GetProduct(model.Id);
        }
        public async Task<ProductResponse> UpdateProduct(int id, Product model)
        {
            _context.Entry(model).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return await GetProduct(id);
        }
        public async Task<Product> DeleteProduct(int id)
        {
            var product = await _context.Product.FindAsync(id);

            if (product == null)
            {
                return null;
            }

            _context.Product.Remove(product);
            await _context.SaveChangesAsync();

            return product;
        }

        #region private methods
        private async Task<List<ProductResponse>> GetAllProducts()
        {
            var result = from a in _context.Product
                         join b in _context.Category on a.CategoryId equals b.Id
                         select new ProductResponse
                         {
                             Id = a.Id,
                             CategoryId = a.CategoryId,
                             CategoryName = b.Name,
                             Name = a.Name,
                             Description = a.Description,
                             Image = a.Image
                         };

            return result.ToList();
        }

        private async Task<ProductResponse> GetProductById(int id)
        {
            var result = from a in _context.Product
                         join b in _context.Category on a.CategoryId equals b.Id
                         where a.Id == id
                         select new ProductResponse
                         {
                             Id = a.Id,
                             CategoryId = a.CategoryId,
                             CategoryName = b.Name,
                             Name = a.Name,
                             Description = a.Description,
                             Image = a.Image
                         };

            return result.FirstOrDefault();
        }

        #endregion
    }
}
