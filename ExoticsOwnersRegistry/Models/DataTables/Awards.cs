using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace ExoticsOwnersRegistry.Models
{
    public class Award
    {
        [Key]
        public Int64 awardID { get; set; }

        [Required]
        public string awardName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-mm-yyyy}", ApplyFormatInEditMode = true)]
        public byte[] awardDate { get; set; }

        // Many awards to 1 car relationship
        public Int64 carID { get; set; }
        public virtual Car car { get; set; }
    }
}
