using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;

/// <summary>  
/// Summary description for ExceptionLogging  
/// article by Vithal Wadje  

/// </summary>  
public static class ExceptionLogging
{
    // All the implementation of signatures goes here 
   
      private static String exepurl;
      static SqlConnection con;


   // SendExcepToDB
      private static void connecttion()
      {
          string constr = WebConfigurationManager.AppSettings["constr"].ToString();
        con = new SqlConnection(constr);
          con.Open();
      }

      public static void SendExcepToDB(Exception exdb, int userid)
    {
        // connecttion();
        using (SqlConnection cn = new SqlConnection(WebConfigurationManager.AppSettings["constr"].ToString()))
        {
            cn.Open();
            //call the overload that takes a connection in place of the connection string
           
       
        DataSet ds = new DataSet();
        try
        {

                if (exdb.InnerException != null && exdb.InnerException.Message != null)
                {
                    exepurl = exdb.InnerException.Message;
                }
            SqlCommand com = new SqlCommand("ExceptionLoggingToDataBase", cn);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ExceptionMsg", exdb.Message.ToString());
            com.Parameters.AddWithValue("@ExceptionType", exdb.GetType().Name.ToString());
            com.Parameters.AddWithValue("@ExceptionURL", exepurl);
            com.Parameters.AddWithValue("@ExceptionSource", exdb.StackTrace.ToString());
           // com.Parameters.AddWithValue("@UserId",userid);
            com.ExecuteNonQuery();

            //ds = SqlHelper.ExecuteDataset(m_Connection_String, CommandType.StoredProcedure, "usp_GetAssignmentResult", arParam);
        }
        catch (Exception ex)
        {
           
        }
        }




    }


}