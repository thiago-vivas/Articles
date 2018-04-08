using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExceptionFilters
{
    public class CustomExceptionFilter : FilterAttribute, IExceptionFilter
    {
        public void OnException( ExceptionContext filterContext )
        {
            filterContext.Result = new RedirectResult( "Home/About" );
            filterContext.ExceptionHandled = true;
        }
    }
}