using LibrarySystem.Commands;
using LibrarySystem.Models;
using MediatR;

namespace LibrarySystem.Handlers
{
    public class AddMemberCommandHandler : IRequestHandler<AddMemberCommand, Member>
    {
        private readonly LibraryDbContext _context;

        public AddMemberCommandHandler(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task<Member> Handle(AddMemberCommand request, CancellationToken cancellationToken)
        {
            _context.Members.Add(request.Member);
            await _context.SaveChangesAsync();
            return request.Member; 
        }
    }
}
