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

namespace Krungsri.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MerchantController : ControllerBase
    {
        private readonly KrungsriContext _context;
        private readonly IAuthService _authService;

        public MerchantController(KrungsriContext context, IAuthService authService)
        {
            _context = context;
            _authService = authService;
        }

        // GET: api/Merchant
        [HttpGet]
        public IEnumerable<MerchantAccess> Getmerchants()
        {
            return _context.merchants;
        }

        // GET: api/Merchant/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMerchantAccess([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var merchantAccess = await _context.merchants.FindAsync(id);

            if (merchantAccess == null)
            {
                return NotFound();
            }

            return Ok(merchantAccess);
        }

        // PUT: api/Merchant/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMerchantAccess([FromRoute] int id, [FromBody] MerchantAccess merchantAccess)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != merchantAccess.MerchantId)
            {
                return BadRequest();
            }

            _context.Entry(merchantAccess).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MerchantAccessExists(id))
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

        // POST: api/Merchant
        [HttpPost]
        public async Task<IActionResult> PostMerchantAccess([FromBody] MerchantModel merchant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var salt = _authService.GenerateSalt();
            MerchantAccess merchantAccess = new MerchantAccess
            {
                BookBank = _authService.GenerateBookBank(),
                Name = merchant.Name,
                UserName = merchant.UserName,
                Salt = salt,
                Password = _authService.HashPassword(merchant.BeforeHashPassword, salt)
            };            

            _context.merchants.Add(merchantAccess);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMerchantAccess", new { id = merchantAccess.MerchantId }, merchantAccess);
        }

        // DELETE: api/Merchant/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMerchantAccess([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var merchantAccess = await _context.merchants.FindAsync(id);
            if (merchantAccess == null)
            {
                return NotFound();
            }
            _context.merchants.Remove(merchantAccess);
            await _context.SaveChangesAsync();

            return Ok(merchantAccess);
        }

        private bool MerchantAccessExists(int id)
        {
            return _context.merchants.Any(e => e.MerchantId == id);
        }
    }
}