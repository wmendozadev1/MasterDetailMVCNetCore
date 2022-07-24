using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestMVCNetCore.Models;

namespace TestMVCNetCore.Context
{
    

    public class TestMVCNetCoreContext : DbContext
    {
        public TestMVCNetCoreContext(DbContextOptions<TestMVCNetCoreContext> options) : base(options)
        {
        }
        public DbSet<Header> Header { get; set; }
        public DbSet<Header_Detail> Header_Detail { get; set; }
        public DbSet<TypeOption> TypeOption { get; set; }


    }

  
}
