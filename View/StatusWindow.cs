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

namespace WinFormFinalproject.View
{
    public partial class StatusWindow : Form
    {
      
        List<TextBox> textboxs = new List<TextBox>();
        List<Button> buttonEdit = new List<Button>();
        List<Button> buttonSave = new List<Button>();
        List<string> Posts = new List<string>();
        UserXML UserXML = new UserXML();
        User User = new User();
        TextBox chosenTextbox = new TextBox();
        public StatusWindow()
        {
            InitializeComponent();
            chosenTextbox.Name = "";
            User.Posts = Posts;
          
        }

        public void LoadUser()
        {
            foreach (var item in User.Posts)
            {
                TextBox textBox = new TextBox();

                textBox.Text = statusBox.Text;
                textBox.BackColor = Color.White;
                textBox.Multiline = true;
                textBox.Size = statusBox.Size;
                textBox.BorderStyle = BorderStyle.Fixed3D;
                textBox.Enabled = false;

                Controls.Add(textBox);
                textBox.Name = $"{textboxs.Count + 1}";
                textBox.Text = item;
                textboxs.Add(textBox);
                Button buttonedit = new Button();
                buttonedit.Name = textBox.Name;
                buttonedit.Text = "Edit";
                buttonedit.BackColor = Color.Black;
                buttonedit.ForeColor = Color.White;
                Controls.Add(buttonedit);
                buttonedit.Click += new System.EventHandler(this.SendButton_Click);
                buttonEdit.Add(buttonedit);


                Button buttonsave = new Button();
                buttonsave.Name = textBox.Name;
                buttonsave.Text = "Save";
                buttonsave.BackColor = Color.Black;
                buttonsave.ForeColor = Color.White;
                Controls.Add(buttonsave);
                buttonedit.Click += new System.EventHandler(this.SendButton_Click);
                buttonSave.Add(buttonsave);


                int position = 0;

                position = (textboxs[0].Height + 5) * (textboxs.Count - 1) + 5;
                textBox.Top = position;
                textBox.Left = 10;
                buttonedit.Top = position - 3;

                buttonedit.Left = textBox.Left + textBox.Width;
                buttonedit.Size = new System.Drawing.Size(60, 40);
                statusBox.Text = "";

                buttonsave.Top = position - 3;
                buttonsave.Left = buttonedit.Left + buttonedit.Width;
                buttonsave.Size = new System.Drawing.Size(60, 40);
                buttonsave.Click += new System.EventHandler(this.SendButton_Click);
                Posts=User.Posts;
            }

        }
        private void EditPost() {
    
            for (int i = 0; i < Posts.Count; i++)
            {
                if  (chosenTextbox.Text == Posts[i])
                {
                    Posts[i] =textboxs[i].Text;
                    break;
                }
            }
        }
        private void SendButton_Click(object sender, EventArgs e)
        {
            if ((sender as Button).Text=="Send")
            {
                Posts.Add(statusBox.Text);
                TextBox textBox = new TextBox();
              
                textBox.Text = statusBox.Text;
                textBox.BackColor = Color.White;
                textBox.Multiline = true;
                textBox.Size = statusBox.Size;
                textBox.BorderStyle =BorderStyle.Fixed3D;
                textBox.Enabled = false;

                Controls.Add(textBox);
                textBox.Name = (textboxs.Count + 1).ToString();
                textboxs.Add(textBox);
                Button buttonedit = new Button();
                buttonedit.Name = textBox.Name;
                buttonedit.Text = "Edit";
                buttonedit.BackColor = Color.Black;
                buttonedit.ForeColor = Color.White;
                Controls.Add(buttonedit);
                buttonedit.Click += new System.EventHandler(this.SendButton_Click);
                buttonEdit.Add(buttonedit);


                Button buttonsave = new Button();
                buttonsave.Name = textBox.Name;
                buttonsave.Text = "Save";
                buttonsave.BackColor = Color.Black;
                buttonsave.ForeColor = Color.White;
                Controls.Add(buttonsave);
                buttonSave.Add(buttonsave);


                int position = 0;
                
                position = (textboxs[0].Height+5) * (textboxs.Count-1)+5;
                textBox.Top = position;
                textBox.Left = 10;
                buttonedit.Top = position-3;
               
                buttonedit.Left = textBox.Left + textBox.Width;
                buttonedit.Size = new System.Drawing.Size(60, 40); 
                statusBox.Text = "";

                buttonsave.Top = position - 3;
                buttonsave.Left=buttonedit.Left +buttonedit. Width;
                buttonsave.Size = new System.Drawing.Size(60, 40);
                buttonsave.Click += new System.EventHandler(this.SendButton_Click);


            }
            else if ((sender as Button).Text == "Edit")
            {

                foreach (var item in textboxs)
                {
                    if ((sender as Button).Name == item.Name)
                    {
                        
                        item.Enabled = true;
                       
                        break;
                    }
                }

            }

            else if ((sender as Button).Text == "Save")
            {

                foreach (var item in textboxs)
                {
                    if ((sender as Button).Name == item.Name)
                    {
                        chosenTextbox.Text = Posts[Convert.ToInt32(item.Name)-1];
                        item.Enabled = false;
                    
                        EditPost();

                        break;
                    }
                }



            }
        }
      
        public DialogResult ShowDialog(User user)
        {
            User = user;
            this.LoadUser();
            return ShowDialog();
        }
        private void StatusWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
           
           User.Posts = Posts;
           
           UserXML.SaveUser(User);
      
        }
    }
}

