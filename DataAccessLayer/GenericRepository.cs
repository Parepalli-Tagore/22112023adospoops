using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class GenericRepository : IGenericRepository
    {
        SqlConnection con = new SqlConnection("Data Source=TPAREPAL-L-5467\\SQLEXPRESS;Initial Catalog=Organization;User ID=sa;Password=Welcome2evoke@1234");
        public List<Employee> GellAllEmployess()
        {
            List<Employee> Employeelist = new List<Employee>();
            SqlCommand cmd = new SqlCommand("Sp_GetEmployees", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                 Employee e = new Employee
                {
                    EmpId = (int)dr["Empid"],
                    EmpName = dr["EmpName"].ToString(),
                    Salary = (decimal)dr["Salary"],
                     HireDate = (DateTime)dr["HireDate"], 
                     Position = dr["Position"].ToString(),
                     Email = dr["Email"].ToString(),
                     address = dr["Address"].ToString(),
                     DeptName = dr["DeptName"].ToString()


                 };
                Employeelist.Add(e);
            }
            con.Close();
            return Employeelist;
        }

        public List<Department> GetAllDepartments()
        {
           
                List<Department> Departmentlist = new List<Department>();
                SqlCommand cmd = new SqlCommand("Sp_GetDepartments", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Department d = new Department
                    {
                        DeptId = (int)dr["DeptId"],
                        DeptName = dr["DeptName"].ToString(),
                        address = dr["Address"].ToString(),
                        StartDate = (DateTime)dr["startDate"],



                    };
                    Departmentlist.Add(d);
                
                }
                con.Close();
            return Departmentlist;

        }

        public int InsertEmployee(Employee e)
        {

            con.Open();
            SqlCommand cmd = new SqlCommand("Sp_InsertEmployee", con);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@EmpId", e.EmpId);
            cmd.Parameters.AddWithValue("@EmpName", e.EmpName);
            cmd.Parameters.AddWithValue("@Salary", e.Salary);
            cmd.Parameters.AddWithValue("@HireDate", e.HireDate);
            cmd.Parameters.AddWithValue("@Position", e.Position);
            cmd.Parameters.AddWithValue("@Email", e.Email);
            cmd.Parameters.AddWithValue("@DeptName", e.DeptName);
            cmd.Parameters.AddWithValue("@Address",e.address);

            int result =cmd.ExecuteNonQuery();

            return result;
        }

        public int InsertDepartment(Department d )
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Sp_InsertDepartment", con);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@EmpId", e.EmpId);
            //cmd.Parameters.AddWithValue("@DeptId", d.DeptId);
            cmd.Parameters.AddWithValue("@DeptName", d.DeptName);
            cmd.Parameters.AddWithValue("@Address", d.address);
            cmd.Parameters.AddWithValue("@StartDate", d.StartDate);
            
            int result = cmd.ExecuteNonQuery();

            return result;
        }
    }
}