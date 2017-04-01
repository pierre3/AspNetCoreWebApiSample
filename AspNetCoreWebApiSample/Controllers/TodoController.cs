using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreWebApiSample.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspNetCoreWebApiSample.Controllers
{
    [Route("api/[controller]")]
    public class TodoController : Controller
    {
        ITodoRepository _repository;
        public TodoController(ITodoRepository repository)
        {
            _repository = repository;
        }

        // GET: api/todo
        [HttpGet]
        public IEnumerable<TodoItem> GetAll()
        {
            return _repository.GetAll();
        }

        // GET api/todo/5
        [HttpGet("{id}",Name ="GetTodo")]
        public IActionResult GetById(long id)
        {
            var item = _repository.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        //POST api/todo
        [HttpPost]
        public IActionResult Create([FromBody] TodoItem item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            _repository.Add(item);
            return CreatedAtRoute("GetTodo", new { Id = item.Key }, item);
        }

        [HttpPut("id")]
        public IActionResult Update(long id,[FromBody]TodoItem item)
        {
            if(item==null || item.Key != id)
            {
                return BadRequest();
            }
            var todo = _repository.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            todo.Name = item.Name;
            todo.IsComplete = item.IsComplete;
            _repository.Update(todo);
            return new NoContentResult();
        }
    }
}
