namespace CarDealer.App.Controllers
{
    using CarDealer.App.Models.Cars;
    using CarDealer.Services;
    using Microsoft.AspNetCore.Mvc;

    [Route("cars/")]
    public class CarsController : Controller
    {
        private readonly ICarService cars;

        public CarsController(ICarService service)
        {
            this.cars = service;
        }
        
        [Route("parts/")]
        public IActionResult Parts()
        {
            return View(this.cars.WithParts());
        } 

        [Route("{make}")]
        public IActionResult ByMake(string make)
        {
            var cars = this.cars.ByMake(make);

            return View(new CarsByMakeModel
            {
                Cars = cars,
                Make = make
            });
        }
    }
}
