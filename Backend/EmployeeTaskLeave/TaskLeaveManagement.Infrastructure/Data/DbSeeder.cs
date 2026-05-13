using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskLeaveManagement.Domain.Entities;

namespace TaskLeaveManagement.Infrastructure.Data
{
    public static class DbSeeder
    {
        public static void Seed(ApplicationDbContext context)
        {
            if (!context.Users.Any())
            {
                context.Users.AddRange(
                    new User
                    {
                        Name = "Admin User",
                        Email = "admin@test.com",
                        Password = "123",
                        Role = "Admin"
                    },
                    new User
                    {
                        Name = "Employee User",
                        Email = "employee@test.com",
                        Password = "123",
                        Role = "Employee"
                    });

                context.SaveChanges();
            }
        }
    }
}
