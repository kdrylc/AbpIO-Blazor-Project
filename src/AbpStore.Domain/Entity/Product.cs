using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace AbpStore.Entity
{
    [Table("Product", Schema = "dbo")]

    public class Product:Entity<int>
    {
        public string Name { get; set; }
        public string Summary { get; set; }
        public string Detail { get; set; }
        public string Image { get; set; }

        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
