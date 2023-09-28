using AbpStore.DTO;
using AbpStore.Entity;
using AbpStore.EntityFrameworkCore;
using AbpStore.IService;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace AbpStore.Service
{
    [Authorize]
    public class ProductAppService:ApplicationService,IProductAppService
    {
        private readonly IRepository<Product,int> _productRepository;
        private readonly IMapper _mapper;
        private readonly AbpStoreDbContext _dbContext;

        public ProductAppService(IRepository<Product, int> productRepository, IMapper mapper, AbpStoreDbContext dbContext)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<ProductDto> CreateAsync(ProductDto productDto)
        {
            var prod = await _productRepository.InsertAsync(new Product
            {
                Name = productDto.Name,
                Summary = productDto.Summary,
                Detail = productDto.Detail,
                Image = productDto.Image,
                CategoryId = productDto.CategoryId
            });

            return new ProductDto
            {
                Id = prod.Id,
                Name = prod.Name,
                Summary = prod.Summary,
                Detail = prod.Detail,
                Image = prod.Image,

            };
        }

        public async Task<int> DeleteAsync(int id)
        {
            var obj = await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (obj != null)
            {
                _dbContext.Products.Remove(obj);
                await _dbContext.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<ProductDto> GetByIdAsync(int id)
        {
            var obj = await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (obj != null)
            {
                return _mapper.Map<Product, ProductDto>(obj);
            }
            return new ProductDto();
        }

        public async Task<List<ProductDto>> GetListAsync()
        {
            return _mapper.Map<IEnumerable<Product>, List<ProductDto>>(_dbContext.Products.Include(x => x.Category));
        }

        public async Task<List<ProductDto>> GetProductByCategoryId(int id)
        {
            var result = await _dbContext.Products.Where(x => x.CategoryId == id).ToListAsync();
            var objProd = _mapper.Map<List<Product>, List<ProductDto>>(result);
            if (objProd.Count > 0)
            {
                return objProd;
            }
            return new List<ProductDto>();
        }

        public async Task<ProductDto> UpdateAsync(ProductDto productDto)
        {
            var objFromDb = await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == productDto.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = productDto.Name;
                objFromDb.Summary = productDto.Summary;
                objFromDb.Detail = productDto.Detail;
                objFromDb.Image = productDto.Image;
                objFromDb.CategoryId = productDto.CategoryId;
                
                await _dbContext.SaveChangesAsync();
                return _mapper.Map<Product, ProductDto>(objFromDb);
            }
            return productDto;
        }
    }
}
