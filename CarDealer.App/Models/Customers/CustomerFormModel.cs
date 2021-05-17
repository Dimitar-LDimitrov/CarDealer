namespace CarDealer.App.Models.Customers
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class CustomerFormModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        public DateTime Birthdate { get; set; }

        [Display(Name = "Young Driver")]
        public bool IsYoungDriver { get; set; }
    }
}
