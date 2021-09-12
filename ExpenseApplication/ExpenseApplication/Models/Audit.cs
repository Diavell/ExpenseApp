using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExpenseApplication.Models
{

    //public class Audit
    //{
    //    public Guid AuditId { get; set; }
    //    public string UserName { get; set; }
    //    public string IPAddress { get; set; }
    //    public string AreaAccessed { get; set; }
    //    public DateTime Timestamp { get; set; }
    //    public string Browser { get; set; }

    //    public Audit() { }
    //}

    public class AuditAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var request = filterContext.HttpContext.Request;
            LogData audit = new LogData()
            {   
                AuditId = Guid.NewGuid(),
                UserName = (request.IsAuthenticated) ? filterContext.HttpContext.User.Identity.Name : "Anonymous",
                IPAddress = request.ServerVariables["HTTP_X_FORWARDED_FOR"] ?? request.UserHostAddress,
                Browser = request.Browser.Browser,
                AreaAccssed = request.RawUrl,
                Timestamp = DateTime.Now
            };

            ExpenseDataEntities7 context = new ExpenseDataEntities7();
            context.LogData.Add(audit);
            context.SaveChanges();
 
            base.OnActionExecuting(filterContext);
        }
    }
}