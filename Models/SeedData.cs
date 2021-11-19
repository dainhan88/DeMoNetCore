using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using DeMoMVCNetCore.Data;

namespace DeMoMVCNetCore.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDBContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationDBContext>>()))
            {
                // Look for any movies.
                if (context.Students.Any())
                {
                    return;   // DB has been seeded
                }

                context.Students.AddRange(
                    new Student
                    {
                        StudentID = 1,
                         University = "Phạm Văn Nhân",
                     
                    },
                    new Student
                    {
                        StudentID = 2,
                        University = "Dinh Thế ANh",                       
                    },

                    new Student
                    {
                        StudentID = 3,
                        University = "Phạm Văn Nhân",
                      
                    },

                    new Student
                    {
                        StudentID = 4,
                        University = "Nguyễn Quang Lâm",
                       
                    }
                );
                context.SaveChanges();
            }
        }
    }
}