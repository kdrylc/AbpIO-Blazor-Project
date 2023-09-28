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
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace AbpStore.Service
{
    [Authorize(Permissions.AbpStorePermissions.Category.Default)]
    public class CategoryAppService:ApplicationService,ICategoryAppService
    {
        private readonly IRepository<Category, int> _cat;
        private readonly AbpStoreDbContext _db;
        private readonly IMapper _mapper;
        public CategoryAppService(IRepository<Category, int> cat,AbpStoreDbContext db, IMapper mapper)
        {
            _cat = cat;
            _db = db;
            _mapper = mapper;
        }

        [Authorize(Permissions.AbpStorePermissions.Category.Create)]
        public async Task<CategoryDto> CreateAsync(CategoryDto categoryDto)
        {
            var cat = await _cat.InsertAsync(new Category
            {
                Name = categoryDto.Name,
                Description = categoryDto.Description,
                Created = DateTime.Now
            });

            return new CategoryDto
            { 
               Id = cat.Id,
               Name = cat.Name,
               Description = cat.Description,
               Created = DateTime.Now
            };
        }
        [Authorize(Permissions.AbpStorePermissions.Category.Delete)]

        public async Task<int> DeleteAsync(int id)
        {
            var obj = await _db.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (obj!=null)
            {
                _db.Categories.Remove(obj);
                await _db.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<CategoryDto> GetByIdAsync(int id)
        {
           var item = await _db.Categories.FirstOrDefaultAsync(x=>x.Id == id);
            if (item!=null)
            {
                return _mapper.Map<Category, CategoryDto>(item);
            }
            return new CategoryDto();
        }

        public async Task<List<CategoryDto>> GetListAsync()
        {
            var items = await _cat.GetListAsync();
            return items
                .Select(item => new CategoryDto
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    Created = DateTime.Now
                }).ToList();
        }

        public async Task<CategoryDto> UpdateAsync(CategoryDto categoryDto)
        {
            var objfromdb = await _db.Categories.FirstOrDefaultAsync(x=>x.Id==categoryDto.Id);
            if (objfromdb != null)
            {
                objfromdb.Name = categoryDto.Name;
                objfromdb.Description = categoryDto.Description;
                objfromdb.Created = DateTime.Now;
                _db.Categories.Update(objfromdb);
                await _db.SaveChangesAsync();
                return _mapper.Map<Category, CategoryDto>(objfromdb);
            }
            return categoryDto;
        }
    }
}
