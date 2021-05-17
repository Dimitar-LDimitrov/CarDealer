namespace CarDealer.Domain
{
    using System.ComponentModel.DataAnnotations;

    public class Sale
    {
        public int Id { get; set; }

        [Range(0, 100)]
        public double Discount { get; set; }

        public int CarId { get; set; }
        public virtual Car Car { get; set; }
        
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
