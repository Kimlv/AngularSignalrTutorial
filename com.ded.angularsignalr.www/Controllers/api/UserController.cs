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
        private UserModel _userModel = null;

        public UserController()
        {
            this._userModel = new UserModel();
        }

        public List<UserPoco> Get()
        {
            return this._userModel.GetUsers();
        }

        public bool Post(UserPoco userPoco)
        {
            bool result = false;
            try
            {
                this._userModel.AddUser(userPoco);
                result = true;
            }
            catch { }
            return result;
        }
    }
}
