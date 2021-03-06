﻿namespace ElisStore.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using ElisStore.Common;
    using ElisStore.Services.Data;
    using ElisStore.Web.ViewModels.Categories;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public IActionResult Index(int id)
        {
            var viewModel = this.categoryService.GetById<CategoryViewModel>(id);

            if (viewModel == null)
            {
                return this.RedirectToAction(nameof(this.All));
            }

            return this.View(viewModel);
        }

        public IActionResult All()
        {
            var categories = new ListCategoryViewModel() { Categories = this.categoryService.GetAll<CategoryViewModel>().ToList() };

            return this.View(categories);
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public IActionResult Create()
        {
            return this.View();
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        [HttpPost]
        public async Task<IActionResult> Create(CategoryInputModel model)
        {

            var exist = this.categoryService.GetByName<CategoryViewModel>(model.Name);

            if (exist != null)
            {
                this.ModelState.AddModelError("Name", "Вече съществува такава категория.");
                return this.View(model);
            }

            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var category = await this.categoryService.Create<CategoryViewModel>(model.Name, model.Name);

            return this.RedirectToAction(nameof(this.Index), new { name = category.Name });
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public IActionResult Edit()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public IActionResult Edit(CategoryInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            return this.View();
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public IActionResult Delete()
        {
            return this.View();
        }
    }
}
