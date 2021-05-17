namespace CarDealer.Domain
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Part
    {
        public Part()
        {
            this.Cars = new HashSet<PartCar>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }

        [Range(0, double.MaxValue)]
        public double Price { get; set; }

        public virtual ICollection<PartCar> Cars { get; set; }

        public int SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}
