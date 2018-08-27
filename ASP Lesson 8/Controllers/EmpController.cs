using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ASP_Lesson_8.Models;

namespace ASP_Lesson_8.Controllers
{
    public class EmpController : ApiController
    {
        private GetEmpl empData = new GetEmpl();
        private GetDep depData = new GetDep();
        
        [Route("getlistEmp")]
        public List<Employee> GetEmp()
        {
            return empData.GetList();
        }

        [Route("getlistDep")]
        public List<Department> GetDep()
        {
            return depData.GetDepList();
        }

        [Route("getlistEmp/{id}")]
        public Employee GetEmp(int id)
        {
            return empData.GetEmplId(id);
        }

        [Route("getlistDep/{id}")]
        public Department GetDep(int id)
        {
            return depData.GetDepId(id);
        }

        [Route("addemployee")]
        public HttpResponseMessage Post([FromBody]Employee value)
        {
            if (empData.AddEmployee(value))
                return Request.CreateResponse(HttpStatusCode.Created);
            else return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
    }
}
