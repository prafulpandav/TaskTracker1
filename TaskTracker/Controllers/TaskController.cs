using Microsoft.AspNetCore.Mvc;
using TaskTracker.Models;
using System.Collections.Generic;

namespace TaskTracker.Controllers
{
    public class TaskController : Controller
    {
        // Fake in-memory data (portfolio demo ke liye DB nahi use kar rahe)
        private static List<TaskItem> tasks = new List<TaskItem>();

        // GET: /Task/
        public IActionResult Index()
        {
            return View(tasks);
        }

        // POST: /Task/Add
        [HttpPost]
        public IActionResult Add(string title)
        {
            if (!string.IsNullOrWhiteSpace(title))
            {
                tasks.Add(new TaskItem
                {
                    Id = tasks.Count + 1,
                    Title = title,
                    IsCompleted = false
                });
            }
            return RedirectToAction("Index");
        }

        // GET: /Task/Complete/1
        public IActionResult Complete(int id)
        {
            var task = tasks.Find(t => t.Id == id);
            if (task != null)
                task.IsCompleted = true;

            return RedirectToAction("Index");
        }

        // GET: /Task/Delete/1
        public IActionResult Delete(int id)
        {
            var task = tasks.Find(t => t.Id == id);
            if (task != null)
                tasks.Remove(task);

            return RedirectToAction("Index");
        }
    }
}
