namespace ElisStore.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ElisStore.Data.Common.Models;

    public class Category : BaseDeletableModel<int>
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}