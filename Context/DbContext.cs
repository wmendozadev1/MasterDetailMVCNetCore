using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestMVCNetCore.Models;

namespace TestMVCNetCore.Context
{


    //public class TestMVCNetCoreContext : DbContext
    public class TestMVCNetCoreContext : IdentityDbContext<IdentityUser, IdentityRole, string, IdentityUserClaim<string>, IdentityUserRole<string>,
       IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>

    {

        public TestMVCNetCoreContext(DbContextOptions<TestMVCNetCoreContext> options)
         : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityUser>();




        }


        //public TestMVCNetCoreContext(DbContextOptions<TestMVCNetCoreContext> options) : base(options)
        //{
        //}
        public DbSet<Header> Header { get; set; }
        public DbSet<Header_Detail> Header_Detail { get; set; }
        public DbSet<TypeOption> TypeOption { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<UserCompany> UserCompany { get; set; }


        public virtual DbSet<UserCompanyVM> UserCompanyVM { get; set; }

    }

  
}
