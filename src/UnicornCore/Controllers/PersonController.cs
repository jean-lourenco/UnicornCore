using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnicornCore.Interfaces.Services;
using UnicornCore.Models.DatabaseEntity;

namespace UnicornCore.Controllers
{
    [Route("api/[controller]")]
    public class PersonController : Controller
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public IEnumerable<Person> Get()
        {
            return _personService.GetAll();
        }

        [HttpGet("{id}", Name = "GetPerson")]
        public IActionResult Get(long id)
        {
            if (id == 0)
                return BadRequest();

            var person = _personService.Find(id);

            if (person == null)
                return NotFound();

            return Ok(person);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Person person)
        {
            if (person == null || person.Id != 0)
                return BadRequest();

            await _personService.AddAsync(person);

            return CreatedAtRoute("GetPerson", new { id = person.Id }, person);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody]Person person)
        {
            if (id == 0 || person.Id == 0 || id != person.Id)
                return BadRequest();

            if (!_personService.Exists(id))
                return NotFound();

            await _personService.UpdateAsync(person);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            if (id == 0)
                return BadRequest();

            if (!_personService.Exists(id))
                return NotFound();

            await _personService.RemoveAsync(id);

            return NoContent();
        }
    }
}