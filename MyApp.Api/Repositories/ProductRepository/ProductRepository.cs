using System;
using AutoMapper;
using MyApp.Entities;

namespace MyApp.Repositories.ProductRepository
{
    public class ProductRepository : GenericRepository<Guid, Product>, IProductRepository
    {
        public ProductRepository(IMapper mapper, MyDbContext myDbContext) : base(mapper, myDbContext)
        {
            
        }
    }
}