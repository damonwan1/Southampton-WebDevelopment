﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HouseSystem.Models;

namespace HouseSystem.DAL
{
    public class LandlordDAO
    {
        private HouseContext db = new HouseContext();

        public Landlord GetLandlordByUsername(string username)
        {
            Landlord landlord = null;
            var query = from s in db.Landlords
                        where s.Username == username
                        select s;
            foreach (var s in query)
            {
                landlord = s;
            }
            return landlord;
        }

        

        public Landlord GetLandlordByID(int id ){
            return db.Landlords.Find(id);
        }
      /*  public ICollection<Advertisement> getAdvertisementByLandlord(string)
        {

        }*/
    }
}