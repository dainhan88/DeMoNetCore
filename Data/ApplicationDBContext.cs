using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DeMoMVCNetCore.Models;
namespace DeMoMVCNetCore.Data{

    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext (DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {
        }
      
       
        public DbSet<DeMoMVCNetCore.Models.Person> people { get; set; }
        public DbSet<DeMoMVCNetCore.Models.Student> Students { get; set; }
        public DbSet<DeMoMVCNetCore.Models.Product> Products { get; set; }
        public DbSet<DeMoMVCNetCore.Models.Category> Categories { get; set; }
    }
}