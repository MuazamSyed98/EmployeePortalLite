using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EmployeePortalLite.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmployeePortalLite.Tests
{
    [TestClass]
    public class EmployeeModelTests
    {
        private bool ValidateModel(Employee model, out List<ValidationResult> results)
        {
            var context = new ValidationContext(model, null, null);
            results = new List<ValidationResult>();
            return Validator.TryValidateObject(model, context, results, validateAllProperties: true);
        }

        [TestMethod]
        public void Employee_WithValidData_IsValid()
        {
            var emp = new Employee
            {
                FullName = "Valid Name",
                Email = "valid@example.com",
                Department = "HR",
                Phone = "5555555555"
            };

            var isValid = ValidateModel(emp, out var results);

            Assert.IsTrue(isValid);
            Assert.AreEqual(0, results.Count);
        }
    }
}
