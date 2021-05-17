namespace CarDealer.Services
{
    using CarDealer.Services.Models.Sales;
    using System.Collections.Generic;

    public interface ISaleService
    {
        IEnumerable<SaleListModel> All();

        SalesDetailModel Details(int id);
    }
}
