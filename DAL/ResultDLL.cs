using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
//using FiitJee.DataAccess;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

/// <summary>
/// Summary description for ResultDLL
/// </summary>
public static class ResultDLL
{
    public static string ConnectionString
    {
        get
        {
            //if (AppSettings("ServerValue").ToString() == "1")
            return System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            //    else if (AppSettings("ServerValue").ToString() == "2")
            //        return System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringOnline"].ToString();
            //    else
            //        return System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringOnlineBeta"].ToString();
        }
    }
    public static DataSet GetAssignmentResult(baseResultHS objBaseResult)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] arParam = new SqlParameter[3];

            arParam[0] = new SqlParameter("@AssignmentID", SqlDbType.Int);
            arParam[0].Value = objBaseResult.assignmentId;

            arParam[1] = new SqlParameter("@StudentID", SqlDbType.Int);
            arParam[1].Value = objBaseResult.studentID;

            arParam[2] = new SqlParameter("@AttemptNo", SqlDbType.Int);
            arParam[2].Value = objBaseResult.AttemptNo;

            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "usp_GetAssignmentResult", arParam);
        }
        catch (Exception )
        {
        }

        return ds;
    }
}
