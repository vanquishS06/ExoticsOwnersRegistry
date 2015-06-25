using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace ExoticsOwnersRegistry.Models
{
    public class CarMaker
    {
        [Key]
        public Int64 makeID { get; set; }
        
        [Required (ErrorMessage="{0} is required")]
        [Display(Name = "Make")]
        public string makeName { get; set; }

        // Free form text
        [DataType(DataType.MultilineText)]
        [Display(Name = "History")]
        public string makeHistory { get; set; }

        // 1 Make to many Models relationship
        public virtual List<CarModel> modelList { get; set; }
    }
}
