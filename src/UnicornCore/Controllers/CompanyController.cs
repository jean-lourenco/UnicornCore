using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnicornCore.Interfaces.Services;
using UnicornCore.Models.DatabaseEntity;

namespace UnicornCore.Controllers
{
    [Route("api/[controller]")]
    public class CompanyController : Controller
    {
        private readonly ICompanyService _companyService;
        private readonly IPersonService _personService;

        public CompanyController(ICompanyService companyService, IPersonService personService)
        {
            _companyService = companyService;
            _personService = personService;
        }

        [HttpGet]
        public IEnumerable<Company> Get()
        {
            return _companyService.GetAll();
        }

        [HttpGet("{id}", Name = "Getcompany")]
        public IActionResult Get(long id)
        {
            if (id == 0)
                return BadRequest();

            var person = _companyService.Find(id);

            if (person == null)
                return NotFound();

            return Ok(person);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Company company)
        {
            if (company == null || company.Id != 0)
                return BadRequest();

            await _companyService.AddAsync(company, true);

            return CreatedAtRoute("Getcompany", new { id = company.Id }, company);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody]Company company)
        {
            if (id == 0 || company.Id == 0 || id != company.Id)
                return BadRequest();

            if (!_companyService.Exists(id))
                return NotFound();

            await _companyService.UpdateAsync(company, true);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            if (id == 0)
                return BadRequest();

            if (!_companyService.Exists(id))
                return NotFound();

            await _companyService.RemoveAsync(id, true);

            return NoContent();
        }

        [HttpGet("retired/{id}")]
        public IActionResult GetRetiredEmployees(long id)
        {
            if (id == 0)
                return BadRequest();

            var company = _companyService.Find(id);

            if (company == null)
                return NotFound();

            return Ok(_companyService.GetRetiredEmployees(company));
        }

        [HttpPatch("employee/{companyId}")]
        public async Task<IActionResult> AddEmployee([FromBody] long id, long companyId)
        {
            if (id == 0 || companyId == 0)
                return BadRequest();

            var person = _personService.Find(id);
            var company = _companyService.Find(companyId);

            if (person == null || company == null)
                return NotFound();

            await _companyService.AddEmployeeAsync(company, person, true);

            return Ok();
        }
    }
}