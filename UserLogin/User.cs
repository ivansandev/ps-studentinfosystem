using System;

namespace UserLogin
{
    public class User
    {
        public System.Int32? UserId { get; set; }
        public System.String Username { get; set; }
        public System.String Password { get; set; }
        public System.String FakNum { get; set; }
        public System.Int32? Role { get; set; }
        public System.DateTime? Created { get; set; }
        public System.DateTime? ActiveTo { get; set; }

        public User() { }

        public User(string username, string password, string fak_num, int role)
        {
            this.Username = username;
            this.Password = password;
            this.FakNum= fak_num;
            this.Role = role;
        }
    }
}
