using QUOTATION.DAL;
using QUOTATION.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUOTATION.SERVICE
{
    public class MasterServices
    {

        //Quotation quoat = Newtonsoft.Json.JsonConvert.DeserializeObject<Quotation>(payload);

        QuotationPayload quoat2 = new QuotationPayload()
        {
            AUTO_ID = 1,
            NO = "3",
            EQUIPMENT_ID = new List<int>() { 1, 2, 3, 4, 5 },
            NOTE = new List<string>()
            {
                "asdasdasdas",
                "asdasdasdas",
            },
        };

        //var json = Newtonsoft.Json.JsonConvert.SerializeObject(quoat2);

        public Response response;

        public Response GetEquipments()
        {

            var json = Newtonsoft.Json.JsonConvert.SerializeObject(quoat2);
            response = new Response();

            try
            {
                using (var ctx = new QUOATATIONEntities())
                {
                    var obj = ctx.EQUIPMENT.ToList();
                    obj.ForEach(o =>
                    {
                        o.QUOTATION_EQUIPMENT = null;
                    });

                    response.result = obj;
                    response.status = true;
                }
            }
            catch (Exception ex)
            {
                response.status = false;
                response.message = ex.Message;
                //ex.InnerException;
            }


            return response;
        }

        public Response GetCustomers()
        {

            response = new Response();

            try
            {
                using (var ctx = new QUOATATIONEntities())
                {
                    var obj = ctx.CUSTOMER.Include("CUSTOMER_CONTACT").ToList();
                    obj.ForEach(o =>
                    {
                        if (o.CUSTOMER_CONTACT.Count > 0)
                        {
                            foreach (var k in o.CUSTOMER_CONTACT)
                            {
                                k.QUOTATION = null;
                                k.CUSTOMER = null;
                        }
                        }

                    });
                    response.result = obj;
                    response.status = true;
                }
            }
            catch (Exception ex)
            {
                response.status = false;
                response.message = ex.Message;
                //ex.InnerException;
            }


            return response;
        }

        public Response GetListCustomerContact()
        {

            response = new Response();

            try
            {
                using (var ctx = new QUOATATIONEntities())
                {

                    var obj = ctx.CUSTOMER_CONTACT.ToList();

                    response.result = obj;
                    response.status = true;
                }
            }
            catch (Exception ex)
            {
                response.status = false;
                response.message = ex.Message;
                //ex.InnerException;
            }


            return response;
        }

        public Response GetSaleOffice()
        {

            response = new Response();

            try
            {
                using (var ctx = new QUOATATIONEntities())
                {
                    var obj = ctx.SALE_OFFICE.ToList();
                    obj.ForEach(o =>
                    {
                        o.QUOTATION = null;
                    });
                    response.result = obj;
                    response.status = true;
                }
            }
            catch (Exception ex)
            {
                response.status = false;
                response.message = ex.Message;

            }


            return response;
        }

    }
}
