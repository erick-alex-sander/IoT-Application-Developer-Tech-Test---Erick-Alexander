using CAD_IoT_Programming_Test.Models;
using CAD_IoT_Programming_Test.Models.SalaryConversion;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net;
using CAD_IoT_Programming_Test.Models.SensorAggregation;
using System.Timers;
using Newtonsoft.Json.Linq;

namespace CAD_IoT_Programming_Test.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private Timer timer;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SalaryConversion()
        {
            List<Employee> employees = new List<Employee>();
            IEnumerable<User> users = null;
            var salaries = JsonConvert.DeserializeObject<Arrays>(System.IO.File.ReadAllText(@"Json/salary_data.json"));

            using (var client = new HttpClient())
            {
                
                client.BaseAddress = new Uri("http://jsonplaceholder.typicode.com/");
                var response = client.GetStringAsync("users").Result;
                users = JsonConvert.DeserializeObject<IEnumerable<User>>(response);
            }

            var url = "https://free.currconv.com/api/v7/convert?q=USD_IDR&compact=ultra&apiKey=f255679ae15fb7f371e0";
            var webClient = new WebClient();
            var jsonData = string.Empty;
            jsonData = webClient.DownloadString(url);
            var jsonObject = JsonConvert.DeserializeObject<Dictionary<string, double>>(jsonData);


            foreach (var user in users)
            {
                Employee employee = new Employee();
                employee.Id = user.Id;
                employee.Name = user.Name;
                employee.Username = user.Username;
                employee.Email = user.Email;
                employee.Address = user.Address.Street + ", " + user.Address.Suite + ", " + user.Address.City + ", " + user.Address.zipcode;
                employee.Phone = user.Phone;
                foreach(var salary in salaries.Array)
                {
                    if (salary.Id == user.Id)
                    {
                        employee.Salary = salary.SalaryInIDR;
                        break;
                    }
                }
                
                employee.SalaryUSD = employee.Salary / jsonObject["USD_IDR"];
                employees.Add(employee);

            }
            
            return View(employees);
        }

        public IActionResult SensorAggregation()
        {
            var sensorData = JsonConvert.DeserializeObject<SensorArray>(System.IO.File.ReadAllText(@"Json/sensor_data.json")).Array.ToList();
            List<SensorDisplay> sensorDisplays = SensorAggregator(sensorData);
            return View(sensorDisplays);
        }

        public IActionResult SensorSimulation()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public JsonResult StartSimulation()
        {
            StoreToJsonFile();
            var sensorData = JsonConvert.DeserializeObject<SensorArray>(System.IO.File.ReadAllText(@"Json/sensordata.json")).Array.ToList();
            List<SensorDisplay> sensorDisplays = SensorAggregator(sensorData);
            return Json(sensorDisplays);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        



        /* Reusable References*/

        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            dateTime = dateTime.AddMilliseconds(unixTimeStamp);
            return dateTime;
        }


        public static double FindMedian (double[] sensors)
        {
            int count = sensors.Length;
            int halfIndex = count / 2;
            double median;

            if (count % 2 == 0)
            {
                median = (sensors[halfIndex] +
                    sensors[halfIndex - 1]) / 2;
            }
            else
            {
                median = sensors[halfIndex];
            }
            return median;
        }

        public List<SensorDisplay> SensorAggregator(List<SensorData> sensorDatas)
        {
            List<SensorDisplay> sensorDisplays = new List<SensorDisplay>();
            var groupDateRoom = (from sensor in sensorDatas
                                 group sensor by (sensor.RoomArea, UnixTimeStampToDateTime(sensor.Timestamp).ToString("yyyy-MM-dd"))).ToList();
            List<SensorMedian> sensorMedians = new List<SensorMedian>();

            foreach (var groupDate in groupDateRoom)
            {
                var filteredList = sensorDatas.Where(s => s.RoomArea == groupDate.Key.RoomArea).Where(s => UnixTimeStampToDateTime(s.Timestamp).ToString("yyyy-MM-dd") == groupDate.Key.Item2);
                var temperatureFilter = filteredList.OrderBy(f => f.Temperature).Select(f => f.Temperature).ToArray();
                var humidityFilter = filteredList.OrderBy(f => f.Humidity).Select(f => f.Humidity).ToArray();
                var medianT = FindMedian(temperatureFilter);
                var medianH = FindMedian(humidityFilter);
                sensorMedians.Add(new SensorMedian(groupDate.Key.RoomArea, groupDate.Key.Item2, medianT, medianH));
            }

            var query = (from sensor in sensorDatas
                         group sensor by new { sensor.RoomArea, DateStamp = UnixTimeStampToDateTime(sensor.Timestamp).ToString("yyyy-MM-dd") }
                        into grp
                         select new
                         {
                             grp.Key.RoomArea,
                             grp.Key.DateStamp,
                             maxT = grp.Max(a => a.Temperature),
                             minT = grp.Min(a => a.Temperature),
                             avgT = grp.Average(a => a.Temperature),
                             maxH = grp.Max(a => a.Humidity),
                             minH = grp.Min(a => a.Humidity),
                             avgH = grp.Average(a => a.Humidity)
                         }).ToList();

            var finalQuery = (from q in query
                              join s in sensorMedians on new { roomArea = q.RoomArea, date = q.DateStamp } equals new { roomArea = s.RoomArea, date = s.DateStamp }
                              select new
                              {
                                  RoomArea = q.RoomArea,
                                  Date = q.DateStamp,
                                  maxT = q.maxT,
                                  minT = q.minT,
                                  avgT = q.avgT,
                                  medT = s.medianT,
                                  maxH = q.maxH,
                                  minH = q.minH,
                                  avgH = q.avgH,
                                  medH = s.medianH
                              }).ToList();
            foreach (var finalquery in finalQuery)
            {
                sensorDisplays.Add(new SensorDisplay(finalquery.RoomArea, finalquery.Date, finalquery.maxT, finalquery.minT, finalquery.avgT, finalquery.medT, finalquery.maxH, finalquery.minH, finalquery.avgH, finalquery.medH));
            }
            return sensorDisplays;
        }

        public void StoreToJsonFile()
        {
            List<SensorData> sensorDatas = new List<SensorData>();
            long count = 0;
            try
            {
                sensorDatas = JsonConvert.DeserializeObject<SensorArray>(System.IO.File.ReadAllText(@"Json\sensordata.json")).Array.ToList();
                count = sensorDatas.Count;
                
            }
            catch (Exception e)
            {
                
            }

            String[] roomNames = { "roomArea1", "roomArea2", "roomArea3" };
            long timeStamp = (long)DateTime.Now.Subtract(new DateTime(1970, 1, 1)).TotalMilliseconds;
            count++;
            foreach (var roomNamed in roomNames)
            {
                sensorDatas.Add(new SensorData(count, timeStamp, GetRandomNumber(26, 35), GetRandomNumber(89, 100), roomNamed));
                count++;
            }
            
            SensorArray sensorArrays = new SensorArray();
            sensorArrays.Array = sensorDatas.ToArray();
            System.IO.File.WriteAllText(@"Json\sensordata.json", JValue.Parse(JsonConvert.SerializeObject(sensorArrays)).ToString(Formatting.Indented).ToString());

        }

        public double GetRandomNumber(double minimum, double maximum)
        {
            Random random = new Random();
            return random.NextDouble() * (maximum - minimum) + minimum;
        }
    }
}
