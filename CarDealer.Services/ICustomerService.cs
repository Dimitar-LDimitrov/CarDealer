namespace CarDealer.Services
{
    using Models.Customers;
    using System;
    using System.Collections.Generic;

    public interface ICustomerService
    {
        IEnumerable<CustomerModel> OrderedCustomers(OrderType order);

        CustomerTotalSaleModel TotalSalesById(int id);

        void Create(string name, DateTime birthdate, bool isYoungDriver);

        void Edit(int id, string name, DateTime birthdate, bool isYoungDriver);

        CustomerModel ById(int id);

        bool Exists(int id);
    }
}
