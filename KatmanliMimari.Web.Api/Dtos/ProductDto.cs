using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KatmanliMimari.Web.Api.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} alanı zorunludur")]
        public string Name { get; set; }
        [Range(1,int.MaxValue,ErrorMessage ="{0} alanı 1'den büyük olmalıdır")]
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
