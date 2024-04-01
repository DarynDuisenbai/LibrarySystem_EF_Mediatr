using LibrarySystem.Models;
using MediatR;

namespace LibrarySystem.Queries
{
    public class GetAllMembersQuery : IRequest<IEnumerable<Member>>
    {
    }
}
