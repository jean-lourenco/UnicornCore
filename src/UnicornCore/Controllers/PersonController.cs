using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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

        // GET api/values
        [HttpGet]
        public IEnumerable<Person> Get()
        {
            return _personService.GetAll();
        }

        // GET api/values/5
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

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            if (person == null || person.Id != 0)
                return BadRequest();

            _personService.Add(person);

            return CreatedAtRoute("GetPerson", new { id = person.Id }, person);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody]Person person)
        {
            if (id == 0 || person.Id == 0 || id != person.Id)
                return BadRequest();

            if (!_personService.Exists(id))
                return NotFound();

            _personService.Update(person);

            return NoContent();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            if (id == 0)
                return BadRequest();

            if (!_personService.Exists(id))
                return NotFound();

            _personService.Remove(id);

            return NoContent();
        }
    }
}