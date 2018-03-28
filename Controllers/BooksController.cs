using System.Linq;
using Fisher.Bookstore.Api.Data;
using Fisher.Bookstore.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fisher.Bookstore.Api.Controllers
{
    [Route("api/[controller]")]
    public class BooksController : Controller
    {
        private readonly BookstoreContext db;

        public BooksController(BookstoreContext db) 
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(db.Books);
        }

        [HttpGet("{id}", Name="GetBook")]
        public IActionResult GetById(int id)
        {
            var book = db.Books.Find(id);

            if (book == null)
            {
                return NotFound();
            }
            
            return Ok(book);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Book book)
        {
            if(book == null)
            {
                return BadRequest();
            }

            db.Books.Add(book);
            db.SaveChanges();

            return CreatedAtRoute("GetBook", new { id = book.Id}, book);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Book item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }
            var book = this.db.Books.FirstOrDefault(x => x.Id == id);

            if (book == null)
            {
                return NotFound();
            }

            book.Author = item.Author;
            book.PublishDate = item.PublishDate;

            this.db.Books.Update(book);
            this.db.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var book = this.db.Books.FirstOrDefault(x => x.Id == id);

            if (book == null)
            {
                return NotFound();
            }

            db.Books.Remove(book);
            db.SaveChanges();
            return NoContent();
        }
    }
}