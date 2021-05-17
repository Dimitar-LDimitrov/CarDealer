namespace CarDealer.App.Models.Parts
{
    using CarDealer.Services.Models.Parts;
    using System.Collections.Generic;

    //This class is if you want to page Part Models
    public class PartPageListingModel
    {
        public IEnumerable<PartListingModel> Parts { get; set; }

        public int TotalPage { get; set; }

        public int CurrentPage { get; set; }

        public int PreviousPage => this.CurrentPage == 1 
            ? 1 
            : this.CurrentPage - 1;

        public int NextPage => this.CurrentPage == this.TotalPage 
            ? this.TotalPage 
            : this.CurrentPage + 1;
    }
}
