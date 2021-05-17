namespace CarDealer.Services
{
    using CarDealer.Services.Models.Suppliers;
    using System.Collections.Generic;

    public interface ISupplierService
    {
        public IEnumerable<SupplierListingModel> AllListing(bool isImporter);

        public IEnumerable<SupplierModel> All();    
    }
}
