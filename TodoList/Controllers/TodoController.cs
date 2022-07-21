using Microsoft.AspNetCore.Mvc;
using TodoList.Models;
using TodoList.Data;
namespace TodoList.Controllers
{
    public class TodoController : Controller
    {
        // Idea
        // connect database => table = Tolist
        private readonly ApplicationDbContext _context;
        //ctor
        public TodoController(ApplicationDbContext context) // public classs ... => public ... 
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var data = _context.TodoTable.OrderBy(f => f.TodoID).ToList();
            return View(data);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Todo td)
        {
            if (ModelState.IsValid)
            {
                var existing = _context.TodoTable.Find(td.TodoID);
                if (existing != null)
                {
                    return BadRequest();
                }

                _context.TodoTable.Add(td);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View();
        }
        //[HttpPut]
        //public ActionResult Done(int id)
        //{
        //    var doneTodo = _context.TodoTable.Find(id);
        //    if (doneTodo == null)
        //    {
        //        return NotFound();
        //    }
        //    _context.TodoTable.Update(doneTodo);
        //    _context.SaveChanges();
        //    return Json(new { Success = true, message = "" });
        //}

        public IActionResult Update(int id)
        {
            var fid = _context.TodoTable.Find(id);
            if (fid == null)
            {
                return NotFound();
            }
            return View(fid);
        }
        [HttpPost]
        public ActionResult Update(Todo td)
        {

            if (ModelState.IsValid)
            {

                _context.TodoTable.Update(td);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var deleteTodo = _context.TodoTable.Find(id);
            if (deleteTodo == null)
            {
                return NotFound();
            }
            _context.TodoTable.Remove(deleteTodo);
            _context.SaveChanges();
            return Json(new { Success = true, message = "" });
        }
    }
}
