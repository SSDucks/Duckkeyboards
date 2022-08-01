using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace RazorPagesMovie.Models
{
    public class AuditRecord
    {
        [Key]
        public int Audit_ID { get; set; }
        [Display(Name = "Audit Action")]
        public string AuditActionType { get; set; }
        // Could be Login Success /Failure/ Logout, Create, Delete, View, Update
        [Display(Name = "Performed By")]
        public string Username { get; set; }
        //Logged in user performing the action

        [Display(Name = "Date/Time Stamp")]
        [DataType(DataType.DateTime)]
        public DateTime DateTimeStamp { get; set; }
        //Time when the event occurred
        [Display(Name = "Listing Record ID")]
        public int KeyListingFieldListingID { get; set; }
        //Store the ID of movie record that is affected
        [Display(Name = "User Role")]
        public string UserRole { get; set; }
        [Display(Name = "Portal")]
        public string PortalArea { get; set; }
    }
}