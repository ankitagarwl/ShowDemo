using ModelsLayer;
using System.Data;
//using BAL;
namespace DAL
{
    /// <summary>
    /// Summary description for IdataAccess.
    /// </summary>
    public interface IdataAccess
    {

     

        DataSet GetUserDetails();
        DataSet GetUserDetailsByID(int id);
        DataSet GetSearchResult(string searchstring);
        int InsertEmployee(Employee employee);
        int UpdateEmployee(Employee employee);
        int DeleteEmployee(int id);



    }
}