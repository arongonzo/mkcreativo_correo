using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Web.Routing;


[AttributeUsageAttribute(AttributeTargets.Class | AttributeTargets.Method,
    Inherited = true, AllowMultiple = true)]
public class AuthorizationAttribute : FilterAttribute, IAuthorizationFilter
{
    private readonly string _userType;
    private string[] UserProfilesRequired { get; set; }

    public AuthorizationAttribute()
    {
    }

    public AuthorizationAttribute(params object[] userProfilesRequired)
    {
        if (userProfilesRequired.Any(p => p.GetType().BaseType != typeof(Enum)))
            throw new ArgumentException("userProfilesRequired");

        this.UserProfilesRequired = userProfilesRequired.Select(p => Enum.GetName(p.GetType(), p)).ToArray();
    }

    public void OnAuthorization(AuthorizationContext filterContext)
    {
        var currentHttpContext = filterContext.RequestContext.HttpContext;
        if (!currentHttpContext.User.Identity.IsAuthenticated)
        {
            filterContext.Result = new RedirectToRouteResult(
                new RouteValueDictionary {
                  { "action", "Unauthorized" },
                  { "controller", "Home" },
                  { "area", "" }
                  }
              );
        }

        if (this.UserProfilesRequired != null)
        {
            bool authorized = false;

            foreach (var role in this.UserProfilesRequired)
                if (HttpContext.Current.User.IsInRole(role))
                {
                    authorized = true;
                    break;

                }
            if (!authorized)
            {

                filterContext.Result = new RedirectToRouteResult(
                            new RouteValueDictionary {
                          { "action", "Login" },
                          { "controller", "Account" },
                          { "area", "" },
                          { "returnUrl", HttpContext.Current.Request.Url }
                          }
                          );
            }

        }

    }
}