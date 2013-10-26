using com.ded.angularsignalr.www.Models;
using com.ded.angularsignalr.www.Models.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace com.ded.angularsignalr.www.Controllers.api
{
    public class UserController : ApiController
    {
        public List<UserPoco> Get()
        {
            return UserModel.GetUsers();
        }

        public bool Post(UserPoco userPoco)
        {
            bool result = false;
            try
            {
                UserModel.AddUser(userPoco);
                result = true;
            }
            catch { }
            return result;
        }
    }
}
