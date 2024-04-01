using LibrarySystem.Commands;
using LibrarySystem.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Handlers
{
    public class LoanBookCommandHandler : IRequestHandler<LoanBookCommand, Loan>
    {
        private readonly LibraryDbContext _context;

        public LoanBookCommandHandler(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task<Loan> Handle(LoanBookCommand request, CancellationToken cancellationToken)
        {
            var item = await _context.Books.FindAsync(request.ItemId);
            var member = await _context.Members.FindAsync(request.MemberId);

            if (item == null)
            {
                throw new Exception($"Book with ID {request.ItemId} not found.");
            }

            if (member == null)
            {
                throw new Exception($"Member with ID {request.MemberId} not found.");
            }

            // Проверяем, есть ли у пользователя несданные книги
            var outstandingLoans = await _context.Loans.AnyAsync(l => l.Member.Id == request.MemberId && !l.IsReturned);
            if (outstandingLoans)
            {
                throw new Exception("Member has outstanding loans.");
            }

            // Создаем новый займ
            var loan = new Loan
            {
                Item = item,
                Member = member,
                //DueDate = DateTimeOffset.UtcNow.ToOffset(TimeSpan.Zero).DateTime.Date.AddDays(14),
                IsReturned = false
            };

            _context.Loans.Add(loan);
            await _context.SaveChangesAsync();

            return loan;
        }
    }
}
