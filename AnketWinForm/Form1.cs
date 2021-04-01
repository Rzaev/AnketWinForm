using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnketWinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // string gender;
        string name;

        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.SelectionMode = SelectionMode.One;
            listBox1.DisplayMember = "Name";

            //if (MaleRadio.Checked)
            //    gender = MaleRadio.Text;
            //else
            //    gender = FemaleRadio.Text;




        }


        private void SaveBtn_Click(object sender, EventArgs e)
        {

            //if (ListBox.NoMatches != listBox1.FindStringExact(name))

            //{
            //    for (int n = listBox1.Items.Count - 1; n >= 0; --n)
            //    {
            //        string removelistitem = name;
            //        if (listBox1.Items[n].ToString().Contains(removelistitem))
            //        {
            //            listBox1.Items.RemoveAt(n);
            //        }
            //    }

            //}

            //List<string> yenilist = new List<string>();
            //yenilist = GetLanguages();
            //name = NameTxt.Text;
            //listBox1.Items.Add(new User
            //{
            //    Name = NameTxt.Text,
            //    Surname = SurnameTxt.Text,
            //    Email = EmailTxt.Text,
            //    Phone = PhoneTxt.Text,
            //    Gender = GetRadioButton(),
            //    Languages = yenilist
            //});

            //File.JsonSerialize(listBox1.SelectedItem as User,name);




            WriteToJson();
        }





        #region Functions
        string gender;
        private string GetRadioButton()
        {
            if (MaleRadio.Checked)
                gender = MaleRadio.Text;
            else
                gender = FemaleRadio.Text;
            return gender;
        }


        List<string> languages = new List<string>();
        private List<string> GetLanguages()
        {
            if (EnglishBox.Checked)
            {
                languages.Add(EnglishBox.Text);
            }
            if (TurkishBox.Checked)
                languages.Add(TurkishBox.Text);
            if (RussianBox.Checked)
                languages.Add(RussianBox.Text);
            return languages;

        }

        private void WriteToJson()
        {
            File.JsonSerialize(listBox1.SelectedItem as User, NameTxt.Text);
            NameTxt.Text = "";
            SurnameTxt.Text = "";
            EmailTxt.Text = "";
            PhoneTxt.Text = "";
            MaleRadio.Checked = false;
            FemaleRadio.Checked = false;
            EnglishBox.Checked = false;
            TurkishBox.Checked = false;
            RussianBox.Checked = false;
        }


        #endregion

        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (NameTxt.Text != string.Empty)
            {
                List<string> yenilist = new List<string>();
                yenilist = GetLanguages();
                name = NameTxt.Text;
                listBox1.Items.Add(new User
                {
                    Name = NameTxt.Text,
                    Surname = SurnameTxt.Text,
                    Email = EmailTxt.Text,
                    Phone = PhoneTxt.Text,
                    Gender = GetRadioButton(),
                    Languages = yenilist
                });
            }
            else
            {
                Name = "Default";
            }
        }

        private void LoadBtn_Click(object sender, EventArgs e)
        {
            if (listBox1.Text != "" && ListBox.NoMatches != listBox1.FindStringExact(LoadTxt.Text))
            {
                //var obj = listBox1.SelectedItem as User;
                string s = LoadTxt.Text;
                var ds = File.JsonDeserialize(s);

                NameTxt.Text = ds.Name;
                SurnameTxt.Text = ds.Surname;
                EmailTxt.Text = ds.Email;
                PhoneTxt.Text = ds.Phone;

                //string gender = GetRadioButton();
                //if (gender == MaleRadio.Text)
                //    MaleRadio.Checked = true;
                //else
                //    FemaleRadio.Checked = true;

                //List<string> dil = GetLanguages();
                //if (dil.Contains(EnglishBox.Text))
                //    EnglishBox.Checked = true;
                //if (dil.Contains(TurkishBox.Text))
                //    TurkishBox.Checked = true;
                //if (dil.Contains(RussianBox.Text))
                //    RussianBox.Checked = true;


                if (gender == MaleRadio.Text)
                    MaleRadio.Checked = true;
                else if (gender == FemaleRadio.Text)
                    FemaleRadio.Checked = true;

                if (languages.Contains(EnglishBox.Text))
                    EnglishBox.Checked = true;
                if (languages.Contains(TurkishBox.Text))
                    TurkishBox.Checked = true;
                if (languages.Contains(RussianBox.Text))
                    RussianBox.Checked = true;

            }
            else
            {
                MessageBox.Show("Username is incorrect");
            }
        }
    }
}
