using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InterestingPLACESaroundTheWorld.Models
{
    public class Tradition
    {
        [Key]
        public int TraditionID { get; set; }
        public String TraditionName { get; set; }
        public String TraditionDescription { get; set; }

        //a tradition can belong to many places

        //many places can have many traditions

        //This way we our implicitly describing a bridging table

        public ICollection<Place> Places { get; set; }
    }
}