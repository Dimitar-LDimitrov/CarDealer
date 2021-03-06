namespace CarDealer.Services
{
    using CarDealer.Services.Models.Parts;
    using System.Collections.Generic;

    public interface IPartService
    {
        IEnumerable<PartListingModel> AllListings(int page = 1, int pageSize = 10);

        IEnumerable<PartBasicModel> All();

        void Create(string name, int quantity, double price, int supplierId);

        PartEditModel ById(int id);

        void Edit(int id, double price, int quantity);

        void Delete(int id);

        bool Exists(int id);

        int Total();
    }
}
