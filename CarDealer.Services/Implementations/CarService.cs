namespace CarDealer.Services.Implementations
{
    using Models.Cars;
    using CarDealer.Data;
    using System.Collections.Generic;
    using System.Linq;
    using CarDealer.Services.Models;
    using CarDealer.Services.Models.Parts;

    public class CarService : ICarService
    {
        private readonly CarDealerDbContext db;

        public CarService(CarDealerDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<CarModel> ByMake(string make)
        {
            return this.db.Cars
                .Where(c => c.Make.ToLower() == make.ToLower())
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .Select(c => new CarModel
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .ToList();
        }

        public IEnumerable<CarsWithPartsModel> WithParts()
        {
            return this.db.Cars
                .OrderByDescending(c => c.Id)
                .Select(c => new CarsWithPartsModel
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance,
                    Parts = c.Parts.Select(p => new PartModel
                    {
                        Name = p.Part.Name,
                        Price = (double)p.Part.Price
                    })
                })
                .ToList();
        }
    }
}
