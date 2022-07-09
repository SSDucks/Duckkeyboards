using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesMovie
{
    public class Review
    {
        public int reviewID { get; set; } // = ( GLOBAL VARIABLE THAT AUTO-INCREMENTS ) !!! ADD THIS WHEN GLOBAL VARIABLE HAS BEEN INCLUDED
        public string reviewText { get; set; }
        public Client myProperty { get; set; }
        public int rating { get; set; }
        public DateTime dateTimePosted { get; set; } = DateTime.Now; // Default Value set to when Review is created
        public Review() { }
        public Review(int Rating, string ReviewText, Client Client)
        {
            rating = Rating;
            reviewText = ReviewText;
            myProperty = Client;
        }
        public void EditReview(string ReviewText)
        {
            reviewText = ReviewText;
        }
        public bool DeleteReview()
        {
            // !!! CHANGE THIS LATER
            return false;
        }
        public void EditRating(int newRating)
        {
            rating = newRating;
        }
    }
}
