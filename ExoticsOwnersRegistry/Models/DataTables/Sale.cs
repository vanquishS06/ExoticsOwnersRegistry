using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace ExoticsOwnersRegistry.Models
{
    public class Sale
    {
        [Key]
        public Int64 saleID { get; set; }

        public string salePrice { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-mm-yyyy}", ApplyFormatInEditMode = true)]
        public byte[] saleDate { get; set; }

        // Many sales to 1 car relationship
        public Int64 carID { get; set; }
        public virtual Car car { get; set; }
    }
}
