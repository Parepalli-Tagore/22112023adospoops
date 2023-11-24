using System.ComponentModel.DataAnnotations;

namespace _22112023adospoops.Models
{
    public abstract class Person
    {
        
        [Required(ErrorMessage = "Address is required")]
        private string Address { get; set; }

        //[Required(ErrorMessage = "Department name is required")]
        //private string DeptName { get; set; }

      

        public string address { get { return Address; } set { Address = value; } }
        //public string deptName { get { return DeptName; } set { DeptName = value; } }




    }
}
