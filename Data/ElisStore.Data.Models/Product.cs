namespace ElisStore.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ElisStore.Data.Common.Models;

    public class Product : BaseDeletableModel<int>
    {
        public Product()
        {
            this.Categories = new HashSet<Category>();
        }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public double Price { get; set; }

        public double Weight { get; set; }

        public ICollection<Category> Categories { get; set; }
    }
}
