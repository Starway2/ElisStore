namespace ElisStore.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ElisStore.Data.Common.Models;

    public class Product : BaseDeletableModel<int>
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public double Price { get; set; }

        public double Weight { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
