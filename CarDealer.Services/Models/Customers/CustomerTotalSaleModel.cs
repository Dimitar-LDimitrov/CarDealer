namespace CarDealer.Services.Models.Customers
{
    using Models.Sales;
    using System.Collections.Generic;
    using System.Linq;

    public class CustomerTotalSaleModel
    {
        public string Name { get; set; }

        public bool IsYoungDriver { get; set; }

        public IEnumerable<SaleModel> BoughtCars { get; set; }

        public int TotalBoughtCars => this.BoughtCars.Count();

        public double TotalMoneySpent
        {
            get
            {
                return this.BoughtCars.Sum(c => c.Price * (1 - c.Discount))
                    * (this.IsYoungDriver ? 0.95 : 1);
            }
        }
    }
}
