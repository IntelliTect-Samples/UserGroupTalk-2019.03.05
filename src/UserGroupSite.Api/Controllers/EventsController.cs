using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using UserGroupSite.Api.ViewModels;
using UserGroupSite.Domain.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserGroupSite.Api.Controllers
{
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        private ApplicationDbContext DbContext { get; }
        private IMapper Mapper { get; }
        public EventsController(ApplicationDbContext dbContext, IMapper mapper)
        {
            DbContext = dbContext;
            Mapper = mapper;
        }
        // GET: api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var events = await DbContext.Events.ToListAsync();
            return Ok(events.Select(e => Mapper.Map<EventViewModel>(e)));
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var fetchedEvent = await DbContext.Events
                .Include(e => e.Location)
                .Include(e => e.EventSpeakers)
                .ThenInclude(es => es.Speaker)
                .SingleOrDefaultAsync(e => e.Id == id);

            if (fetchedEvent == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<EventViewModel>(fetchedEvent));
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]EventInputViewModel viewModel)
        {
            var eventToAdd = Mapper.Map<Event>(viewModel);

            DbContext.Events.Add(eventToAdd);
            await DbContext.SaveChangesAsync();

            return Ok(Mapper.Map<EventViewModel>(eventToAdd));
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]string value)
        {
            return Ok();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }
    }
}
