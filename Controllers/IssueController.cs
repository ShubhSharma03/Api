using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using trackingapi.Data;
using trackingapi.Model;

namespace trackingapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssueController : ControllerBase
    {
        private readonly IssueDbContext? _context;
        //public class IssuesController : DbContext
        //{
        public IssueController(IssueDbContext context)
        {
            _context = context;
        }
        //}
        [HttpGet]
        public async Task<IEnumerable<Issue>> Get()
        {
            return await _context.Issues.ToListAsync();
            
        }

            private readonly ILogger<IssueController> _logger;
        public IssueController(IssueDbContext? context, ILogger<IssueController> logger) : this(context)
        {
            _logger = logger;
        }


        [HttpGet("id")]
        [ProducesResponseType(typeof(Issue), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByid(int id)
        {
            var issue = await _context.Issues.FindAsync(id);
            return issue == null ? NotFound() : Ok(issue);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(Issue issue)
        {
            await _context.Issues.AddAsync(issue);
            await _context.SaveChangesAsync();

            //result CreatedAtAction(nameof(GetById), New { id = issue.Id}, issue );
            //return Ok();
            return CreatedAtAction("GetByid", new { id = issue }, issue);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, Issue issue) 
        {
            if (id != issue.Id) return BadRequest();

            _context.Entry(issue).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();

        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> Delete(int id)
        {
            var issueToDelete = await _context.Issues.FindAsync(id);
            if (issueToDelete == null) return NotFound();

            _context.Issues.Remove(issueToDelete);
            await _context.SaveChangesAsync();

            return NoContent();
        }


    }
}
