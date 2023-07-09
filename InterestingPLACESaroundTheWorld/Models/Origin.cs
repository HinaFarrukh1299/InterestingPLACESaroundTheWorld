using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace InterestingPLACESaroundTheWorld.Models
{
    public class Origin
    {
        

        [Key]
        public int OriginID { get; set; }
        public string Continent { get; set; }
        public string Country { get; set; }
    
}

    }
