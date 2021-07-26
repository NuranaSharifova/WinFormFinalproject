using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormFinalproject.Presenter;
using WinFormFinalproject.Repository;
using WinFormFinalproject.View;

namespace WinFormFinalproject
{
    public partial class Form1 : Form
    {

        public UserPresenter UserPresenter { get; set; }
        public Form1()
        {
            InitializeComponent();
            UserPresenter = new UserPresenter();
        }
        public string UserName
        {
            get { return textBox1.Text; }
            set {textBox1.Text = value; }
        }
        public string Passwordd
        {
            get { return textBox2.Text; }
            set {textBox2.Text = value; }
        }
       
        private void Registerbutton_Click(object sender, EventArgs e)
        {
           
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();
           
        }

        private void Loginbutton_Click(object sender, EventArgs e)
        {

           UserPresenter.SignIn(UserName, Passwordd);
        
        }

       
    }
}
