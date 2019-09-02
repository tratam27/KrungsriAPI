using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Krungsri.DataAccess.Context;
using Krungsri.DataAccess.Models;

namespace Krungsri.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MerchantTransactionController : ControllerBase
    {
        private readonly KrungsriContext _context;

        public MerchantTransactionController(KrungsriContext context)
        {
            _context = context;
        }

        // GET: api/MerchantTransaction
        [HttpGet]
        public IEnumerable<MerchantTransactionAccess> GetmerchantTransactions()
        {
            return _context.merchantTransactions;
        }

        // GET: api/MerchantTransaction/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMerchantTransactionAccess([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var merchantTransactionAccess = await _context.merchantTransactions.FindAsync(id);

            if (merchantTransactionAccess == null)
            {
                return NotFound();
            }

            return Ok(merchantTransactionAccess);
        }

        // PUT: api/MerchantTransaction/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMerchantTransactionAccess([FromRoute] int id, [FromBody] MerchantTransactionAccess merchantTransactionAccess)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != merchantTransactionAccess.Id)
            {
                return BadRequest();
            }

            _context.Entry(merchantTransactionAccess).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MerchantTransactionAccessExists(id))
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

        // POST: api/MerchantTransaction
        [HttpPost]
        public async Task<IActionResult> PostMerchantTransactionAccess([FromBody] MerchantTransactionAccess merchantTransactionAccess)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.merchantTransactions.Add(merchantTransactionAccess);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMerchantTransactionAccess", new { id = merchantTransactionAccess.Id }, merchantTransactionAccess);
        }

        // DELETE: api/MerchantTransaction/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMerchantTransactionAccess([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var merchantTransactionAccess = await _context.merchantTransactions.FindAsync(id);
            if (merchantTransactionAccess == null)
            {
                return NotFound();
            }

            _context.merchantTransactions.Remove(merchantTransactionAccess);
            await _context.SaveChangesAsync();

            return Ok(merchantTransactionAccess);
        }

        private bool MerchantTransactionAccessExists(int id)
        {
            return _context.merchantTransactions.Any(e => e.Id == id);
        }
    }
}