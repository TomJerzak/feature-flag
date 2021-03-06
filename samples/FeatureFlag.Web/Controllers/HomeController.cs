﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FeatureFlag.Web.FeatureFlags;
using Microsoft.AspNetCore.Mvc;
using FeatureFlag.Web.Models;

namespace FeatureFlag.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if(FeatureFlagWrapper.HelloWorldFeature.FeatureEnabled)
                Console.WriteLine("Hello World!");

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}