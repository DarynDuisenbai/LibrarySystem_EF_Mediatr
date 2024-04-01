using LibrarySystem.Models;
using MediatR;

namespace LibrarySystem.Commands
{
    public class AddBookCommand : IRequest<Book>
    {
        public Book Book { get; set; }

        public AddBookCommand(Book book)
        {
            Book = book;
        }
    }
}
