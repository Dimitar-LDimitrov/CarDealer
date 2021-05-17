namespace CarDealer.App.Controllers
{
    using CarDealer.App.Infrastructure.Extentions;
    using CarDealer.App.Models.Customers;
    using CarDealer.Services;
    using Microsoft.AspNetCore.Mvc;
    using System;

    [Route("customers")]
    public class CustomersController : Controller
    {
        private readonly ICustomerService customers;

        public CustomersController(ICustomerService customers)
        {
            this.customers = customers;
        }

        [Route(nameof(Edit) + "/{id}")]
        public IActionResult Edit(int id)
        {
            var customer = this.customers.ById(id);

            if (customer == null)
            {
                return NotFound();
            }

            return View(new CustomerFormModel
            {
                Id = id,
                Name = customer.Name,
                Birthdate = customer.Birthdate,
                IsYoungDriver = customer.IsYoungDriver
            });
        }

        [Route("create")]
        public IActionResult Create() => View();

        [HttpPost]
        [Route(nameof(Edit) + "/{id}")]
        public IActionResult Edit(int id, CustomerFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            bool customerExists = this.customers.Exists(id);

            if (!customerExists)
            {
                return NotFound();
            }

            this.customers.Edit(
                id,
                model.Name,
                model.Birthdate,
                model.IsYoungDriver); 

            return RedirectToAction(nameof(All), new { order = OrderType.Ascending.ToString() });
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create(CustomerFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            this.customers.Create(model.Name, model.Birthdate, model.IsYoungDriver);

            return RedirectToAction(nameof(All), new { order = OrderType.Ascending.ToString() });
        }

        [Route("all/{order}")]
        public IActionResult All(string order)
        {
            var orderType = order.ToLower() == "ascending"
                ? OrderType.Ascending
                : OrderType.Descending;

            var customers = this.customers.OrderedCustomers(orderType);

            return View(new AllCustomersModel
            {
                Customers = customers,
                OrderType = orderType
            });
        }

        [Route("{id}")]
        public IActionResult TotalSales(int id)
            => this.ViewOrNotFound(this.customers.TotalSalesById(id));
    }
}
