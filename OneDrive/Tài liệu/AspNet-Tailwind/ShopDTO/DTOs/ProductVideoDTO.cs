using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DTO.DTOs
{
    public class ProductVideoDTO
    {
        public int VideoId { get; set; }
        public int ProductId { get; set; }
        public string VideoUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
