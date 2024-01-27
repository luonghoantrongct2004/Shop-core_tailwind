using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Shop.DTO.DTOs;
using ShopBussinessLogic.Service.IServices;
using ShopDataAccess.Entity.Pay;
using ShopDataAccess.Models;

namespace Shop.Web.Areas.Pay.Controllers
{
    [Area("Pay")]
    public class TransactionPayAdminController : Controller
    {
        private readonly ShopDbContext _context;
        private readonly IEntityService<TransactionPayDTO> _service;

        public TransactionPayAdminController(ShopDbContext context, IEntityService<TransactionPayDTO> service)
        {
            _context = context;
            _service = service;
        }

        // GET: Pay/TransactionPays
        public async Task<IActionResult> Index()
        {
            return View(await _service.GetListsAsync());
        }

        // GET: Pay/TransactionPays/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var transactionPay = await _service.GetAsync(id);
            if (transactionPay == null)
            {
                return NotFound();
            }

            return View(transactionPay);
        }

        // GET: Pay/TransactionPays/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pay/TransactionPays/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TransactionId,OrderId,PaymentMethod,AmountMoney,TransactionDate")] TransactionPayDTO transactionPay)
        {
            if (ModelState.IsValid)
            {
                await _service.AddAsync(transactionPay);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(transactionPay);
        }

        // GET: Pay/TransactionPays/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var transactionPay = await _service.GetAsync(id);
            if (transactionPay == null)
            {
                return NotFound();
            }
            return View(transactionPay);
        }

        // POST: Pay/TransactionPays/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TransactionId,OrderId,PaymentMethod,AmountMoney,TransactionDate")] TransactionPayDTO transactionPay)
        {
            if (id != transactionPay.TransactionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _service.UpdateAsync(transactionPay);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransactionPayExists(transactionPay.TransactionId))
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
            return View(transactionPay);
        }

        // GET: Pay/TransactionPays/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transactionPay = await _context.Transactions
                .FirstOrDefaultAsync(m => m.TransactionId == id);
            if (transactionPay == null)
            {
                return NotFound();
            }

            return View(transactionPay);
        }

        // POST: Pay/TransactionPays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteAsync(id);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransactionPayExists(int id)
        {
            return _context.Transactions.Any(e => e.TransactionId == id);
        }
    }
}
