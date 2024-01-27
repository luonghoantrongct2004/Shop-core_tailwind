using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Shop.DAL.Entity.Role;
using Shop.DTO.DTOs;
using ShopBussinessLogic.Service.IServices;
using ShopDataAccess.Entity.Brand;
using ShopDataAccess.Models;

namespace Shop.Web.Areas.Brand.Controllers
{
    [Area("Brand")]
    [Route("admin/brand/[action]/{id?}")]
    [Authorize(Roles = RoleName.Editor + "," + RoleName.Administrator)]
    public class BrandAdminController : Controller
    {
        private readonly ShopDbContext _context;
        private readonly IEntityService<BrandDTO> _service;

        public BrandAdminController(ShopDbContext context, IEntityService<BrandDTO> service)
        {
            _context = context;
            _service = service;
        }

        // GET: Brand/Brands    
        public async Task<IActionResult> Index()
        {
            return View(await _service.GetListsAsync());
        }

        // GET: Brand/Brands/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var brand = await _service.GetAsync(id);
            if (brand == null)
            {
                return NotFound();
            }

            return View(brand);
        }

        // GET: Brand/Brands/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BrandName,Slug,BrandDescription,MetaTitle,MetaDescription")] BrandDTO brand)
        {
            if (ModelState.IsValid)
            {
                await _service.AddAsync(brand);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(brand);
        }

        // GET: Brand/Brands/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var brand = await _service.GetAsync(id);
            if (brand == null)
            {
                return NotFound();
            }
            return View(brand);
        }

        // POST: Brand/Brands/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BrandName,Slug,BrandDescription,MetaTitle,MetaDescription")] BrandDTO brand)
        {
            if (id != brand.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _service.UpdateAsync(brand);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BrandExists(brand.Id))
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
            return View(brand);
        }

        // GET: Brand/Brands/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var brand = await _service.GetAsync(id);
            if (brand == null)
            {
                return NotFound();
            }

            return View(brand);
        }

        // POST: Brand/Brands/Delete/5
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteAsync(id);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BrandExists(int id)
        {
            return _context.Brands.Any(e => e.Id == id);
        }
    }
}
