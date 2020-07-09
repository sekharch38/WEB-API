using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using WEB_API_SEARCH.Models;

namespace WEB_API_SEARCH.Controllers
{
    public class SearchController : Controller
    {
        //
        // GET: /Search/
        public ActionResult Index( string search)
        {
            IEnumerable<Employee> obj =null ;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("http://localhost:52885/api/");
            var consumeapi = hc.GetAsync("SearchEmployee?search=" + search);
            consumeapi.Wait();
            var readData = consumeapi.Result;
            if (readData .IsSuccessStatusCode)
            {
                var displayData = readData.Content.ReadAsAsync<List<Employee>>();
                displayData.Wait();
                obj = displayData.Result;

            }

            return View(obj);
        }
	}
}