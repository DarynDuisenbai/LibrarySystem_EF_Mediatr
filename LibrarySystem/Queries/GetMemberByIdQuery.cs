using LibrarySystem.Models;
using MediatR;

namespace LibrarySystem.Queries
{
    public class GetMemberByIdQuery : IRequest<Member>
    {
        public int MemberId { get; }

        public GetMemberByIdQuery(int memberId)
        {
            MemberId = memberId;
        }
    }
}
