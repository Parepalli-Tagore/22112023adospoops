using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _22112023adospoops.Models
{
   
        public class Employee : Person
        {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmpId { get; set; }

        [Required(ErrorMessage = "First name is required")]
        public string EmpName { get; set; }


        [Required(ErrorMessage = "Salary is required")]
        //[MaxLength(255)]
        public decimal Salary { get; set; }

        [Required(ErrorMessage = "Hire date is required")]
        [DataType(DataType.Date, ErrorMessage = "Invalid date format")]
        public DateTime HireDate;

        [Required(ErrorMessage = "Position is required")]
        public string Position;

        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email;


        // Other properties...

        [Required(ErrorMessage = "Department is required")]
        //[ForeignKey("Department")]
        public string DeptName { get; set; }


        public Department Department { get; set; }
    }

}

