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
      
        List<Label> labels = new List<Label>();
        List<Button> buttonEdit = new List<Button>();
        List<Button> buttonSave = new List<Button>();
        List<string> Posts = new List<string>();
        UserXML userXML = new UserXML();
        Label chosenLabel;
        public StatusWindow()
        {
            InitializeComponent();
        }
        //void EditButton_Click(object sender, EventArgs e)
        //{
         
        //    string but_name = (sender as Button).Name;

        //    foreach (var item in labels)
        //    {
        //        if (but_name == item.Name)
        //        {
        //            statusBox.Text = item.Text;
        //            chosenLabel = item;

        //        }
        //    }
        //}
        //public void ShowUserPosts() {

        //    int Ypos = 220;

        //    for (int i = 0; i < Posts.Count; i++)
        //    {
        //        Label label = new Label();

        //        Controls.Add(label);
        //        label.Text = Posts[i];
        //        label.AutoSize = true;
        //        label.Location = new Point(60, Ypos);

        //        label.Name = $"{i + 1}";
        //        labels.Add(label);
        //        Button button = new Button();
        //        Controls.Add(button);
        //        button.Name = $"{i + 1}";
        //        button.Text = "Edit";
        //        button.Click += new System.EventHandler(this.EditButton_Click);
        //        Ypos = label.Location.Y + label.Size.Height + 5;
        //        button.Location = new Point(60, Ypos);
        //        buttons.Add(button);
        //        Ypos += 30;
        //    }

        //}
        //void UpdateWindow()
        //{
           

        //    for (int i = 0; i < Posts.Count; i++)
        //    {
        //        labels[i].Location = new Point(60, Ypos);

        //        Ypos = labels[i].Location.Y + labels[i].Size.Height + 5;
        //        buttonEdit[i].Location = new Point(60, Ypos);
        //        buttonSave[i].Location = new Point(60, Ypos);
        //        Ypos += 30;
        //    }
        //}
        private void AddButton_Click(object sender, EventArgs e)
        {
            if ((sender as Button).Text=="Add")
            {
                Posts.Add(statusBox.Text);
                Label label = new Label();
                label.Text = statusBox.Text;
                label.BackColor = Color.Gray;
                label.Size = statusBox.Size;
                Controls.Add(label);
                label.Name = $"{labels.Count + 1}";
                labels.Add(label);
                Button buttonedit = new Button();
                buttonedit.Name = label.Name;
                buttonedit.Text = "Edit";
                buttonedit.BackColor = Color.Red;
                Controls.Add(buttonedit);
                //buttonedit.Click += new System.EventHandler(this.EditButton_Click);
                buttonEdit.Add(buttonedit);


                Button buttonsave = new Button();
                buttonsave.Name = label.Name;
                buttonsave.Text = "Edit";
                //buttonsave.BackColor = Color.Green;
                Controls.Add(buttonsave);
                //buttonedit.Click += new System.EventHandler(this.EditButton_Click);
                buttonEdit.Add(buttonsave);

                int position = 0;


                position = labels[labels.Count - 1].Top + labels[labels.Count - 1].Height + 5;
                label.Top =position;
                label.Left = 10;
                buttonedit.Top = position;
                buttonedit.Left = label.Left + label.Width;



                buttonsave.Top = position;
                buttonsave.Left = buttonsave.Left + buttonsave.Width;
                position += 10;
                //buttonRemove.Click += ButtonRemove_Click;
                //this.Controls.Add(buttonRemove);

            }
            else if ((sender as Button).Text=="Edit")
            {

                foreach (var item in labels)
                {
                    if ((sender as Button).Name == item.Name)
                    {
                        statusBox.Text = item.Text;
                        chosenLabel = item;

                    }
                }


                //for (int i = 0; i < Posts.Count; i++)
                //{
                //    if (chosenLabel.Text == Posts[i])
                //    {
                //        Posts[i] = statusBox.Text;
                //        chosenLabel.Text = statusBox.Text;

                //        break;
                //    }
                //}
            }
            //UpdateWindow();
            else if ((sender as Button).Text == "Save")
            {

                foreach (var item in labels)
                {
                    if ((sender as Button).Name == item.Name)
                    {
                        statusBox.Text = item.Text;
                        chosenLabel = item;

                    }
                }


                //for (int i = 0; i < Posts.Count; i++)
                //{
                //    if (chosenLabel.Text == Posts[i])
                //    {
                //        Posts[i] = statusBox.Text;
                //        chosenLabel.Text = statusBox.Text;

                //        break;
                //    }
                //}
            }
        }
    }
}

