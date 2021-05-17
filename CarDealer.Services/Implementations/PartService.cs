﻿namespace CarDealer.Services.Implementations
{
    using CarDealer.Data;
    using CarDealer.Domain;
    using CarDealer.Services.Models.Parts;
    using System.Collections.Generic;
    using System.Linq;

    public class PartService : IPartService
    {
        private readonly CarDealerDbContext db;

        public PartService(CarDealerDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<PartListingModel> All(int page = 1, int pageSize = 10)
        {
            return this.db.Parts
            .OrderByDescending(p => p.Id)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .Select(p => new PartListingModel
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Quantity = p.Quantity,
                SupplierName = p.Supplier.Name
            })
            .ToList();
        }

        public void Create(string name, int quantity, double price, int supplierId)
        {
            var part = new Part
            {
                Name = name,
                Quantity = quantity > 0 ? quantity : 1,
                Price = price,
                SupplierId = supplierId
            };

            this.db.Parts.Add(part);
            this.db.SaveChanges();
        }

        public int Total() => this.db.Parts.Count();
    }
}
 