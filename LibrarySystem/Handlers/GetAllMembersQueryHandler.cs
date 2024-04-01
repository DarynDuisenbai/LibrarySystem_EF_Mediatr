using LibrarySystem.Models;
using LibrarySystem.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Handlers
{
    public class GetAllMembersQueryHandler : IRequestHandler<GetAllMembersQuery, IEnumerable<Member>>
    {
        private readonly LibraryDbContext _context;

        public GetAllMembersQueryHandler(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Member>> Handle(GetAllMembersQuery request, CancellationToken cancellationToken)
        {
            // Получаем всех участников из базы данных
            return await _context.Members.ToListAsync();
        }
    }
}
