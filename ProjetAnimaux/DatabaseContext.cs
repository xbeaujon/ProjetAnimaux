using Microsoft.EntityFrameworkCore;
using ProjetAnimaux;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetAnimaux
{
    public class DatabaseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
                    => options.UseLazyLoadingProxies().UseSqlServer("Server=LOEN-PC\\SQLEXPRESS;" +
                            "Database=ProjetAnimaux;" +
                            "Integrated Security=true");

        public DbSet<Race> Races { get; set; }
        public DbSet<Animal> Animals { get; set; }
    }
}

