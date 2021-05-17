using CarDealer.Services.Models.Cars;

namespace CarDealer.Services.Models.Sales
{
    public class SalesDetailModel : SaleListModel
    {
        public CarModel Car { get; set; }
    }
}
