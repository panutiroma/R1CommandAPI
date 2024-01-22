using CommandAPI.Data;
using CommandAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CommandAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommandAPIRepo _repository;

        public CommandsController(ICommandAPIRepo repository)
        {
            _repository = repository;
        }

        [HttpGet("get-all")]
        [Authorize]
        public ActionResult<IEnumerable<Command>> GetAllCommands()
        {
            var commandItems = _repository.GetAllCommands();
            return Ok(commandItems);
        }

        [HttpGet("{id}")]
        [Authorize]
        public ActionResult<Command> GetCommandById(int id)
        {
            var commandItem = _repository.GetCommandById(id);

            return commandItem == null ? NotFound() : Ok(commandItem);
        }
    }
}
