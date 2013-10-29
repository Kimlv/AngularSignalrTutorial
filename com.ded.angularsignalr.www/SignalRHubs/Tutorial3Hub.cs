using com.ded.angularsignalr.www.Models;
using com.ded.angularsignalr.www.Models.Pocos;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace com.ded.angularsignalr.www.SignalRHubs
{
    public class Tutorial3Hub : Hub
    {
        private UserModel _userModel = null;

        public Tutorial3Hub()
        {
            this._userModel = new UserModel();
        }

        public void GetUsers()
        {
            List<UserPoco> userPocos = this._userModel.GetUsers();
            this.Clients.Caller.receiveUsers(userPocos);
        }

        public void AddUser(UserPoco user)
        {
            UserPoco userPoco = this._userModel.AddUser(user);
            this.Clients.All.receiveAddedUser(userPoco);
        }
    }
}