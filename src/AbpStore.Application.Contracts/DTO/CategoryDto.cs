using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace AbpStore.DTO
{
    public class CategoryDto:EntityDto<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }

    }
}
