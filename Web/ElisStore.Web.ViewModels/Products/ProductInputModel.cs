namespace ElisStore.Web.ViewModels.Products
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ElisStore.Common;
    using ElisStore.Data.Models;
    using ElisStore.Services.Mapping;
    using Microsoft.AspNetCore.Http;

    public class ProductInputModel : IMapTo<Product>
    {
        [Required(ErrorMessage = GlobalConstants.RequiredField)]
        [Display(Name = "Име")]
        public string Name { get; set; }

        [Required(ErrorMessage = GlobalConstants.RequiredField)]
        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Display(Name = "Снимка")]
        public IFormFile Image { get; set; }

        [Required(ErrorMessage = GlobalConstants.RequiredField)]
        [Display(Name = "Цена")]
        public double Price { get; set; }

        [Required(ErrorMessage = GlobalConstants.RequiredField)]
        [Display(Name = "Тегло")]
        public double Weight { get; set; }

        [Required(ErrorMessage = GlobalConstants.RequiredField)]
        [Range(1, int.MaxValue)]
        [Display(Name = "Категория")]
        public int CategoryId { get; set; }

        public IEnumerable<CategoryDropDownViewModel> Categories { get; set; }
    }
}
