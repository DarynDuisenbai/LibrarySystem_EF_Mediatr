using LibrarySystem.Commands;
using LibrarySystem.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace LibrarySystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoansController : ControllerBase
    {
        //private LibraryDbContext _context;

        private readonly IMediator _mediator;

        public LoansController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost("Loan")]
        public async Task<IActionResult> LoanItem(int itemId, int memberId)
        {
            var command = new LoanBookCommand(itemId, memberId);
            var result = await _mediator.Send(command);
            return Ok(result);
        }


        [HttpPost("Return")]
        public async Task<IActionResult> ReturnItem(int itemId)
        {
            var command = new ReturnBookCommand(itemId);
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
