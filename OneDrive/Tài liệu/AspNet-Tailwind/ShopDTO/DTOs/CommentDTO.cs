using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DTO.DTOs
{
    public class CommentDTO
    {
        public int ComnmentId { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        [Display(Name = "Nội dung")]
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
