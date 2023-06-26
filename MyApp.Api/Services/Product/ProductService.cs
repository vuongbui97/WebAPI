using AutoMapper;
using MyApp.Repositories.ProductRepository;
using System;

namespace MyApp.Services.Product
{
    public class ProductService: GenericService<Guid, Entities.Product>, IProductService
    {
        public ProductService(IMapper mapper, IProductRepository productRepository) : base(mapper, productRepository)
        {
            
        }
    }
}