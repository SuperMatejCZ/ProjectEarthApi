﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ProjectEarthServerAPI.Models;

namespace ProjectEarthServerAPI.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    [Route("player/environment")]
    public class LocatorController : Controller
    {

        public static String serverBaseIP = "http://93.209.243.32";

        private readonly ILogger<LocatorController> _logger;

        public LocatorController(ILogger<LocatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ContentResult Get()
        {
            LocatorResponse.Root response = new LocatorResponse.Root()
            {
                result = new LocatorResponse.Result()
                {
                    serviceEnvironments = new LocatorResponse.ServiceEnvironments()
                    {
                        production = new LocatorResponse.Production()
                        {
                            //serviceUri = "https://client.mceserv.net",
                            //cdnUri = "https://cdn.mceserv.net",
                            playfabTitleId = "11509",
                            serviceUri = serverBaseIP,
                            cdnUri = serverBaseIP+"/cdn",
                            //playfabTitleId = "F0DE2" //maybe make our own soon? - Mojang could kill this anytime after server sunset with no warning. 
                        }
                    },
                    supportedEnvironments = new LocatorResponse.SupportedEnvironments()
                    {
                        _2020121702 = new List<string>()

                    }
                },
                //updates = new LocatorResponse.Updates()
            };

            response.result.supportedEnvironments._2020121702.Add("production");
            var resp = JsonConvert.SerializeObject(response);
            return Content(resp,"application/json");

        }
    }
}