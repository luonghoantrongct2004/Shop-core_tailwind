﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.DAL.Entity.Role;
using Shop.DTO.DTOs;
using ShopBussinessLogic.Service.IServices;
using ShopDataAccess.Entity.Product;
using ShopDataAccess.Models;

namespace Shop.Web.Areas.Product.Controllers
{
    [Area("Product")]
    [Route("admin/product/[action]/{id?}")]
    [Authorize(Roles = RoleName.Editor + "," + RoleName.Administrator)]
    public class ProductAdminController : Controller
    {
        private readonly ShopDbContext _context;
        private readonly IEntityService<ProductDTO> _service;

        public ProductAdminController(ShopDbContext context, IEntityService<ProductDTO> service)
        {
            _context = context;
            _service = service;
        }

        [TempData]
        public string StatusMessage { get; set; }
        // GET: Product/ProductsAdmin
        [Authorize(Policy = "CanView")]
        public async Task<IActionResult> Index()
        {
            return View(await _service.GetListsAsync());
        }

        // GET: Product/ProductsAdmin/Details/5
        [Authorize(Policy = "CanView")]
        public async Task<IActionResult> Details(int id)
        {
            var product = await _service.GetAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
        [Authorize(Policy = "CanCreate")]
        // GET: Product/ProductsAdmin/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Product/ProductsAdmin/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,ProductName,Slug,Description,Price,Quantity,Image,Video,CategoryId,BrandId,MetaTitle,MetaDescription")] ProductDTO product)
        {
            if (ModelState.IsValid)
            {
                await _service.AddAsync(product);
                await _context.SaveChangesAsync();
                StatusMessage = $"Đã tạo 1 sản phẩm {product.ProductName}";
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Product/ProductsAdmin/Edit/5
        [Authorize(Policy = "CanEdit")]
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _service.GetAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Product/ProductsAdmin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,ProductName,Slug,Description,Price,Quantity,Image,Video,CategoryId,BrandId,MetaTitle,MetaDescription")] ProductDTO product)
        {
            if (id != product.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _service.UpdateAsync(product);
                    await _context.SaveChangesAsync();
                    StatusMessage = $"Đã sửa 1 sản phẩm {product.ProductName}";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductId))
                    {
                        return View(nameof(Edit));
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Product/ProductsAdmin/Delete/5
        [Authorize(Policy = "CanDelete")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _service.GetAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Product/ProductsAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteAsync(id);
            await _context.SaveChangesAsync();
            StatusMessage = $"Đã xóa 1 sản phẩm {id}";
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }
    }
}
