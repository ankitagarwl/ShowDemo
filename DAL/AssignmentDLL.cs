using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using StaticProperty;
//using FiitJee.DataAccess;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
/// <summary>
/// Summary description for AssignmentDLL
/// </summary>
public static class AssignmentDLL
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

    public static DataSet GetUserAttempt_HS(int AssignmentID, int StudentID)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] arParam = new SqlParameter[2];

            arParam[0] = new SqlParameter("@AssignmentID", SqlDbType.Int);
            arParam[0].Value = AssignmentID;

            arParam[1] = new SqlParameter("@StudentID", SqlDbType.Int);
            arParam[1].Value = StudentID;


            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "GetUserAttempt_HS", arParam);

        }
        catch (Exception )
        {
        }

        return ds;
    }
    public static int AddAssignment(baseSetAssignment objBaseAssignment)
    {
        int Success = -1;
        try
        {
            SqlParameter[] arParam = new SqlParameter[4];

            arParam[0] = new SqlParameter("@ClassID", SqlDbType.Int);
            arParam[0].Value = objBaseAssignment.ClassID;

            arParam[1] = new SqlParameter("@SubjectID", SqlDbType.Int);
            arParam[1].Value = objBaseAssignment.SubjectID;

            arParam[2] = new SqlParameter("@NoOfAssignment", SqlDbType.Int);
            arParam[2].Value = objBaseAssignment.AssignmentNo;

            arParam[3] = new SqlParameter("@TopicID", SqlDbType.Int);
            arParam[3].Value = objBaseAssignment.TopicID;

            Success = (int)SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "AddAssignment", arParam);

        }
        catch (Exception )
        {
        }

        return Success;
    }

    public static DataSet GetAssignment(baseSetAssignment objBaseAssignment, int Status)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] arParam = new SqlParameter[3];

            arParam[0] = new SqlParameter("@ClassID", SqlDbType.Int);
            arParam[0].Value = objBaseAssignment.ClassID;

            arParam[1] = new SqlParameter("@TopicID", SqlDbType.Int);
            arParam[1].Value = objBaseAssignment.TopicID;

            arParam[2] = new SqlParameter("@Status", SqlDbType.Int);
            arParam[2].Value = Status;

            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "GetAssignment", arParam);

        }
        catch (Exception )
        {
        }

        return ds;
    }
    public static DataSet GetAssignmentReport(baseSetAssignment objBaseAssignment)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] arParam = new SqlParameter[2];

            arParam[0] = new SqlParameter("@ClassID", SqlDbType.Int);
            arParam[0].Value = objBaseAssignment.ClassID;

            arParam[1] = new SqlParameter("@SubjectID", SqlDbType.Int);
            arParam[1].Value = objBaseAssignment.SubjectID;

            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "GetAssignmentReport", arParam);

        }
        catch (Exception )
        {
        }

        return ds;
    }
    public static int SaveAssignment(baseSetAssignment objBaseAssignment)
    {
        int Success = -1;
        try
        {
            SqlParameter[] arParam = new SqlParameter[5];

            arParam[0] = new SqlParameter("@AssignmentID", SqlDbType.Int);
            arParam[0].Value = objBaseAssignment.AssignmentID;

            arParam[1] = new SqlParameter("@RuleID", SqlDbType.Int);
            arParam[1].Value = objBaseAssignment.RuleID;

            arParam[2] = new SqlParameter("@Syllabus", SqlDbType.NVarChar, 1000);
            arParam[2].Value = objBaseAssignment.Syllabus;

            arParam[3] = new SqlParameter("@Instrunction", SqlDbType.Text);
            arParam[3].Value = objBaseAssignment.Instrunction;

            arParam[4] = new SqlParameter("@Level", SqlDbType.Int);
            arParam[4].Value = objBaseAssignment.LevelID;

            Success = (int)SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "SaveAssignment", arParam);

        }
        catch (Exception )
        {
        }

        return Success;
    }

    public static DataTable GetAssignmentDetail(int RuleID)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] arParam = new SqlParameter[1];

            arParam[0] = new SqlParameter("@RuleID", SqlDbType.Int);
            arParam[0].Value = RuleID;

            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "GetAssignmentDetail", arParam);

        }
        catch (Exception )
        {
        }

        return ds.Tables[0];
    }

    public static DataTable GetAssignmentQuestion(int AssignmentID)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] arParam = new SqlParameter[1];

            arParam[0] = new SqlParameter("@AssignmentID", SqlDbType.Int);
            arParam[0].Value = AssignmentID;

            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "adp_GetAssignmentQuestion", arParam);

        }
        catch (Exception )
        {
        }

        return ds.Tables[0];
    }

    public static DataTable GetQuestionType()
    {
        DataSet ds = new DataSet();
        try
        {
            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "GetQuestionType");

        }
        catch (Exception )
        {
        }

        return ds.Tables[0];
    }

    public static int SaveQuestion(baseQuestion objBaseQuestion)
    {
        int Success = -1;
        try
        {
            SqlParameter[] arParam = new SqlParameter[8];

            arParam[0] = new SqlParameter("@QuestionNO", SqlDbType.NVarChar, 10);
            arParam[0].Value = objBaseQuestion.QuestionNO;

            arParam[1] = new SqlParameter("@QuestionImage", SqlDbType.NVarChar, 50);
            arParam[1].Value = objBaseQuestion.QuestionImage;

            arParam[2] = new SqlParameter("@SolutionImage", SqlDbType.NVarChar, 50);
            arParam[2].Value = objBaseQuestion.SolutionImage;

            arParam[3] = new SqlParameter("@QuestionType", SqlDbType.Int);
            arParam[3].Value = objBaseQuestion.QuestionType;

            arParam[4] = new SqlParameter("@Answer", SqlDbType.NVarChar, 20);
            arParam[4].Value = objBaseQuestion.Answer;

            arParam[5] = new SqlParameter("@AssignmentID", SqlDbType.NVarChar, 1000);
            arParam[5].Value = objBaseQuestion.AssignmentID;

            arParam[6] = new SqlParameter("@QuestionID", SqlDbType.Int);
            arParam[6].Value = objBaseQuestion.QuestionID;

            arParam[7] = new SqlParameter("@XML", SqlDbType.Text);

            if (objBaseQuestion.xml == null)
                arParam[7].Value = "";
            else
                arParam[7].Value = objBaseQuestion.xml.GetXml();

            Success = (int)SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "UpdateQuestion", arParam);

        }
        catch (Exception )
        {
        }

        return Success;
    }

    public static DataSet GetQuestionDetail(int QuestionID)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] arParam = new SqlParameter[1];

            arParam[0] = new SqlParameter("@QuestionID", SqlDbType.Int);
            arParam[0].Value = QuestionID;

            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "GetQuestionDetail", arParam);
        }
        catch (Exception )
        {

        }
        return ds;
    }

    public static DataTable GetFacultyAssignment(int FacultyID, int TopicID)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] arParam = new SqlParameter[2];

            arParam[0] = new SqlParameter("@FacultyID", SqlDbType.Int);
            arParam[0].Value = FacultyID;

            arParam[1] = new SqlParameter("@TopicID", SqlDbType.Int);
            arParam[1].Value = TopicID;

            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "GetFacultyAssignmentDetail", arParam);

        }
        catch (Exception )
        {
        }

        return ds.Tables[0];
    }

    public static DataTable AssignmentStatus(baseAssignmentStatus objBaseAssignmentStatus)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] arParam = new SqlParameter[3];

            arParam[0] = new SqlParameter("@AssignmentID", SqlDbType.Int);
            arParam[0].Value = objBaseAssignmentStatus.AssignmentID;

            arParam[1] = new SqlParameter("@IsPublish", SqlDbType.Bit);
            arParam[1].Value = objBaseAssignmentStatus.IsPublish;

            arParam[2] = new SqlParameter("@Reason", SqlDbType.NVarChar, 500);
            arParam[2].Value = objBaseAssignmentStatus.Reason;

            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "AssignmentStatus", arParam);
        }
        catch (Exception )
        {

        }
        return ds.Tables[0];
    }

    public static int ChangeAssignmentFaculty(int FacultyID, string AssignmentID)
    {
        int Success = -1;
        try
        {
            SqlParameter[] arParam = new SqlParameter[2];

            arParam[0] = new SqlParameter("@FacultyID", SqlDbType.Int);
            arParam[0].Value = FacultyID;

            arParam[1] = new SqlParameter("@AssignmentID", SqlDbType.NVarChar, 500);
            arParam[1].Value = AssignmentID;

            Success = (int)SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "ChangeAssignmentFaculty", arParam);

        }
        catch (Exception )
        {

        }

        return Success;
    }

    public static DataTable AssignmentRequest(int AssignmentID)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] arParam = new SqlParameter[1];
            arParam[0] = new SqlParameter("@AssignmentID", SqlDbType.Int);
            arParam[0].Value = AssignmentID;
            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "GetAssignmentRequest", arParam);           
        }
        catch (Exception )
        {
        }

        return ds.Tables[0];
    }

    public static DataTable AssignmentRequest4Approval()
    {
        DataSet ds = new DataSet();
        try
        {
            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "GetEditRequest4Approval");
        }
        catch (Exception)
        {
        }
        return ds.Tables[0];
    }

    public static DataTable GetAssignmentPreview(int AssignmentID)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] arParam = new SqlParameter[1];

            arParam[0] = new SqlParameter("@AssignmentID", SqlDbType.Int);
            arParam[0].Value = AssignmentID;

            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "AssignmentPreview", arParam);

        }
        catch (Exception )
        {
        }

        return ds.Tables[0];
    }

    public static DataSet GetAssignment4Attempt(int AssignmentID)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] arParam = new SqlParameter[1];

            arParam[0] = new SqlParameter("@AssignmentID", SqlDbType.Int);
            arParam[0].Value = AssignmentID;

            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "GetAssignment4Attempt", arParam);

        }
        catch (Exception )
        {
        }

        return ds;
    }

    public static int UpdateRequest(baseUpdateRequest objBaseRequest)
    {
        int Success = -1;
        try
        {
            SqlParameter[] arParam = new SqlParameter[3];

            arParam[0] = new SqlParameter("@RequestID", SqlDbType.Int);
            arParam[0].Value = objBaseRequest.RequestID;

            arParam[1] = new SqlParameter("@RequestStatus", SqlDbType.Int);
            arParam[1].Value = objBaseRequest.RequestStatus;

            arParam[2] = new SqlParameter("@Remark", SqlDbType.NVarChar, 100);
            arParam[2].Value = objBaseRequest.Remark;

            Success = (int)SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "UpdateRequest", arParam);

        }
        catch (Exception )
        {
        }
        return Success;
    }

    public static DataTable GetAssignmentInstrunction(int AssignmentID)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] arParam = new SqlParameter[1];

            arParam[0] = new SqlParameter("@AssignmentID", SqlDbType.Int);
            arParam[0].Value = AssignmentID;

            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "GetAssignmentInstrunction", arParam);

        }
        catch (Exception )
        {
        }

        return ds.Tables[0];
    }

    public static int SetAssignmentAttempt(int AssignmentID, int StudentID)
    {
        int Success = -1;
        try
        {
            SqlParameter[] arParam = new SqlParameter[2];

            arParam[0] = new SqlParameter("@AssignmentID", SqlDbType.Int);
            arParam[0].Value = AssignmentID;

            arParam[1] = new SqlParameter("@StudentID", SqlDbType.Int);
            arParam[1].Value = StudentID;

            Success = (int)SqlHelper.ExecuteScalar(ConnectionString, CommandType.StoredProcedure, "SetAssignmentAttempt", arParam);

        }
        catch (Exception )
        {
        }

        return Success;
    }

    public static int SetStudentAssignment(baseStudentAnswerHS objBaseStudentAssignment)
    {
        int Success = -1;
        try
        {
            SqlParameter[] arParam = new SqlParameter[7];

            arParam[0] = new SqlParameter("@StudentID", SqlDbType.Int);
            arParam[0].Value = objBaseStudentAssignment.userId;

            arParam[1] = new SqlParameter("@AssignmentID", SqlDbType.Int);
            arParam[1].Value = objBaseStudentAssignment.assignmentID;

            arParam[2] = new SqlParameter("@QuestionID", SqlDbType.Int);
            arParam[2].Value = objBaseStudentAssignment.questionId;

            arParam[3] = new SqlParameter("@QuestionTypeID", SqlDbType.Int);
            arParam[3].Value = objBaseStudentAssignment.questionTypeId;

            arParam[4] = new SqlParameter("@QuestionNumber", SqlDbType.Int);
            arParam[4].Value = objBaseStudentAssignment.questionNumber;

            arParam[5] = new SqlParameter("@Answer", SqlDbType.NVarChar);
            arParam[5].Value = objBaseStudentAssignment.answer;

            arParam[6] = new SqlParameter("@AttemptNo", SqlDbType.Int);
            arParam[6].Value = objBaseStudentAssignment.attemptNo;

            Success = (int)SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "usp_SetStudentAssignment", arParam);

        }
        catch (Exception )
        {
        }

        return Success;
    }

    public static int SetStudentAssignmentAll(baseStudentAnswerHS objBaseStudentAnswer)
    {
        int Success = -1;
        try
        {
            SqlParameter[] arParam = new SqlParameter[5];

            arParam[0] = new SqlParameter("@StudentID", SqlDbType.Int);
            arParam[0].Value = objBaseStudentAnswer.userId;

            arParam[1] = new SqlParameter("@AssignmentID", SqlDbType.Int);
            arParam[1].Value = objBaseStudentAnswer.assignmentID;

            arParam[2] = new SqlParameter("@XML", SqlDbType.Text);
            arParam[2].Value = objBaseStudentAnswer.xml;

            arParam[3] = new SqlParameter("@AttemptNo", SqlDbType.Int);
            arParam[3].Value = objBaseStudentAnswer.attemptNo;

            arParam[4] = new SqlParameter("@Min", SqlDbType.Int);
            arParam[4].Value = objBaseStudentAnswer.minuteTaken;

            Success = (int)SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "usp_SetStudentAssignmentAll", arParam);

        }
        catch (Exception )
        {
        }

        return Success;
    }

    public static DataTable DeleteAssignment(int AssignmentID)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] arParam = new SqlParameter[1];

            arParam[0] = new SqlParameter("@AssignmentID", SqlDbType.Int);
            arParam[0].Value = AssignmentID;

            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "DeleteAssignment", arParam);

        }
        catch (Exception )
        {
        }

        return ds.Tables[0];
    }

    public static DataTable GetClassAssignment(int ClassID)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] arParam = new SqlParameter[1];

            arParam[0] = new SqlParameter("@ClassID", SqlDbType.Int);
            arParam[0].Value = ClassID;

            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "GetClassAssignment", arParam);

        }
        catch (Exception )
        {
        }

        return ds.Tables[0];
    }

    public static DataTable GetClassSubjectSummary(int ClassID, int SubjectID)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] arParam = new SqlParameter[2];

            arParam[0] = new SqlParameter("@ClassID", SqlDbType.Int);
            arParam[0].Value = ClassID;

            arParam[1] = new SqlParameter("@SubjectID", SqlDbType.Int);
            arParam[1].Value = SubjectID;


            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "GetClassSubjectAssignment", arParam);
        }
        catch (Exception )
        {
        }

        return ds.Tables[0];
    }

    public static DataSet GetAssignmentMarking(int AssignmentID)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] arParam = new SqlParameter[1];

            arParam[0] = new SqlParameter("@AssignmentID", SqlDbType.Int);
            arParam[0].Value = AssignmentID;

            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "GetAssignmentMarking", arParam);

        }
        catch (Exception )
        {
        }

        return ds;
    }

    public static int UpdateSyllabus(int AssignmentID, string Syllabus, string AssignmentDate)
    {
        int Success = -1;
        try
        {
            SqlParameter[] arParam = new SqlParameter[3];

            arParam[0] = new SqlParameter("@AssignmentID", SqlDbType.Int);
            arParam[0].Value = AssignmentID;

            arParam[1] = new SqlParameter("@Syllabus", SqlDbType.NVarChar, 1000);
            arParam[1].Value = Syllabus;

            arParam[2] = new SqlParameter("@AssignmentDate", SqlDbType.Date);
            if (AssignmentDate != "")
            {
                arParam[2].Value = AssignmentDate;
            }

            Success = (int)SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "UpdateSyllabus", arParam);

        }
        catch (Exception )
        {
        }

        return Success;
    }

    public static DataSet CheckTrialAssignment(int AssignmentID, string XML)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] arParam = new SqlParameter[2];

            arParam[0] = new SqlParameter("@AssignmentID", SqlDbType.Int);
            arParam[0].Value = AssignmentID;

            arParam[1] = new SqlParameter("@XML", SqlDbType.Text);
            arParam[1].Value = XML;

            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "ChcekTrialAssignment", arParam);

        }
        catch (Exception )
        {
        }

        return ds;
    }

}
