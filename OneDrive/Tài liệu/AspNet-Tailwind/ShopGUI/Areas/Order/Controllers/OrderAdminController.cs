using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.DAL.Entity.Role;
using Shop.DTO.DTOs;
using ShopBussinessLogic.Service.IServices;
using ShopDataAccess.Models;

namespace Shop.Web.Areas.Order.Controllers
{
    [Area("Order")]
    [Route("admin/order/[action]/{id?}")]
    [Authorize(Roles = RoleName.Editor + "," + RoleName.Administrator)]
    public class OrderAdminController : Controller
    {
        private readonly ShopDbContext _context;
        private readonly IEntityService<OrderDTO> _service;

        public OrderAdminController(ShopDbContext context, IEntityService<OrderDTO> service)
        {
            _context = context;
            _service = service;
        }

        // GET: Order/Orders
        public async Task<IActionResult> Index()
        {
            return View(await _service.GetListsAsync());
        }

        // GET: Order/Orders/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var order = await _service.GetAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Order/Orders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Order/Orders/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,UserId,Status,TotalAmount,ShippingAddress,PaymentMethod,CreatedDate,UpdatedDate")] OrderDTO order)
        {
            if (ModelState.IsValid)
            {
                await _service.AddAsync(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }

        // GET: Order/Orders/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var order = await _service.GetAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        // POST: Order/Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderId,UserId,Status,TotalAmount,ShippingAddress,PaymentMethod,CreatedDate,UpdatedDate")] OrderDTO order)
        {
            if (id != order.OrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _service.UpdateAsync(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.OrderId))
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
            return View(order);
        }

        // GET: Order/Orders/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var order = await _service.GetAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Order/Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteAsync(id);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.OrderId == id);
        }
    }
}
