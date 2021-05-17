namespace CarDealer.Services.Implementations
{
    using CarDealer.Data;
    using System.Linq;
    using System.Collections.Generic;
    using CarDealer.Services.Models.Suppliers;

    public class SupplierService : ISupplierService
    {
        private readonly CarDealerDbContext db;

        public SupplierService(CarDealerDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<SupplierModel> All()
            => this.db
                .Suppliers
                .OrderByDescending(s => s.Id)
                .Select(s => new SupplierModel
                {
                    Id = s.Id,
                    Name = s.Name
                })
                .ToList();

        public IEnumerable<SupplierListingModel> AllListing(bool isImpoter)
         => this.db
                .Suppliers
                .OrderByDescending(s => s.Id)
                .Where(s => s.IsImporter == isImpoter)
                .Select(s => new SupplierListingModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    TotalParts = s.Parts.Count
                })
                .ToList();
    }
}
