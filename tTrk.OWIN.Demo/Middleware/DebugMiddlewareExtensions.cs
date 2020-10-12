using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using tTrk.OWIN.Demo.Middleware;

namespace Owin
{
    public static class DebugMiddlewareExtensions
    {

        public static void UseDebugMiddleWare(this IAppBuilder app, DebugMiddlewareOptions options = null)
        {
            if (options == null)
                options = new DebugMiddlewareOptions();

            app.Use<DebugMiddleware>(options);
        }
    }
}