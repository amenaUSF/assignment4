using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using assignment4.Models;
using Newtonsoft.Json;
using assignment4.data_access_folder;
using System.Net.Http;
using assignment4.Controllers;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace assignment4.Controllers
{
    public class HomeController : Controller
    {
        public ApplicationDBContext dbContext; //for connection to the db
        static string BASE_URL = "https://webapi.nhtsa.gov/api/SafetyRatings";        //base url returns all the years

        //        static string API_KEY = "MjVw14hfA0dY17COvv6hojZXNIRNzNOFZKHmLcQS"; //Add your API key here inside "" - no key required for our API
        HttpClient httpClient;


        /*creating a constructor for the homecontroller -1. database context is defined to connect to the db
         2. Constructor to initialize the connection to the data source
         3. pass the application db context os that its available for connection with the db
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
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(
            new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
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

            }
        }//end of get_vyears() function to return all the years

        /*action to populate the years DB*/
        public IActionResult Populateyears()
        {
            // Retrieve the years that were saved in the symbols method
            List<v_year> years = JsonConvert.DeserializeObject<List<v_year>>(TempData["years"].ToString());
            //List<v_year> years = JsonConvert.DeserializeObject<List<v_year>>(tem.ToString());

            foreach (v_year v_year in years)
            {
                //Database will give PK constraint violation error when trying to insert.                //So add years only if it doesnt exist, check existence using years present inside already
                if (dbContext.years.Where(c => c.ModelYear.Equals(v_year.ModelYear)).Count() == 0)
                {
                    dbContext.years.Add(v_year);
                }
            }

            dbContext.SaveChanges();
            ViewBag.dbSuccessComp = 1;
            return View("Index");
        }//end of populating the years in the db

        /* get make for each model year*/
        public List<v_make> GetV_Make(string yearname)
        {
            //initializing again so the function works in recursive calls too
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(
            new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                string PATH = BASE_URL + "/modelyear/" + yearname;
                string data = "";
                List<v_make> makes = null;
                httpClient.BaseAddress = new Uri(PATH);
                {
                    HttpResponseMessage response = httpClient.GetAsync(PATH).GetAwaiter().GetResult();
                    if (response.IsSuccessStatusCode)
                    {
                        data = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                        data = data.Replace("&", "_"); //since our API requires us to replace & with _ otherwise retreival at vehicle ids will throw error
                        data = data.Replace("/", "");
                    }
                    if (!data.Equals(""))
                    {
                        makes = JsonConvert.DeserializeObject<MakeResult>(data).Results;
                    }

                }

                return makes;
            }
        }//end of get_vmake() function to return all the makes for a year 

        /*action to populate the makes DB*/
        public IActionResult PopulateMake()
        {
            // Retrieve the years that were saved in the symbols method
            List<v_make> makes = JsonConvert.DeserializeObject<List<v_make>>(TempData["makes"].ToString());

            foreach (v_make v_make in makes)
            {
                //Database will give PK constraint violation error when trying to insert if the model and year combination already exists.                //So add years only if it doesnt exist, check existence using years present inside already
                if (dbContext.makes.Where(c => c.Make.Equals(v_make.Make) && c.ModelYear.Equals(v_make.ModelYear)).Count() == 0)
                {
                    /*                   var yearId = dbContext.years
                                            .Where(w => w.ModelYear == v_make.ModelYear)
                                            .Select(s => s.year_id).ToList();
                                        v_make.year_id = yearId[0];
                         */
                    dbContext.makes.Add(v_make);
                }
            }
            dbContext.SaveChanges();
            ViewBag.dbSuccessComp = 1;
            return View("Index");
        }//end of populating model in the db

        /* get all the models for a year and a make*/
        public List<v_model> GetV_model(string yearname, string make)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(
            new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                string PATH = BASE_URL + "/modelyear/" + yearname + "/make/" + make;
                string data = "";
                List<v_model> models = null;
                httpClient.BaseAddress = new Uri(PATH);
                {
                    HttpResponseMessage response = httpClient.GetAsync(PATH).GetAwaiter().GetResult();
                    if (response.IsSuccessStatusCode)
                    {
                        data = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                        data = data.Replace("&", "_");
                        data = data.Replace("/", "");
                    }
                    if (!data.Equals(""))
                    {
                        models = JsonConvert.DeserializeObject<ModelResult>(data).Results;
                    }

                }
                return models;
            }


        }//end of get_vmodels) function to return all the models for a year and a make


        /*action to populate the make DB*/
        public IActionResult PopulateModel()
        {
            // Retrieve the years that were saved in the symbols method
            List<v_model> models = JsonConvert.DeserializeObject<List<v_model>>(TempData["models"].ToString());

            foreach (v_model v_model in models)
            {
                if (dbContext.models.Where(c => c.Make.Equals(v_model.Make) && c.ModelYear.Equals(v_model.ModelYear) && c.Model.Equals(v_model.Model)).Count() == 0)
                {
                    /*var yearId = dbContext.makes
                        .Where(w => w.ModelYear == v_model.ModelYear)
                        .Select(s => s.year_id).ToList();
                    v_model.year_id = yearId[0];
  
                    var makeId = dbContext.makes
                       .Where(w => w.Make == v_model.Make)
                       .Select(s => s.make_id).ToList();
                    v_model.make_id = makeId[0];
                    */
                    dbContext.models.Add(v_model);
                }

            }

            dbContext.SaveChanges();
            ViewBag.dbSuccessComp = 1;
            return View("Index");
        }//end of populating models for the year and make in the db


        /* get all the vehicle ids for a year and a make and a model*/
        public List<v_id> GetV_id(string yearname, string make, string model)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(
            new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                string PATH = BASE_URL + "/modelyear/" + yearname + "/make/" + make + "/model/" + model;
                string data = "";
                List<v_id> vid = null;
                httpClient.BaseAddress = new Uri(PATH);
                {
                    HttpResponseMessage response = httpClient.GetAsync(PATH).GetAwaiter().GetResult();
                    if (response.IsSuccessStatusCode)
                    {
                        data = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();


                    }
                    if (!data.Equals(""))
                    {
                        vid = JsonConvert.DeserializeObject<VidResult>(data).Results;
                    }

                }
                return vid;
            }


        }//end of get_vids() function to return all the vehicle ids for a spefic year, make and model

        /*action to populate the ids DB*/
        public IActionResult PopulateId()
        {
            // Retrieve the years that were saved in the symbols method
            List<v_id> vids = JsonConvert.DeserializeObject<List<v_id>>(TempData["vids"].ToString());

            foreach (v_id v_id in vids)
            {
                //Database will give PK constraint violation error when trying to insert.                //So add vehicle ids only if it doesnt exist, check existence using years present inside already
                if (v_id != null)
                {
                    if (dbContext.ids.Where(c => c.VehicleId.Equals(v_id.VehicleId)).Count() == 0)
                    {
                        dbContext.ids.Add(v_id);
                    }

                }
            }

            dbContext.SaveChanges();
            ViewBag.dbSuccessComp = 1;
            return View("Index");
        }//end of populating ids for the year model and make in the db

        /* get safety rating details for a vehicle id*/
        public List<safetyratings> GetV_safetyrating(string vid)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(
            new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                string PATH = BASE_URL + "/VehicleId/" + vid;
                string data = "";
                List<safetyratings> SR = null;
                httpClient.BaseAddress = new Uri(PATH);
                {
                    HttpResponseMessage response = httpClient.GetAsync(PATH).GetAwaiter().GetResult();
                    if (response.IsSuccessStatusCode)
                    {
                        data = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                        data = data.Replace("&", "_");
                        data = data.Replace("/", "");

                    }
                    if (!data.Equals(""))
                    {
                        SR = JsonConvert.DeserializeObject<SafetyRatingsResult>(data).Results;
                    }

                }
                return SR;
            }


        }//end of get_vids() function to return all the vehicle ids for a spefic year, make and model

        /*action to populate the safety ratings DB*/
        public IActionResult PopulateSR()
        {
            // Retrieve the years that were saved in the symbols method
            List<safetyratings> safety = JsonConvert.DeserializeObject<List<safetyratings>>(TempData["safety"].ToString());

            foreach (safetyratings safetyratings in safety)
            {
                //Database will give PK constraint violation error when trying to insert.                //So add vehicle ids and their safety rating details only if it doesnt exist, check existence using vehicle ids present inside already
                if (dbContext.safety.Where(c => c.VehicleId.Equals(safetyratings.VehicleId)).Count() == 0)
                {
                    //code to get foreign keys from the other tables corresponding to the values in this table
                    var yearId = dbContext.years
                       .Where(w => w.ModelYear == safetyratings.ModelYear)
                       .Select(s => s.year_id).ToList();
                    safetyratings.year_id = yearId[0];
                    var makeId = dbContext.makes
                       .Where(w => w.Make == safetyratings.Make)
                       .Select(s => s.make_id).ToList();
                    safetyratings.make_id = makeId[0];
                    var modelId = dbContext.models
                   .Where(w => w.Model == safetyratings.Model)
                    .Select(s => s.model_id).ToList();
                    safetyratings.model_id = modelId[0];

                    dbContext.safety.Add(safetyratings);
                }
            }

            dbContext.SaveChanges();
            ViewBag.dbSuccessComp = 1;
            return View("Index");
        }//end of populating safety ratings and details in the db

        //loading data from API into our local database
        public void PopulatetheDBfromAPI()
        {
            /*
            //Set ViewBag variable first to transfer data to DB eventually
            ViewBag.dbSuccessComp = 0;

            //to get all the years

            List<v_year> years = GetV_Years();
            //Save companies in TempData, so they do not have to be retrieved again
            TempData["years"] = JsonConvert.SerializeObject(years);

            Populateyears();


            //to get makes data for each of the years in the year table
            ViewBag.dbSuccessComp = 0;
            List<v_year> years2 = dbContext.years.ToList();
            foreach (v_year v_year in years2)
            {
                List<v_make> makes = GetV_Make(v_year.ModelYear.ToString());
                TempData["makes"] = JsonConvert.SerializeObject(makes);
                PopulateMake();
            }

            //to get models data for each of the years and makes combo in the makes table
            ViewBag.dbSuccessComp = 0;
            List<v_make> makes2 = dbContext.makes.ToList();
            foreach (v_make v_make in makes2)
            {
                List<v_model> models = GetV_model(v_make.ModelYear.ToString(), v_make.Make);
                TempData["models"] = JsonConvert.SerializeObject(models);
                PopulateModel();
            }

            //to get vehicle ids (variants) available for each of the years, makes and models combo in the models table
            ViewBag.dbSuccessComp = 0;
            List<v_model> models2 = dbContext.models.ToList();
            foreach (v_model v_model in models2)
            {
                List<v_id> vids = GetV_id(v_model.ModelYear.ToString(), v_model.Make, v_model.Model);
                if (vids != null)
                {
                    TempData["vids"] = JsonConvert.SerializeObject(vids);
                    Console.WriteLine(v_model.ModelYear.ToString() + v_model.Make + v_model.Model);
                    PopulateId();
                }
            }
            */
            //to get safety ratings for each of the vehicle variants in the ids (v_ids) table
/*            ViewBag.dbSuccessComp = 0;
            List<v_id> vids2 = dbContext.ids.ToList();
            foreach (v_id v_id in vids2)
            {
                List<safetyratings> safety = GetV_safetyrating(v_id.VehicleId.ToString());
                TempData["safety"] = JsonConvert.SerializeObject(safety);
                PopulateSR();
            }
            
    */
        }


        public IActionResult Index()
          {
            //this populates the DB from the API (will run just one time to store data from API (in sequential steps) since we have to hit our API alot sequentially
            PopulatetheDBfromAPI();  
            //populate DB to make the website function
              return View();
          }
        
        public IActionResult aboutus()
        {
            return View();
        }
        public IActionResult carratings()
        {
            return View();
        }
        [HttpGet]
        public IActionResult checkyours()
        {
            //to get a list of all available options
            IEnumerable<int> yearsquery = from m in dbContext.Vehicle_Years
                                            orderby m.ModelYear
                                            select m.ModelYear
                                           ;
            IQueryable<string> makesquery = from m in dbContext.Vehicle_Makes
                                         orderby m.Make
                                         select m.Make;
            IQueryable<string> modelsquery = from m in dbContext.Vehicle_Models
                                            orderby m.Model
                                            select m.Model;
//send as blank at get
            IQueryable<safetyratingsview> view_safetyrating=null;

            SearchView viewmodel = new SearchView {
                Years = new SelectList(yearsquery.ToList()),
                Makes = new SelectList(makesquery.ToList()),
                Models = new SelectList(modelsquery.ToList()),
                safetyrating = view_safetyrating
            };
            return View(viewmodel);
        }

        [HttpPost]
        public IActionResult checkyours(string yearsearch, string makesearch, string modelsearch)
        {
            IEnumerable<int> yearsquery = from m in dbContext.Vehicle_Years
                                          orderby m.ModelYear
                                          select m.ModelYear
                               ;
            IQueryable<string> makesquery = from m in dbContext.Vehicle_Makes
                                            orderby m.Make
                                            select m.Make;
            IQueryable<string> modelsquery = from m in dbContext.Vehicle_Models
                                             orderby m.Model
                                             select m.Model;

            //var to store filtered results in and transfer to the model
            IQueryable<safetyratingsview> view_safetyrating;
            //filtered years
            var f_years = from m in dbContext.Vehicle_Years
                          select m;
            if (yearsearch != "All Years")
            {
                f_years = from m in f_years
                          where m.ModelYear == Int32.Parse(yearsearch)
                          select m;
            }
            //filtered makes
            var f_makes = from m in dbContext.Vehicle_Makes
                          select m;
            if (makesearch != "All Makes")
            {
                f_makes = from m in f_makes
                          where m.Make == makesearch
                          select m;
            }
            //filtered models
            var f_models = from m in dbContext.Vehicle_Models
                           select m;
            if (modelsearch!="All Models")
            {
                f_models = from m in f_models
                           where m.Model == modelsearch
                           select m;
            }


            //filter on year,make and model (1 - many relationship)

            view_safetyrating = from d in dbContext.Vehicle_Safetyratings
                                join c in f_years on d.year_id equals c.year_id
                                join e in f_makes on d.make_id equals e.make_id
                                join f in f_models on d.model_id equals f.model_id
                                select new safetyratingsview
                                {
                                    OverallRating = d.OverallRating,
                                    OverallFrontCrashRating = d.OverallFrontCrashRating,
                                    FrontCrashDriversideRating = d.FrontCrashDriversideRating,
                                    FrontCrashPassengersideRating = d.FrontCrashPassengersideRating,
                                    OverallSideCrashRating = d.OverallSideCrashRating,
                                    SideCrashDriversideRating = d.SideCrashDriversideRating,
                                    SideCrashPassengersideRating = d.SideCrashPassengersideRating,
                                    RolloverRating = d.RolloverRating,
                                    RolloverPossibility = d.RolloverPossibility,
                                    SidePoleCrashRating = d.SidePoleCrashRating,
                                    ComplaintsCount = d.ComplaintsCount,
                                    RecallsCount = d.RecallsCount,
                                    ModelYear = c.ModelYear,
                                    Make = e.Make,
                                    Model = f.Model,
                                    VehicleDescription = d.VehicleDescription
                                };


            SearchView viewmodel = new SearchView
            {
                Years = new SelectList(yearsquery.ToList()),
                Makes = new SelectList(makesquery.ToList()),
                Models = new SelectList(modelsquery.ToList()),

                safetyrating = view_safetyrating
            };
            return View(viewmodel);
        }

        public IActionResult carsearch(int year, string make, string model)
        {
            Console.WriteLine("in the car search");
            return View("carratings");
        }
        public IActionResult contactus()
        {
            return View();
        }


    }
}
