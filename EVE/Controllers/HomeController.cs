using EVE.Data;
using EVE.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace EVE.Controllers
{
    [DataContract]
    public class DataPoint
    {
        public DataPoint(double y=0,string label="")
        {
            //this.X = x;
            this.Y = y;
            this.Label = label;
        }

        //[DataMember(Name = "x")]
        //public Nullable<double> X = null;

        [DataMember(Name = "y")]
        [JsonProperty("y")]
        public Nullable<double> Y = null;

        [DataMember(Name = "label")]
        [JsonProperty("label")]
        public string Label = "";
    }
    public class HomeController : Controller
    {
        private readonly EVEContext _context;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, EVEContext context)
        {
            _logger = logger;
            _context = context;
        }


        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Developers()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Shipping()
        {
            return View();
        }

        public IActionResult WebsiteTerms()
        {
            return View();
        }

        public IActionResult Carees()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //[Authorize]
        public ActionResult Graphs()
        {

            List<DataPoint> dataPoints = new List<DataPoint>();

            int i = 0;
            for (var day = DateTime.Today.AddDays(-7).Date; day.Date <= DateTime.Today.Date; day = day.AddDays(1))
            {
                int ordercount = _context.OrderDetail.Where(d => d.OrderDate.Date == day).Count();
                DataPoint tempdp = new DataPoint();
                tempdp.Label = day.Date.ToShortDateString();
                tempdp.Y = ordercount +i;
                dataPoints.Add(tempdp);
                i++;
                
            }
            ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);
            ViewBag.DataPoints2 = dataPoints;
            return View();

        }
        //[Authorize(Roles = "Admin")]
        public ActionResult Graph2()
        {

            List<DataPoint> dataPoints = new List<DataPoint>();
            var productTypes = _context.ProductType.Select(p=>p.Name).ToList();
            double numofproducts = _context.Product.Select(p => p.ProductID).Count();
            foreach (var type in productTypes)
            {
                double typecount = _context.Product.Where(p => p.ProductType.Name.Equals(type)).Count();
                DataPoint tempdp = new DataPoint();
                tempdp.Label = type;
                tempdp.Y = (typecount / numofproducts)*100 ;
                dataPoints.Add(tempdp);


            }
            ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);
            return View();

        }
    }

}
