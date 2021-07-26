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

namespace WinFormFinalproject
{
    public partial class RegisterForm : Form
    {
        public RegisterPresenter RegisterPresenter { get; set; }
        public RegisterForm()
        {
            InitializeComponent();
        }
        public string UserName
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }
        public string Passwordd
        {
            get { return textBox2.Text; }
            set { textBox2.Text = value; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegisterPresenter = new RegisterPresenter();
            RegisterPresenter.Register(textBox1.Text.ToString(), textBox2.Text.ToString());
            this.Close();
        }
    }
}
