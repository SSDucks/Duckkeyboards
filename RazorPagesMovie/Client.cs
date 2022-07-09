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
        public int saltValue { get; set; }
        public List<Review> reviewList { get; set; }
        public Client() { }
        public Client(int ClientID, string Password, string Email, string Username, int SaltValue)
        {
            clientID = ClientID;
            password = Password;
            email = Email;
            username = Username;
            saltValue = SaltValue;
        }
        public string CreateHash(string Password, int randNum)
        {
            // !!! CHANGE THIS LATER
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
    }
}
