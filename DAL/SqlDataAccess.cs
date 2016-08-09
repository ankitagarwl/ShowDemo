using System;
using Microsoft.ApplicationBlocks.Data;
using System.Data;
using System.Data.SqlClient;
using DAL;
using ModelsLayer;

namespace DAL
{
    /// <summary>
    /// Summary description for sqlDataAccess.
    /// </summary>
    public class SqlDataAccess : IdataAccess
    {
        // All the implementation of signatures goes here 
        string m_Connection_String = "Data Source = DESKTOP-JVONE3B; Initial Catalog = Test; Integrated Security = true";

        public SqlDataAccess(string _ConnectionString)
        {
            m_Connection_String = _ConnectionString;
        }

        public DataSet GetUserDetails()
        {
            int CurrentPage = 1;
            int PageSize = 10;
            DataSet dtStAdminLogin;
            SqlParameter[] arrParam = new SqlParameter[2];
            arrParam[0] = new SqlParameter("@PageSize", PageSize);
            arrParam[1] = new SqlParameter("@CurrentPage", CurrentPage);
            dtStAdminLogin = SqlHelper.ExecuteDataset(m_Connection_String, CommandType.StoredProcedure, "getEmployeeDetails_new", arrParam);
            return dtStAdminLogin;
        }

        public DataSet GetUserDetailsByID(int id)
        {
            DataSet dtStAdminLogin;
            SqlParameter[] arrParam = new SqlParameter[1];

            arrParam[0] = new SqlParameter("@id", id);
            //arrParam[1] = new SqlParameter("@Pwd", objAdminLogin.password);
            //arrParam[2] = new SqlParameter("@IPAddress", objAdminLogin.IPAddress);

            dtStAdminLogin = SqlHelper.ExecuteDataset(m_Connection_String, CommandType.StoredProcedure, "getEmployeeDetailsByID_new", arrParam);

            return dtStAdminLogin;
        }

        public int InsertEmployee(Employee employee)
        {
            DataSet dtStAdminLogin;
            SqlParameter[] arrParam = new SqlParameter[10];

            
            arrParam[0] = new SqlParameter("@First_Name", employee.First_Name);
            arrParam[1] = new SqlParameter("@Last_Name", employee.Last_Name);
            arrParam[2] = new SqlParameter("@Email_Id", employee.Email_Id);
            arrParam[3] = new SqlParameter("@Worker_Id", employee.Worker_Id);
            arrParam[4] = new SqlParameter("@Role_Id", employee.Role_Id);
            arrParam[5] = new SqlParameter("@InsertedBy", employee.InsertedBy);
            arrParam[6] = new SqlParameter("@ModifiedBy", employee.ModifiedBy);
            arrParam[7] = new SqlParameter("@Status", employee.Status);
            arrParam[8] = new SqlParameter("@Action", employee.Action);
            arrParam[9] = new SqlParameter("@id", employee.Id);
            dtStAdminLogin = SqlHelper.ExecuteDataset(m_Connection_String, CommandType.StoredProcedure, "InsertUpdateEmployee", arrParam);
            return Convert.ToInt32(dtStAdminLogin.Tables[0].Rows[0]["status"]);
        }

        public int UpdateEmployee(Employee employee)
        {
            DataSet dtStAdminLogin;
            SqlParameter[] arrParam = new SqlParameter[10];

            arrParam[0] = new SqlParameter("@id", employee.Id);
            arrParam[1] = new SqlParameter("@First_Name", employee.First_Name);
            arrParam[2] = new SqlParameter("@Last_Name", employee.Last_Name);
            arrParam[3] = new SqlParameter("@Email_Id", employee.Email_Id);
            arrParam[4] = new SqlParameter("@Worker_Id", employee.Worker_Id);
            arrParam[5] = new SqlParameter("@Role_Id", employee.Role_Id);
            arrParam[6] = new SqlParameter("@InsertedBy", employee.InsertedBy);
            arrParam[7] = new SqlParameter("@ModifiedBy", employee.ModifiedBy);
            arrParam[8] = new SqlParameter("@Status", employee.Status);
            arrParam[9] = new SqlParameter("@Action", employee.Action);
            dtStAdminLogin = SqlHelper.ExecuteDataset(m_Connection_String, CommandType.StoredProcedure, "InsertUpdateEmployee", arrParam);
            return Convert.ToInt32(dtStAdminLogin.Tables[0].Rows[0]["status"]);
        }

        public int DeleteEmployee(int id)
        {
            DataSet dtStAdminLogin;
            SqlParameter[] arrParam = new SqlParameter[1];
            arrParam[0] = new SqlParameter("@id", id);
            dtStAdminLogin = SqlHelper.ExecuteDataset(m_Connection_String, CommandType.StoredProcedure, "DeleteEmployee_new", arrParam);
            return Convert.ToInt32(dtStAdminLogin.Tables[0].Rows[0]["status"]);
        }

        public DataSet GetSearchResult(string searchstring)
        {
            DataSet dtStAdminLogin;
            SqlParameter[] arrParam = new SqlParameter[1];
            arrParam[0] = new SqlParameter("@searchstring", searchstring);
            dtStAdminLogin = SqlHelper.ExecuteDataset(m_Connection_String, CommandType.StoredProcedure, "GetSearchResult", arrParam);
            return dtStAdminLogin;
        }
    }
}


