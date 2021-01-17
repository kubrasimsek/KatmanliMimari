using KatmanliMimari.Core.Entity;
using KatmanliMimari.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KatmanliMimari.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IService<Person> _personService;
        public PersonsController(IService<Person> service)
        {
            _personService = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var person = await _personService.GetAllAsync();
            return Ok(person);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var person = await _personService.GetByIdAsync(id);
            return Ok(person);
        }

        [HttpPost]
        public async Task<IActionResult> Save(Person person)
        {
            var newPerson = await _personService.AddAsync(person);
            return Ok(newPerson);

        }
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {

            var person = _personService.GetByIdAsync(id).Result;
            _personService.Remove(person);
            return NoContent();
        }
    }
}
