using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using TrashCollector.Models;


namespace TrashCollector.Controllers
{
    public class EmployeeController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        public EmployeeController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        public EmployeeController()
        {

        }
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }
        // GET: /Employee/GetZipList
        public ActionResult GetZipList()
        {
            //Figure this out var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>());

            return View();
        }
        // POST /Employee/GetZipList
        [HttpPost]
        public async Task<ActionResult> GetZipList(GetZipListViewModel model)
        {
            model.Pickups = new List<PickupModel>();
            foreach (User a in UserManager.Users)
            {
                if (a.RoleId == 0)
                {
                    if (a.Zip == model.Zip && a != null && a.Pickupday == DateTime.Now.DayOfWeek)
                    {
                        if (!VacationCheck(a.StartDate, a.EndDate))
                        {
                            PickupModel pickup = new PickupModel();
                            pickup.LastName = a.LastName.ToString();
                            pickup.Address = (a.Address);
                            pickup.Day = (a.Pickupday.ToString());
                            pickup.Zip =(a.Zip.ToString());
                            model.Pickups.Add(pickup);                           
                        }
                    }
                }
            }
            return View("ShowRouteList", model);
            
        }

        public ActionResult ShowRouteList(GetZipMapViewModel model)
        {
            return View(model);
        }

        //helper method
        public bool VacationCheck(DateTime start, DateTime end)
        {
            DateTime defaultDate = new DateTime(2000, 1, 1);
            if(start != defaultDate)
            {
                if(DateTime.Now.Date <= start && DateTime.Now.Date >= end)
                {
                    return true;
                }
            }
            return false;
        }

        public ActionResult Map()
        {
            return View();
        }
        public ActionResult MapRoute(GetZipMapViewModel model)
        {
            return View(model);
        }
        // GET: /Employee/GetZipMap
        public ActionResult GetZipMap()
        {
            return View();
        }
        // POST /Employee/GetZipMap
        [HttpPost]
        public async Task<ActionResult> GetZipMap(GetZipMapViewModel model)
        {
            model.Pickup = new List<PickupMapModel>();
            foreach (User a in UserManager.Users)
            {
                if (a.RoleId == 0)
                {
                    if (a.Zip == model.Zip && a != null && a.Pickupday == DateTime.Now.DayOfWeek)
                    {
                        if (!VacationCheck(a.StartDate, a.EndDate))
                        {
                            string address = a.Address;
                            string requestUri = string.Format("http://maps.googleapis.com/maps/api/geocode/xml?address={0}&sensor=false", Uri.EscapeDataString(address));

                            WebRequest request = WebRequest.Create(requestUri);
                            WebResponse response = request.GetResponse();
                            XDocument xdoc = XDocument.Load(response.GetResponseStream());

                            XElement result = xdoc.Element("GeocodeResponse").Element("result");
                            XElement locationElement = result.Element("geometry").Element("location");
                            XElement lat = locationElement.Element("lat");
                            XElement lng = locationElement.Element("lng");
                            PickupMapModel pickup = new PickupMapModel();
                            pickup.LastName = a.LastName.ToString();
                            pickup.Address = (a.Address);
                            pickup.Day = (a.Pickupday.ToString());
                            pickup.Zip = (a.Zip.ToString());
                            pickup.Lat = lat.Value.ToString();
                            pickup.Lng = lng.Value.ToString();
                            model.Pickup.Add(pickup);
                        }
                    }
                }
            }
           
            return View("MapRoute", model);
        }
    }
}