using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesMovie
{
     public class Client
    {
        public int clientID { get; set; } // = (GLOBAL CLiENT ID VARIABLE) ADD THIS LATER !!!!!!!!!!!!
        public string password { get; set; }
        public string email { get; set; }
        public string username { get; set; }
        public string saltValue { get; set; } = GetSaltValue();
        public List<Review> reviewList { get; set; }
        public ShoppingCart shoppingCart { get; set; }
        public Client() { }
        public Client(int ClientID, string Password, string Email, string Username)
        {
            clientID = ClientID;
            password = Password;
            email = Email;
            username = Username;
        }
        public string CreateHash(string Password, int randNum)
        {
            // !!! CHANGE THIS LATERa
            return "";
        }
        public void CreateReview(Review Review)
        {
            // !!! CHANGE THIS LATER
        }
        public int TotalReviews(List<Review> reviewList)
        {
            return reviewList.Count;
        }
        // Code we took from the web to generate a random salt Value. It's horrible. 
        // Btw DON'T USE THIS FUNCTION TO GET THE CLIENT'S SALT VALUE, IT WILL RANDOMIZE EACH TIME, THIS IS SOLELY USED FOR CREATING INITIAL VALUE
        public static string GetSaltValue()
        {
            string chars = "$%#@!*abcdefghijklmnopqrstuvwxyz1234567890?;:ABCDEFGHIJKLMNOPQRSTUVWXYZ^&";
            string saltValue = "";
            Random rand = new Random();
            for (int i = 0; i < 16; i++)
            {
                int num = rand.Next(0, chars.Length);
                saltValue += chars[num];
            }
            return saltValue;
        }
    }
}
