namespace CarDealer.App.Controllers
{
    using CarDealer.App.Models.Cars;
    using CarDealer.Services;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Collections.Generic;

    [Route("cars/")]
    public class CarsController : Controller
    {
        private readonly ICarService cars;
        private readonly IPartService parts;

        public CarsController(
            ICarService service,
            IPartService parts)
        {
            this.cars = service;
            this.parts = parts;
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

        [Route(nameof(Create))]
        public IActionResult Create()
        {
            return View(new CarFormModel
            {
                AllParts = this.GetPartsSelectedItems()
            });
        }

        [HttpPost]
        [Route(nameof(Create))]
        public IActionResult Create(CarFormModel carModel)
        {
            if (!ModelState.IsValid)
            {
                carModel.AllParts = this.GetPartsSelectedItems();
                return View(carModel);
            }

            this.cars.Create(
                carModel.Make,
                carModel.Model,
                carModel.TravelledDistance,
                carModel.SelectedParts);

            return RedirectToAction(nameof(Parts));
        }

        private IEnumerable<SelectListItem> GetPartsSelectedItems()
        {
            return this.parts
                .All()
                .Select(s => new SelectListItem
                {
                    Text = s.Name,
                    Value = s.Id.ToString()
                });
        }
    }
}
