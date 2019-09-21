using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsAPI.Data;
using SportsAPI.Models;

namespace SportsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTestMappingsController : ControllerBase
    {
        private readonly SportsAPIContext _context;

        public UserTestMappingsController(SportsAPIContext context)
        {
            _context = context;
        }

        // GET: api/UserTestMappings
        [HttpGet]
        public IEnumerable<UserTestMapping> GetUserTestMapping()
        {
            return _context.UserTestMapping;
        }

        [HttpGet("getAthletesByTestId/{id}")]
        public IEnumerable<UserTestMapping> getAthletesByTestId([FromRoute] int id)
        {
            System.Diagnostics.Debug.WriteLine("Z");
            return _context.UserTestMapping.Where(t => t.TId==id);
        }
        [HttpGet("getPar")]
        public async Task<List<int>> getPar()
        {
            List<int> num = new List<int>();
            foreach (var test in _context.Test.OrderByDescending(x => x.Date))
            {
                var lst =  await _context.UserTestMapping.Where(x => x.TId == test.Id).ToListAsync();
                num.Add(lst.Count);
            }
            return num;
        }
        // GET: api/UserTestMappings/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserTestMapping([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userTestMapping = await _context.UserTestMapping.FindAsync(id);

            if (userTestMapping == null)
            {
                return NotFound();
            }

            return Ok(userTestMapping);
        }

        // PUT: api/UserTestMappings/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserTestMapping([FromRoute] int id, [FromBody] UserTestMapping userTestMapping)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userTestMapping.Id)
            {
                return BadRequest();
            }

            _context.Entry(userTestMapping).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserTestMappingExists(id))
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

        // POST: api/UserTestMappings
        [HttpPost]
        public async Task<IActionResult> PostUserTestMapping([FromBody] UserTestMapping userTestMapping)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.UserTestMapping.Add(userTestMapping);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserTestMapping", new { id = userTestMapping.Id }, userTestMapping);
        }

        // DELETE: api/UserTestMappings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserTestMapping([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userTestMapping = await _context.UserTestMapping.FindAsync(id);
            if (userTestMapping == null)
            {
                return NotFound();
            }

            _context.UserTestMapping.Remove(userTestMapping);
            await _context.SaveChangesAsync();

            return Ok(userTestMapping);
        }

        private bool UserTestMappingExists(int id)
        {
            return _context.UserTestMapping.Any(e => e.Id == id);
        }
    }
}