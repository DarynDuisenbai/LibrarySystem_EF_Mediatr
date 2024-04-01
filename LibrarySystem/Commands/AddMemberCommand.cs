using LibrarySystem.Models;
using MediatR;

namespace LibrarySystem.Commands
{
    public class AddMemberCommand : IRequest<Member>
    {
        public Member Member { get; set; }

        public AddMemberCommand(Member member)
        {
            Member = member;
        }
    }
}
