using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using music.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace music.Controllers
{
    [Route("api/Song")]
    public class SongController : Controller
    {
        private readonly MusicContext _context;

        public SongController(MusicContext context)
        {
            _context = context;

            if (_context.SongObjects.Count() == 0)
            {
                _context.SongObjects.Add(new Song { Track = 0, Name = "SongName", Created = DateTime.Now, LastModified = DateTime.Now });
                _context.SaveChanges();
            }
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Song> Get()
        {
            return _context.SongObjects.ToList();
        }

        // GET api/<controller>/5
        [HttpGet("{id}", Name = "GetSongById")]
        public IActionResult Get(long id)
        {
            var item = _context.SongObjects.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]Song value)
        {
            if (value == null)
            {
                return BadRequest();
            }

            _context.SongObjects.Add(value);
            _context.SaveChanges();

            return CreatedAtRoute("GetById", new { id = value.Id }, value);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody]Song value)
        {
            if (value == null || value.Id != id)
            {
                return BadRequest();
            }

            var baseObj = _context.SongObjects.FirstOrDefault(t => t.Id == id);
            if (baseObj == null)
            {
                return NotFound();
            }

            baseObj.LastModified = DateTime.Now;

            _context.SongObjects.Update(baseObj);
            _context.SaveChanges();
            return new NoContentResult();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var baseObj = _context.SongObjects.FirstOrDefault(t => t.Id == id);
            if (baseObj == null)
            {
                return NotFound();
            }

            _context.SongObjects.Remove(baseObj);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}
