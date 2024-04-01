using LibrarySystem.Commands;
using LibrarySystem.Models;
using MediatR;

namespace LibrarySystem.Handlers
{
    public class AddBookCommandHandler : IRequestHandler<AddBookCommand, Book>
    {
        private readonly LibraryDbContext _context;

        public AddBookCommandHandler(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task<Book> Handle(AddBookCommand request, CancellationToken cancellationToken)
        {
            _context.Books.Add(request.Book);
            await _context.SaveChangesAsync();
            return request.Book;
        }
    }
}
