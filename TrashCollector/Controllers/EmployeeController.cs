using Microsoft.AspNet.Identity;
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
        public async Task<ActionResult> GetZipList(GetZipListViewModel model)
        {
            //ApplicationDbContext db = new ApplicationDbContext();
           // var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            var list = new List<string>();
            var query = from d in UserManager.Users
                            where d.Zip == model.Zip
                            select d.Zip;
            return View(list);   
        }
    }
}