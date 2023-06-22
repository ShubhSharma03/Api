using System.Collections.Generic;
using System.Linq;
using Api2.models;
using Microsoft.AspNetCore.Mvc;


namespace YourProjectName.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private static List<TodoItem> _todoItems = new List<TodoItem>();

        [Route("GetAll")]
        [HttpGet]
        public ActionResult<IEnumerable<TodoItem>> GetAllItems()
        {
            return _todoItems;
        }

        [Route("GetItemById")]
        [HttpGet("{id}")]
        public ActionResult<TodoItem> GetItemById(int id)
        {
            var item = _todoItems.FirstOrDefault(i => i.Id == id);
            if (item == null)
                return NotFound();

            return item;
        }

        [Route("Create")]
        [HttpPost]
        public ActionResult<TodoItem> CreateItem(TodoItem item)
        {
            item.Id = _todoItems.Count + 1;
            _todoItems.Add(item);

            return CreatedAtAction(nameof(GetItemById), new { id = item.Id }, item);
        }

        [Route("UpdateItem/{id}")]
        //[HttpPut("{id}")]
        [HttpPut]
        public IActionResult UpdateItem(int id, TodoItem item)
        {
            var existingItem = _todoItems.FirstOrDefault(i => i.Id == id);
            if (existingItem == null)
                return NotFound();

            existingItem.Title = item.Title;
            existingItem.IsCompleted = item.IsCompleted;

            return NoContent();
        }

        [Route("Delete/{id}")]
        //[HttpDelete("{id}")]
        [HttpDelete]
        public IActionResult DeleteItem(int id)
        {
            var existingItem = _todoItems.FirstOrDefault(i => i.Id == id);
            if (existingItem == null)
                return NotFound();

            _todoItems.Remove(existingItem);

            return NoContent();
        }
    }
}

