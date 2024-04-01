using LibrarySystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Text.Json;
using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using LibrarySystem.Queries;
using LibrarySystem.Commands;

namespace LibrarySystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly LibraryDbContext _context;
        private readonly IMediator _mediator;


        public BooksController(LibraryDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            var query = new GetAllBooksQuery();
            var books = await _mediator.Send(query);
            return Ok(books);

        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

       
        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(Book book)
        {
            /*if (book.PublicationDate == null)
            {
                return BadRequest("PublicationDate is required.");
            }

            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBook", new { id = book.Id }, book);
            */
            var command = new AddBookCommand(book);
            var addedBook = await _mediator.Send(command);
            return CreatedAtAction("GetBook", new { id = addedBook.Id }, addedBook);
        }

       
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, Book book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }

            _context.Entry(book).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Book>> DeleteBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        
    }
}
