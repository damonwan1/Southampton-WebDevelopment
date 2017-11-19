using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using HouseSystem.Models;

namespace HouseSystem.DAL
{
    //Initializer the data
    public class HouseInitializer : DropCreateDatabaseIfModelChanges<HouseContext>
    {

        protected override void Seed(HouseContext context)
        {
            //student Initializer
            var students = new List<Student>
            {
            new Student{Username="damon",Password="123",Birthday=DateTime.Parse("1994-05-02")},
            new Student{Username="coconut",Password="123",Birthday=DateTime.Parse("1995-08-12")},
            };
            students.ForEach(s => context.Students.Add(s));
            context.SaveChanges();

            //staff Initializer
            var universityStaffs = new List<UniversityStaff>
            {
            new UniversityStaff{Username="staff",Password="123",Birthday=DateTime.Parse("1975-11-12")}
            };
            universityStaffs.ForEach(s => context.UniversityStaffs.Add(s));
            context.SaveChanges();

            //Landlord Initializer
            var landlords = new List<Landlord>
            {
            new Landlord{Username="landlord",Password="123",Birthday=DateTime.Parse("1979-01-12")}
            };
            landlords.ForEach(s => context.Landlords.Add(s));
            context.SaveChanges();

            //advertisements Initializer
            var advertisements = new List<Advertisement>
            {
            new Advertisement{LandlordID=1,Pass=0,Title="I:Good price house",Description="Initial Data(wait):close to the university of southampton, just 75/week!"},
            new Advertisement{LandlordID=1,Pass=1,Title="I;4 room house",Description="Initial Data(pass):close to the university of southampton, just 115/week!"},
            new Advertisement{LandlordID=1,Pass=2,Title="I:Near the sea house",Description="Initial Data(Fail):asdasfjkakj1danjsk asdjaksdask",RefuseReason="wrong description!"}
            };
            advertisements.ForEach(s => context.Advertisements.Add(s));
            context.SaveChanges();

        }
    }
}