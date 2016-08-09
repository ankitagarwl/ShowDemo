using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DAL;
using ModelsLayer;
using System.Web.Configuration;

namespace BAL
{
   public class Category
    { 

       public IEnumerable<Employee> GetUserDetails()
       {
           DataSet dtSt;
            string connstring = WebConfigurationManager.AppSettings["constr"].ToString();
           IdataAccess GetCategorySqlDataAccess = new SqlDataAccess(connstring);
           dtSt = GetCategorySqlDataAccess.GetUserDetails();
          // return dtSt;

            foreach (DataRow row in dtSt.Tables[0].Rows)
            {
                yield return new Employee
                {
                    Id = Convert.ToInt32(row["Id"]),
                    First_Name  = Convert.ToString(row["firstname"]),
                    Last_Name = Convert.ToString(row["lastname"]),
                    Email_Id = Convert.ToString(row["emailid"]),
                    Worker_Id = Convert.ToString(row["workerid"]),
                    Role_Id = Convert.ToInt32(row["roleid"]),
                    RoleName = Convert.ToString(row["role"])
                    //fdsf


                };
            }
        }

        public Employee GetUserById(int id)
        {
            DataSet dtSt;
            Employee employee = new Employee();
            string connstring = WebConfigurationManager.AppSettings["constr"].ToString();
            IdataAccess GetCategorySqlDataAccess = new SqlDataAccess(connstring);
            dtSt = GetCategorySqlDataAccess.GetUserDetailsByID(id);
            if (dtSt.Tables[0].Rows.Count > 0)
            {
                employee.Id = Convert.ToInt32(dtSt.Tables[0].Rows[0]["Id"]);
                employee.First_Name = Convert.ToString(dtSt.Tables[0].Rows[0]["firstname"]);
                employee.Last_Name = Convert.ToString(dtSt.Tables[0].Rows[0]["lastname"]);
                employee.Email_Id = Convert.ToString(dtSt.Tables[0].Rows[0]["emailid"]);
                employee.Worker_Id = Convert.ToString(dtSt.Tables[0].Rows[0]["workerid"]);
                employee.Role_Id = Convert.ToInt32(dtSt.Tables[0].Rows[0]["roleid"]);
                employee.RoleName = Convert.ToString(dtSt.Tables[0].Rows[0]["role"]);
            }
            return employee;


        }

        public IEnumerable<Employee> GetSearchResult(string search)
        {
            DataSet dtSt;
            Employee employee = new Employee();
            IdataAccess GetCategorySqlDataAccess = new SqlDataAccess(WebConfigurationManager.AppSettings["constr"].ToString());
            dtSt = GetCategorySqlDataAccess.GetSearchResult(search);
            foreach (DataRow row in dtSt.Tables[0].Rows)
            {
                yield return new Employee
                {
                    Id = Convert.ToInt32(row["Id"]),
                    First_Name = Convert.ToString(row["firstname"]),
                    Last_Name = Convert.ToString(row["lastname"]),
                    Email_Id = Convert.ToString(row["emailid"]),
                    Worker_Id = Convert.ToString(row["workerid"]),
                    Role_Id = Convert.ToInt32(row["roleid"]),
                    RoleName = Convert.ToString(row["role"])

                };
            }


        }

        public int InsertEmployee(Employee emp)
        {
            
            IdataAccess GetCategorySqlDataAccess = new SqlDataAccess(WebConfigurationManager.AppSettings["constr"].ToString());
            emp.Action = 1;
            emp.Status = 1;
            int status = GetCategorySqlDataAccess.InsertEmployee(emp);
            if (status == 1)
            {

            }
            else
            {

            }
            return status;


        }

        public int UpdateEmployee(Employee emp)
        {

            IdataAccess GetCategorySqlDataAccess = new SqlDataAccess(WebConfigurationManager.AppSettings["constr"].ToString());
            emp.Action = 2;
            emp.Status = 1;
            int status = GetCategorySqlDataAccess.UpdateEmployee(emp);
            if (status == 1)
            {

            }
            else
            {

            }
            return status;


        }

        public int DeleteEmployee(int Id)
        {

            IdataAccess GetCategorySqlDataAccess = new SqlDataAccess(WebConfigurationManager.AppSettings["constr"].ToString());
            int status = GetCategorySqlDataAccess.DeleteEmployee(Id);
            if (status == 1)
            {

            }
            else
            {

            }
            return status;


        }



       
    }
}
