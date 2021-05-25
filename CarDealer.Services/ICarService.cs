namespace CarDealer.Services
{
    using Models.Cars;
    using System.Collections.Generic;

    public interface ICarService
    {
        IEnumerable<CarModel> ByMake(string make);

        IEnumerable<CarsWithPartsModel> WithParts();

        void Create(string make, string model, long travelledDistance);
    }
}
