namespace CarDealer.Services.Implementations
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

        public IEnumerable<PartBasicModel> All()
            => this.db
               .Parts
               .OrderBy(p => p.Id)
               .Select(p => new PartBasicModel
               {
                   Id = p.Id,
                   Name = p.Name
               })
               .ToList();

        public IEnumerable<PartListingModel> AllListings(int page = 1, int pageSize = 10)
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

        public PartEditModel ById(int id)
        {
            return this.db.Parts
                .Where(p => p.Id == id)
                .Select(p => new PartEditModel
                {
                    Name = p.Name,
                    Price = p.Price,
                    Quantity = p.Quantity
                })
                .FirstOrDefault();
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

        public void Delete(int id)
        {
            var part = this.db.Parts
                .Where(p => p.Id == id)
                .First();

            if (part == null)
            {
                return;
            }

            this.db.Parts.Remove(part);
            this.db.SaveChanges();
        }

        public void Edit(int id, double price, int quantity)
        {
            var existingPart = this.db.Parts.Find(id);

            if (existingPart == null)
            {
                return;
            }

            existingPart.Quantity = quantity;
            existingPart.Price = price;

            this.db.SaveChanges();
        }

        public bool Exists(int id) => this.db.Parts.Any(p => p.Id == id);

        public int Total() => this.db.Parts.Count();
    }
}
 