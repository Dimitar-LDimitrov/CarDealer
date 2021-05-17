namespace CarDealer.Domain
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Supplier
    {
        public Supplier()
        {
            this.Parts = new HashSet<Part>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public bool IsImporter { get; set; }

        public virtual ICollection<Part> Parts { get; set; }
    }
}
