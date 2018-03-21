using System.Linq;
using Fisher.Bookstore.Api.Data;
using Fisher.Bookstore.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fisher.Bookstore.Api.Controllers
{
    [Route("api/[controller]")]
    public class AuthorsController : Controller
    {
        private readonly BookstoreContext db;

        public AuthorsController(BookstoreContext db) 
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(db.Authors);
        }

        [HttpGet("{id}", Name="GetAuthor")]
        public IActionResult GetById(int id)
        {
            var author = db.Authors.Find(id);

            if (author == null)
            {
                return NotFound();
            }
            
            return Ok(author);
        }

        [HttpPost]
        public IActionResult Post(Author author)
        {
            if(author == null)
            {
                return BadRequest();
            }

            db.Authors.Add(author);
            db.SaveChanges();

            return CreatedAtRoute("GetAuthor", new { id = author.Id}, author);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Author newAuthor)
        {
            if (newAuthor == null || newAuthor.Id != id)
            {
                return BadRequest();
            }
            var currentAuthor = this.db.Authors.FirstOrDefault(x => x.Id == id);

            if (currentAuthor == null)
            {
                return NotFound();
            }

            currentAuthor.Name = newAuthor.Name;
            currentAuthor.Bio = newAuthor.Bio;

            this.db.Authors.Update(currentAuthor);
            this.db.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var author = this.db.Authors.FirstOrDefault(x => x.Id == id);

            if (author == null)
            {
                return NotFound();
            }

            db.Authors.Remove(author);
            db.SaveChanges();
            return NoContent();
        }
    }
}