namespace CarDealer.Services.Models.Customers
{
    using System;

    public class CustomerModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Birthdate { get; set; }

        public bool IsYoungDriver { get; set; }
    }
}
