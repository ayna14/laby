using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lab1.Models
{
    public class ActionFilter : ActionFilterAttribute
    {
        DataLogs dl;
        Logs l;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            dl = new DataLogs();
            l = new Logs();
            l.action = filterContext.ActionDescriptor.ActionName;
            dl.Logs.Add(l);
            dl.SaveChanges();
        }
    }
}