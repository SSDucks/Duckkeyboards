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
        [Display(Name = "Item Name")]
        public string itemName { get; set; }
        [Display(Name = "Weight")]
        [RegularExpression("^([0-9]+([.][0-9]*)?|[.][0-9]+)$", ErrorMessage = "Please enter valid positive number.")]
        public double weight { get; set; }
        [RegularExpression("^([0-9]+([.][0-9]*)?|[.][0-9]+)$", ErrorMessage = "Please enter valid positive number.")]
        [Display(Name = "Price")]
        public double price { get; set; }
        [Display(Name = "Colour")]
        public string colour { get; set; }
        [Required]
        [Display(Name = "Image Name")]
        public string imageName { get; set; }
        [Display(Name = "Item Type")]
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

