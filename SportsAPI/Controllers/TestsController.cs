using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsAPI.Data;
using SportsAPI.Models;

namespace SportsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestsController : ControllerBase
    {
        private readonly SportsAPIContext _context;

        public TestsController(SportsAPIContext context)
        {
            _context = context;
        }


        //[HttpGet]
        //public ActionResult<Test[]> GetTests()
        //{
        //    Test[] tst = {
        //        new Test(){ Id=1, Type = "Cooper", Date = new DateTime(2019,09,14)},
        //        new Test(){ Id=2, Type = "Stellar", Date = new DateTime(2019,09,12)},
        //        new Test(){ Id=3, Type = "Anne", Date = new DateTime(2019,04,10)},
        //        new Test(){ Id=4, Type = "Matthew", Date = new DateTime(2019,03,19)},
        //        new Test(){ Id=5, Type = "Oscar", Date = new DateTime(2019,04,29)}

        //    };
        //    return Ok(tst);
        //}
        // GET: api/Tests
        [HttpGet]
        public IEnumerable<Test> GetTests()
        {
            return _context.Test;
        }

        //GET: api/Tests/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTest([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var test = await _context.Test.FindAsync(id);

            if (test == null)
            {
                return NotFound();
            }

            return Ok(test);
            //return Ok(new Test() { Id = 5, Type = "Oscar", Date = new DateTime(2019, 04, 29) });
        }

        // PUT: api/Tests/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTest([FromRoute] int id, [FromBody] Test test)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != test.Id)
            {
                return BadRequest();
            }

            _context.Entry(test).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestExists(id))
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

        // POST: api/Tests
        [HttpPost]
        public async Task<IActionResult> PostTest([FromBody] Test test)
        {
            System.Diagnostics.Debug.WriteLine("A");
            System.Diagnostics.Debug.WriteLine(test.Type);
            System.Diagnostics.Debug.WriteLine("Z");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Test.Add(test);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTest", new { id = test.Id }, test);
        }

        [HttpPost("Add")]
        public void PostingTest()
        {
            System.Diagnostics.Debug.WriteLine("ZZZ");
        }
        // DELETE: api/Tests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTest([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var test = await _context.Test.FindAsync(id);
            if (test == null)
            {
                return NotFound();
            }

            _context.Test.Remove(test);
            await _context.SaveChangesAsync();

            return Ok(test);
        }

        private bool TestExists(int id)
        {
            return _context.Test.Any(e => e.Id == id);
        }
    }
}