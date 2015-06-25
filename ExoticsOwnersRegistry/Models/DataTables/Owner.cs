using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace ExoticsOwnersRegistry.Models
{
    // An owner can own multiple cars during any period, past or current
    // TODO: Later migrate all the attributes to fluent API
    public class Owner
    {
        // Owner name lengths
        const int CSOWNERNAMEMINLEN = 2;
        const int CSOWNERNAMEMAXLEN = 50;

        [Key]
        public Int64 ownerID { get; set; }

        [Display(Name = "First Name")]
        [MinLength(CSOWNERNAMEMINLEN, ErrorMessage = "Name is too short")]
        [MaxLength(CSOWNERNAMEMAXLEN, ErrorMessage = "Name is too long")]
        [RegularExpression(@"[a-zA-Z''-'\s]*$")]
        public string firstName { get; set; }

        [Display(Name = "Last Name")]
        [MinLength(CSOWNERNAMEMINLEN, ErrorMessage = "Name is too short")]
        [MaxLength(CSOWNERNAMEMAXLEN, ErrorMessage = "Name is too long")]
        [RegularExpression(@"[a-zA-Z''-'\s]*$")]
        public string lastName { get; set; }

        [EmailAddress]
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Full Name")]
        public string fullName
        {
            get{ return lastName + ", " + firstName; }
        }

        // Many owners can own Many cars relationship
        // MVC will create the Id link table automatically
        public virtual List<Car> carList { get; set; }

        ////////////// Internal dbase data ///////////////

        // Owner privacy: Only initials will be displayed
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool hideOwner { get; set; }
    }
}
