using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWebApiSample.Models
{
    public class TodoRepository : ITodoRepository
    {
        private TodoContext _context;

        public TodoRepository(TodoContext todoContext)
        {
            _context = todoContext;
            Add(new TodoItem { Name = "Item1" });
        }

        public void Add(TodoItem item)
        {
            _context.Add(item);
            _context.SaveChanges();
        }

        public TodoItem Find(long key)
        {
            return _context.TodoItems.FirstOrDefault(item => item.Key == key);
        }

        public IEnumerable<TodoItem> GetAll()
        {
            return _context.TodoItems.ToList();
        }

        public void Remove(long key)
        {
            var entity = _context.TodoItems.FirstOrDefault(item => item.Key == key);
            _context.TodoItems.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(TodoItem item)
        {
            _context.Update(item);
            _context.SaveChanges();
        }
    }
}
