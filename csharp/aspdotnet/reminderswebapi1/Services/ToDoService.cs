using reminderswebapi1.Models;

namespace reminderswebapi1.Services
{
    public class ToDoService : IToDoService
    {
        private static int _id = 1;

        private List<ToDo> _toDos = new List<ToDo>();

        private ILogger<ToDoService> _logger;

        public ToDoService(ILogger<ToDoService> logger, List<ToDo> _testData = null) {
            _logger = logger;
            if (_testData != null) { _toDos = _testData; }
        }

        /// <summary>
        /// Gets a list of all ToDos
        /// </summary>
        /// <returns>A list of all ToDos</returns>
        public List<ToDo> GetToDos() 
        { 
            return _toDos; 
        }

        /// <summary>
        /// Gets a ToDo item
        /// </summary>
        /// <param name="id">The id of the item</param>
        /// <returns>The Todo Item</returns>
        public ToDo GetToDo(int id)
        {
            var item = _toDos.FirstOrDefault(todo => todo.Id == id);

            // This statement is redundant
            if (item == null) { return null; } 

            return item;
        }

        /// <summary>
        /// Creates a ToDo Item
        /// </summary>
        /// <param name="title">The title of the item</param>
        /// <param name="description">The description of the item</param>
        /// <returns></returns>
        public ToDo CreateToDo(string title, string description)
        {
            var item = new ToDo
            {
                Id = _id++,
                Title = title,
                Description = description
            };

            _toDos.Add(item);

            return item;
        }

        /// <summary>
        /// Modifies a ToDO Item
        /// </summary>
        /// <param name="id">The id of the item</param>
        /// <param name="title">The title of the item</param>
        /// <param name="description">The description of the item</param>
        /// <param name="complete">Whether the item is complete</param>
        /// <returns>The modified item</returns>
        public ToDo? ModifyToDo(int id, string title, string description, bool complete = false)
        {
            var item = _toDos.FirstOrDefault(todo => todo.Id == id);

            if (item == null) { return null; }
            
            item.Title = title;
            item.Description = description;
            item.Complete = complete;

            return item;
        }

        /// <summary>
        /// Marks a ToDo as done
        /// </summary>
        /// <param name="id">The id of the item</param>
        /// <returns>The modified item</returns>
        public ToDo MarkDone(int id)
        {
            var item = _toDos.FirstOrDefault(todo => todo.Id == id);

            if (item == null) { return null; }

            item.Complete = true;

            return item;
        }

        /// <summary>
        /// Deletes a ToDo
        /// </summary>
        /// <param name="id">The id of the item</param>
        /// <returns>The deleted item</returns>
        public ToDo Delete(int id)
        {
            var item = _toDos.FirstOrDefault(todo => todo.Id == id);

            if (item == null) { return null; }

            _toDos.Remove(item);

            return item;
        }
    }
}
