using HouseSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HouseSystem.DAL
{

    public class AdvertisementDAO
    {
        private HouseContext db = new HouseContext();

        public List<Advertisement> GetAdvsPass() {
            var query = from s in db.Advertisements
                        where s.Pass == 1
                        select s;
            if (query == null) {
                return null;
            }
            return query.ToList();
        }

        public List<Advertisement> GetAdvsUnprocessed()
        {
            var query = from s in db.Advertisements
                        where s.Pass == 0
                        select s;
            if (query == null)
            {
                return null;
            }
            return query.ToList();
        }

        //add to database
        public void AddAdvertisement(Advertisement advertisement)
        {
            db.Advertisements.Add(advertisement);
            db.SaveChanges();
        }
    }

    
}