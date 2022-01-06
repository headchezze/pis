using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFLibrary
{
    public class WorkerPresent
    {
        public string Login { get; private set; }
        public string Password { get; private set; }
        public string Organization { get; private set; }
        public string Fullname { get; private set; }

        public WorkerPresent(string fullname, string org, string login, string password)
        {
            Fullname = fullname;
            Organization = org;
            Login = login;
            Password = password;
        }
    }
}
