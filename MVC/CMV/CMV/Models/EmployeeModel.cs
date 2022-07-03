using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CMV.Models
{
    public class EmployeeModel
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\MCA\MCA\MCA Program\Sem2\ASP\MVC\CMV\CMV\App_Data\Database.mdf;Integrated Security=True");

        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Enter Dept")]
        public string Department { get; set; }

        [Required(ErrorMessage = "Please Enter Salary")]
        [Range(5000, 50000, ErrorMessage = "Value should be between 5k to 50k")]
        public int Salary { get; set; }

        //Retrieve all records from a table 
        public List<EmployeeModel> getData()
        {
            List<EmployeeModel> lstEmp = new List<EmployeeModel>();

            SqlDataAdapter apt = new SqlDataAdapter("select * from tbl_emp", con);
            DataSet ds = new DataSet();
            apt.Fill(ds);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                lstEmp.Add(new EmployeeModel { Id = Convert.ToInt32(dr["Id"].ToString()), Name = dr["Name"].ToString(), Department = dr["Dept"].ToString(), Salary = Convert.ToInt32(dr["Salary"].ToString()) });
            }

            return lstEmp;
        }


        //Retrieve single record from a table 
        public EmployeeModel getData(string Id)
        {
            EmployeeModel emp = new EmployeeModel();
            SqlCommand cmd = new SqlCommand("select * from tbl_emp where id='" + Id + "'", con);

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    emp.Id = Convert.ToInt32(dr["Id"].ToString());
                    emp.Name = dr["Name"].ToString();
                    emp.Department = dr["Dept"].ToString();
                    emp.Salary = Convert.ToInt32(dr["Salary"].ToString());
                }
            }
            con.Close();
            return emp;
        }

        //Insert a record into a database table 
        public bool insert(EmployeeModel Emp)
        {

            SqlCommand cmd = new SqlCommand("insert into tbl_emp values(@name,@dept,@salary)", con);
            cmd.Parameters.AddWithValue("@name", Emp.Name);
            cmd.Parameters.AddWithValue("@dept", Emp.Department);
            cmd.Parameters.AddWithValue("@salary", Emp.Salary);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            if (i >= 1)
            {
                return true;
            }


            return false;
        }

        //Update a record into a database table 
        public bool update(EmployeeModel Emp)
        {

            SqlCommand cmd = new SqlCommand("update tbl_emp set Name=@name, Dept=@dept, Salary=@salary where Id = @id", con);
            cmd.Parameters.AddWithValue("@name", Emp.Name);
            cmd.Parameters.AddWithValue("@dept", Emp.Department);
            cmd.Parameters.AddWithValue("@salary", Emp.Salary);
            cmd.Parameters.AddWithValue("@id", Emp.Id);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            if (i >= 1)
            {
                return true;
            }


            return false;
        }

        //delete a record from a database table 
        public bool delete(EmployeeModel Emp)
        {

            SqlCommand cmd = new SqlCommand("delete tbl_emp where Id = @id", con);
            cmd.Parameters.AddWithValue("@id", Emp.Id);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            if (i >= 1)
            {
                return true;
            }
            return false;
        }


        //[Required(ErrorMessage = "Please enter Name")] 
        //[Display(Name = "Enter Name:")] 
        //public string Name { get; set; } 
        //[Required] 
        //public string Department { get; set; } 
        //[Required(ErrorMessage = "Please enter Salary")] 
        //[Range(2000, 10000, ErrorMessage = "Salary must be between 2k to 10K")] 
        //public int Salary { get; set; } 
    }
}


