using QUOTATION.DAL;
using QUOTATION.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUOTATION.SERVICE
{

    public class QuotationService
    {
        public Response response;

        public Response SaveQuotaion(string pl)
        {
            QuotationPayload payload = Newtonsoft.Json.JsonConvert.DeserializeObject<QuotationPayload>(pl);
            response = new Response();

            try
            {
                DAL.QUOTATION q = new DAL.QUOTATION()
                {
                    NO = payload.NO,
                    TYPE = payload.TYPE,
                    BOSS_RATE = payload.BOSS_RATE == null ? 0 : Convert.ToDecimal(payload.BOSS_RATE),
                    BOSS_SHIFT_1 = payload.BOSS_SHIFT_1 == null ? 0 : Convert.ToInt32(payload.BOSS_SHIFT_1),
                    BOSS_SHIFT_2 = payload.BOSS_SHIFT_2 == null ? 0 : Convert.ToInt32(payload.BOSS_SHIFT_2),
                    GUARD_MAN_RATE = payload.GUARD_MAN_RATE == null ? 0 : Convert.ToDecimal(payload.GUARD_MAN_RATE),
                    GUARD_MAN_SHIFT_1 = payload.GUARD_MAN_SHIFT_1 == null ? 0 : Convert.ToInt32(payload.GUARD_MAN_SHIFT_1),
                    GUARD_MAN_SHIFT_2 = payload.GUARD_MAN_SHIFT_2 == null ? 0 : Convert.ToInt32(payload.GUARD_MAN_SHIFT_2),
                    GUARD_WOMAN_RATE = payload.GUARD_WOMAN_RATE == null ? 0 : Convert.ToDecimal(payload.GUARD_WOMAN_RATE),
                    GUARD_WOMAN_SHIFT_1 = payload.GUARD_WOMAN_SHIFT_1 == null ? 0 : Convert.ToInt32(payload.GUARD_WOMAN_SHIFT_1),
                    GUARD_WOMAN_SHIFT_2 = payload.GUARD_WOMAN_SHIFT_2 == null ? 0 : Convert.ToInt32(payload.GUARD_WOMAN_SHIFT_2),
                    BAIL_RATE = payload.BAIL_RATE,
                    CREATE_DATE = payload.CREATE_DATE,
                    SALE_OFFICE_ID = payload.SALE_OFFICE_ID,
                    CONTACT_ID = payload.CONTACT_ID,
                    EMPLOYEE_ID = payload.EMPLOYEE_ID,
                };

                using (QUOATATIONEntities ctx = new QUOATATIONEntities())
                {
                    var qObj = ctx.QUOTATION.Add(q);
                    ctx.SaveChanges();


                    List<NOTE> notes = new List<NOTE>();
                    foreach (var item in payload.NOTE)
                    {
                        if (item != "")
                        {
                            NOTE note = new NOTE()
                            {
                                DETAIL = item,
                            };
                            notes.Add(note);
                        }

                    }

                    var nObj = ctx.NOTE.AddRange(notes);
                    ctx.SaveChanges();

                    List<QUOTATION_NOTE> qNotes = new List<QUOTATION_NOTE>();
                    foreach (var item in nObj)
                    {


                        QUOTATION_NOTE qNote = new QUOTATION_NOTE()
                        {
                            QUOTATION_ID = q.AUTO_ID,
                            NOTE_ID = item.AUTO_ID
                        };

                        qNotes.Add(qNote);



                    }
                    ctx.QUOTATION_NOTE.AddRange(qNotes);
                    ctx.SaveChanges();

                    List<QUOTATION_EQUIPMENT> qEquipments = new List<QUOTATION_EQUIPMENT>();
                    foreach (var item in payload.EQUIPMENT_ID)
                    {

                        QUOTATION_EQUIPMENT equip = new QUOTATION_EQUIPMENT()
                        {
                            EQUIPMENT_ID = item,
                            QUOTATION_ID = qObj.AUTO_ID,
                        };
                        qEquipments.Add(equip);


                    }

                    ctx.QUOTATION_EQUIPMENT.AddRange(qEquipments);

                    ctx.SaveChanges();
                    response.result = q.AUTO_ID;
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
        public Response EditQuotaion(string pl)
        {
            QuotationPayload payload = Newtonsoft.Json.JsonConvert.DeserializeObject<QuotationPayload>(pl);
            response = new Response();

            try
            {


                using (QUOATATIONEntities ctx = new QUOATATIONEntities())
                {
                    var quoat = ctx.QUOTATION.Where(o => o.AUTO_ID == payload.AUTO_ID).FirstOrDefault();

                    if (quoat != null)
                    {
                        quoat.NO = payload.NO;
                        quoat.TYPE = payload.TYPE;
                        quoat.BOSS_RATE = payload.BOSS_RATE == null ? 0 : Convert.ToDecimal(payload.BOSS_RATE);
                        quoat.BOSS_SHIFT_1 = payload.BOSS_SHIFT_1 == null ? 0 : Convert.ToInt32(payload.BOSS_SHIFT_1);
                        quoat.BOSS_SHIFT_2 = payload.BOSS_SHIFT_2 == null ? 0 : Convert.ToInt32(payload.BOSS_SHIFT_2);
                        quoat.GUARD_MAN_RATE = payload.GUARD_MAN_RATE == null ? 0 : Convert.ToDecimal(payload.GUARD_MAN_RATE);
                        quoat.GUARD_MAN_SHIFT_1 = payload.GUARD_MAN_SHIFT_1 == null ? 0 : Convert.ToInt32(payload.GUARD_MAN_SHIFT_1);
                        quoat.GUARD_MAN_SHIFT_2 = payload.GUARD_MAN_SHIFT_2 == null ? 0 : Convert.ToInt32(payload.GUARD_MAN_SHIFT_2);
                        quoat.GUARD_WOMAN_RATE = payload.GUARD_WOMAN_RATE == null ? 0 : Convert.ToDecimal(payload.GUARD_WOMAN_RATE);
                        quoat.GUARD_WOMAN_SHIFT_1 = payload.GUARD_WOMAN_SHIFT_1 == null ? 0 : Convert.ToInt32(payload.GUARD_WOMAN_SHIFT_1);
                        quoat.GUARD_WOMAN_SHIFT_2 = payload.GUARD_WOMAN_SHIFT_2 == null ? 0 : Convert.ToInt32(payload.GUARD_WOMAN_SHIFT_2);
                        quoat.BAIL_RATE = payload.BAIL_RATE;
                        quoat.CREATE_DATE = payload.CREATE_DATE;
                        quoat.SALE_OFFICE_ID = payload.SALE_OFFICE_ID;
                        quoat.CONTACT_ID = payload.CONTACT_ID;
                        quoat.EMPLOYEE_ID = payload.EMPLOYEE_ID;
                    }

                    var deletedQNotes = ctx.QUOTATION_NOTE.Where(o => o.QUOTATION_ID == quoat.AUTO_ID).ToList();
                    var deletedQNotesIds = deletedQNotes.Select(o => o.NOTE_ID).ToList();
                    var deletedNotes = ctx.NOTE.Where(o => deletedQNotesIds.Contains(o.AUTO_ID)).ToList();
                    ctx.QUOTATION_NOTE.RemoveRange(deletedQNotes);
                    ctx.NOTE.RemoveRange(deletedNotes);

                    List<NOTE> notes = new List<NOTE>();
                    foreach (var item in payload.NOTE)
                    {
                        if (item != "")
                        {
                            NOTE note = new NOTE()
                            {
                                DETAIL = item,
                            };
                            notes.Add(note);
                        }
                    }

                    var nObj = ctx.NOTE.AddRange(notes);
                    ctx.SaveChanges();

                    List<QUOTATION_NOTE> qNotes = new List<QUOTATION_NOTE>();
                    foreach (var item in nObj)
                    {
                        QUOTATION_NOTE qNote = new QUOTATION_NOTE()
                        {
                            QUOTATION_ID = quoat.AUTO_ID,
                            NOTE_ID = item.AUTO_ID
                        };

                        qNotes.Add(qNote);
                    }
                    ctx.QUOTATION_NOTE.AddRange(qNotes);
                    ctx.SaveChanges();


                    var deletedQEquipments = ctx.QUOTATION_EQUIPMENT.Where(o => o.QUOTATION_ID == quoat.AUTO_ID).ToList();
                    ctx.QUOTATION_EQUIPMENT.RemoveRange(deletedQEquipments);

                    List<QUOTATION_EQUIPMENT> qEquipments = new List<QUOTATION_EQUIPMENT>();
                    foreach (var item in payload.EQUIPMENT_ID)
                    {
                        QUOTATION_EQUIPMENT equip = new QUOTATION_EQUIPMENT()
                        {
                            EQUIPMENT_ID = item,
                            QUOTATION_ID = quoat.AUTO_ID,
                        };
                        qEquipments.Add(equip);
                    }

                    ctx.QUOTATION_EQUIPMENT.AddRange(qEquipments);

                    ctx.SaveChanges();
                    response.result = quoat.AUTO_ID;
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
        public Response GetQuotation(int id)
        {

            response = new Response();

            try
            {

                using (QUOATATIONEntities ctx = new QUOATATIONEntities())
                {

                    var q = ctx.QUOTATION
                        .Include("QUOTATION_EQUIPMENT")
                        .Include("QUOTATION_NOTE")
                        //.Include("QUOTATION_EQUIPMENT.EQUIPMENT")
                        .Include("QUOTATION_NOTE.NOTE")
                        .Where(o => o.AUTO_ID == id).FirstOrDefault();
                    QuotationPayload quotation = new QuotationPayload()
                    {
                        AUTO_ID = q.AUTO_ID,
                        NO = q.NO,
                        TYPE = q.TYPE,
                        BOSS_RATE = q.TYPE,
                        BOSS_SHIFT_1 = q.BOSS_SHIFT_1,
                        BOSS_SHIFT_2 = q.BOSS_SHIFT_2,
                        GUARD_MAN_RATE = q.GUARD_MAN_RATE,
                        GUARD_MAN_SHIFT_1 = q.GUARD_MAN_SHIFT_1,
                        GUARD_MAN_SHIFT_2 = q.GUARD_MAN_SHIFT_2,
                        GUARD_WOMAN_RATE = q.GUARD_WOMAN_RATE,
                        GUARD_WOMAN_SHIFT_1 = q.GUARD_WOMAN_SHIFT_1,
                        GUARD_WOMAN_SHIFT_2 = q.GUARD_WOMAN_SHIFT_2,
                        BAIL_RATE = q.BAIL_RATE,
                        CREATE_DATE = q.CREATE_DATE,
                        CONTACT_ID = q.CONTACT_ID,
                        SALE_OFFICE_ID = q.SALE_OFFICE_ID,
                        EMPLOYEE_ID = q.EMPLOYEE_ID,
                    };
                    if (q != null)
                    {
                        quotation.EQUIPMENT_ID = new List<int>();
                        foreach (var equipment in q.QUOTATION_EQUIPMENT)
                        {
                            quotation.EQUIPMENT_ID.Add(equipment.EQUIPMENT_ID);
                        }

                        quotation.NOTE = new List<string>();
                        foreach (var note in q.QUOTATION_NOTE)
                        {
                            quotation.NOTE.Add(note.NOTE.DETAIL);
                        }
                    };
                    response.result = quotation;
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

        public Response GetQuotationForReport(int id)
        {

            response = new Response();

            try
            {

                using (QUOATATIONEntities ctx = new QUOATATIONEntities())
                {

                    var q = ctx.QUOTATION
                       .Include("CUSTOMER_CONTACT")
                        .Include("CUSTOMER_CONTACT.CUSTOMER")
                        .Include("SALE_OFFICE")
                        .Include("EMPLOYEE")
                        .Include("QUOTATION_EQUIPMENT")
                        .Include("QUOTATION_NOTE")
                        .Include("QUOTATION_EQUIPMENT.EQUIPMENT")
                        .Include("QUOTATION_NOTE.NOTE")
                        .Where(o => o.AUTO_ID == id).FirstOrDefault();

                    QuotationInvoice qInvoice = new QuotationInvoice()
                    {
                        no = q.NO,
                        create_date = q.CREATE_DATE.ToString(),
                        sale_name = q.EMPLOYEE != null ? q.EMPLOYEE.NAME : "",
                        sale_phone = q.EMPLOYEE != null ? q.EMPLOYEE.MOBILE : "",
                        customer_contact = q.CUSTOMER_CONTACT != null ? q.CUSTOMER_CONTACT.NAME : "",
                        customer_contact_phone = q.CUSTOMER_CONTACT != null ? q.CUSTOMER_CONTACT.MOBILE : "",
                        customer_office = q.CUSTOMER_CONTACT != null ? q.CUSTOMER_CONTACT.CUSTOMER.NAME : "",
                        guard_boss_amount1 = q.BOSS_SHIFT_1,
                        guard_boss_amount2 = q.BOSS_SHIFT_2,
                        guard_boss_rate = q.BOSS_RATE.ToString("#,##0.00"),
                        guard_boss_total = (Convert.ToDecimal(q.BOSS_SHIFT_1 + q.BOSS_SHIFT_2) * q.BOSS_RATE).ToString("#,##0.00"),
                        guard_man_amount1 = q.GUARD_MAN_SHIFT_1,
                        guard_man_amount2 = q.GUARD_MAN_SHIFT_2,
                        guard_man_rate = q.GUARD_MAN_RATE.ToString("#,##0.00"),
                        guard_man_total = (Convert.ToDecimal(q.GUARD_WOMAN_SHIFT_1 + q.GUARD_WOMAN_SHIFT_2) * q.GUARD_WOMAN_RATE).ToString("#,##0.00"),
                        guard_woman_amount1 = q.GUARD_WOMAN_SHIFT_1,
                        guard_woman_amount2 = q.GUARD_WOMAN_SHIFT_2,
                        guard_woman_rate = q.GUARD_WOMAN_RATE.ToString("#,##0.00"),
                        guard_woman_total = (Convert.ToDecimal(q.GUARD_WOMAN_SHIFT_1 + q.GUARD_WOMAN_SHIFT_2) * q.GUARD_WOMAN_RATE).ToString("#,##0.00"),
                        bali_rate = q.BAIL_RATE != null ? Convert.ToDecimal(q.BAIL_RATE).ToString("#,##0.00"):"0",

                    };
                    qInvoice.equipment_set_1 = new List<NameVal>();
                    qInvoice.equipment_set_2 = new List<NameVal>();
                    qInvoice.note = new List<NameVal>();

                    var listEquip = q.QUOTATION_EQUIPMENT.Select(o => o.EQUIPMENT.NAME).ToList();
                    var listNote = q.QUOTATION_NOTE.Select(o => o.NOTE.DETAIL).ToList();
                    //listEquip = listEquip.Distinct();
                    for (int i = 0; i < listNote.Count; i++)
                    {
                        qInvoice.note.Add(new NameVal() { name = listNote[i] });
                    }
                    for (int i = 0; i < listEquip.Count; i++)
                    {
                        if (i % 2 == 0)
                        {
                            qInvoice.equipment_set_1.Add(new NameVal() { name = listEquip[i] });
                        }
                        else
                        {
                            qInvoice.equipment_set_2.Add(new NameVal() { name = listEquip[i] });
                        }
                    }

                    qInvoice.total = (Convert.ToDecimal(qInvoice.guard_boss_total) + Convert.ToDecimal(qInvoice.guard_man_total) + Convert.ToDecimal(qInvoice.guard_woman_total)).ToString();
                    if (qInvoice.bali_rate != null)
                    {
                        qInvoice.total = (Convert.ToDecimal(qInvoice.total) +Convert.ToDecimal(qInvoice.bali_rate)).ToString("#,##0.00");
                    }

                    qInvoice.vat = ((Convert.ToDecimal(7) * Convert.ToDecimal(qInvoice.total)) / Convert.ToDecimal(100)).ToString("#,##0.00");
                    qInvoice.total_vat = (Convert.ToDecimal(qInvoice.total) + Convert.ToDecimal(qInvoice.vat)).ToString("#,##0.00");


                    response.result = qInvoice;
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
        public Response GenerateNo(int id)
        {
            response = new Response();
            try
            {

                using (QUOATATIONEntities ctx = new QUOATATIONEntities())
                {
                    var date = DateTime.Now;
                    var year = (date.Year + 543).ToString().Substring(2);
                    var quoatList = ctx.QUOTATION.Where(o => o.NO.Contains("/" + year)).Select(o => o.NO).ToList();
                    List<int> lno = new List<int>();

                    quoatList.ForEach(o =>
                    {
                        var no = Convert.ToInt32(o.Substring(0, 4));
                        lno.Add(no);
                    });


                    if (lno.Count > 0)
                    {
                        var max = lno.Max();
                        var no = (max + 1).ToString().PadLeft(4, '0') + "/" + year;
                        var currQuoat = ctx.QUOTATION.Where(o => o.AUTO_ID == id).FirstOrDefault();
                        currQuoat.NO = no;
                        response.result = currQuoat.NO;
                        response.message = currQuoat.AUTO_ID.ToString();
                    }
                    else
                    {
                        var no = (1).ToString().PadLeft(4, '0') + "/" + year;
                        var currQuoat = ctx.QUOTATION.Where(o => o.AUTO_ID == id).FirstOrDefault();
                        currQuoat.NO = no;
                        response.result = currQuoat.NO;
                        response.message = currQuoat.AUTO_ID.ToString();
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

        public Response GetListQuotation(string pl)
        {
            FilterPayload payload = null;
            if (pl != null)
            {
                payload = Newtonsoft.Json.JsonConvert.DeserializeObject<FilterPayload>(pl);
            }


            response = new Response();

            try
            {

                using (QUOATATIONEntities ctx = new QUOATATIONEntities())
                {

                    IQueryable<DAL.QUOTATION> query = ctx.QUOTATION
                        .Include("CUSTOMER_CONTACT")
                        .Include("CUSTOMER_CONTACT.CUSTOMER")
                        .Include("SALE_OFFICE")
                        .Include("EMPLOYEE")
                        .Include("QUOTATION_EQUIPMENT")
                        .Include("QUOTATION_NOTE")
                        .Include("QUOTATION_EQUIPMENT.EQUIPMENT")
                        .Include("QUOTATION_NOTE.NOTE");

                    if (payload != null)
                    {
                        if (payload.no != "" && payload.no != null)
                            query = query.Where(o => o.NO.Contains(payload.no));

                        if (payload.customer != "" && payload.customer != null)
                            query = query.Where(o => o.CUSTOMER_CONTACT.CUSTOMER.NAME.Contains(payload.customer));

                        if (payload.customer_contact != "" && payload.customer_contact != null)
                            query = query.Where(o => o.CUSTOMER_CONTACT.NAME.Contains(payload.customer_contact));

                        if (payload.create_date_from != null)
                            query = query.Where(o => o.CREATE_DATE >= payload.create_date_from);

                        if (payload.create_date_to != null)
                            query = query.Where(o => o.CREATE_DATE <= payload.create_date_to);

                        if (payload.create_by != "" && payload.create_by != null)
                            query = query.Where(o => o.EMPLOYEE.NAME.Contains(payload.create_by));

                    }


                    var rawQuotas = query.ToList();
                    var quotas = (from item in rawQuotas
                                  select new
                                  {
                                      AUTO_ID = item.AUTO_ID,
                                      NO = item.NO == "" ? "ยังไม่ได้ออกใบเสนอราคา" : item.NO,
                                      CUSTOMER = item.CUSTOMER_CONTACT != null ? item.CUSTOMER_CONTACT.CUSTOMER.NAME : "",
                                      CUSTOMER_CONTACT = item.CUSTOMER_CONTACT != null ? item.CUSTOMER_CONTACT.NAME : "",
                                      CREATE_DATE = item.CREATE_DATE != null ? Convert.ToDateTime(item.CREATE_DATE).ToString("MM/dd/yyyy") : "",
                                      EMPLOYEE_NAME = item.EMPLOYEE != null ? item.EMPLOYEE.NAME : "",
                                      TOTAL = 1000,
                                      SALE_OFFICE = item.SALE_OFFICE != null ? item.SALE_OFFICE.NAME : ""

                                  }).ToList();


                    response.result = quotas;
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
    }
}
