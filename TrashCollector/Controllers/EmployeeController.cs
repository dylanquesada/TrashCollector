using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
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
            return View();
        }
        // POST /Employee/GetZipList
        [HttpPost]
        public ActionResult GetZipList(EmployeeViewModel model)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            if (ModelState.IsValid)
            {
                var list = new List<string>();
                var query = from d in db.Users
                            orderby d.Zip
                            select d.Zip;
                return View(list);
            }
            return View();
        }
    }
}