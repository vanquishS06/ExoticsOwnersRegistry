using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace ExoticsOwnersRegistry.Models
{
    // An history period belong to one car
    public class HistoryPeriod
    {
        public Int64 historyPeriodID { get; set; }

        // Period range
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-yyyy}", ApplyFormatInEditMode = true)]
        public byte[] startDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-yyyy}", ApplyFormatInEditMode = true)]
        public byte[] endDate { get; set; }

        // 1 history period to 1 owner relationship
        // Use foreign key as key for 1 : 1 
        [Key]
        [ForeignKey("owner")]
        public Int64 ownerID { get; set; }
        [Display(Name = "Period Owner")]
        public virtual Owner owner { get; set; }

        // Free form text
        [DataType(DataType.MultilineText)]
        public byte[] historyDetails { get; set; }

        [Display(Name = "Period Picture")]
        [DataType(DataType.ImageUrl)]
        public byte[] periodPictures { get; set; }

        // Many Periods to 1 car relationship
        public Int64 carID { get; set; }
        public virtual Car car { get; set; }
    }
}
