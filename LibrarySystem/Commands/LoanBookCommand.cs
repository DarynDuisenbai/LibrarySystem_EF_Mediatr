using LibrarySystem.Models;
using MediatR;

namespace LibrarySystem.Commands
{
    public class LoanBookCommand : IRequest<Loan>
    {
        public int ItemId { get; set; }
        public int MemberId { get; set; }

        public LoanBookCommand(int itemId, int memberId)
        {
            ItemId = itemId;
            MemberId = memberId;
        }
    }
}
