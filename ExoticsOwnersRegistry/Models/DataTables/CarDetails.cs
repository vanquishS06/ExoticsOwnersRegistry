using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace ExoticsOwnersRegistry.Models
{
    public enum eFuelSystemType
    {
        Injected=1,
        Carburated=2,
        Unknown=-1
    };

    // Details for a car
    public class CarDetails
    {
        // 1 to 1 relationship: use car key as car detail key
        // ForeignKey: REQUIRED for 1 to 1 relationship to ID child
        // Param name must match the declared Object for foreign key
        [Key]
        [ForeignKey("car")]
        public Int64 carID { get; set; }
        public virtual Car car { get; set; }

        [Display(Name = "Original Fuel System")]
        public Nullable<eFuelSystemType> originalFuelSystem { get; set; }

        [Display(Name = "Current Fuel System")]
        public Nullable<eFuelSystemType> currentFuelSystem { get; set; }

        [Display(Name = "Original Exterior Color")]
        public string originalExteriorColor { get; set; }

        [Display(Name = "Original Interior Color")]
        public string originalInteriorColor { get; set; }

        [Display(Name = "Current Exterior Color")]
        public string currentExteriorColor { get; set; }

        [Display(Name = "Current Interior Color")]
        public string currentInteriorColor { get; set; }

        [DisplayFormat(DataFormatString = "MY{0:yy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Official Model Year")]
        public Nullable<DateTime> modelYear { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-mm-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date of Production")]
        public Nullable<DateTime> productionDate { get; set; }

        [Display(Name = "Country of Delivery")]
        public string deliveryCountry { get; set; }

        [Display(Name = "Delivery DealerShip")]
        public string deliveryDealership { get; set; }

        [Display(Name = "Current Country location")]
        public string currentCountryLocation { get; set; }

        // State, county, etc...
        [Display(Name = "Regional Location")]
        public string currentRegionalLocation { get; set; }
    }
}
