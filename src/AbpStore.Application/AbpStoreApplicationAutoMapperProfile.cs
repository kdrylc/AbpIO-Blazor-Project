using AbpStore.DTO;
using AbpStore.Entity;
using AutoMapper;

namespace AbpStore;

public class AbpStoreApplicationAutoMapperProfile : Profile
{
    public AbpStoreApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<Category, CategoryDto>();
        CreateMap<Product, ProductDto>();
    }
}
