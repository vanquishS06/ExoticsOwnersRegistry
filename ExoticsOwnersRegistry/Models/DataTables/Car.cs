using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

// This is added to insure warning on non CLS complaint Keys
[assembly: CLSCompliant(true)]

namespace ExoticsOwnersRegistry.Models
{
    public enum eApprovalStatus
    {
        Submitted = 0,
        Pending = 1,
        Accepted = 2,
        Rejected = 3
    };

    public class Car
    {
        // Key type MUST BE CLS compliant!
        [Key]
        public Int64 carID { get; set; }

        // One to one car to make relationship
        [ForeignKey("carMaker")]
        public Int64? makeID { get; set; }
        [Display(Name = "Make")]
        public virtual CarMaker carMaker { get; set; }

        // One to one car to model relationship
        [ForeignKey("carModel")]
        public Int64? modelID { get; set; }
        [Display(Name = "Model")]
        public virtual CarModel carModel { get; set; }

        // One to one car to submodel relationship
        [ForeignKey("carSubModel")]
        public Int64? subModelID { get; set; }
        [Display(Name = "Sub-Model")]
        public virtual CarSubModel carSubModel { get; set; }

        [Required]
        public string VIN { get; set; }

        [Display(Name="Showcase Picture")]
        [DataType(DataType.ImageUrl)]
        public byte[] showCaseCarPicture { get; set; }

        // One to one current owner to car relationship
        [ForeignKey("owner")]
        public Int64 ownerID { get; set; }
        [Display(Name = "Current Owner")]
        public virtual Owner owner { get; set; }

        // Details about the car : 1 to 1 relationship
        // Note: Virtual allow lazy loading to work - critical
        [Display(Name="Car Details")]
        public virtual CarDetails carDetails { get; set; }

        //// One to many car to history period
        //// Note: Virtual allow lazy loading to work - critical
        //public virtual List<HistoryPeriod> historyList { get; set; }

        //// List of one car to many public auctions
        //// Note: Virtual allow lazy loading to work - critical
        //public virtual List<Auction> auctionList { get; set; }

        //// List of one car to many tags during the car's life
        //TODO - NO: MANY CAR TO MANY TAGS 
        //public virtual List<LicenceTag> licenseTagList { get; set; }
        
        //// List of one car to many information submitters
        //// Note: Virtual allow lazy loading to work - critical
        //public virtual List<Submitter> submitterList { get; set; }

        //// List of one car to many awards
        //// Note: Virtual allow lazy loading to work - critical
        //public virtual List<Award> awardList { get; set; }

        //// List of one car to many sales
        //// Note: Virtual allow lazy loading to work - critical
        //public virtual List<Sale> saleList { get; set; }

        ////////////// Internal dbase data ///////////////

        //[DataType(DataType.DateTime)]
        //[DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        //public byte[] createdDate { get; set; }

        //[DataType(DataType.DateTime)]
        //[DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        //public byte[] LastModifiedDate { get; set; }

        // Car privacy except owner
        [Display(Name = "Hidden Record")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool bHideCar { get; set; }

        // Submittion approval
        //TODO create an enum dropdown
        [Display(Name = "Approval Status")]
        public int approvalStatus { get; set; }

        // [Timestamp] is necesssary to concurency detection and exception 
        // [Browsable] is neccessary to hide the property from view binding
        [Timestamp]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte[] TimeStamp { get; set; }
    }
}