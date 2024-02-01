﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shop.BLL.Service.IServices;
using Shop.DAL.Entity.Cart;
using Shop.DTO.DTOs;
using Shop.Web.Models;
using ShopBussinessLogic.Service.IServices;
using ShopDataAccess.Models;

namespace Shop.Web.Controllers
{
    public class CartHomeController : Controller
    {
        private readonly ShopDbContext _context; 
        private static readonly List<CartItemProductModel> CartItems = new List<CartItemProductModel>();
        private readonly UserManager<ShopUser> _userManager;
        public CartHomeController(ShopDbContext context, UserManager<ShopUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IActionResult Cart(string? userId)
        {
            var user = _userManager.Users.FirstOrDefault(u => u.Id == userId);
            if (user == null || user.Address == null)
            {
                user.Address = "Chưa có địa chỉ";
            }
            ViewBag.Address = user.Address;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddToCart(int productId, int quantity, string userId)
        {
            var existingCartItem = CartItems.FirstOrDefault(item => item.ProductId == productId);
            if (existingCartItem != null)
            {
                existingCartItem.Quantity += quantity;
                existingCartItem.SubTotal = existingCartItem.Quantity * existingCartItem.Products.Price;
            }
            else
            {
                var product = GetProductById(productId);
                var newCartItem = new CartItemProductModel
                {
                    CartItems = new CartItemDTO
                    {
                        ProductId = productId,
                        Quantity = quantity,
                        SubTotal = quantity * product.Price,
                    },
                    Products = product
                };
                CartItems.Add(newCartItem);
            }
            return Json(new {success = true});
        }
        private ProductDTO GetProductById(int productId)
        {
            return new ProductDTO
            { ProductId = productId};
        }
        [HttpPost]
        public IActionResult UpdateQuantityAsyn(int productId, int quantity)
        {
            try
            {
                var existingCartItem = CartItems.FirstOrDefault(item => item.ProductId == productId);
                if (existingCartItem != null)
                {
                    existingCartItem.Quantity = quantity;
                    existingCartItem.SubTotal = existingCartItem.Products.Price * quantity;
                    return Json(new { success = true });
                }
                else
                {
                    return Json(new { success = false, message = "CartItem not found." });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
        [HttpGet]
        public IActionResult GetCartTotal()
        {
            try
            {
                decimal total = CartItems.Sum(s => s.SubTotal);
                return Json(total);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
        public async Task<IActionResult> RemoveCart(int productId)
        {
            var cartItem = CartItems.SingleOrDefault(item => item.ProductId == productId);
            if (cartItem != null)
            {
                CartItems.Remove(cartItem);
                await _context.SaveChangesAsync();
            }
            return View("Index");
        }
    }
}
