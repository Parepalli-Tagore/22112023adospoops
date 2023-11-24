using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IGenericRepository
    {
        List<Employee> GellAllEmployess();

        int InsertEmployee(Employee e);

        List<Department> GetAllDepartments();

       int InsertDepartment(Department d);


    }
}
