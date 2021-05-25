using System;
using System.Collections.Generic;
using System.Text;

namespace UserLogin
{
    public class Log
    {
        public System.Int32? LogId { get; set; }
        public System.DateTime? Time { get; set; }
        public System.String User { get; set; }
        public System.Int32? Role { get; set; }
        public System.String Activity { get; set; }

        public Log(DateTime time, string user, int role, string activity)
        {
            this.Time = time;
            this.User = user;
            this.Role = role;
            this.Activity = activity;
        }

        public Log() { }

        public override string ToString()
        {
            return Activity;
        }
    }
}
