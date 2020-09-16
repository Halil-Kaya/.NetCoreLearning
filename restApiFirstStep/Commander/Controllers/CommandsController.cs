using System.Collections.Generic;
using Commander.Data;
using Commander.Models;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{   
    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase
    {

        private readonly ICommandRepository _repo;

        public CommandsController(ICommandRepository repository){
            _repo = repository;
        }

        //GET api/commands
        [HttpGet]
        public ActionResult<IEnumerable<Command>> GetAllCommands(){
            return Ok(_repo.GetAppCommands());
        }

        //GET api/commands/{id}
        [HttpGet("{id}")]
        public ActionResult <Command> GetCommandById(int id){
             return Ok(_repo.GetCommandById(id));
        }



        [HttpPost]
        public ActionResult<Command> CreateCommands(Command command){

            System.Console.WriteLine("HowTo: " +command.HowTo);

            return Ok(command);
        }




        
    }
}