namespace CarDealer.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Customer
    {
        public Customer()
        {
            this.Sales = new HashSet<Sale>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public bool IsYoungDriver { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}
