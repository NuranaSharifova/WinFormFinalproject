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
       public bool firstread { get; set; } = false;
        string Path= "User.xml";
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<User>));
        List<User> Users=new List<User>();
        public UserXML()
        {

            if (!File.Exists(Path)) {

                File.Create(Path).Close();
                firstread =false;
                
            }
            firstread = true;
           
        }

        public void Read() {

           
          
            using (var ser = new StreamReader(Path))
            {
                this.Users = (List<User>)xmlSerializer.Deserialize(ser);
            }

        }
        public void SaveUsers() {


            using (var ser = new StreamWriter(Path))
            {
                xmlSerializer.Serialize(ser, Users);
            }
            MessageBox.Show("Informations have been saved","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
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

                this.Users.Add(user);

            }
            SaveUsers();
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
