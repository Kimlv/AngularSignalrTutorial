using com.ded.angularsignalr.www.Models.PocoFactories;
using com.ded.angularsignalr.www.Models.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace com.ded.angularsignalr.www.Models
{
    public class UserModel
    {
        public delegate void RaiseUserRetrievedDelegate(UserPoco user);

        public RaiseUserRetrievedDelegate OnUserRetrieved;

        public UserModel()
        {

        }
        public List<UserPoco> GetUsers()
        {
            return UserPocoFactory.GetUserPocos();
        }

        public void GetUsersAsync()
        {
            List<UserPoco> users = UserPocoFactory.GetUserPocos();
            if (this.OnUserRetrieved != null)
            {
                foreach (UserPoco user in users)
                {
                    this.OnUserRetrieved(user);
                }
            }
        }

        public UserPoco AddUser(UserPoco userPoco)
        {
            AngularSignalrDemoEntities context = new AngularSignalrDemoEntities();
            User user = new User();
            user.UserName = userPoco.UserName;
            user.Email = userPoco.Email;
            user.FirstName = userPoco.FirstName;
            user.LastName = userPoco.LastName;
            context.Users.Add(user);
            context.SaveChanges();

            return UserPocoFactory.GetUserPoco(user);
        }

        public void AddUserAsync(UserPoco user)
        {
            this.AddUser(user);
            if (this.OnUserRetrieved != null)
            {
                this.OnUserRetrieved(user);
            }
        }
    }
}