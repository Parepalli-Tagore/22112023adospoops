using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Department : Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DeptId { get; set; }

        [Required(ErrorMessage = "Department name is required")]
        public DateTime StartDate { get; set; }
        public string DeptName { get;set; }


        // Other properties...

        public List<Employee> Employees { get; set; }
    }
}
