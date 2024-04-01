using LibrarySystem.Commands;
using LibrarySystem.Models;
using LibrarySystem.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MembersController : ControllerBase
    {
        private readonly LibraryDbContext _context;
        private readonly IMediator _mediator;

        public MembersController(LibraryDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        /*public async Task<ActionResult<IEnumerable<Member>>> GetMembers()
        {
            return await _context.Members.ToListAsync();
        }
        */
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Member>>> GetMembers()
        {
            var query = new GetAllMembersQuery();
            var members = await _mediator.Send(query);
            return Ok(members);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Member>> GetMember(int id)
        {
            var query = new GetMemberByIdQuery(id);
            var member = await _mediator.Send(query);

            if (member == null)
            {
                return NotFound();
            }

            return Ok(member);
        }

        [HttpPost]
        public async Task<ActionResult<Member>> PostMember(Member member)
        {
            var command = new AddMemberCommand(member);
            var addedMember = await _mediator.Send(command);
            return CreatedAtAction("GetMember", new { id = addedMember.Id }, addedMember);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutMember(int id, Member Member)
        {
            if (id != Member.Id)
            {
                return BadRequest();
            }

            _context.Entry(Member).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

       
        [HttpDelete("{id}")]
        public async Task<ActionResult<Member>> DeleteMember(int id)
        {
            var Member = await _context.Members.FindAsync(id);
            if (Member == null)
            {
                return NotFound();
            }

            _context.Members.Remove(Member);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
