using Microsoft.EntityFrameworkCore;
using Ordering.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Persistance
{
    public class OrderContextSeed
    {
        public static async Task Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasData(
                new Order() {
                    Id=1,
                    UserName="wahidahmed061992@gmail.com",
                    FirstName="wahid",
                    LastName="ahmed",
                    EmailAddress= "wahidahmed061992@gmail.com",
                    TotalPrice=1102,City="dhaka",
                    CVV = "Test",
                    CardName = "Test",
                    CardNumber = "Test",
                    Expiration = "Test",
                    PaymentMethod = 1,
                    CreatedBy = "Test",
                    CreatedDate = DateTime.Now,
                    PhoneNumber = "01700000000",
                    ZipCode = "Test",
                    Address="test"
                }
                );
        }
    }
}
