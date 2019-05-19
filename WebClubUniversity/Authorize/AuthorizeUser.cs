using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebClubUniversity.Authorize
{
    public class AuthorizeUser:AuthorizeAttribute
    {
        public static int? User_Session = null;
        public override void OnAuthorization(AuthorizationContext filterContext)
        {

            if (User_Session == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Home", action = "LoginError" }));
            }
        }
    }
}