using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace ExoticsOwnersRegistry.Models
{
    public class CarSubModel
    {
        [Key]
        public Int64 subModelID { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = "Sub-Model Name")]
        public string subModelName { get; set; }

        // Free form text
        [DataType(DataType.MultilineText)]
        [Display(Name = "Description")]
        public string subModelDescription { get; set; }

        // Many sub-Models to 1 Model relationship
        [ForeignKey("carModel")]
        public Int64? modelID { get; set; }
        [Required]
        public virtual CarModel carModel { get; set; }
    }
}
