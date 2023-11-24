using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Employee : Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmpId { get; set; }

        [Required(ErrorMessage = "First name is required")]
        public string EmpName { get; set; }


        [Required(ErrorMessage = "Salary is required")]
       // [MaxLength(255)]
        public decimal Salary { get; set; }

        [Required(ErrorMessage = "Hire date is required")]
        [DataType(DataType.Date, ErrorMessage = "Invalid date format")]
        public DateTime HireDate { get; set; }

        [Required(ErrorMessage = "Position is required")]
        public string Position { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }


        // Other properties...

        [Required(ErrorMessage = "Department is required")]
        //[ForeignKey("Department")]
        public string DeptName { get; set; }


        public Department Department { get; set; }
    }
}
