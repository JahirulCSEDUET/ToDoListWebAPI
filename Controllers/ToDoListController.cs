using Microsoft.AspNetCore.Mvc;
using ToDoListWebAPI.DTO;
namespace ToDoListWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToDoListController : ControllerBase
    {
        private static List<ToDoList> ToDoItems = new()
        {
            new ToDoList { Id = 1, Title = "Buy groceries", Description = "Milk, Bread, Eggs", IsCompleted = false, CreatedAt = DateTime.Now, DueDate = DateTime.Now.AddDays(1), Priority = 2 },
            new ToDoList { Id = 2, Title = "Finish project", Description = "Complete the ASP.NET Core project", IsCompleted = false, CreatedAt = DateTime.Now, DueDate = DateTime.Now.AddDays(3), Priority = 1 },
            new ToDoList { Id = 3, Title = "Call mom", Description = "Check in with family", IsCompleted = true, CreatedAt = DateTime.Now.AddDays(-1), DueDate = null, Priority = 3 },
            new ToDoList { Id = 4, Title = "Workout", Description = "Go for a run", IsCompleted = false, CreatedAt = DateTime.Now, DueDate = DateTime.Now.AddDays(2), Priority = 2 }
        };
        [HttpGet]
        public ActionResult<List<ToDoList>> RetrievingAll()
        {
            return ToDoItems;
        }
        [HttpGet("{id}")]
        public ActionResult<ToDoList> RetrievingById(int id) {             
            var item = ToDoItems.Find(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }
        [HttpPost]
        public ActionResult Adding(ToDoList toDoList)
        {

            toDoList.Id = ToDoItems.Max(s => s.Id) + 1;
            ToDoItems.Add(toDoList);
            return Ok("New To-Do item successfully added");
        }
        [HttpPut("{id}")]
        public ActionResult Updating(int id, ToDoList toDoList)
        {
            var item = ToDoItems.Find(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            item.Title = toDoList.Title;
            item.Description = toDoList.Description;
            item.IsCompleted = toDoList.IsCompleted;
            item.DueDate = toDoList.DueDate;
            item.Priority = toDoList.Priority;
            return Ok("To-Do item update successfully.");
        }
        [HttpDelete("{id}")]
        public ActionResult Deleting(int id)
        {
            var item = ToDoItems.Find(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            ToDoItems.Remove(item);
            return Ok("To-Do item successfully deleted.");
        }

    }
}
