using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using HouseSystem.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace HouseSystem.DAL
{
    public class HouseContext : DbContext
    {

        public HouseContext() : base("HouseContext")
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Landlord> Landlords { get; set; }
        public DbSet<UniversityStaff> UniversityStaffs { get; set; }
        //此项可省略，因为Staff包含它
        public DbSet<Advertisement> Advertisements { get; set; }
        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //去掉自动复数的表名规则
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}