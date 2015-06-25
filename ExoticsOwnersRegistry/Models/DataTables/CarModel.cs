using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace ExoticsOwnersRegistry.Models
{
    public class CarModel
    {
        [Key]
        public Int64 modelID { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = "Model Name")]
        public string modelName { get; set; }

        // Free form text
        [DataType(DataType.MultilineText)]
        [Display(Name = "Description")]
        public string ModelDescription { get; set; }

        // Many Models to 1 car Make relationship
        [ForeignKey("carMaker")]
        public Int64? makeID { get; set; }
        public virtual CarMaker carMaker { get; set; }

        // 1 Model to many Sub-model relationship
        public virtual List<CarSubModel> subModelList { get; set; }
    }
}
