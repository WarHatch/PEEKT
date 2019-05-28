using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TravelAgent.Cross_cutting
{
    public class TrackExecutionTime : ActionFilterAttribute, IExceptionFilter 
    {
        
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            string message = "User = " + filterContext.HttpContext.User.Identity.Name + " " + filterContext.ActionDescriptor.DisplayName + " -> OnActionExecuted \t- " +
                DateTime.Now.ToString() + "\n";
            LogExecutionTime(message);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            string message = "User = " + Environment.UserName + " " + 
                filterContext.RouteData.Values["controller"].ToString() +
                " -> " + filterContext.RouteData.Values["action"].ToString() +
                " -> OnResultExecuted \t- " + DateTime.Now.ToString() + "\n";
            LogExecutionTime(message);
            LogExecutionTime("---------------------------------------------------------\n");
        }

        public void OnException(ExceptionContext filterContext)
        {
            string message = "User = " + Environment.UserName + " " + 
               filterContext.RouteData.Values["controller"].ToString() + " -> " +
               filterContext.RouteData.Values["action"].ToString() + " -> " +
               filterContext.Exception.Message + " \t- " + DateTime.Now.ToString() + "\n";
            LogExecutionTime(message);
            LogExecutionTime("---------------------------------------------------------\n");
        }

        private void LogExecutionTime(string message)
        {
            File.AppendAllText("Output/Data.txt", message);
        }
    }
}
