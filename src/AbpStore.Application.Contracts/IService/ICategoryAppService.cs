using AbpStore.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace AbpStore.IService
{
    public interface ICategoryAppService:IApplicationService
    {
        Task<List<CategoryDto>> GetListAsync();
        Task<CategoryDto> CreateAsync(CategoryDto categoryDto);
        Task<CategoryDto> UpdateAsync(CategoryDto categoryDto);

        Task<int> DeleteAsync(int id);
        Task<CategoryDto> GetByIdAsync(int id);
    }
}
