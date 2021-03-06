namespace CarDealer.App.Models.Suppliers
{
    using CarDealer.Services.Models.Suppliers;
    using System.Collections.Generic;

    public class SuppliersModel
    {
        public string Type { get; set; }

        public IEnumerable<SupplierListingModel> Suppliers { get; set; }
    }
}
