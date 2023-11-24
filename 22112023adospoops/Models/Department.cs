using DataAccessLayer;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _22112023adospoops.Models
{
    public class Department:Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DeptId { get; set; }

        [Required(ErrorMessage = "Department name is required")]
        public DateTime StartDate { get; set; }


        // Other properties...

        public List<Employee> Employees { get; set; }
    }
}
