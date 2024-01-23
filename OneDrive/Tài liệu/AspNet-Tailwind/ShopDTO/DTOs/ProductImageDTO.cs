using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DTO.DTOs
{
    public class ProductImageDTO
    {
        public int ImageId { get; set; }
        public int ProductId { get; set; }
        public string Image { get; set; }
    }
}
