using QUOTATION.MODEL;
using QUOTATION.SERVICE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QUOTATION.API.Controllers
{
    public class AuthController : Controller
    {
        loginService authService = new loginService();
        Response resp = new Response();
        // GET: Auth
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Login(user user)
        {
            resp = authService.Login(user);
            return Json(resp, JsonRequestBehavior.AllowGet);
        }
    }
}