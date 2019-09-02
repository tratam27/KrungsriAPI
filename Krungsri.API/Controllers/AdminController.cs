using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Krungsri.DataAccess.Context;
using Krungsri.DataAccess.Models;
using Krungsri.Domain.Interfaces;
using Krungsri.API.Models;
using Krungsri.Domain.Models;

namespace Krungsri.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly KrungsriContext _context;
        private readonly IAuthService _authService;
        private readonly IAdminTransactionService _adminTransactionService;

        public AdminController(KrungsriContext context,IAuthService authService, IAdminTransactionService adminTransaction)
        {
            _context = context;
            _authService = authService;
            _adminTransactionService = adminTransaction;
        }
        // GET: api/Admin
        [HttpGet]
        public IEnumerable<AdminAccess> Getadmins()
        {
            return _context.admins;
        }
        [HttpPost("addtranbeforescan")]
        public IActionResult AddTranBeforeScan(AdminTranModel adminTran)
        {
            AdminTranDto adminTranDto = new AdminTranDto
            {
                AdminId = adminTran.AdminId,
                MoneyAmount = adminTran.MoneyAmount,
                Ref = _authService.GenerateSixReference()
            };
            _adminTransactionService.AddTransactionBeforeScan(adminTranDto);
            var expire = _adminTransactionService.GetAdminTransaction(adminTranDto.Ref);
            AdminExpireModel adminExpire = new AdminExpireModel
            {
                AdminId = expire.AdminId,
                ExpiryDate = expire.ExpiryDate,
                MoneyAmount = expire.MoneyAmount,
                Ref = expire.Ref
            };
            return Ok(adminExpire);
        }
        [HttpPost("updateuseridandbalance")]
        public IActionResult UpdateUserIdAndBalance(AdminUpdateUserIdAndBalance userIdAndBalance)
        {
            AdminUpdateUserIdAndBalanceDto userIdAndBalanceDto = new AdminUpdateUserIdAndBalanceDto
            {
                Ref = userIdAndBalance.Ref,
                UserId = Convert.ToInt32(userIdAndBalance.UserId),
                TopUpMoney = Convert.ToDecimal(userIdAndBalance.TopUpMoney)
            };
            _adminTransactionService.UpdateUserId(userIdAndBalanceDto);
            var balacne = _adminTransactionService.UpdateUserBalance(userIdAndBalanceDto);
            return Ok(balacne);
        }
        [HttpPost("admintranmonthly")]
        public IActionResult AdminTransMonthly([FromBody] AdminTranMonthlyModel adminTranMonthly)
        {
            var trans = _adminTransactionService.ShowMonthlyTrans(adminTranMonthly.AdminId);
            return Ok(trans);
        }
        // GET: api/Admin/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAdminAccess([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var adminAccess = await _context.admins.FindAsync(id);

            if (adminAccess == null)
            {
                return NotFound();
            }

            return Ok(adminAccess);
        }

        // PUT: api/Admin/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdminAccess([FromRoute] int id, [FromBody] AdminAccess adminAccess)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != adminAccess.AdminId)
            {
                return BadRequest();
            }

            _context.Entry(adminAccess).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdminAccessExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Admin
        [HttpPost]
        public async Task<IActionResult> PostAdminAccess([FromBody] AdminModel admin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var salt = _authService.GenerateSalt();
            AdminAccess adminAccess = new AdminAccess
            {
                BookBank = _authService.GenerateBookBank(),
                Name = admin.Name,
                UserName = admin.UserName,
                Salt = salt,
                Password = _authService.HashPassword(admin.BeforeHashPassword, salt)
            };
            _context.admins.Add(adminAccess);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdminAccess", new { id = adminAccess.AdminId }, adminAccess);
        }

        // DELETE: api/Admin/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdminAccess([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var adminAccess = await _context.admins.FindAsync(id);
            if (adminAccess == null)
            {
                return NotFound();
            }

            _context.admins.Remove(adminAccess);
            await _context.SaveChangesAsync();

            return Ok(adminAccess);
        }

        private bool AdminAccessExists(int id)
        {
            return _context.admins.Any(e => e.AdminId == id);
        }
    }
}