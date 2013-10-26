using com.ded.angularsignalr.www.Models.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace com.ded.angularsignalr.www.Models.PocoFactories
{
    public class UserPocoFactory : PocoFactoryBase
    {
        public static UserPoco GetUserPoco(long userId)
        {
            AngularSignalrDemoEntities context = new AngularSignalrDemoEntities();
            User user = context.Users.Where(u => u.UserId == userId).FirstOrDefault<User>();
            UserPoco userPoco = (UserPoco)GetPopulatedPoco(user, typeof(UserPoco));
            return userPoco;
        }

        public static UserPoco GetUserPoco(User user)
        {
            UserPoco userPoco = (UserPoco)GetPopulatedPoco(user, typeof(UserPoco));
            return userPoco;
        }
       
        public static List<UserPoco> GetUserPocos()
        {
            AngularSignalrDemoEntities context = new AngularSignalrDemoEntities();
            IEnumerable<User> users = context.Users;
            List<UserPoco> userPocos = new List<UserPoco>();
            foreach(User user in users)
            {
                userPocos.Add(GetUserPoco(user));
            }
            return userPocos;
        }
    }
}