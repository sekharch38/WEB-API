using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WEB_API_SEARCH.Models;

namespace WEB_API_SEARCH.Controllers
{
    public class SearchEmployeeController : ApiController
    {
        public IHttpActionResult getempname(string search)
        {
            EmployeeEntities entities = new EmployeeEntities();
            var result = entities.Employees.Where(x => x.First_Name.StartsWith(search) || search == null).ToList();
            return Ok(result);
        }
    }
}
