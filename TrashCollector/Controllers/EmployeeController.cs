﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
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
            //Figure this out var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>());

            return View();
        }
        // POST /Employee/GetZipList
        [HttpPost]
        public async Task<ActionResult> GetZipList(GetZipListViewModel model)
        {
            model.Pickups = new List<PickupModel>();
            //UserManager = new ApplicationUserManager(new UserStore<User>(context.Get<ApplicationDbContext>()));
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

        public ActionResult ShowRouteList(GetZipListViewModel model)
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
        //public async Task<ActionResult> GetZipList(GetZipListViewModel model)
        //{
        //    //ApplicationDbContext db = new ApplicationDbContext();
        //   // var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
        //    var list = new List<string>();
        //    var query = from d in UserManager.Users
        //                    where d.Zip == model.Zip
        //                    select d.Zip;
        //    return View(list);   
        //}
        public ActionResult Map()
        {
            return View();
        }
    }
}