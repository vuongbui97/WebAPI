using System;
using MyApp.Entities;

namespace MyApp.Repositories.ProductRepository
{
    public interface IProductRepository : IGenericRepository<Guid, Product>
    {
        
    }
}