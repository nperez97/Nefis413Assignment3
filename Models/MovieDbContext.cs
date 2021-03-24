using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nefis413Assignment3.Models
{
    public class MovieDbContext : DbContext
    {
        //constructor
        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options) //takes from base(options)
        {

        }
        //property
        public DbSet<AddMovie> Movie { get; set; }
    }
}
