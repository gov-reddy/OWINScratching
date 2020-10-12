using Owin;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using tTrk.OWIN.Demo.Middleware;
using Nancy.Owin;
using Nancy;
using System.Web.Http;

namespace tTrk.OWIN.Demo
{
    public class Startup
    {
        public static void Configuration(IAppBuilder app)
        {
            app.UseDebugMiddleWare(new DebugMiddlewareOptions
            {

                OnIncomingRequest = (ctx) =>
                {
                    var watch = new Stopwatch();
                    watch.Start();
                    ctx.Environment["DebugStopWatch"] = watch;
                },
                OnOutgoingRequest = (ctx) =>
                {
                    var watch = (Stopwatch)ctx.Environment["DebugStopWatch"];
                    watch.Stop();
                    Debug.WriteLine("This Request took : " + watch.ElapsedMilliseconds + " ms");
                }

            });

            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            app.UseWebApi(config);
            //app.Map("/nancy", mappedApp => { mappedApp.UseNancy(); });
            app.UseNancy( configuration => {
                configuration.PassThroughWhenStatusCodesAre(HttpStatusCode.NotFound);
                });

            app.Use(async (ctx, next)=> {
                await ctx.Response.WriteAsync("Hello World..!!!");
            });
        }
    }
}