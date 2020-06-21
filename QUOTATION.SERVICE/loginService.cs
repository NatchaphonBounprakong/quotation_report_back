using QUOTATION.DAL;
using QUOTATION.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUOTATION.SERVICE
{
    public class user
    {
        public string id { get; set; }
        public string password { get; set; }

    }

    public class userData
    {
        public int id { get; set; }
        public string name { get; set; }
        public string sale_office { get; set; }
        public string mobile { get; set; }
        public DateTime expire_date { get; set; }
    }


    public class loginService
    {
        Response response;

        public Response Login(user user)
        {

            try
            {
                using (var ctx = new QUOATATIONEntities())
                {
                    response = new Response();
                    var emp = ctx.EMPLOYEE.Where(o => o.USER_NAME == user.id && o.PASSWORD == user.password).FirstOrDefault();
                    if (emp != null)
                    {
                        userData userData = new userData()
                        {
                            id = emp.AUTO_ID,
                            expire_date = DateTime.Now.AddDays(7),
                            mobile = emp.MOBILE,
                            name = emp.NAME,
                            sale_office = emp.SALE_OFFICE,
                        };
                       
                        response.status = true;
                        response.message = "valid credential";
                        response.result = userData;
                    }
                    else
                    {
                        response.status = false;
                        response.message = "invalid credential";
                    }
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
