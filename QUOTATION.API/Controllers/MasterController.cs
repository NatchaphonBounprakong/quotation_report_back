using QUOTATION.MODEL;
using QUOTATION.SERVICE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QUOTATION.API.Controllers
{
    public class MasterController : Controller
    {
        MasterServices eqpService = new MasterServices();
        Response resp = new Response();
        // GET: Equipment
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetEquipments()
        {            
            resp = eqpService.GetEquipments();
            return Json(resp, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCustomers()
        {
            resp = eqpService.GetCustomers();
            return Json(resp, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetListCustomerContact()
        {
            resp = eqpService.GetListCustomerContact();
            return Json(resp, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetSaleOffice()
        {
            resp = eqpService.GetSaleOffice();
            return Json(resp, JsonRequestBehavior.AllowGet);
        }




    }
}