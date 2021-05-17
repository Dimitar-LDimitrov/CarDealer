namespace CarDealer.Domain
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Car
    {
        public Car()
        {
            this.Parts = new HashSet<PartCar>();
            this.Sales = new List<Sale>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Make { get; set; }

        [Required]
        [MaxLength(50)]
        public string Model { get; set; }

        [Range(0, long.MaxValue)]
        public long TravelledDistance { get; set; }

        public virtual ICollection<PartCar> Parts { get; set; }

        public ICollection<Sale> Sales { get; set; }
    }
}
