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


        /// <summary>
        /// Gets a list of all ToDos
        /// </summary>
        /// <returns>A list of ToDos</returns>
        [HttpGet]
        public ActionResult<IEnumerable<ToDo>> Get()
        {
            var items = _todosService.GetToDos();
            return items;
        }

        /// <summary>
        /// Gets a ToDo item by id
        /// </summary>
        /// <param name="id">The id of the item</param>
        /// <returns>A ToDo Item</returns>
        [HttpGet("{id}")]
        public ActionResult<ToDo> Get(int id)
        {
            var item = _todosService.GetToDo(id);

            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        /// <summary>
        /// Creates a ToDo item
        /// </summary>
        /// <param name="title">The title of the Item</param>
        /// <param name="description">The description of the item</param>
        /// <returns>The created item</returns>
        [HttpPost]
        public ActionResult<ToDo> Post([FromBody] ToDo todo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            ToDo result = _todosService.CreateToDo(todo.Title, todo.Description);
            return result;
        }
        /*
        // PUT api/<ToDosController>/5
        [HttpPut("{id}")]
        public ActionResult<ToDo> Put([FromBody] ToDo todo)
        {
            return null;
        }

        // DELETE api/<ToDosController>/5
        [HttpDelete("{id}")]
        public ActionResult<ToDo> Delete(int id)
        {
            return null;
        }*/
    }
}
