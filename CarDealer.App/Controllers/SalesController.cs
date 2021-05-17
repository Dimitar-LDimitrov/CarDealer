namespace CarDealer.App.Controllers
{
    using CarDealer.App.Infrastructure.Extentions;
    using CarDealer.Services;
    using Microsoft.AspNetCore.Mvc;

    [Route("sales")]
    public class SalesController : Controller
    {
        private readonly ISaleService service;

        public SalesController(ISaleService service)
        {
            this.service = service;
        }

        public IActionResult All()
        {
            return View(this.service.All());
        }

        [Route("{id}")]
        public IActionResult Details(int id)
        {
            return this.ViewOrNotFound(this.service.Details(id));
        }
    }
}
