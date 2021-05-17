namespace CarDealer.App.Models.Customers
{
    using CarDealer.Services;
    using CarDealer.Services.Models.Customers;
    using System.Collections.Generic;

    public class AllCustomersModel
    {
        public IEnumerable<CustomerModel> Customers { get; set; }

        public OrderType OrderType { get; set; }
    }
}
