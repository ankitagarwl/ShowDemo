using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BAL;
using ModelsLayer;
using System.Web.Http.Cors;
using Newtonsoft.Json;
using static System.Net.WebRequestMethods;
using System.Web.Mvc;
using System.Web.Http.Routing;
using InterfaceLayer;
namespace WebApplication4.Controllers
{
    //[Authorize(Roles ="adad")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ValuesController : ApiController
    {
        //readonly IUserManagement _IUserManagement;
        //public ValuesController(IUserManagement IUserManagement)
        //{
        //    this._IUserManagement = IUserManagement;
        //}

        //public ValuesController()
        //{
        //    //this._IUserManagement = IUserManagement;
        //}

        #region Get

        // api/values/
        [System.Web.Mvc.HttpGet]
        [System.Web.Mvc.Route("values/")]
        public IEnumerable<Employee> GetAllUsers()

        {
            Category ct = new Category();
            DataSet ds = new DataSet();
            var users = ct.GetUserDetails();
            return users;
        }

        //api/values/1
        [System.Web.Mvc.HttpGet]
        [System.Web.Mvc.Route("values/{id}")]
        public IEnumerable<Employee> GetUserById(int id)
        {
            List<Employee> emp = new List<Employee>();
            Category ct = new Category();
            DataSet ds = new DataSet();
            try
            {
                //throw new Exception();

                var users = ct.GetUserById(id);
                if (users == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
                emp.Add(users);

            }
            catch (Exception ex) {
                ExceptionLogging.SendExcepToDB(ex, 0);
            }
            IEnumerable<Employee> list = emp;
            return list;
        }

        //[Route("api/values/GetSearchResult/{searcheddata}")]
        [System.Web.Http.Route("Ankit/{searcheddata}")]
        [System.Web.Mvc.HttpGet]
        public IEnumerable<Employee> GetSearchResult(string searcheddata)
        {
            //Category ct = new Category();
            //DataSet ds = new DataSet();
            //var users = ct.GetUserDetails();
            //return users;

            List<Employee> emp = new List<Employee>();
            Category ct = new Category();
            DataSet ds = new DataSet();
            //try
            //{
                //throw new Exception();

                var users = ct.GetSearchResult(searcheddata);
                if (users == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
                return users;

            //}
            //catch (Exception ex)
            //{
                //ExceptionLogging.SendExcepToDB(ex, 0);
            //}
            
            
        }
        #endregion

        #region Post
        //api/values/ employee - body-json {"Id":"4","Name":"Frank11","Designation":"Chappel"}
        public HttpResponseMessage Post([FromBody]Employee employee)
        {
            Category ct = new Category();
            employee.Status = 1;
            int status = ct.InsertEmployee(employee);
            if (status != 1)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            else
            {
                var filePath = @"D:\path.json";
                // Read existing json data
                var jsonData = System.IO.File.ReadAllText(filePath);
                // De-serialize to object or create new list
                var employeeList = JsonConvert.DeserializeObject<List<Employee>>(jsonData)
                                      ?? new List<Employee>();

                // Add any new employees
                employeeList.Add(new Employee()
                {
                    Id = employee.Id,
                    First_Name = employee.First_Name,
                    Last_Name = employee.Last_Name
                });
                
                // Update json data string
                jsonData = JsonConvert.SerializeObject(employeeList);
                System.IO.File.WriteAllText(filePath, jsonData);
            }
            return Request.CreateResponse(HttpStatusCode.OK,"Employee Inserted");
        }
        #endregion

        #region Put
        //api/values/1 employee - body-json {"Id":"4","Name":"Frank11","Designation":"Chappel"}
        public HttpResponseMessage Put(int id, [FromBody]Employee employee)
        {
            Category ct = new Category();
            employee.Status = 2;
            int status = ct.UpdateEmployee(employee);
            if (status != 1)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            else
            {

                //string json = System.IO.File.ReadAllText(@"D:\path.json");
                //dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
                //jsonObj["Id"][0] = "new password";
                //string output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
                //System.IO.File.WriteAllText(@"D:\path.json", output);
            }
            return Request.CreateResponse(HttpStatusCode.OK, "Employee Updated");
        }
        #endregion

        #region Delete
        //api/values/1 
        public HttpResponseMessage DeleteUser(int id)
         {
            Category ct = new Category();
            int status = ct.DeleteEmployee(id);
            if (status != 1)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK, "Employee Deleted");
        }
        #endregion 
    }
}
