using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace WinFormFinalproject.Repository
{
  public  class UserXML
    {
        bool firstread = false;
        string Path= "User.xml";
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<User>));
        List<User> Users;
        public UserXML()
        {

            if (!File.Exists(Path)) {

                File.Create(Path).Close();
                firstread = true;
                
            }
           
            Users = new List<User>();
        }

        public void Read() {

            Users = new List<User>();


            using (var ser = new StreamReader(Path))
            {
                Users = (List<User>)xmlSerializer.Deserialize(ser);
            }

        }
        public void SaveUsers(List<User> users) {


            using (var ser = new StreamWriter(Path))
            {
                xmlSerializer.Serialize(ser, users);
            }
            MessageBox.Show("User have been saved","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
        public void SaveUser(User user) {
            User usernull = null;
            if (!firstread)
            {
                Read();
                usernull = Users.Find(x => x.Username == user.Username);
            }
            firstread = false;
         
            if (usernull==null){

                Users.Add(user);
            
            }
            SaveUsers(Users);
        }
        public IEnumerable<User> GetAllUsers()
        {
            return Users;
        }
        public User GetUserByName(string name)
        {
            return Users.Find(x => x.Username == name);
        }


    }
}
