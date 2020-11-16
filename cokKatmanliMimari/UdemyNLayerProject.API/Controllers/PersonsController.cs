using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UdemyNLayerProject.Core.models;
using UdemyNLayerProject.Core.Services;

namespace UdemyNLayerProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {

        //Service katmanının yapısı sayesinde person objesi için ayrıca repository oruşturmama gerek kalmadı mükemmel
        private readonly IService<Person> _personService;

        public PersonsController(IService<Person> personService){
            _personService = personService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll(){
            var persons = await _personService.GetAllAsync();
            return Ok(persons);
        }

        [HttpPost]
        public async Task<IActionResult> Save(Person person){
            var newPerson = await _personService.AddAsync(person);
            return Ok(newPerson);
        }
        
    }
}