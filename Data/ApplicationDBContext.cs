using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DeMoMVCNetCore.Models;

    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext (DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {
        }

        public DbSet<DeMoMVCNetCore.Models.Person> Person { get; set; }

        public DbSet<DeMoMVCNetCore.Models.Students> Students { get; set; }

        public DbSet<DeMoMVCNetCore.Models.Products> Products { get; set; }

        public DbSet<DeMoMVCNetCore.Models.Employees> Employees { get; set; }
    }
