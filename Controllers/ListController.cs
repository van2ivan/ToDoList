using Microsoft.AspNetCore.Mvc;
using ToDoList.Data;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class ListController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ListController(ApplicationDbContext db)
        {
            _db = db;

        }
        public IActionResult Index()
        {
            IEnumerable<ListModel> list = _db.ListModel.ToList();
            return View(list);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ListModel obj)
        {
            if (ModelState.IsValid)
            {
                _db.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                NotFound();
            }
            var item = _db.ListModel.Find(id);
            if(item == null)
            {
                NotFound();
            }
            return View(item);
        }
        [HttpPost]
        public IActionResult Edit(ListModel obj)
        {
            if (ModelState.IsValid)
            {
                _db.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                NotFound();
            }
            var item = _db.ListModel.Find(id);
            if (item == null)
            {
                NotFound();
            }
            return View(item);
        }
        [HttpPost]
        public IActionResult Delete(ListModel obj)
        {

            _db.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
            return View(obj);
        }
    }
}



