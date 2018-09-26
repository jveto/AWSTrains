using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrainTracker.Models;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace TrainTracker.Controllers
{
    public class HomeController : Controller
    {

        private Context _context;
        public HomeController(Context context){
            _context = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet ("Dashboard")]
        public IActionResult Dashboard () {
            return View ();
        }

        [HttpGet ("Tips")]
        public IActionResult Tips () {
            return View ();
        }

        [HttpGet]
        [Route("/map")]
        public IActionResult Map()
        {
            return View();
        }

        [HttpGet("makeDB")]
        public IActionResult DBMe(string str){
            string URL = "https://data.cityofchicago.org/resource/8mj8-j3c4.json";
            string urlParameters;

            // Create dictionary to run through each API request
            Dictionary<string, string> Stations = new Dictionary<string, string>();
            Stations.Add("red", "Red");
            Stations.Add("blue", "Blue");
            Stations.Add("g", "Green");
            Stations.Add("brn", "Brown");
            Stations.Add("p", "Purple");
            Stations.Add("pexp", "PurpleExpress");
            Stations.Add("y", "Yellow");
            Stations.Add("pnk", "Pink");
            Stations.Add("o", "Orange");

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // looping through each key, using they key as parameter
            foreach(KeyValuePair<string, string> entry in Stations){
                urlParameters = $"?{entry.Key}=true";
                HttpResponseMessage response = client.GetAsync(urlParameters).Result;
                if(response.IsSuccessStatusCode){
                    System.Console.WriteLine("Yay!");
                    // read the response as a string
                    var dataObjects = response.Content.ReadAsStringAsync().Result;
                    System.Console.WriteLine(dataObjects);
                    System.Console.WriteLine("******************************************************************************");
                    // convert the response to a json object
                    dynamic json2 = JsonConvert.DeserializeObject(dataObjects);
                    // go through each value in the call
                    
                    foreach(var x in json2){
                        TrainStation NewStation = new TrainStation();
                        NewStation.Latitude = x.location.coordinates[1];
                        NewStation.Longitude = x.location.coordinates[0];
                        NewStation.Direction = x.direction_id;
                        NewStation.MapId = x.map_id;
                        NewStation.DescStationName = x.station_descriptive_name;
                        NewStation.StationName = x.station_name;
                        NewStation.StopId = x.stop_id;
                        NewStation.StopName = x.stop_name;
                        NewStation.ada = x.ada;
                        NewStation.Blue = x.blue;
                        NewStation.Brown = x.brn;
                        NewStation.Green = x.g;
                        NewStation.Orange = x.o;
                        NewStation.Purple = x.p;
                        NewStation.PurpleExpress = x.pexp;
                        NewStation.Pink = x.pnk;
                        NewStation.Red = x.red;
                        NewStation.Yellow = x.y;
                        _context.Add(NewStation);
                        _context.SaveChanges();
                        System.Console.WriteLine(x);
                    }
                }
                else{
                    System.Console.WriteLine("Aww");
                }
                
            }
            client.Dispose();
            
            
            
            return View("dashboard");
        }
    }
}