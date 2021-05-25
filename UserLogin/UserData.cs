using System;
using System.Collections.Generic;
using System.Linq;

namespace UserLogin
{
    public static class UserData
    {
        private static List<User> _testUsers = new List<User>();

        public static List<User> TestUsers
        {
            get
            {
                ResetTestUserData();
                return _testUsers;
            }
            set { }
        }

        public static User IsUserPassCorrect(string username, string password)
        {
            try
            {
                UserContext context = new UserContext();
                return (from user in context.Users where user.Username == username && user.Password == password select user).First();
            }
            catch (System.InvalidOperationException)
            {
                return null;
            }
        }

        private static void ResetTestUserData()
        {
            _testUsers.Add(new User
            {
                Username = "admin",
                Password = "12345",
                FakNum = "7777777",
                Role = 1
            });

            _testUsers.Add(new User
            {
                Username = "student1",
                Password = "111111",
                FakNum = "121218000",
                Role = 4
            });

            _testUsers.Add(new User
            {
                Username = "student2",
                Password = "222222",
                FakNum = "7654321",
                Role = 4
            });

            DateTime now = DateTime.Now;
            foreach(User user in _testUsers)
            {
                user.Created = now;
                user.ActiveTo = DateTime.MaxValue;
            }
        }

        public static void SetUserActiveTo(string username, DateTime newActiveDate)
        {
            UserContext context = new UserContext();
            foreach(User user in context.Users)
            {
                if (user.Username.Equals(username))
                {
                    Logger.LogActivity("Промяна на активност на " + username);
                    user.ActiveTo = newActiveDate;
                }
            }
            context.SaveChanges();
        }

        public static void AssignUserRole(string username, UserRoles newRole)
        {
            UserContext context = new UserContext();
            foreach (User user in context.Users)
            {
                if (user.Username.Equals(username))
                {
                    Logger.LogActivity("Промяна на роля на " + username);
                    user.Role = Convert.ToInt32(newRole);
                }
            }
            context.SaveChanges();
        }
    }
}
