using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace ExoticsOwnersRegistry.Models
{
    // Define the submitter of a car information 
    public class Submitter
    {
        [Key]
        public Int64 submitterID { get; set; }
      
        public string name { get; set; }

        [EmailAddress]
        public string SubmitterEmail { get; set; }

       // Submitter privacy
        public bool hideSubmitter { get; set; }

        // Many cars to one Submitter relationship
        public virtual List<Int64> carIDList { get; set; }
        public virtual List<Car> carList { get; set; }
    }
}
