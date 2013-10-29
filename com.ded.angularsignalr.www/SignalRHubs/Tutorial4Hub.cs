using com.ded.angularsignalr.www.Models;
using com.ded.angularsignalr.www.Models.Pocos;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace com.ded.angularsignalr.www.SignalRHubs
{
    public class Tutorial4Hub : Hub
    {
        private UserModel _userModel = null;

        public Tutorial4Hub()
        {
            this._userModel = new UserModel();
            this._userModel.OnUserRetrieved += ReceiveUserEvent;
        }

        public void GetUsers()
        {
            this._userModel.GetUsersAsync();
        }

        public void AddUser(UserPoco user)
        {
           this._userModel.AddUserAsync(user);
        }

        public void ReceiveUserEvent(UserPoco user)
        {
            this.Clients.Caller.receiveUser(user);
        }
    }
}