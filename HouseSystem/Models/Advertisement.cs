using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace HouseSystem.Models
{
    public class Advertisement
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
       // public byte []Image {get;set;}
        //0 unprocceed ,1 successful,2 unsuccessful
        public int Pass { get; set; }
        public string address { get; set; }
        public string RefuseReason { get; set; }
        public int LandlordID { get; set; }

        public virtual Landlord Landlord { get; set; }
        public virtual ICollection<Image> Images { get; set; }

    }
}