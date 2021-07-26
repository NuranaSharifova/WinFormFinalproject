using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormFinalproject
{
    public class User
    {
        public User(string username,  string password)
        {
            Username = username;
            Password = password;
            Posts =new List<string> ();
        }

        public string Username { get; set; }   
        public string Password { get; set; }
        public List <string> Posts { get; set; }
        public User()
        {

        }
    }
}
