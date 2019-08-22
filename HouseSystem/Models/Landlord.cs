using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace HouseSystem.Models
{
    public class Landlord:User
    { 
        public string Telephone { get; set; }
        public virtual ICollection<Advertisement> Advertisements { get; set; }
        //merge test 
    }
}
