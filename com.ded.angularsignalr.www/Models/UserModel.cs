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
        public static List<UserPoco> GetUsers()
        {
            return UserPocoFactory.GetUserPocos();
        }

        public static UserPoco AddUser(UserPoco userPoco)
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
    }
}