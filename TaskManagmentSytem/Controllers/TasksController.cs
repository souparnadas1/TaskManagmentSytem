using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TaskCore.Entity;
using TaskInfastructure.Services;

namespace TaskManagmentSytem.Controllers
{
    public class TasksController : Controller
    {
        private readonly TaskService _service;
        private readonly CategoryService _cservice;
        public TasksController(TaskService service, CategoryService cservice)
        {
            _service = service;
            _cservice = cservice;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = new SelectList(await _cservice.getAllAsync(), "Id", "Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Tasks task)
        {
            try
            {
                await _service.AddTasks(task);
                TempData["Message"] = "Task created successfully";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Categories = await _cservice.getAllAsync();
                TempData["Message"] = ex.Message;
                return RedirectToAction("Create");
            }
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _service.getAllAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var category = await _service.GetByIdAsync(id);
            return View(category);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Tasks task, int id)
        {
            try
            {
                await _service.UpdateAsync(task, id);
                TempData["Message"] = "Task Updated successfully";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
                return RedirectToAction("Edit", new { id = id });
            }
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _service.DeleteAsync(id);
                TempData["Message"] = "Task Deleted successfully";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
                return RedirectToAction("Index");
            }
        }
    }
}
