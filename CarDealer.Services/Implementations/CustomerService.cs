namespace CarDealer.Services.Implementations
{
    using Models.Sales;
    using Models.Customers;
    using Data;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using CarDealer.Domain;

    public class CustomerService : ICustomerService
    {
        private readonly CarDealerDbContext db;

        public CustomerService(CarDealerDbContext db)
        {
            this.db = db;
        }

        public CustomerModel ById(int id)
        {
            return this.db
                .Customers
                .Where(c => c.Id == id)
                .Select(c => new CustomerModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Birthdate = c.BirthDate,
                    IsYoungDriver = c.IsYoungDriver
                })
                .FirstOrDefault();
        }

        public void Create(string name, DateTime birthdate, bool isYoungDriver)
        {
            var customer = new Customer
            {
                Name = name,
                BirthDate = birthdate,
                IsYoungDriver = isYoungDriver
            };

            this.db.Add(customer);
            this.db.SaveChanges();
        }

        public bool Exists(int id) => this.db.Customers.Any(c => c.Id == id);

        public void Edit(int id, string name, DateTime birthdate, bool isYoungDriver)
        {
            var existingCustomer = this.db.Customers.Find(id);

            if (existingCustomer == null)
            {
                return;
            }

            existingCustomer.Name = name;
            existingCustomer.BirthDate = birthdate;
            existingCustomer.IsYoungDriver = isYoungDriver;

            this.db.SaveChanges();
        }

        public IEnumerable<CustomerModel> OrderedCustomers(OrderType order)
        {
            var customersQuery = this.db.Customers.AsQueryable();

            switch (order)
            {
                case OrderType.Ascending:
                    customersQuery = customersQuery
                        .OrderBy(c => c.BirthDate)
                        .ThenBy(c => c.IsYoungDriver);
                    break;

                case OrderType.Descending:
                    customersQuery = customersQuery
                        .OrderByDescending(c => c.BirthDate)
                        .ThenBy(c => c.IsYoungDriver);
                    break;

                default:
                    throw new InvalidOperationException($"Invalid order direction: {order}.");
            }

            return customersQuery
                .Select(c => new CustomerModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Birthdate = c.BirthDate,
                    IsYoungDriver = c.IsYoungDriver
                })
                .ToList();
        }

        public CustomerTotalSaleModel TotalSalesById(int id)
        {
            return this.db.Customers
                .Where(c => c.Id == id)
                .Select(c => new CustomerTotalSaleModel
                {
                    Name = c.Name,
                    BoughtCars = c.Sales.Select(s => new SaleModel
                    { 
                        Price = s.Car.Parts.Sum(p => p.Part.Price),
                        Discount = s.Discount
                    })
                })
                .FirstOrDefault();
        }
    }
}
