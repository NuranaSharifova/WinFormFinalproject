using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormFinalproject.Repository;

namespace WinFormFinalproject.Presenter
{
    public class RegisterPresenter
    {
        public UserXML userXML { get; set; }
        public RegisterPresenter()
        {
            

        }
        public void Register(string name, string password)
        {
            userXML = new UserXML();

            User user = new User(name, password);
            userXML.SaveUser(user);

        }
    }
}
