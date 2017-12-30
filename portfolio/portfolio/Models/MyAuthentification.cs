using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace portfolio.Models
{
	public class MyAuthentification : FilterAttribute, IAuthenticationFilter

	{
		public void OnAuthentication(AuthenticationContext filterContext)
		{
			var user = filterContext.HttpContext.User;
			if (user == null || !user.Identity.IsAuthenticated)
			{
				filterContext.Result = new HttpUnauthorizedResult(); 
			}
		}

		public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
		{
			var user = filterContext.HttpContext.User;
			if (user == null || !user.Identity.IsAuthenticated)
			{
				/*filterContext.Result = new 
					RedirectToRouteResult(
					new System.Web.Routing.RouteValueDictionary {
						{"controller","Home" },{"action","LogOn"}
					}
					
					);*/
					var Result = new PartialViewResult();
				Result.ViewName = "~/Views/Shared/NotAuth.cshtml";
				filterContext.Result = Result;


			}
		}
	}
}