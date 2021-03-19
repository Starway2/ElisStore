namespace ElisStore.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using ElisStore.Common;
    using ElisStore.Services.Data;
    using ElisStore.Web.ViewModels.Categories;
    using ElisStore.Web.ViewModels.Products;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class ProductsController : Controller
    {
        private readonly IProductsService productsService;
        private readonly ICategoryService categoryService;

        public ProductsController(IProductsService productsService, ICategoryService categoryService)
        {
            this.productsService = productsService;
            this.categoryService = categoryService;
        }

        public IActionResult Index(string name)
        {
            var viewModel = this.productsService.GetByName<ProductViewModel>(name);

            if (viewModel == null)
            {
                return this.RedirectToAction("All", "Category");
            }

            return this.View(viewModel);
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public IActionResult Create()
        {
            var categories = this.categoryService.GetAll<CategoryDropDownViewModel>();
            var viewModel = new ProductInputModel() { Categories = categories };

            return this.View(viewModel);
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        [HttpPost]
        public async Task<IActionResult> Create(ProductInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var product = await this.productsService.Create(model);
            return this.View("Index", product);
        }
    }
}
