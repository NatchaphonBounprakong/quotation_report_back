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
                    var obj = ctx.EQUIPMENT.Include("QUOTATION_EQUIPMENT").ToList();
                    //obj.ForEach(o =>
                    //{
                    //    o.QUOTATION_EQUIPMENT = null;
                    //});

                    var equip = (from item in obj
                                 select new
                                 {
                                     AUTO_ID= item.AUTO_ID,
                                     NAME = item.NAME,
                                     TYPE = item.TYPE,
                                     QUOTA= item.QUOTATION_EQUIPMENT != null ? item.QUOTATION_EQUIPMENT.Count():0

                                 }).ToList();

                    response.result = equip;
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

        public Response ManageEquipment(string pl)
        {
            EquipmentPayload payload = null;
            if (pl != null)
            {
                payload = Newtonsoft.Json.JsonConvert.DeserializeObject<EquipmentPayload>(pl);
            }

            Response response = new Response();
            try
            {
                using (var ctx = new QUOATATIONEntities())
                {
                    if (payload.id != 0)
                    {
                        var equipment = ctx.EQUIPMENT.Where(o => o.AUTO_ID == payload.id).FirstOrDefault();
                        if (equipment != null)
                        {
                            equipment.NAME = payload.name;
                            equipment.TYPE = payload.type;
                        }
                    }
                    else
                    {
                        var equip = new EQUIPMENT()
                        {
                            NAME = payload.name,
                            TYPE = payload.type
                        };
                        ctx.EQUIPMENT.Add(equip);
                    }
                    ctx.SaveChanges();
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

        public Response DeleteEquipment(int id)
        {
            Response response = new Response();
            try
            {
                using (var ctx = new QUOATATIONEntities())
                {
                    var equipment = ctx.EQUIPMENT.Where(o => o.AUTO_ID == id).FirstOrDefault();
                    ctx.EQUIPMENT.Remove(equipment);
                    ctx.SaveChanges();
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
