using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public static DateTime userDate { get; set; }
        public static DateTime date = DateTime.Now;

        public static int Month = date.Month;
        public static int Year = date.Year;

        Color red = Color.FromName("Red");
        Color grey = Color.FromName("LightGray");
        Color white = Color.FromName("White");

        DateTime start = new DateTime(Year, Month, 1);
        public int countDays = DateTime.DaysInMonth(Year, Month);
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
           
            for (int i = 1; i < 32; i++)
            {
                (Controls["label"+i] as Label).Text=start.ToShortDateString();
                if (start.Month > Month)
                {
                    (Controls["label" + i] as Label).Visible=false;
                    (Controls["richTextBox" + i] as RichTextBox).Visible=false;
                }
                if (start > date.AddDays(-1))
                {
                    if ((int)start.DayOfWeek == 0 || (int)start.DayOfWeek == 6)
                    {
                        (Controls["richTextBox" + i] as RichTextBox).BackColor = red;
                    }    
                }
                else
                {
                    (Controls["richTextBox" + i] as RichTextBox).BackColor = grey;
                }
                start = start.AddDays(1);
            }
        }
        private void button1_Click(object sender, EventArgs e)
            {
                int load = 0;

                for (int i = 1; i <= countDays; i++)
                {
                    if ((Controls["richTextBox" + i] as RichTextBox).Text.Equals(""))
                    {
                        load++;
                    }
                }

                int busyHours = (countDays - load) * 8;
                int freeHours = load * 8;

                textBox1.Text = "Free days: " + load.ToString() + ", Hours: " + freeHours;
                textBox2.Text = "Busy days: " + (countDays - load).ToString() + ", Hours: " + busyHours;
            }
         private void button2_Click(object sender, EventArgs e)
        {
                try
                {
                    DateTime userDate = DateTime.Parse(this.textBox3.Text);
                    int userMonth = userDate.Month + 1;

                    countDays = DateTime.DaysInMonth(userDate.Year, userDate.Month);
                    textBox1.Text = "";
                    textBox2.Text = "";

                    for (int i = 1; i < 32; i++)
                    {
                        if (userDate.Month < userMonth)
                        {
                            (Controls["label" + i] as Label).Text = userDate.ToShortDateString();
                            (Controls["label" + i] as Label).Visible = true;
                            (Controls["richTextBox" + i] as RichTextBox).Visible = true;
                            (Controls["richTextBox" + i] as RichTextBox).Text = "";
                            if (userDate < DateTime.Now)
                            {
                                (Controls["richTextBox" + i] as RichTextBox).BackColor = grey;
                            }
                            else
                            {
                                if ((int)userDate.DayOfWeek == 0 || (int)userDate.DayOfWeek == 6)
                                {
                                    (Controls["richTextBox" + i] as RichTextBox).BackColor = red;
                                }
                                else
                                {
                                    (Controls["richTextBox" + i] as RichTextBox).BackColor = white;
                                }
                            }
                        }
                        else
                        {
                            (Controls["label" + i] as Label).Visible = false;
                            (Controls["richTextBox" + i] as RichTextBox).Visible = false;
                        }
                        userDate = userDate.AddDays(1);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + " Enter year and month as following: 2021,7");
                }
            }
        
        private void label1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void richTextBox1_TextChanged(object sender, EventArgs e) { }
        private void richTextBox18_TextChanged(object sender, EventArgs e) { }
        private void richTextBox29_TextChanged(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void textBox3_TextChanged(object sender, EventArgs e) { }
        private void textBox2_TextChanged(object sender, EventArgs e) { }
    }
    }
   