using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HouseSystem.Models;

namespace HouseSystem.DAL
{
    public class StudentDAO
    {
        private HouseContext db = new HouseContext();

        public Student GetStudentByUsername(string username) {
            Student stu=null;
            var query = from s in db.Students
                        where s.Username == username select s;
            foreach (var s in query)
            {
                stu= s;
            }
            return stu;
        }
    }
}