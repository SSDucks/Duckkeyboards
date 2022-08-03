using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace RazorPagesMovie.Models
{
    public class Listing
    {

        public int listingID { get; set; }
        [Required]
        public string itemName { get; set; }
        public double weight { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public double price { get; set; }
        public string colour { get; set; }
        [Required]
        public string imageName { get; set; }
        public string itemType { get; set; }
        //[ErrorMessage = "Please enter a valid image"]
        public string content { get; set; }

        public Listing() { }
        public Listing(int ListingID, string ItemName, double Weight, double Price, string Colour, string ImageName, string itemType, string content)
        {
            listingID = ListingID;
            itemName = ItemName;
            weight = Weight;
            price = Price;
            colour = Colour;
            imageName = ImageName;
            this.itemType = itemType;
        }
    }

        public class FileViewModel
        {
            public IFormFile FormFile { get; set; }
        }
}

