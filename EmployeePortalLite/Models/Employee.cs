using System.ComponentModel.DataAnnotations;

namespace EmployeePortalLite.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        public string Department { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;
    }
}
