using LibrarySystem.Models;
using MediatR;

namespace LibrarySystem.Queries
{
    public class GetAllBooksQuery : IRequest<IEnumerable<Book>>
    {
    }
}
