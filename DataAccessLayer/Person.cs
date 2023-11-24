using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
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
