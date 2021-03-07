namespace ElisStore.Web.Controllers
{
    using System.Diagnostics;
    using System.Linq;

    using ElisStore.Services.Data;
    using ElisStore.Web.ViewModels;
    using ElisStore.Web.ViewModels.Category;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : Controller
    {
        private readonly ICategoryService categoryService;

        public HomeController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var data = this.categoryService.GetAll<CategoryViewModel>().ToList();
            ListCategoryViewModel categories = new ListCategoryViewModel() { Categories = data };
            return this.View(categories);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
