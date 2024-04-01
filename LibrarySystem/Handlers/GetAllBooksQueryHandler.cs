using LibrarySystem.Models;
using LibrarySystem.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Handlers
{
    public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, IEnumerable<Book>>
    {
        private readonly LibraryDbContext _context;

        public GetAllBooksQueryHandler(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Book>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            return await _context.Books.ToListAsync();
        }
    }
}
