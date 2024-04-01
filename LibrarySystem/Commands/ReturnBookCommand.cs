using MediatR;

namespace LibrarySystem.Commands
{
    public class ReturnBookCommand : IRequest<string>
    {
        public int ItemId { get; set; }

        public ReturnBookCommand(int itemId)
        {
            ItemId = itemId;
        }
    }
}
