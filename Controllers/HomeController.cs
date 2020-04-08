using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using assignment4.Models;
using assignment4.APIHandlerManager;
using Newtonsoft.Json;
using assignment4.data_access_folder;
using System.Net.Http;


namespace assignment4.Controllers
{
    public class HomeController : Controller
    {
        public ApplicationDBContext dbContext;

        //base url returns all the years
        static string BASE_URL = "https://webapi.nhtsa.gov/api/SafetyRatings";
        //        static string API_KEY = "MjVw14hfA0dY17COvv6hojZXNIRNzNOFZKHmLcQS"; //Add your API key here inside "" - no key required for our API
        HttpClient httpClient;

        /*creating a constructor for the homecontroller 
         database context is defined to connect to the db
        //Constructor to initialize the connection to the data source
        //pass the application db context os that its available for connection with the db
         instance of http client is created*/
        public HomeController(ApplicationDBContext context)
        {
            //for db part of the app
            dbContext = context;
            //for API part of the app
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            //            httpClient.DefaultRequestHeaders.Add("X-Api-Key", API_KEY);

            //header for the http request - we want our return in json 
            httpClient.DefaultRequestHeaders.Accept.Add(
            new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        /*to get all the years from the API*/
        public List<v_year> GetV_Years()
        {
            string PATH = BASE_URL;
            string data = "";
            List<v_year> years = null;
            httpClient.BaseAddress = new Uri(PATH);
            {
                HttpResponseMessage response = httpClient.GetAsync(PATH).GetAwaiter().GetResult();
                if (response.IsSuccessStatusCode)
                {
                    data = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                }
                if (!data.Equals(""))
                {
                    years = JsonConvert.DeserializeObject<YearResult>(data).Results;
                }

            }
            return years;
        }//end of get_vyears() function to return all the years

        /*action to populate the years DB*/
        public IActionResult Populateyears()
        {
            // Retrieve the companies that were saved in the symbols method
            List<v_year> years = JsonConvert.DeserializeObject<List<v_year>>(TempData["years"].ToString());

            foreach (v_year v_year in years)
            {

                //Database will give PK constraint violation error when trying to insert record with existing PK.
                //So add company only if it doesnt exist, check existence using symbol (PK)
                if (dbContext.years.Where(c => c.ModelYear.Equals(v_year.ModelYear)).Count() == 0)
                {
                    dbContext.years.Add(v_year);
                }
            }

            dbContext.SaveChanges();
            ViewBag.dbSuccessComp = 1;
            return View("Index");
        }

        public IActionResult  Index()
        {
            //Set ViewBag variable first to transfer data to DB eventually
            ViewBag.dbSuccessComp = 0;
            List<v_year> years = GetV_Years();

            //Save companies in TempData, so they do not have to be retrieved again
            TempData["years"] = JsonConvert.SerializeObject(years);

            Populateyears();
            return View();
        }




        /*  public IActionResult Index()
          {
              ApplicationDBContext context;
            //to connect to database and pass in the API handler create instance of app db context
          // to get all the years
          APIHandler webHandler = new APIHandler(context);
               List<v_year> years = webHandler.GetV_Years();//now this has all the years
              TempData["years"] = JsonConvert.SerializeObject(years);
            //List<safetyratings> SR = webHandler.GetV_safetyrating("7520");
              return View();
          }
          */

        public IActionResult aboutus()
        {
            return View();
        }
        public IActionResult carratings()
        {
            return View();
        }
        public IActionResult checkyours()
        {
            return View();
        }
        public IActionResult contactus()
        {
            return View();
        }


    }
}
