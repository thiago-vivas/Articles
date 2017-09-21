using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ActionResults.Controllers
{
    public class ActionResultsController : Controller
    {

        public ActionResult Index()
        {

            return View();
        }
        // GET: ActionResults
        public ViewResult ViewResultSample()
        {
            return View();
        }
        public PartialViewResult PartialViewResultSample()
        {
            return PartialView("_PartialViewResultSample");
        }
        public RedirectResult RedirectResultSample()
        {
            return Redirect("Index");
        }
        public RedirectToRouteResult RedirectToRouteResultSample()
        {
            return RedirectToRoute(new { Controller = "Home", Action = "Index" });
        }
        public ContentResult ContentResultSample()
        {
            return Content("ContentResult Sample");
        }
        public JsonResult JsonResultSample()
        {
            Dictionary<int, string> Clients = new Dictionary<int, string>();
            Clients.Add(1, "Client1");
            Clients.Add(2, "Client2");
            Clients.Add(3, "Client3");
            Clients.Add(4, "Client4");

            return Json(Clients.ToList(), JsonRequestBehavior.AllowGet);
        }


        public JavaScriptResult JavaScriptResultSample()
        {
            string jsData = @" $('#updateTime').html('" + DateTime.Now.ToLocalTime() + "')";
            return JavaScript(jsData);
        }
        public HttpStatusCodeResult HttpStatusCodeResultSample()
        {
            return new HttpStatusCodeResult(HttpStatusCode.MethodNotAllowed, "HttpStatusCodeResult Sample");
        }
        public HttpUnauthorizedResult HttpUnauthorizedResultSample()
        {
            return new HttpUnauthorizedResult("HttpUnauthorizedResult Sample");
        }
        public HttpNotFoundResult HttpNotFoundResultSample()
        {
            return new HttpNotFoundResult("HttpNotFoundResult Sample");
        }
        public FileResult FileResultSample()
        {

            byte[] data = Encoding.UTF8.GetBytes("file result sample");
            return File(data, "text/plain");
        }
        public FileContentResult FileContentResultSample()
        {
            byte[] data = Encoding.UTF8.GetBytes("file content result sample");
            return new FileContentResult(data, "text/plain");
        }
        public FilePathResult FilePathResultSample()
        {
            return new FilePathResult("~\\Content\\bootstrap.css", "application/css");
        }
        public FileStreamResult FileStreamResultSample()
        {
            byte[] data = Encoding.UTF8.GetBytes("file stream result sample");
            var stream = new MemoryStream(data);
            var fileStreamResult = new FileStreamResult(stream, "text/plain");
            fileStreamResult.FileDownloadName = "FileStreamResultSample.txt";
            return fileStreamResult;
        }
        public EmptyResult EmptyResultSample()
        {
            return new EmptyResult();
        }
    }
}