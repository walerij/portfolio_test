using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace portfolio.Models
{
	public class MyRoleFliter: AuthorizeAttribute 
	{
		public void OnAuthorization(AuthorizationContext filterContext)
		{
			var user = filterContext.HttpContext.User;
			if (user == null || !user.Identity.IsAuthenticated)
			{
				var Result = new PartialViewResult();
				Result.ViewName = "~/Views/Shared/NotAuth.cshtml";
				filterContext.Result = Result;

			}
		}
		public void OnAuthorizationChallenge(AuthorizationContext filterContext)
		{
			var user = filterContext.HttpContext.User;
			if (user == null || !user.Identity.IsAuthenticated)
			{
				var Result = new PartialViewResult();
				Result.ViewName = "~/Views/Shared/NotAuth.cshtml";
				filterContext.Result = Result;

			}
		}

	}
}