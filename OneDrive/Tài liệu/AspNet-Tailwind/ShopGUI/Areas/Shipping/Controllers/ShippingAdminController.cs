using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Shop.DAL.Entity.Role;
using Shop.DTO.DTOs;
using ShopBussinessLogic.Service.IServices;
using ShopDataAccess.Models;

namespace Shop.Web.Areas.Shipping.Controllers
{
    [Area("Shipping")]
    [Route("admin/order/[action]/{id?}")]
    [Authorize(Roles = RoleName.Editor + "," + RoleName.Administrator)]
    public class ShippingAdminController : Controller
    {
        private readonly ShopDbContext _context;
        private readonly IEntityService<ShippingDTO> _service;

        public ShippingAdminController(ShopDbContext context, IEntityService<ShippingDTO> service)
        {
            _context = context;
            _service = service;
        }

        // GET: Shipping/ShippingAdmin
        public async Task<IActionResult> Index()
        {
            return View(await _service.GetListsAsync());
        }

        // GET: Shipping/ShippingAdmin/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var shipping = await _service.GetAsync(id);
            if (shipping == null)
            {
                return NotFound();
            }

            return View(shipping);
        }

        // GET: Shipping/ShippingAdmin/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Shipping/ShippingAdmin/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ShippingId,OrderId,ShippingMethod,ShippingCost,ShippingAddress")] ShippingDTO shipping)
        {
            if (ModelState.IsValid)
            {
                await _service.AddAsync(shipping);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shipping);
        }

        // GET: Shipping/ShippingAdmin/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var shipping = await _service.GetAsync(id);
            if (shipping == null)
            {
                return NotFound();
            }
            return View(shipping);
        }

        // POST: Shipping/ShippingAdmin/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ShippingId,OrderId,ShippingMethod,ShippingCost,ShippingAddress")] ShippingDTO shipping)
        {
            if (id != shipping.ShippingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _service.UpdateAsync(shipping);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShippingExists(shipping.ShippingId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(shipping);
        }

        // GET: Shipping/ShippingAdmin/Delete/5
        public async Task<IActionResult> Delete(int id)
        {

            var shipping = await _service.GetAsync(id);
            if (shipping == null)
            {
                return NotFound();
            }

            return View(shipping);
        }

        // POST: Shipping/ShippingAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteAsync(id);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShippingExists(int id)
        {
            return _context.Shippings.Any(e => e.ShippingId == id);
        }
    }
}
