namespace CarDealer.App.Models.Parts
{
    using CarDealer.Services.Models.Suppliers;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class PartFormModel
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }

        [Range(0, double.MaxValue)]
        public double Price { get; set; }

        [Display(Name = "Supplier")]
        public int SupplierId { get; set; }

        public IEnumerable<SupplierModel> AllSuppliers { get; set; }
    }
}
