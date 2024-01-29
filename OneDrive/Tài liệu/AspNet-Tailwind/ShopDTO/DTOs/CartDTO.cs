﻿using ShopDataAccess.Models;
namespace Shop.DTO.DTOs
{
    public class CartDTO
    {
        public int CartId { get; set; }
        public decimal TotalPrice { get; set; }
        public string UserId { get; set; }
        public virtual ShopUser User { get; set; }
        public virtual ICollection<CartItemDTO> CartItems { get; set; }
    }
}
