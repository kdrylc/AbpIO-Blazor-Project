using AbpStore.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace AbpStore.IService
{
    public interface IProductAppService:IApplicationService
    {
        Task<List<ProductDto>> GetListAsync();
        Task<ProductDto> CreateAsync(ProductDto productDto);
        Task<ProductDto> UpdateAsync(ProductDto productDto);

        Task<int> DeleteAsync(int id);
        Task<ProductDto> GetByIdAsync(int id);
        public Task<List<ProductDto>> GetProductByCategoryId(int id);

    }
}
