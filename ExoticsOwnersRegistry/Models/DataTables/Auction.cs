using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace ExoticsOwnersRegistry.Models
{
    // Defines an auction for a car
    public class Auction
    {
        [Key]
        public Int64 auctionID { get; set; }

        [Required]
        public string auctioner { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:mm-yyyy}", ApplyFormatInEditMode = true)]
        public byte[] auctionDate { get; set; }

        // No sales flag indicator
        public bool noSale { get; set; }

        // Total Price sold
        [DataType(DataType.Currency)]
        public decimal salePrice { get; set; }

        public string comments { get; set; }

        // Many Auctions to 1 car relationship
        public Int64 carID { get; set; }
        public virtual Car car { get; set; }
    }
}
