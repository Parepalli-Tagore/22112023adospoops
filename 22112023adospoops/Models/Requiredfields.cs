using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;

namespace _22112023adospoops.Models
{
    public class Requiredfields
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }
        public DateTime hireDate { get; set; }
        public string position { get; set; }
        public string email { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string location { get; set; }
        public string manager { get; set; }

    }
}
