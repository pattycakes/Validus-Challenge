using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using music.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace music.Controllers
{
    [Route("api/BaseModel")]
    public class BaseModelController : Controller
    {
        private readonly MusicContext _context;

        public BaseModelController(MusicContext context)
        {
            _context = context;

            if (_context.BaseObjects.Count() == 0)
            {
                _context.BaseObjects.Add(new BaseModel { Created = DateTime.Now, LastModified = DateTime.Now });
                _context.SaveChanges();
            }
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<BaseModel> Get()
        {
            return _context.BaseObjects.ToList();
        }

        // GET api/<controller>/5
        [HttpGet("{id}", Name = "GetById")]
        public IActionResult Get(long id)
        {
            var item = _context.BaseObjects.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]BaseModel value)
        {
            if (value == null)
            {
                return BadRequest();
            }

            _context.BaseObjects.Add(value);
            _context.SaveChanges();

            return CreatedAtRoute("GetById", new { id = value.Id }, value);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody]BaseModel value)
        {
            if (value == null || value.Id != id)
            {
                return BadRequest();
            }

            var baseObj = _context.BaseObjects.FirstOrDefault(t => t.Id == id);
            if (baseObj == null)
            {
                return NotFound();
            }

            baseObj.LastModified = DateTime.Now;

            _context.BaseObjects.Update(baseObj);
            _context.SaveChanges();
            return new NoContentResult();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var baseObj = _context.BaseObjects.FirstOrDefault(t => t.Id == id);
            if (baseObj == null)
            {
                return NotFound();
            }

            _context.BaseObjects.Remove(baseObj);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}
