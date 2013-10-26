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
        public void GetUsers()
        {
            List<UserPoco> userPocos = UserModel.GetUsers();
            this.Clients.Caller.receiveUsers(userPocos);
        }

        public void AddUser(UserPoco user)
        {
            UserPoco userPoco = UserModel.AddUser(user);
            this.Clients.All.receiveAddedUser(userPoco);
        }
    }
}