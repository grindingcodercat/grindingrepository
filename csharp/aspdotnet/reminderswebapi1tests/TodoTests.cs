using Microsoft.Extensions.Logging;
using Moq;
using reminderswebapi1.Models;
using reminderswebapi1.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace reminderswebapi1tests
{
    public class TodoTests
    {
        [Fact]
        public void ListToDosTest()
        {
            List<ToDo> testData = new List<ToDo>
            {
                new ToDo { Id = 1, Title = "Test1", Description = "Test1" }
            };

            var mockLogger = new Mock<ILogger<ToDoService>>();
            ToDoService service = new ToDoService(mockLogger.Object, testData);
            var result = service.GetToDos();

            Assert.Single(result);
        }
    }
}
