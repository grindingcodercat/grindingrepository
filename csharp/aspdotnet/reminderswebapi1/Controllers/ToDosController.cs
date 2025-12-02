using Microsoft.AspNetCore.Mvc;
using reminderswebapi1.Models;
using reminderswebapi1.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace reminderswebapi1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDosController : ControllerBase
    {
        private readonly IToDoService _todosService;
        private ILogger<ToDosController> _logger;

        public ToDosController(IToDoService todosService, ILogger<ToDosController> logger)
        {
            _todosService = todosService;
            _logger = logger;
        }


        // GET: api/<ToDosController>
        [HttpGet]
        public IEnumerable<ToDo> Get()
        {
            var items = _todosService.GetToDos();
            return items;
        }

        // GET api/<ToDosController>/5
        [HttpGet("{id}")]
        public ToDo Get(int id)
        {
            var item = _todosService.GetTo(id);

            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        // POST api/<ToDosController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ToDosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ToDosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
