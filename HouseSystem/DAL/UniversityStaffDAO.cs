using HouseSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HouseSystem.DAL
{
    public class UniversityStaffDAO
    {
        private HouseContext db = new HouseContext();

        public UniversityStaff GetStaffByUsername(string username)
        {
            UniversityStaff staff = null;
            var query = from s in db.UniversityStaffs
                        where s.Username == username
                        select s;
            foreach (var s in query)
            {
                staff = s;
            }
            return staff;
        }
    }
}