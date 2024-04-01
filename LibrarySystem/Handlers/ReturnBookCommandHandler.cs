using LibrarySystem.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Handlers
{
    public class ReturnBookCommandHandler : IRequestHandler<ReturnBookCommand, string>
    {
        private readonly LibraryDbContext _context;

        public ReturnBookCommandHandler(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task<string> Handle(ReturnBookCommand request, CancellationToken cancellationToken)
        {
            var loan = await _context.Loans.FirstOrDefaultAsync(l => l.Item.Id == request.ItemId && !l.IsReturned);

            if (loan == null)
            {
                throw new Exception($"No active loan found for book with ID {request.ItemId}.");
            }

            loan.IsReturned = true;
            loan.ReturnDate = DateTime.Today; // Задаем дату возврата

            await _context.SaveChangesAsync();

            return $"Book returned successfully.";
        }
    }
}
