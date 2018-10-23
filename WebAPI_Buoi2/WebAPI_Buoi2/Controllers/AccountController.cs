using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Security;
using WebAPI_Buoi2.Models;

namespace WebAPI_Buoi2.Controllers
{
    public class AccountController : ApiController
    {
        [HttpPost]
        public void Login(LoginVM data)
        {
            if (data.Username.Equals("admin"))
            {
                if (data.Password.Equals("admin"))
                {
                    FormsAuthentication.SetAuthCookie(data.Username, false);
                }
                else
                {

                }
            }
            else
            {

            }
        }
    }
}
