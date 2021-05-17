namespace CarDealer.Services.Implementations
{
    using CarDealer.Data;
    using CarDealer.Services.Models.Cars;
    using CarDealer.Services.Models.Sales;
    using System.Collections.Generic;
    using System.Linq;

    public class SaleService : ISaleService
    {
        private readonly CarDealerDbContext db;

        public SaleService(CarDealerDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<SaleListModel> All()
             => this.db.Sales
                .OrderByDescending(s => s.Id)
                .Select(s => new SaleListModel
                {
                    Id = s.Id,
                    CustomerName = s.Customer.Name,
                    Discount = s.Discount,
                    IsYoungDriver = s.Customer.IsYoungDriver,
                    Price = s.Car.Parts.Sum(p => p.Part.Price)
                })
                .ToList();

        public SalesDetailModel Details(int id)
        {
            return this.db.Sales
                .Where(s => s.Id == id)
                .Select(s => new SalesDetailModel
                {   
                    Id = s.Id,
                    CustomerName = s.Customer.Name,
                    Discount = s.Discount,
                    IsYoungDriver = s.Customer.IsYoungDriver,
                    Price = s.Car.Parts.Sum(p => p.Part.Price),
                    Car = new CarModel
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance
                    }
                })
                .FirstOrDefault();
        }
    }
}
