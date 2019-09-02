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
    public class AdminTransactionController : ControllerBase
    {
        private readonly KrungsriContext _context;

        public AdminTransactionController(KrungsriContext context)
        {
            _context = context;
        }

        // GET: api/AdminTransaction
        [HttpGet]
        public IEnumerable<AdminTransactionAccess> GetadminTransactions()
        {
            return _context.adminTransactions;
        }
        // GET: api/AdminTransaction/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAdminTransactionAccess([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var adminTransactionAccess = await _context.adminTransactions.FindAsync(id);

            if (adminTransactionAccess == null)
            {
                return NotFound();
            }

            return Ok(adminTransactionAccess);
        }

        // PUT: api/AdminTransaction/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdminTransactionAccess([FromRoute] int id, [FromBody] AdminTransactionAccess adminTransactionAccess)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != adminTransactionAccess.Id)
            {
                return BadRequest();
            }

            _context.Entry(adminTransactionAccess).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdminTransactionAccessExists(id))
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
        // POST: api/AdminTransaction
        [HttpPost]
        public async Task<IActionResult> PostAdminTransactionAccess([FromBody] AdminTransactionAccess adminTransactionAccess)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.adminTransactions.Add(adminTransactionAccess);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdminTransactionAccess", new { id = adminTransactionAccess.Id }, adminTransactionAccess);
        }
        // DELETE: api/AdminTransaction/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdminTransactionAccess([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var adminTransactionAccess = await _context.adminTransactions.FindAsync(id);
            if (adminTransactionAccess == null)
            {
                return NotFound();
            }

            _context.adminTransactions.Remove(adminTransactionAccess);
            await _context.SaveChangesAsync();

            return Ok(adminTransactionAccess);
        }

        private bool AdminTransactionAccessExists(int id)
        {
            return _context.adminTransactions.Any(e => e.Id == id);
        }
    }
}