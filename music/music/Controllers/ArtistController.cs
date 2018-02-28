using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using music.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace music.Controllers
{
    [Route("api/Artist")]
    public class ArtistController : Controller
    {
        private readonly MusicContext _context;

        public ArtistController(MusicContext context)
        {
            _context = context;

            if (_context.ArtistObjects.Count() == 0)
            {
                // DON"T JUDGE ME
                _context.ArtistObjects.Add(new Artist
                {
                    Name = "ArtistName",
                    Albums = new List<Album>() {
                        new Album {
                            Name = "AlbumName",
                            YearReleased = 1992,
                            Songs = new List<Song>() {
                                new Song {
                                    Track = 0,
                                    Name = "SongName",
                                    Created = DateTime.Now,
                                    LastModified = DateTime.Now } },
                            Created = DateTime.Now,
                            LastModified = DateTime.Now } },
                    Created = DateTime.Now,
                    LastModified = DateTime.Now
                } ) ;

                _context.SaveChanges();
            }
        }
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Artist> Get()
        {
            return _context.ArtistObjects.ToList();
        }

        // GET api/<controller>/5
        [HttpGet("{id}", Name = "GetArtistById")]
        public IActionResult Get(long id)
        {
            var item = _context.ArtistObjects.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]Artist value)
        {
            if (value == null)
            {
                return BadRequest();
            }

            _context.ArtistObjects.Add(value);
            _context.SaveChanges();

            return CreatedAtRoute("GetById", new { id = value.Id }, value);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody]Artist value)
        {
            if (value == null || value.Id != id)
            {
                return BadRequest();
            }

            var baseObj = _context.ArtistObjects.FirstOrDefault(t => t.Id == id);
            if (baseObj == null)
            {
                return NotFound();
            }

            baseObj.LastModified = DateTime.Now;

            _context.ArtistObjects.Update(baseObj);
            _context.SaveChanges();
            return new NoContentResult();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var baseObj = _context.ArtistObjects.FirstOrDefault(t => t.Id == id);
            if (baseObj == null)
            {
                return NotFound();
            }

            _context.ArtistObjects.Remove(baseObj);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}
