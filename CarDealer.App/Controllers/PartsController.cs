namespace CarDealer.App.Controllers
{
    using CarDealer.App.Models.Parts;
    using CarDealer.Services;
    using System;
    using Microsoft.AspNetCore.Mvc;

    public class PartsController : Controller
    {
        private const int PageSize = 25;

        private readonly IPartService parts;

        public PartsController(IPartService parts)
        {
            this.parts = parts;
        }

        public IActionResult Create() => View();

        public IActionResult All(int page = 1)
        {
            return View(new PartPageListingModel
            {
                CurrentPage = page,
                Parts = this.parts.All(page, PageSize),
                TotalPage = (int)Math.Ceiling(this.parts.Total() / (double)PageSize)
            });
        }
    }
}
