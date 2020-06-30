using QUOTATION.MODEL;
using QUOTATION.SERVICE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Mail;

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

        [HttpPost]
        public EmptyResult SendEmail()
        {
            var fileName = Request.Form["file_name"].Replace("/", "_");
            HttpPostedFileBase pdf = Request.Files["pdf"];
            string path = @"C:\VMS\QuotationPdf\" + fileName + ".pdf";
            pdf.SaveAs(path);

            var id = Convert.ToInt32(Request.Form["quotation_id"]);

            var fromAddress = new MailAddress("from@gmail.com", "From Name");
            var toAddress = new MailAddress("to@example.com", "To Name");
            const string fromPassword = "fromPassword";
            const string subject = "Subject";
            const string body = "Body";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }

            return null;
        }
    }
}