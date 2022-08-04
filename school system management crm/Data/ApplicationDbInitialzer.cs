using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using school_system_management_crm.Data.Static;
using school_system_management_crm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace school_system_management_crm.Data
{
    public class ApplicationDbInitialzer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceccope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var Context = serviceccope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                Context.Database.EnsureCreated();
                if (!Context.Departments.Any())
                {
                    Context.Departments.AddRange(new List<Department>()
                    {
                        new Department()
                        {
                            Name = "IT"
                        },
                        new Department()
                        {
                            Name = "RH"
                        },
                        new Department()
                        {
                            Name = "Human Resources"
                        }
                    });
                    Context.SaveChanges();
                }

                //Employees
                if (!Context.Employees.Any())
                {
                    Context.Employees.AddRange(new List<Employee>()
                    {
                        new Employee()
                        {
                            Name = "yasine essadi",
                            Address = "Lot D In C 290",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now,
                            Salary = 5000,
                            DepartmentId = 1
                        },
                        new Employee()
                        {
                            Name = "yushi essadi",
                            Address = "Lot B In F 100",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now,
                            Salary = 8000,
                            DepartmentId = 3
                        },
                        new Employee()
                        {
                            Name = "jane essadi",
                            Address = "Lot M In C 300",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now,
                            Salary = 9000,
                            DepartmentId = 2
                        }
                    });
                    Context.SaveChanges();
                }
            }
        }
        public static async Task SeedAsync(IApplicationBuilder applicationBuilder)
        {
            using (var servicescope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var rolemanger = servicescope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await rolemanger.RoleExistsAsync(UserRoles.Admin))
                    await rolemanger.CreateAsync(new IdentityRole(UserRoles.Admin));

                if (!await rolemanger.RoleExistsAsync(UserRoles.User))
                    await rolemanger.CreateAsync(new IdentityRole(UserRoles.User));


                var usermanager = servicescope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                //Admin
                string AdminEamail = "yasine.esadi@gmail.com";
                var AdminUser = await usermanager.FindByEmailAsync(AdminEamail);

                if (AdminUser == null)
                {
                    var newAdmin = new ApplicationUser()
                    {
                        FullName = "Yassine essadi",
                        Email = AdminEamail,
                        UserName = "Admin",
                        EmailConfirmed = true
                    };
                    await usermanager.CreateAsync(newAdmin, "User000.?13");
                    await usermanager.AddToRoleAsync(newAdmin, UserRoles.Admin);
                }

                //User
                string UserEmail = "jane.essadi@gmail.com";
                var UserUser = await usermanager.FindByEmailAsync(UserEmail);

                if (UserUser == null)
                {
                    var newUser = new ApplicationUser()
                    {
                        FullName = "Jane essadi",
                        Email = UserEmail,
                        UserName = "User",
                        EmailConfirmed = true
                    };
                    await usermanager.CreateAsync(newUser, "User000.?13");
                    await usermanager.AddToRoleAsync(newUser, UserRoles.User);
                }
            }
        }
    }
    
}
