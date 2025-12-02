using reminderswebapi1.Models;

namespace reminderswebapi1.Services
{
    public class ToDoService : IToDoService
    {
        private static int _id = 1;

        private List<ToDo> _toDos = new List<ToDo>();

        private ILogger<ToDoService> _logger;

        public ToDoService(ILogger<ToDoService> logger) {
            _logger = logger;
        }

        public List<ToDo> GetToDos() 
        { 
            return _toDos; 
        }

        public ToDo GetToDo(int id)
        {
            var item = _toDos.FirstOrDefault(todo => todo.Id == id);

            // This statement is redundant
            if (item == null) { return null; } 

            return item;
        }

        public ToDo CreateToDo(string title, string description)
        {
            var toDo = new
            {
                Id = _id++,
                Title = title,
                Description = description
            };

            _toDos.Add(todo);
        }

        public ToDo ModifyToDo(int id, string title, string description, bool complete = false)
        {
            var item = _toDos.FirstOrDefault(todo => todo.Id == id);

            if (item == null) { return null; }
            
            item.Title = title;
            item.Description = description;
            item.Complete = complete;

            return item;
        }

        public ToDo MarkDone(int id)
        {
            var item = _toDos.FirstOrDefault(todo => todo.Id == id);

            if (item == null) { return null; }

            item.Complete = true;

            return item;
        }

        public ToDo Delete(int id)
        {
            var item = _toDos.FirstOrDefault(todo => todo.Id == id);

            if (item == null) { return null; }

            _toDos.Remove(item);

            return item;
        }
    }
}
