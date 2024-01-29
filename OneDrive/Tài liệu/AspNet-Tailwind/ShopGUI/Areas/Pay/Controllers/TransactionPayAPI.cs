using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shop.DTO.DTOs;
using ShopDataAccess.Entity.Pay;
using ShopDataAccess.Models;

namespace Shop.Web.Areas.Pay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionPayAPI : ControllerBase
    {
        private readonly ShopDbContext _context;
        private readonly UserManager<ShopUser> _userManager;

        public TransactionPayAPI(ShopDbContext context, UserManager<ShopUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        [TempData]
        public string StatusMessage { get; set; }
        // GET: api/<TransactionPayAPI>
        [HttpGet]
        public async Task<IActionResult> GetTransactions()
        {
            try
            {
                var currentUser = await _userManager.GetUserAsync(User);
                if (currentUser != null)
                {
                    var transactions = _context.Transactions
                        .Where(t => t.UserId == currentUser.Id)
                        .ToList();
                    return Ok(transactions);
                }
                else
                {
                    return BadRequest(new { StatusMessage = "Người dùng không tồn tại." });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error processing transaction", error = ex.Message });
            }
        }
        // POST api/<TransactionPayAPI>
        [HttpPost]
        public async Task<IActionResult> ProcessTransactionAsync([FromBody] TransactionPayDTO transactionPay)
        {
            try
            {
                var currentUser = await _userManager.GetUserAsync(User);
                if (currentUser != null)
                {
                    currentUser.TransactionPays.Add(new TransactionPay
                    {
                        PaymentMethod = transactionPay.PaymentMethod,
                        AmountMoney = transactionPay.AmountMoney,
                        TransactionDate = transactionPay.TransactionDate,
                    });
                    await _context.SaveChangesAsync();
                    return Ok(new { StatusMessage = $"Đã thêm phương thức thanh toán {transactionPay.PaymentMethod}" });
                }
                else
                {
                    return BadRequest(new { StatusMessage = "Người dùng không tồn tại." });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error processing transaction", error = ex.Message });
            }
        }

        // PUT api/<TransactionPayAPI>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TransactionPayAPI>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
