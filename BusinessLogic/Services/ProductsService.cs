﻿using AutoMapper;
using Core.DTOs;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Org.BouncyCastle.Crypto;

namespace Core.Services
{
    public class ProductsService : IProductsService
    {
        //private readonly ShopDbContext context;
        private readonly IRepository<Product> productRepo;
        private readonly IRepository<Category> categoryRepo;
        private readonly IFileService fileService;
        private readonly IMapper mapper;

        public ProductsService(IRepository<Product> productRepo,
                               IRepository<Category> categoryRepo,
                               IFileService fileService,
                               IMapper mapper)
        {
            this.productRepo = productRepo;
            this.categoryRepo = categoryRepo;
            this.fileService = fileService;
            this.mapper = mapper;
        }

        public void Create(CreateProductDto product)
        {
            // TODO: rewrite to async methods

            // save image to the server
            string imagePath = fileService.SaveProductImage(product.Image).Result;

            productRepo.Insert(new Product()
            {
                Name = product.Name,
                Price = product.Price,
                CategoryId = product.CategoryId,
                ImagePath = imagePath
            });
            productRepo.Save();
        }

        public void Delete(int id)
        {
            var product = productRepo.GetByID(id);

            if (product == null) return;

            // delete image from the server: fileService.DeleteProductImage()

            // delete element from db
            productRepo.Delete(product);
            productRepo.Save();
        }

        public void Edit(ProductDto dto)
        {
            // delete old image from the server: fileService.DeleteProductImage()
            // save new image to the server: fileService.SaveProductImage()

            //var entity = new Product()
            //{
            //    Id = dto.Id,
            //    Name = dto.Name,
            //    Price = dto.Price,
            //    ImagePath = dto.ImagePath,
            //    CategoryId = dto.CategoryId
            //};
            var entity = mapper.Map<Product>(dto);

            productRepo.Update(entity);
            productRepo.Save();
        }

        public List<ProductDto> GetAll()
        {
            // include properties: LEFT JOIN in SQL
            //var result = productRepo.Get(orderBy: x => x.OrderBy(p => p.Name), includeProperties: new[] { "Category" }).ToList();
            var result = productRepo.GetListBySpec(new Products.OrderedAll());

            return mapper.Map<List<ProductDto>>(result);
        }

        public ProductDto? Get(int id)
        {
            if (id < 0) return null; // exception

            // get product by id
            //var product = productRepo.GetByID(id);
            var product = productRepo.GetItemBySpec(new Products.ById(id));

            //if (product == null) return null; // exception

            //return new ProductDto()
            //{
            //    Id = product.Id,
            //    Name = product.Name,
            //    Price = product.Price,
            //    ImagePath = product.ImagePath,
            //    CategoryId = product.CategoryId,
            //    CategoryName = product.Category?.Name
            //};
            return mapper.Map<ProductDto>(product);
        }

        public List<Category> GetCategories()
        {
            return categoryRepo.GetAll().ToList();
        }

        public List<ProductDto> Get(int[] ids)
        {
            //var result = productRepo.Get(x => ids.Contains(x.Id)).ToList();
            var result = productRepo.GetListBySpec(new Products.ByIds(ids));

            return mapper.Map<List<ProductDto>>(result);
        }
    }
}
