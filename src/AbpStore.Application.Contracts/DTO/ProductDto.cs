using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace AbpStore.DTO
{
    public class ProductDto:EntityDto<int>
    {
        public string Name { get; set; }
        public string Summary { get; set; }
        public string Detail { get; set; }
        public string Image { get; set; }
        public int CategoryId { get; set; }
        public CategoryDto Category { get; set; }
    }
}
