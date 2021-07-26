using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormFinalproject.Repository;
using WinFormFinalproject.View;

namespace WinFormFinalproject.Presenter
{
   public  class UserPresenter
    {
        UserXML UserXML=new UserXML();
        User user = new User();
        public UserPresenter()
        {
          
        }
       
        public void SignIn(string name, string password)
        {
            UserXML.Read();
            user = UserXML.GetUserByName(name);
            if ((user != null) && user.Password == password)
            {


                StatusWindow statusWindow = new StatusWindow();
                statusWindow.ShowDialog(user);
            
            }
            else {

                MessageBox.Show("Not registered user","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
