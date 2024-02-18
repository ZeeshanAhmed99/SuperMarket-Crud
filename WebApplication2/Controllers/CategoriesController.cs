using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            var categories = CategoriesRepository.GetCategories();
            return View(categories);
        }
        public IActionResult Edit(int? id)
        {
           // var category = new Category {Id = id.HasValue?id.Value:0};
            //if (id.HasValue)
            //    return new ContentResult
            //    {
            //        Content = id.ToString(),
            //    };
            //else
            //    return new ContentResult
            //    {
            //        Content = "null content",
            //    };
            var category = CategoriesRepository.GetCategoryById(id.HasValue?id.Value : 0);
            return View(category);
        }
        [HttpPost]
		public IActionResult Edit(Category category)
		{
            if (ModelState.IsValid)
            {
                CategoriesRepository.UpdateCategory(category.Id, category);
				return RedirectToAction(nameof(Index));
			}
            return View(category);
		}
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add([FromForm] Category category) 
        { 
           if(ModelState.IsValid)
            {
                CategoriesRepository.AddCategory(category);
                return RedirectToAction(nameof(Index));
            }
           return View(category);
        }
        public IActionResult Delete(int id)
        {
            CategoriesRepository.DeleteCategory(id);
            return RedirectToAction(nameof(Index));
        }
	}
}
