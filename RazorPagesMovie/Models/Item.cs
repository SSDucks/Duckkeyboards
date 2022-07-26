using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


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
        public string itemImage { get; set; }
        public Item() { }
        public Item(int ItemID, string ItemName, double Weight, double Price, string Colour, string ItemImage)
        {
            itemID = ItemID;
            itemName = ItemName;
            weight = Weight;
            price = Price;
            colour = Colour;
            itemImage = ItemImage;
        }
    }
}
