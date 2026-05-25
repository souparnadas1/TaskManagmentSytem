using Microsoft.AspNetCore.Mvc;
using TaskCore.Entity;
using TaskInfastructure.Services;

namespace TaskManagmentSytem.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CategoryService _service;
        public CategoryController(CategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Taskcategory category)
        {
            try
            {
                await _service.AddCategory(category);
                TempData["Message"] = "Category created successfully";
                return RedirectToAction("Index");
            }
            catch(Exception ex) 
            {
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
        public async Task<IActionResult> Edit(Taskcategory category,int id)
        {
            try
            {
                await _service.UpdateAsync(category,id);
                TempData["Message"] = "Category Updated successfully";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
                return RedirectToAction("Create");
            }
        }
    }
}
