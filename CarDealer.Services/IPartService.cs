namespace CarDealer.Services
{
    using CarDealer.Services.Models.Parts;
    using System.Collections.Generic;

    public interface IPartService
    {
        IEnumerable<PartListingModel> All(int page = 1, int pageSize = 10);

        int Total();
    }
}
