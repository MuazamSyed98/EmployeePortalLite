using System.Threading.Tasks;
using EmployeePortalLite.Controllers;
using EmployeePortalLite.Data;
using EmployeePortalLite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmployeePortalLite.Tests
{
    [TestClass]
    public class EmployeeControllerTests
    {
        private ApplicationDbContext GetRealContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=aspnet-EmployeePortalLite-aaa77683-35a8-442e-975b-73c76de4a474;Trusted_Connection=True;MultipleActiveResultSets=true")
                .Options;

            return new ApplicationDbContext(options);
        }

        [TestMethod]
        public async Task Index_ReturnsViewResult()
        {
            using var context = GetRealContext();

            context.Employees.Add(new Employee
            {
                FullName = "Test User",
                Email = "test@example.com",
                Department = "IT",
                Phone = "1234567890"
            });
            await context.SaveChangesAsync();

            var controller = new EmployeesController(context);

            var result = await controller.Index();

            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }
    }
}
