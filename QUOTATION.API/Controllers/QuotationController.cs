using QUOTATION.MODEL;
using QUOTATION.SERVICE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QUOTATION.API.Controllers
{
    public class QuotationController : Controller
    {
        // GET: Quotation
        QuotationService qService = new QuotationService();
        Response resp = new Response();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult SaveQuotaion(string payload)
        {
            resp = qService.SaveQuotaion(payload);
            return Json(resp, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EditQuotaion(string payload)
        {
            resp = qService.EditQuotaion(payload);
            return Json(resp, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetQuotation(int id)
        {
            resp = qService.GetQuotation(id);
            return Json(resp, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GenerateNo(int id)
        {
            resp = qService.GenerateNo(id);
            return Json(resp, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetQuotationForReport(int id)
        {
            resp = qService.GetQuotationForReport(id);
            return Json(resp, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetListQuotation(string payload)
        {
            resp = qService.GetListQuotation(payload);
            return Json(resp, JsonRequestBehavior.AllowGet);
        }
    }
}