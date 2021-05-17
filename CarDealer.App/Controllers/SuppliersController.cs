namespace CarDealer.App.Controllers
{
    using CarDealer.App.Models.Suppliers;
    using CarDealer.Services;
    using Microsoft.AspNetCore.Mvc;

    public class SuppliersController : Controller
    {
        private readonly ISupplierService suppliers;

        public SuppliersController(ISupplierService suppliers)
        {
            this.suppliers = suppliers;
        }

        //[Route("suppliers/{isImporter}")]
        //public IActionResult All(bool isImporter)
        //{
        //    var suppliers = this.suppliers.All(isImporter);

        //    return View(suppliers);
        //}

        public IActionResult Local()
        {
            return View("Suppliers", this.GetSupplierModel(false));
        }
        
        public IActionResult Importers()
        {
            return View("Suppliers", this.GetSupplierModel(true));
        }

        private SuppliersModel GetSupplierModel(bool importers)
        {
            var type = importers ? "Importer" : "Local";

            var suppliers = this.suppliers.AllListing(importers);

            return new SuppliersModel
            {
                Type = type,
                Suppliers = suppliers
            };
        }
    }
}
