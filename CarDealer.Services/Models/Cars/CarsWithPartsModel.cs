namespace CarDealer.Services.Models.Cars
{
    using CarDealer.Services.Models.Parts;
    using System.Collections.Generic;

    public class CarsWithPartsModel : CarModel
    {
        public IEnumerable<PartModel> Parts { get; set; }
    }
}
