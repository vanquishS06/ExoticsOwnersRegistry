using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace ExoticsOwnersRegistry.Models
{
    // Known tag for a car
    public class LicenceTag
    {
        [Key]
        public Int64 tagID { get; set; }

        public string tag { get; set; }

        // Tag privacy
        public bool hideTag { get; set; }

        // Many cars to one tag relationship
        //TODO - NO: MANY CARTO MANY TAGS 
        public virtual List<Int64> carIDList { get; set; }
        public virtual List<Car> carList { get; set; }
    }
}
