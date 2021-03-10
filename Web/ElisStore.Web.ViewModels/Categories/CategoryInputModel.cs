namespace ElisStore.Web.ViewModels.Categories
{
    using System.ComponentModel.DataAnnotations;

    public class CategoryInputModel
    {
        [Required(ErrorMessage = "Името на категорията е задължително!")]
        [MinLength(3)]
        [Display(Name = "Име на категорията")]
        public string Name { get; set; }

        [Display(Name = "Описание на категорията")]
        public string Description { get; set; }
    }
}
