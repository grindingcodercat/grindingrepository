using reminderswebapi1.Models;

namespace reminderswebapi1.Services
{
    public interface IToDoService
    {
        List<ToDo> GetToDos();
        ToDo GetToDo(int id);
        ToDo CreateToDo(string title, string description);
        ToDo ModifyToDo(int id, string title, string description, bool complete = false);
        ToDo MarkDone(int id);
        ToDo Delete(int id);
    }
}
