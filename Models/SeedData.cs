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
                if (context.Products.Any())
                {
                    return;   // DB has been seeded
                }

                context.Products.AddRange(
                    new Products
                    {
                        ProductID = "000001",
                        ProductName = "VŨ Văn Đức",
                        Unitprice = "abc",
                        Quantity = "123",
                    },

                    new Products
                    {
                        ProductID = "000002",
                        ProductName = "Dinh Thế ANh",
                        Unitprice = "CBA",
                        Quantity = "1234",
                    },

                    new Products
                    {
                        ProductID = "000003",
                        ProductName = "Phạm Văn Nhân",
                        Unitprice = "À Lố",
                        Quantity = "0021324"
                    },

                    new Products
                    {
                        ProductID = "000004",
                        ProductName = "Nguyễn Quang Lâm",
                        Unitprice = "Bề lố",
                        Quantity = "00213244"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}