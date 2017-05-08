﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Web.Http.Filters;
using System.Web.Routing;


[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
public class SessionExpireAttribute : System.Web.Mvc.ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
        HttpContext ctx = HttpContext.Current;
        // check  sessions here
        if (HttpContext.Current.Session["username"] == null || !filterContext.HttpContext.Request.IsAuthenticated)
        {
            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                filterContext.Result = new JsonResult { Data = "_Logon_" };
            }
            else
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary {
                        { "Controller", "Home" },
                        { "Action", "TimeoutRedirect" }
                });
            }
            
            return;
        }
        base.OnActionExecuting(filterContext);
    }
}

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
public class LocsAuthorizeAttribute : AuthorizeAttribute
{
    protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
    {
        HttpContext ctx = HttpContext.Current;

        // If the browser session has expired...
        if (ctx.Session["UserName"] == null)
        {
            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                // For AJAX requests, we're overriding the returned JSON result with a simple string,
                // indicating to the calling JavaScript code that a redirect should be performed.
                filterContext.Result = new JsonResult { Data = "_Logon_" };
            }
            else
            {
                // For round-trip posts, we're forcing a redirect to Home/TimeoutRedirect/, which
                // simply displays a temporary 5 second notification that they have timed out, and
                // will, in turn, redirect to the logon page.
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary {
                        { "Controller", "Home" },
                        { "Action", "TimeoutRedirect" }
                });
            }
        }
        else if (filterContext.HttpContext.Request.IsAuthenticated)
        {
            // Otherwise the reason we got here was because the user didn't have access rights to the
            // operation, and a 403 should be returned.
            filterContext.Result = new HttpStatusCodeResult(403);
        }
        else
        {
            base.HandleUnauthorizedRequest(filterContext);
        }
    }
}