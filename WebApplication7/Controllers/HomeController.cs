//*********************************************************
//
// Copyright (c) Microsoft. All rights reserved.
// THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
// IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
// PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.
//
//*********************************************************

//
// HomeController.cs
//

using SampleLeak.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleLeak.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string userID = null;
            SampleLeak.Models.User user;

            //Check to see if the user is a known user 
            if (this.ControllerContext.HttpContext.Request.Cookies.AllKeys.Contains("site-user-id"))
            {
                //Retreive the user's ID from the cookie
                userID = this.ControllerContext.HttpContext.Request.Cookies["site-user-id"].Value;
            }

            //Get the user from the database
            user = UserRepository.GetUser(userID);

            //Add a cookie for future use
            if (String.IsNullOrEmpty(userID))
            {
                HttpCookie newCookie = new HttpCookie("site-user-id", user.Id);
                this.ControllerContext.HttpContext.Response.Cookies.Add(newCookie);
            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}