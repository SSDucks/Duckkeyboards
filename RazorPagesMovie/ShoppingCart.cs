using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesMovie
{
    public class ShoppingCart
    {
        public Client client { get; set; }
        public List<Item> itemList { get; set; }
        public int cartID { get; set; }
        public ShoppingCart() { }
        public ShoppingCart(Client Client, List<Item> ItemList, int CartID)
        {
            client = Client;
            itemList = ItemList;
            cartID = CartID;
        }
        public double CalculateTotal(List<Item> itemList)
        {
            // !!! DO THIS LATER
            // LOOP THROUGH EACH ITEM IN LIST AND ADD THEIR COST ATTRIBUTE TOGETHER
            return 0;
        }
        public void AddItem(Item Item)
        {
            itemList.Add(Item);
        }
        public void RemoveItem(Item removeItem)
        {
            // !!! DO THIS LATER
            // ALSO WHEN REMOVING, WHAT IF THERE IS MULTIPLE INSTANCES OF THE SAME ITEM, DELETE ALL? DELETE ONE?
        }
        public int ItemCount()
        {
            return itemList.Count;
        }
    }
}
