using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebApplication15.Models
{
    public class createdb:DbContext
    {
        public DbSet<tablephonebook> tablephonebook { get; set; }
        public createdb(DbContextOptions<createdb> options)
          : base(options)
        {
           // Database.EnsureCreated();
        }
    }
}
