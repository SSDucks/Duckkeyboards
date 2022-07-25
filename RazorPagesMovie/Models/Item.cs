using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace RazorPagesMovie
{
    public class Item
    {
        public int itemID { get; set; }
        public string itemName { get; set; }
        public double weight { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public double price { get; set; }
        public string colour { get; set; }
        public string imageName { get; set; }
        public byte[] Content { get; set; }
        public Item() { }
        public Item(int ItemID, string ItemName, double Weight, double Price, string Colour, string ImageName)
        {
            itemID = ItemID;
            itemName = ItemName;
            weight = Weight;
            price = Price;
            colour = Colour;
            imageName = ImageName;
        }

    }

    public class FileViewModel
    {
        public IFormFile FormFile { get; set; }
    }
}
