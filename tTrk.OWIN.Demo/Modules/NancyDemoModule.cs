﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;
using Nancy.Owin;

namespace tTrk.OWIN.Demo.Modules
{
    public class NancyDemoModule : NancyModule
    {

        public NancyDemoModule()
        {
            Get("/nancy",  x =>
            {
                var env = Context.GetOwinEnvironment();
                return "Hello from Nancy! You requested :" + env["owin.RequestPathBase"] + env["owin.RequestPath"];
            });
        }
    }
}