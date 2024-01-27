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
using ShopDataAccess.Entity.Blog;
using ShopDataAccess.Models;

namespace Shop.Web.Areas.Blog.Controllers
{
    [Area("Blog")]
    [Route("admin/blog/new/[action]/{id?}")]
    [Authorize(Roles = RoleName.Editor + "," + RoleName.Administrator)]
    public class NewAdminController : Controller
    {
        private readonly ShopDbContext _context;
        private readonly IEntityService<NewDTO> _service;

        public NewAdminController(ShopDbContext context, IEntityService<NewDTO> service)
        {
            _context = context;
            _service = service;
        }

        // GET: Blog/News
        public async Task<IActionResult> Index()
        {
            return View(await _service.GetListsAsync());
        }

        // GET: Blog/News/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var news = await _service.GetAsync(id);
            if (news == null)
            {
                return NotFound();
            }

            return View(news);
        }

        // GET: Blog/News/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Blog/News/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TitleNew,Content,CreatedDate")] NewDTO news)
        {
            if (ModelState.IsValid)
            {
                await _service.AddAsync(news);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(news);
        }

        // GET: Blog/News/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var news = await _service.GetAsync(id);
            if (news == null)
            {
                return NotFound();
            }
            return View(news);
        }

        // POST: Blog/News/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TitleNew,Content,CreatedDate")] NewDTO news)
        {
            if (id != news.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _service.UpdateAsync(news);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NewsExists(news.Id))
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
            return View(news);
        }

        // GET: Blog/News/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var news = await _service.GetAsync(id);
            if (news == null)
            {
                return NotFound();
            }

            return View(news);
        }

        // POST: Blog/News/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
                await _service.DeleteAsync(id);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NewsExists(int id)
        {
            return _context.News.Any(e => e.Id == id);
        }
    }
}
