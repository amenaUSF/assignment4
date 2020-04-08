using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;
using assignment4.Models;
using assignment4.data_access_folder;
using assignment4.Controllers;

namespace assignment4.APIHandlerManager
{
  
    public class APIHandler
    {

        public ApplicationDbContext dbContext;
        
        //base url returns all the years
        static string BASE_URL = "https://webapi.nhtsa.gov/api/SafetyRatings";
//        static string API_KEY = "MjVw14hfA0dY17COvv6hojZXNIRNzNOFZKHmLcQS"; //Add your API key here inside "" - no key required for our API
        HttpClient httpClient;


        //Constructor to initialize the connection to the data source
        //pass the application db context os that its available for connection with the db
        public APIHandler(ApplicationDBContext context)
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

        /// <summary>
        /// Method to receive data from API end point as a collection of objects
        /// JsonConvert parses the JSON string into classes
        /// </summary>
        /// <returns></returns>
        public List<v_year> GetV_Years()
        {
            string PATH = BASE_URL ;
            string data = "";
            List<v_year> years= null;
            httpClient.BaseAddress = new Uri(PATH);
            {
                HttpResponseMessage response = httpClient.GetAsync(PATH).GetAwaiter().GetResult();
                if (response.IsSuccessStatusCode)
                {
                    data = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                }
                if (!data.Equals(""))
                {
                    years= JsonConvert.DeserializeObject<YearResult>(data).Results;
                }
               
            }
            return years;
        }//end of get_vyears() function to return all the years

        /* get make for each model year*/
        public List<v_make> GetV_Make(string yearname)
        {
            string PATH = BASE_URL+"/modelyear/"+yearname;
            string data = "";
            List<v_make> makes = null;
            httpClient.BaseAddress = new Uri(PATH);
            {
                HttpResponseMessage response = httpClient.GetAsync(PATH).GetAwaiter().GetResult();
                if (response.IsSuccessStatusCode)
                {
                    data = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                }
                if (!data.Equals(""))
                {
                    makes = JsonConvert.DeserializeObject<MakeResult>(data).Results;
                }

            }
            return makes;
        }//end of get_vmake() function to return all the makes for a year 

        /* get all the models for a year and a make*/
        public List<v_model> GetV_model(string yearname,string make)
        {
            string PATH = BASE_URL + "/modelyear/" + yearname + "/make/" + make;
            string data = "";
            List<v_model> models = null;
            httpClient.BaseAddress = new Uri(PATH);
            {
                HttpResponseMessage response = httpClient.GetAsync(PATH).GetAwaiter().GetResult();
                if (response.IsSuccessStatusCode)
                {
                    data = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                }
                if (!data.Equals(""))
                {
                    models = JsonConvert.DeserializeObject<ModelResult>(data).Results;
                }

            }
            return models;
        }//end of get_vmodels) function to return all the models for a year and a make

        /* get all the vehicle ids for a year and a make and a model*/
        public List<v_id> GetV_id(string yearname, string make, string model)
        {
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
        }//end of get_vids() function to return all the vehicle ids for a spefic year, make and model

        /* get safety rating details for a vehicle id*/
        public List<safetyratings> GetV_safetyrating(string vid)
        {
            string PATH = BASE_URL + "/VehicleId/" + vid;
            string data = "";
            List<safetyratings> SR = null;
            httpClient.BaseAddress = new Uri(PATH);
            {
                HttpResponseMessage response = httpClient.GetAsync(PATH).GetAwaiter().GetResult();
                if (response.IsSuccessStatusCode)
                {
                    data = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                }
                if (!data.Equals(""))
                {
                    SR = JsonConvert.DeserializeObject<SafetyRatingsResult>(data).Results;
                }

            }
            return SR;
        }//end of get_vids() function to return all the vehicle ids for a spefic year, make and model

    }
}
