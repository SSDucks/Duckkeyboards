using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesMovie
{
    public class Admin
    {
        public int adminID { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string username { get; set; }
        public int saltValue { get; set; }

        public Admin() { }
        public Admin(int id, string Password, string emailAddress, string Username, int SaltValue)
        {
            adminID = id;
            password = Password;
            email = emailAddress;
            username = Username;
            saltValue = SaltValue;
        }
        public string CreateHash(string password, int saltValue)
        {
            // COME BACK TO THIS LATER
            return "";
        }
        public string DeleteReview(Review review)
        {
            // COME BACK TO THIS LATER
            return "";
        }
        public void CreateItem(Item item)
        {
            // COME BACK TO THIS LATER
            return;
        }
        public void DeleteItem(Item item)
        {
            // COME BACK TO THIS LATER
            return;
        }
        public void EditItem(Item item)
        {
            // COME BACK TO THIS LATER
            return;
        }
    }
}
