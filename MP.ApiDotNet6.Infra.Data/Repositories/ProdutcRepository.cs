using Microsoft.EntityFrameworkCore;
using MP.ApiDotNet6.Domain.Entities;
using MP.ApiDotNet6.Domain.Repositories;
using MP.ApiDotNet6.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP.ApiDotNet6.Infra.Data.Repositories
{
    public class ProdutcRepository : IProductRepository
    {
        private readonly ApplicationDbContext _db;
        
        public ProdutcRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<Product> CreateProductAsync(Product product)
        {
            _db.Add(product);
            await _db.SaveChangesAsync();
            return product;
        }

        public async Task DeleteProductAsync(Product product)
        {
            _db.Remove(product);
            await _db.SaveChangesAsync();
        }

        public async Task EditProductAsync(Product product)
        {
            _db.Product.Update(product);
            await _db.SaveChangesAsync();
           
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _db.Product.FirstOrDefaultAsync(x=> x.Id == id);

        }

        public async Task<ICollection<Product>> GetProductsAsync()
        {
            return await _db.Product.ToListAsync();
        }
    }
}
