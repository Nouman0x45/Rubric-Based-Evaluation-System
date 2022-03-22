using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Font = iTextSharp.text.Font;

namespace RubricsBasedProject.Frames
{
    public partial class MainFrame : Form
    {
        bool drag = false;
        Point start_point = new Point(0, 0);

        public MainFrame()
        {
            InitializeComponent();
            MainTabControl1.SelectTab(1);
            viewGrid(dataGridView1, "Student", -1);
            var con = Configuration.getInstance().getConnection();
            String query = "Select Name from Lookup where category = @category";
            SqlCommand sc = new SqlCommand(query, con);
            sc.Parameters.AddWithValue("@category", "STUDENT_STATUS");
            SqlDataReader reader = sc.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("Name", typeof(string));
            dt.Load(reader);
            comboBox1.ValueMember = "Name";
            comboBox1.DataSource = dt;


        }

        //// ------------------ Validation FUnctions ------------------------ ////
        bool IsValidEmail(string email)
        {
            try
            {
                email = email.Trim();
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        ////------------------- Panel Movement FUnctions ------------------------///

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            start_point = new Point(e.X, e.Y);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - start_point.X, p.Y - start_point.Y);
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            start_point = new Point(e.X, e.Y);
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - start_point.X, p.Y - start_point.Y);
                
            }
        }

        private void label1_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        ////------------------- FUnctions for minimizing and maximizing ------------------------///

        private void button13_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void button14_MouseClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        ////------------------- Hover Effects and PlaceHOlder FUnctions for GUI------------------------///

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(30, 170, 231);
            button1.ForeColor = Color.FromArgb(249, 249, 249);
            this.button1.Image = RubricsBasedProject.Properties.Resources.icons8_courses_30__1_;

        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(249, 249, 249);
            button1.ForeColor = Color.Gray;
            this.button1.Image = RubricsBasedProject.Properties.Resources.icons8_courses_30;
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.BackColor = Color.FromArgb(30, 170, 231);
            button2.ForeColor = Color.FromArgb(249, 249, 249);
            this.button2.Image = RubricsBasedProject.Properties.Resources.icons8_students_30__1_;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.FromArgb(249, 249, 249);
            button2.ForeColor = Color.Gray;
            this.button2.Image = RubricsBasedProject.Properties.Resources.icons8_students_30;
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.BackColor = Color.FromArgb(30, 170, 231);
            button3.ForeColor = Color.FromArgb(249, 249, 249);
            this.button3.Image = RubricsBasedProject.Properties.Resources.icons8_agreement_30__1_;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.FromArgb(249, 249, 249);
            button3.ForeColor = Color.Gray;
            this.button3.Image = RubricsBasedProject.Properties.Resources.icons8_agreement_30;
        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {
            button4.BackColor = Color.FromArgb(30, 170, 231);
            button4.ForeColor = Color.FromArgb(249, 249, 249);
            this.button4.Image = RubricsBasedProject.Properties.Resources.icons8_calendar_30__1_1;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.BackColor = Color.FromArgb(249, 249, 249);
            button4.ForeColor = Color.Gray;
            this.button4.Image = RubricsBasedProject.Properties.Resources.icons8_calendar_30;
        }

        //private void button5_MouseEnter(object sender, EventArgs e)
        //{
        //    button5.BackColor = Color.FromArgb(30, 170, 231);
        //    button5.ForeColor = Color.FromArgb(249, 249, 249);
        //    this.button5.Image = RubricsBasedProject.Properties.Resources.icons8_report_card_30__1_;
        //}

        //private void button5_MouseLeave(object sender, EventArgs e)
        //{
        //    button5.BackColor = Color.FromArgb(249, 249, 249);
        //    button5.ForeColor = Color.Gray;
        //    this.button5.Image = RubricsBasedProject.Properties.Resources.icons8_report_card_30;
        //}

        private void button6_MouseEnter(object sender, EventArgs e)
        {
            button6.BackColor = Color.FromArgb(30, 170, 231);
            button6.ForeColor = Color.FromArgb(249, 249, 249);
            this.button6.Image = RubricsBasedProject.Properties.Resources.icons8_news_30__1_;
        }

        private void button6_MouseLeave(object sender, EventArgs e)
        {
            button6.BackColor = Color.FromArgb(249, 249, 249);
            button6.ForeColor = Color.Gray;
            this.button6.Image = RubricsBasedProject.Properties.Resources.icons8_news_30;
        }

        private void button7_MouseEnter(object sender, EventArgs e)
        {
            button7.BackColor = Color.FromArgb(30, 170, 231);
            button7.ForeColor = Color.FromArgb(249, 249, 249);
        }

        private void button7_MouseLeave(object sender, EventArgs e)
        {
            button7.BackColor = Color.FromArgb(249, 249, 249);
            button7.ForeColor = Color.Gray;
        }

        private void button8_MouseEnter(object sender, EventArgs e)
        {
            button8.BackColor = Color.FromArgb(30, 170, 231);
            button8.ForeColor = Color.FromArgb(249, 249, 249);

        }

        private void button9_MouseEnter(object sender, EventArgs e)
        {
            button9.BackColor = Color.FromArgb(30, 170, 231);
            button9.ForeColor = Color.FromArgb(249, 249, 249);

        }

        private void button8_MouseLeave(object sender, EventArgs e)
        {

            button8.BackColor = Color.FromArgb(249, 249, 249);
            button8.ForeColor = Color.Gray;
        }

        private void button9_MouseLeave(object sender, EventArgs e)
        {

            button9.BackColor = Color.FromArgb(249, 249, 249);
            button9.ForeColor = Color.Gray;
        }

        private void button11_MouseEnter(object sender, EventArgs e)
        {

            button11.BackColor = Color.FromArgb(30, 170, 231);
            button11.ForeColor = Color.FromArgb(249, 249, 249);
        }

        private void button10_MouseEnter(object sender, EventArgs e)
        {

            button10.BackColor = Color.FromArgb(30, 170, 231);
            button10.ForeColor = Color.FromArgb(249, 249, 249);
        }

        private void button11_MouseLeave(object sender, EventArgs e)
        {

            button11.BackColor = Color.FromArgb(249, 249, 249);
            button11.ForeColor = Color.Gray;
        }

        private void button10_MouseLeave(object sender, EventArgs e)
        {

            button10.BackColor = Color.FromArgb(249, 249, 249);
            button10.ForeColor = Color.Gray;
        }

        private void button12_MouseEnter(object sender, EventArgs e)
        {
            this.button12.Image = RubricsBasedProject.Properties.Resources.icons8_xbox_x_30__1_;
            button12.BackColor = Color.Transparent;
        }

        private void button12_MouseLeave(object sender, EventArgs e)
        {
            this.button12.Image = RubricsBasedProject.Properties.Resources.icons8_xbox_x_30;
        }

        private void button13_MouseEnter(object sender, EventArgs e)
        {
            this.button13.Image = RubricsBasedProject.Properties.Resources.icons8_square_30__1_;
            button13.BackColor = Color.FromArgb(249, 249, 249);
        }

        private void button13_MouseLeave(object sender, EventArgs e)
        {
            this.button13.Image = RubricsBasedProject.Properties.Resources.icons8_square_30;
        }

        private void button14_MouseEnter(object sender, EventArgs e)
        {
            this.button14.Image = RubricsBasedProject.Properties.Resources.icons8_minus_30__1_;
            button14.BackColor = Color.FromArgb(249, 249, 249);
        }

        private void button14_MouseLeave(object sender, EventArgs e)
        {
            this.button14.Image = RubricsBasedProject.Properties.Resources.icons8_minus_30;
        }

        private void button12_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "First Name")
            {
                textBox1.Text = "";
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button15_MouseEnter(object sender, EventArgs e)
        {
            button15.BackColor = Color.FromArgb(30, 170, 231);
            button15.ForeColor = Color.FromArgb(249, 249, 249);
        }

        private void button15_MouseLeave(object sender, EventArgs e)
        {
            button15.BackColor = Color.FromArgb(249, 249, 249);
            button15.ForeColor = Color.Gray;
        }



        private void button17_MouseEnter(object sender, EventArgs e)
        {
            button17.BackColor = Color.FromArgb(255, 51, 51);
            button17.ForeColor = Color.FromArgb(249, 249, 249);
        }

        private void button16_MouseEnter(object sender, EventArgs e)
        {
            button16.BackColor = Color.FromArgb(0, 230, 0);
            button16.ForeColor = Color.FromArgb(249, 249, 249);
        }

        private void button16_MouseLeave(object sender, EventArgs e)
        {
            button16.BackColor = Color.FromArgb(249, 249, 249);
            button16.ForeColor = Color.Gray;
        }

        private void button17_MouseLeave(object sender, EventArgs e)
        {
            button17.BackColor = Color.FromArgb(249, 249, 249);
            button17.ForeColor = Color.Gray;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "First Name";
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Last Name")
            {
                textBox2.Text = "";
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Last Name";
            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text == "Contact")
            {
                textBox3.Text = "";
            }
        }

        private void button29_MouseEnter(object sender, EventArgs e)
        {
            button29.BackColor = Color.FromArgb(30, 170, 231);
            button29.ForeColor = Color.FromArgb(249, 249, 249);
        }

        private void button29_MouseLeave(object sender, EventArgs e)
        {
            button29.BackColor = Color.FromArgb(249, 249, 249);
            button29.ForeColor = Color.Gray;
        }

        private void button30_Click(object sender, EventArgs e)
        {

        }


        private void textBox10_Enter(object sender, EventArgs e)
        {
            if (textBox10.Text == "Type Rubric Level  Details")
            {
                textBox10.Text = "";
            }

        }

        private void textBox10_Leave(object sender, EventArgs e)
        {
            if (textBox10.Text == "")
            {
                textBox10.Text = "Type Rubric Level  Details";
            }
        }

        private void button32_MouseEnter(object sender, EventArgs e)
        {
            button32.BackColor = Color.FromArgb(0, 230, 0);
            button32.ForeColor = Color.FromArgb(249, 249, 249);
        }

        private void button31_MouseEnter(object sender, EventArgs e)
        {
            button31.BackColor = Color.FromArgb(30, 170, 231);
            button31.ForeColor = Color.FromArgb(249, 249, 249);
        }

        private void button30_MouseEnter(object sender, EventArgs e)
        {

            button30.BackColor = Color.FromArgb(255, 51, 51);
            button30.ForeColor = Color.FromArgb(249, 249, 249);
        }

        private void button32_MouseLeave(object sender, EventArgs e)
        {
            button32.BackColor = Color.FromArgb(249, 249, 249);
            button32.ForeColor = Color.Gray;
        }

        private void button31_MouseLeave(object sender, EventArgs e)
        {
            button31.BackColor = Color.FromArgb(249, 249, 249);
            button31.ForeColor = Color.Gray;
        }

        private void button30_MouseLeave(object sender, EventArgs e)
        {
            button30.BackColor = Color.FromArgb(249, 249, 249);
            button30.ForeColor = Color.Gray;
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                textBox3.Text = "Contact";
            }
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            if (textBox4.Text == "Email Address")
            {
                textBox4.Text = "";
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                textBox4.Text = "Email Address";
            }
        }

        private void textBox5_Enter(object sender, EventArgs e)
        {
            if (textBox5.Text == "Registration Number")
            {
                textBox5.Text = "";
            }
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
            {
                textBox5.Text = "Registration Number";
            }
        }

        private void textBox6_Enter(object sender, EventArgs e)
        {
            if (textBox6.Text == "Search Student Here")
            {
                textBox6.Text = "";
            }
        }


        private void button22_MouseEnter(object sender, EventArgs e)
        {
            button22.BackColor = Color.FromArgb(30, 170, 231);
            button22.ForeColor = Color.FromArgb(249, 249, 249);
        }





        private void button22_MouseLeave(object sender, EventArgs e)
        {
            button22.BackColor = Color.FromArgb(249, 249, 249);
            button22.ForeColor = Color.Gray;
        }



        private void button21_MouseLeave(object sender, EventArgs e)
        {
            button21.BackColor = Color.FromArgb(249, 249, 249);
            button21.ForeColor = Color.Gray;
        }

        private void button24_MouseLeave(object sender, EventArgs e)
        {
            button24.BackColor = Color.FromArgb(249, 249, 249);
            button24.ForeColor = Color.Gray;
        }



        private void button24_MouseEnter(object sender, EventArgs e)
        {
            button24.BackColor = Color.FromArgb(255, 51, 51);
            button24.ForeColor = Color.FromArgb(249, 249, 249);
        }

        private void button21_MouseEnter(object sender, EventArgs e)
        {
            button21.BackColor = Color.FromArgb(0, 230, 0);

            button21.ForeColor = Color.FromArgb(249, 249, 249);
        }


        private void textBox6_Leave(object sender, EventArgs e)
        {
            if (textBox6.Text == "")
            {
                textBox6.Text = "Search Student Here";
                viewGrid(dataGridView1, "Student", -1);
            }
        }


        private void textBox7_Enter(object sender, EventArgs e)
        {
            if (textBox7.Text == "Type CLO here")
            {
                textBox7.Text = "";
            }

        }

        private void textBox7_Leave(object sender, EventArgs e)
        {
            if (textBox7.Text == "")
            {
                textBox7.Text = "Type CLO here";

            }
        }

        private void button19_MouseEnter(object sender, EventArgs e)
        {
            button19.BackColor = Color.FromArgb(30, 170, 231);
            button19.ForeColor = Color.FromArgb(249, 249, 249);
        }

        private void button19_MouseLeave(object sender, EventArgs e)
        {
            button19.BackColor = Color.FromArgb(249, 249, 249);
            button19.ForeColor = Color.Gray;
        }

        private void button20_MouseEnter(object sender, EventArgs e)
        {
            button20.BackColor = Color.FromArgb(0, 230, 0);
            button20.ForeColor = Color.FromArgb(249, 249, 249);
        }

        private void button20_MouseLeave(object sender, EventArgs e)
        {
            button20.BackColor = Color.FromArgb(249, 249, 249);
            button20.ForeColor = Color.Gray;
        }

        private void button18_MouseEnter(object sender, EventArgs e)
        {
            button18.BackColor = Color.FromArgb(255, 51, 51);
            button18.ForeColor = Color.FromArgb(249, 249, 249);
        }

        private void button18_MouseLeave(object sender, EventArgs e)
        {
            button18.BackColor = Color.FromArgb(249, 249, 249);
            button18.ForeColor = Color.Gray;
        }


        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_Enter(object sender, EventArgs e)
        {
            if (textBox8.Text == "Type Rubrics here")
            {
                textBox8.Text = "";
            }
        }

        private void textBox8_Leave(object sender, EventArgs e)
        {
            if (textBox8.Text == "")
            {
                textBox8.Text = "Type Rubrics here";
            }
        }

        private void button28_MouseEnter(object sender, EventArgs e)
        {
            button28.BackColor = Color.FromArgb(0, 230, 0);
            button28.ForeColor = Color.FromArgb(249, 249, 249);
        }

        private void button25_MouseEnter(object sender, EventArgs e)
        {
            button25.BackColor = Color.FromArgb(255, 51, 51);
            button25.ForeColor = Color.FromArgb(249, 249, 249);
        }

        private void button27_MouseEnter(object sender, EventArgs e)
        {

            button27.BackColor = Color.FromArgb(30, 170, 231);
            button27.ForeColor = Color.FromArgb(249, 249, 249);
        }

        private void button28_MouseLeave(object sender, EventArgs e)
        {
            button28.BackColor = Color.FromArgb(249, 249, 249);
            button28.ForeColor = Color.Gray;
        }

        private void button27_MouseLeave(object sender, EventArgs e)
        {
            button27.BackColor = Color.FromArgb(249, 249, 249);
            button27.ForeColor = Color.Gray;
        }

        private void button25_MouseLeave(object sender, EventArgs e)
        {
            button25.BackColor = Color.FromArgb(249, 249, 249);
            button25.ForeColor = Color.Gray;
        }


        private void button7_MouseEnter_1(object sender, EventArgs e)
        {
            button7.BackColor = Color.FromArgb(30, 170, 231);
            button7.ForeColor = Color.FromArgb(249, 249, 249);
        }

        private void button7_MouseLeave_1(object sender, EventArgs e)
        {

            button7.BackColor = Color.FromArgb(249, 249, 249);
            button7.ForeColor = Color.Gray;
        }

        private void button35_MouseEnter(object sender, EventArgs e)
        {
            button35.BackColor = Color.FromArgb(0, 230, 0);
            button35.ForeColor = Color.FromArgb(249, 249, 249);
        }

        private void button34_MouseEnter(object sender, EventArgs e)
        {
            button34.BackColor = Color.FromArgb(30, 170, 231);
            button34.ForeColor = Color.FromArgb(249, 249, 249);
        }

        private void button33_MouseEnter(object sender, EventArgs e)
        {

            button33.BackColor = Color.FromArgb(255, 51, 51);
            button33.ForeColor = Color.FromArgb(249, 249, 249);
        }

        private void button35_MouseLeave(object sender, EventArgs e)
        {

            button35.BackColor = Color.FromArgb(249, 249, 249);
            button35.ForeColor = Color.Gray;
        }

        private void button34_MouseLeave(object sender, EventArgs e)
        {

            button34.BackColor = Color.FromArgb(249, 249, 249);
            button34.ForeColor = Color.Gray;
        }

        private void button33_MouseLeave(object sender, EventArgs e)
        {

            button33.BackColor = Color.FromArgb(249, 249, 249);
            button33.ForeColor = Color.Gray;
        }

        private void button41_MouseEnter(object sender, EventArgs e)
        {
            button41.BackColor = Color.FromArgb(0, 230, 0);
            button41.ForeColor = Color.FromArgb(249, 249, 249);
        }

        private void button39_MouseEnter(object sender, EventArgs e)
        {
            button39.BackColor = Color.FromArgb(255, 51, 51);
            button39.ForeColor = Color.FromArgb(249, 249, 249);
        }

        private void button39_MouseLeave(object sender, EventArgs e)
        {
            button39.BackColor = Color.FromArgb(249, 249, 249);
            button39.ForeColor = Color.Gray;
        }

        private void button41_MouseLeave(object sender, EventArgs e)
        {
            button41.BackColor = Color.FromArgb(249, 249, 249);
            button41.ForeColor = Color.Gray;
        }

        private void button38_MouseEnter(object sender, EventArgs e)
        {
            button38.BackColor = Color.FromArgb(0, 230, 0);
            button38.ForeColor = Color.FromArgb(249, 249, 249);
        }

        private void button37_MouseEnter(object sender, EventArgs e)
        {
            button37.BackColor = Color.FromArgb(30, 170, 231);
            button37.ForeColor = Color.FromArgb(249, 249, 249);

        }

        private void button36_MouseEnter(object sender, EventArgs e)
        {

            button36.BackColor = Color.FromArgb(255, 51, 51);
            button36.ForeColor = Color.FromArgb(249, 249, 249);
        }

        private void button36_MouseLeave(object sender, EventArgs e)
        {
            button36.BackColor = Color.FromArgb(249, 249, 249);
            button36.ForeColor = Color.Gray;
        }

        private void button37_MouseLeave(object sender, EventArgs e)
        {
            button37.BackColor = Color.FromArgb(249, 249, 249);
            button37.ForeColor = Color.Gray;
        }

        private void button38_MouseLeave(object sender, EventArgs e)
        {
            button38.BackColor = Color.FromArgb(249, 249, 249);
            button38.ForeColor = Color.Gray;
        }

        private void textBox12_Enter(object sender, EventArgs e)
        {
            if (textBox12.Text == "Assignement Title")
            {
                textBox12.Text = "";
            }
        }

        private void textBox12_Leave(object sender, EventArgs e)
        {
            if (textBox12.Text == "")
            {
                textBox12.Text = "Assignement Title";

            }
        }

        private void textBox13_Enter(object sender, EventArgs e)
        {
            if (textBox13.Text == "Total Marks")
            {
                textBox13.Text = "";
            }
        }

        private void textBox13_Leave(object sender, EventArgs e)
        {
            if (textBox13.Text == "")
            {
                textBox13.Text = "Total Marks";

            }
        }

        private void textBox14_Enter(object sender, EventArgs e)
        {
            if (textBox14.Text == "Total Weightage")
            {
                textBox14.Text = "";
            }
        }

        private void textBox14_Leave(object sender, EventArgs e)
        {
            if (textBox14.Text == "")
            {
                textBox14.Text = "Total Weightage";

            }
        }

        private void textBox17_Enter(object sender, EventArgs e)
        {
            if (textBox17.Text == "Name")
            {
                textBox17.Text = "";
            }
        }

        private void textBox17_Leave(object sender, EventArgs e)
        {
            if (textBox17.Text == "")
            {
                textBox17.Text = "Name";

            }
        }

        private void textBox16_Enter(object sender, EventArgs e)
        {
            if (textBox16.Text == "Total Marks")
            {
                textBox16.Text = "";
            }
        }

        private void textBox16_Leave(object sender, EventArgs e)
        {
            if (textBox16.Text == "")
            {
                textBox16.Text = "Total Marks";

            }
        }

        private void textBox15_Enter(object sender, EventArgs e)
        {
            if (textBox15.Text == "Rubric ID")
            {
                textBox15.Text = "";
            }
        }

        private void textBox15_Leave(object sender, EventArgs e)
        {
            if (textBox15.Text == "")
            {
                textBox15.Text = "Rubric ID";

            }
        }

        private void textBox18_Enter(object sender, EventArgs e)
        {
            if (textBox18.Text == "Assignment ID")
            {
                textBox18.Text = "";
            }
        }

        private void textBox18_Leave(object sender, EventArgs e)
        {
            if (textBox18.Text == "")
            {
                textBox18.Text = "Assignment ID";

            }
        }

        private void textBox19_Enter(object sender, EventArgs e)
        {
            if (textBox19.Text == "Student ID")
            {
                textBox19.Text = "";
            }
        }

        private void textBox19_Leave(object sender, EventArgs e)
        {
            if (textBox19.Text == "")
            {
                textBox19.Text = "Student ID";

            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        ////// ---------------------  CRUD Functions --------------------- //////
        
        /// <summary>
        /// TO Add Student data into database Tablex
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button16_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (textBox1.Text != "First Name" && textBox2.Text != "Last Name" && textBox3.Text != "Contact" && textBox4.Text != "Email Address" && textBox5.Text != "Registration Number")
                {
                    
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmdd = new SqlCommand("Select COUNT (*) from Student WHERE RegistrationNumber='" + textBox5.Text + "'", con);
                int count = 0;
                count = Convert.ToInt32(cmdd.ExecuteScalar());
                if (count == 1)
                {
                    MessageBox.Show("Record Already Exist with same Registration Number");
                    return;
                }
                setidCOrrectly("Student");
                String query1 = "Insert into Student values (@FirstName, @LastName, @Contact,@Email, @RegistrationNumber,@Status)";
                SqlCommand cmd = new SqlCommand(query1, con);

                cmd.Parameters.AddWithValue("@FirstName", textBox1.Text);
                cmd.Parameters.AddWithValue("@LastName", textBox2.Text);
                cmd.Parameters.AddWithValue("@Contact", textBox3.Text);
                cmd.Parameters.AddWithValue("@Email", textBox4.Text);
                cmd.Parameters.AddWithValue("@RegistrationNumber", textBox5.Text);
                cmd.Parameters.AddWithValue("@Status", Lookupid());
                cmd.ExecuteNonQuery();


                // TO show data in grid
                viewGrid(dataGridView1, "Student", -1);
                setTextFIeldsBack();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception" + ex);
            }

        }

        private void button15_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("UPDATE Student set FirstName=@FirstName, LastName=@LastName, Contact=@Contact,Email=@Email, RegistrationNumber=@RegistrationNumber,Status=@Status where id=@id", con);

                cmd.Parameters.AddWithValue("@FirstName", textBox1.Text);
                cmd.Parameters.AddWithValue("@LastName", textBox2.Text);
                cmd.Parameters.AddWithValue("@Contact", textBox3.Text);
                cmd.Parameters.AddWithValue("@Email", textBox4.Text);
                cmd.Parameters.AddWithValue("@RegistrationNumber", textBox5.Text);
                cmd.Parameters.AddWithValue("@Status", Lookupid());
                cmd.Parameters.AddWithValue("@id", Idlabel.Text);
                // con.Open();
                cmd.ExecuteNonQuery();
                //con.Close();
                viewGrid(dataGridView1, "Student", -1);
                MessageBox.Show("Updated Successfully");
                setTextFIeldsBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex + "");
            }
        }

        private void button17_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("delete StudentResult where StudentId= @id", con);
                cmd.Parameters.AddWithValue("@id", Idlabel.Text);
                cmd.ExecuteNonQuery();
                cmd = new SqlCommand("delete StudentAttendance where StudentId= @id", con);
                cmd.Parameters.AddWithValue("@id", Idlabel.Text);
                cmd.ExecuteNonQuery();
                cmd = new SqlCommand("delete Student where id= @id", con);
                cmd.Parameters.AddWithValue("@id", Idlabel.Text);
                cmd.ExecuteNonQuery();
                viewGrid(dataGridView1, "Student", -1);
                setTextFIeldsBack();
            }
            catch { }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            String query = "Select * from Student Where id Like '%" + textBox6.Text + "%' OR FirstName Like '%" + textBox6.Text + "%' OR LastName Like '%" + textBox6.Text + "%' " +
                "OR Contact Like '%" + textBox6.Text + "%' OR Email Like '%" + textBox6.Text + "%' OR RegistrationNumber Like '%" + textBox6.Text + "%' OR Status Like '%" + textBox6.Text + "%'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button20_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox7.Text.Length <= 50)
            {
                if (textBox7.Text != "Type CLO here")
                {
                    var con = Configuration.getInstance().getConnection();
                    setidCOrrectly("Clo");
                    String query = "Insert into Clo values (@Name, @DateCreated, @DateUpdated)";
                    // String query = "insert into Clo(Name, DateCreated, DateUpdated) Values(" + textBox7.Text + ", GETDATE(), GETDATE())";
                    SqlCommand cmd = new SqlCommand(query, con);
                    DateTime time = DateTime.Now;              // Use current time
                    string format = "yyyy-MM-dd HH:mm:ss";
                    cmd.Parameters.AddWithValue("@Name", textBox7.Text);
                    cmd.Parameters.AddWithValue("@DateCreated", time.ToString(format));
                    cmd.Parameters.AddWithValue("@DateUpdated", time.ToString(format));
                    cmd.ExecuteNonQuery();
                    viewGrid(dataGridView2, "Clo", -1);
                    textBox7.Text = "Type CLO here";


                }
            }
            else
            {
                MessageBox.Show("Clo Name should be less than 50 characters!");
            }

        }

        private void button19_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox7.Text.Length <= 50 && label9.Text != "label9")
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("UPDATE Clo set Name=@Name, DateUpdated=@DateUpdated where id=@id", con);
                DateTime time = DateTime.Now;              // Use current time
                string format = "yyyy-MM-dd HH:mm:ss";
                cmd.Parameters.AddWithValue("@Name", textBox7.Text);
                cmd.Parameters.AddWithValue("@DateUpdated", time.ToString(format));
                cmd.Parameters.AddWithValue("@id", label13.Text);
                cmd.ExecuteNonQuery();
                viewGrid(dataGridView2, "Clo", -1);
                textBox7.Text = "Type CLO here";
                label3.Text = "label9";
            }
            else
            {
                MessageBox.Show("Clo Name should be less than 50 characters!");
            }
        }



        private void button18_MouseClick(object sender, MouseEventArgs e)
        {
            if (label13.Text != "label9")
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("Delete StudentResult where AssessmentComponentId in (select Id from AssessmentComponent where RubricId in (select Id from Rubric where CloId=@CloId))", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@CloId", label13.Text);
                cmd.ExecuteNonQuery();

                //ASSESSMENT COMPONENT
                con = Configuration.getInstance().getConnection();
                cmd = new SqlCommand("Delete AssessmentComponent where RubricId in (select Id from Rubric where CloId=@CloId)", con);
                da = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@CloId", label13.Text);
                cmd.ExecuteNonQuery();

                //RUBRIC LEVEL
                con = Configuration.getInstance().getConnection();
                cmd = new SqlCommand("Delete RubricLevel where RubricId in (select Id from Rubric where CloId=@CloId)", con);
                da = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@CloId", label13.Text);
                cmd.ExecuteNonQuery();

                //DELELTING RUBRICS
                con = Configuration.getInstance().getConnection();
                cmd = new SqlCommand("Delete Rubric where CloId=@CloId", con);
                da = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@CloId", label13.Text);
                cmd.ExecuteNonQuery();

                //DELETING CLO
                con = Configuration.getInstance().getConnection();
                cmd = new SqlCommand("Delete Clo where Id=@Id", con);
                da = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@Id", label13.Text);
                _ = cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully Deleted");
                viewGrid(dataGridView2, "Clo", -1);
                textBox7.Text = "Type CLO here";
                label3.Text = "label9";
            }

        }

        private void button21_MouseClick(object sender, MouseEventArgs e)
        {

            DateTime timee = dateTimePicker1.Value;              // Use current time
            string formatt = "yyyy-MM-dd";

            var con = Configuration.getInstance().getConnection();
            SqlCommand cmdd = new SqlCommand("Select COUNT (*) from ClassAttendance WHERE cast( AttendanceDate as date)='" + timee.ToString(formatt) + "'", con);
            int count = 0;
            count = Convert.ToInt32(cmdd.ExecuteScalar());
            if (count == 0)
            {
                //int attendID = AttenID(timee.ToString(formatt));
                //viewGrid(dataGridView3, "StudentAttendance", attendID);
                //return;
                setidCOrrectly("ClassAttendance");
                String query = "Insert into ClassAttendance values (@AttendanceDate)";
                // String query = "insert into Clo(Name, DateCreated, DateUpdated) Values(" + textBox7.Text + ", GETDATE(), GETDATE())";
                SqlCommand cmd = new SqlCommand(query, con);
                DateTime time = dateTimePicker1.Value;              // Use current time
                string format = "yyyy-MM-dd HH:mm:ss";
                cmd.Parameters.AddWithValue("@AttendanceDate", time.ToString(format));
                cmd.ExecuteNonQuery();

                Tempshow(time.ToString(format));

                for (int i = 0; i < dataGridView3.RowCount; i++)
                {
                    String que = "Insert into StudentAttendance values (@AttendanceId,@StudentId,@AttendanceStatus)";
                    SqlCommand cmd2 = new SqlCommand(que, con);
                    cmd2.Parameters.AddWithValue("@AttendanceId", dataGridView3.Rows[i].Cells[0].Value ?? (object)DBNull.Value);
                    cmd2.Parameters.AddWithValue("@StudentId", dataGridView3.Rows[i].Cells[1].Value ?? (object)DBNull.Value);
                    cmd2.Parameters.AddWithValue("@AttendanceStatus", 1);
                    cmd2.ExecuteNonQuery();
                }

                int attenID = Int32.Parse(dataGridView3.Rows[0].Cells[0].Value.ToString());
                viewGrid(dataGridView3, "StudentAttendance", attenID);


            }
            else
            {
                MessageBox.Show("That date Attendance is Already Added! See Below!");
            }
        }

        private void button24_MouseClick(object sender, MouseEventArgs e)
        {
            DateTime time = dateTimePicker1.Value;              // Use current time
            string format = "yyyy-MM-dd";
            int attendID = AttenID(time.ToString(format));

            var con = Configuration.getInstance().getConnection();

            SqlCommand cmd = new SqlCommand("delete StudentAttendance where AttendanceId = @AttendanceId", con);
            cmd.Parameters.AddWithValue("@AttendanceId", attendID);
            cmd.ExecuteNonQuery();
            // viewGrid(dataGridView2, "Clo", -1);
           // MessageBox.Show("Student attendance deleted!");
            SqlCommand cmdd = new SqlCommand("delete ClassAttendance WHERE cast( AttendanceDate as date)= @AttendanceDate", con);
            cmdd.Parameters.AddWithValue("@AttendanceDate", time.ToString(format));
            cmdd.ExecuteNonQuery();

            MessageBox.Show("attendance deleted!");
            dataGridView3.DataSource = null;
            dataGridView3.Rows.Clear();
            
        }


        private void button28_MouseClick(object sender, MouseEventArgs e)
        {
            if (CloLable.Text != "label23" && textBox8.Text != "Type Rubrics here")
            {
                var con = Configuration.getInstance().getConnection();
                String query = "insert into Rubric values((select max(id) from Rubric) + 1,'" + textBox8.Text + "',@CloId)";
                // String query = "insert into Clo(Name, DateCreated, DateUpdated) Values(" + textBox7.Text + ", GETDATE(), GETDATE())";
                SqlCommand cmd = new SqlCommand(query, con);
                //cmd.Parameters.AddWithValue("@Details", textBox8.Text);
                cmd.Parameters.AddWithValue("@CloId", CloLable.Text);
                cmd.ExecuteNonQuery();
                viewGrid(dataGridView5, "Rubric", -1);
                textBox8.Text = "Type Rubrics here";
                textBox9.Text = "Select Clo From Table";
                CloLable.Text = "label23";

            }
        }



        private void button27_MouseClick(object sender, MouseEventArgs e)
        {
            if (RubLabel.Text != "label22")
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("UPDATE Rubric set Details=@Details, CloId=@CloId where id=@id", con);

                cmd.Parameters.AddWithValue("@details", textBox8.Text);
                cmd.Parameters.AddWithValue("@CloId", CloLable.Text);
                cmd.Parameters.AddWithValue("@id", RubLabel.Text);
                cmd.ExecuteNonQuery();
                viewGrid(dataGridView5, "Rubric", -1);
                textBox8.Text = "Type Rubrics here";
                textBox9.Text = "Select Clo From Table";
                RubLabel.Text = "label22";
                CloLable.Text = "label23";

            }
        }

        private void button25_MouseClick(object sender, MouseEventArgs e)
        {
            if (RubLabel.Text != "label22")
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("Delete StudentResult where AssessmentComponentId in (select Id from AssessmentComponent where RubricId in (select Id from Rubric where Id=@RubricId))", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@RubricId", RubLabel.Text);
                _ = cmd.ExecuteNonQuery();

                //ASSESSMENT COMPONENT
                con = Configuration.getInstance().getConnection();
                cmd = new SqlCommand("Delete AssessmentComponent where RubricId in (select Id from Rubric where RubricId=@RubricId)", con);
                da = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@RubricId", RubLabel.Text);
                _ = cmd.ExecuteNonQuery();

                //RUBRIC LEVEL
                con = Configuration.getInstance().getConnection();
                cmd = new SqlCommand("Delete RubricLevel where RubricId in (select Id from Rubric where Id=@RubricId)", con);
                da = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@RubricId", RubLabel.Text);
                _ = cmd.ExecuteNonQuery();

                //DELELTING RUBRICS
                con = Configuration.getInstance().getConnection();
                cmd = new SqlCommand("Delete Rubric where Id=@RubricId", con);
                da = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@RubricId", RubLabel.Text);
                _ = cmd.ExecuteNonQuery();

                MessageBox.Show("Successfully Deleted");

                viewGrid(dataGridView5, "Rubric", -1);
                textBox8.Text = "Type Rubrics here";
                textBox9.Text = "Select Clo From Table";
                RubLabel.Text = "label22";
                CloLable.Text = "label23";
            }

        }

        private void button32_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox10.Text != "Type Rubric Level  Details" && textBox11.Text != "Rubric Id")
            {
                setidCOrrectly("RubricLevel");
                var con = Configuration.getInstance().getConnection();
                String query = "insert into RubricLevel values(@RubricId,@Details,@MeasurementLevel)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@RubricId", Int32.Parse(textBox11.Text));

                cmd.Parameters.AddWithValue("@Details", textBox10.Text);
                cmd.Parameters.AddWithValue("@MeasurementLevel", Int32.Parse(comboBox2.Text));
                cmd.ExecuteNonQuery();
                viewGrid(dataGridView7, "RubricLevel", -1);
                textBox11.Text = "Rubric Id";
                textBox10.Text = "Type Rubric Level  Details";

            }
        }

        private void button31_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox10.Text != "Type Rubric Level  Details" && textBox11.Text != "Rubric Id")
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("UPDATE RubricLevel set RubricId=@RubricId, Details=@Details,MeasurementLevel=@MeasurementLevel where id=@id", con);

                cmd.Parameters.AddWithValue("@RubricId", Int32.Parse(RubLabel.Text));
                cmd.Parameters.AddWithValue("@Id", Int32.Parse(RubLevelLabel.Text));
                cmd.Parameters.AddWithValue("@Details", textBox10.Text);
                cmd.Parameters.AddWithValue("@MeasurementLevel", Int32.Parse(comboBox2.Text));
                cmd.ExecuteNonQuery();
                viewGrid(dataGridView7, "RubricLevel", -1);
                textBox11.Text = "Rubric Id";
                textBox10.Text = "Type Rubric Level  Details";
                RubLabel.Text = "label25";
                RubLevelLabel.Text = "RubLevelLabel";

            }
        }

        private void button30_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox10.Text != "Type Rubric Level  Details" && textBox11.Text != "Rubric Id")
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("Delete StudentResult where RubricMeasurementId = (select Id from RubricLevel where RubricId = @RubricId and id=@id)", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@RubricId", textBox11.Text);
                cmd.Parameters.AddWithValue("@id", RubLevelLabel.Text);
                cmd.ExecuteNonQuery();

                //RUBRIC LEVEL
                con = Configuration.getInstance().getConnection();
                cmd = new SqlCommand("delete RubricLevel where id= @id", con);
                cmd.Parameters.AddWithValue("@id", RubLevelLabel.Text);
                cmd.ExecuteNonQuery();
                viewGrid(dataGridView7, "RubricLevel", -1);
                textBox11.Text = "Rubric Id";
                textBox10.Text = "Type Rubric Level  Details";
                RubLabel.Text = "label25";
                RubLevelLabel.Text = "RubLevelLabel";

            }


        }

        private void button35_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox12.Text != "Assignement Title" && textBox13.Text != "Total Marks" && textBox14.Text != "Total Weightage")
            {
                setidCOrrectly("Assessment");
                var con = Configuration.getInstance().getConnection();
                String query = "insert into Assessment values(@Title,@DateCrated,@TotalMarks,@TotalWeightage)";
                DateTime time = DateTime.Now;              // Use current time
                string format = "yyyy-MM-dd HH:mm:ss";
                // String query = "insert into Clo(Name, DateCreated, DateUpdated) Values(" + textBox7.Text + ", GETDATE(), GETDATE())";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Title", textBox12.Text);
                cmd.Parameters.AddWithValue("@DateCrated", time.ToString(format));
                cmd.Parameters.AddWithValue("@TotalMarks", Int32.Parse(textBox13.Text));
                cmd.Parameters.AddWithValue("@TotalWeightage", Int32.Parse(textBox14.Text));
                cmd.ExecuteNonQuery();
                viewGrid(dataGridView8, "Assessment", -1);
                textBox12.Text = "Assignement Title";
                textBox13.Text = "Total Marks";
                textBox14.Text = "Total Weightage";

            }
        }

        private void button34_MouseClick(object sender, MouseEventArgs e)
        {
            if (LabelAssessId.Text != "label32")
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("UPDATE Assessment set Title=@Title,TotalMarks=@TotalMarks,TotalWeightage=@TotalWeightage where id=@id", con);

                cmd.Parameters.AddWithValue("@Title", textBox12.Text);
                cmd.Parameters.AddWithValue("@id", LabelAssessId.Text);
                cmd.Parameters.AddWithValue("@TotalMarks", Int32.Parse(textBox13.Text));
                cmd.Parameters.AddWithValue("@TotalWeightage", Int32.Parse(textBox14.Text));
                cmd.ExecuteNonQuery();

                viewGrid(dataGridView8, "Assessment", -1);
                textBox12.Text = "Assignement Title";
                textBox13.Text = "Total Marks";
                textBox14.Text = "Total Weightage";
                LabelAssessId.Text = "label32";

            }
        }

        private void button33_MouseClick(object sender, MouseEventArgs e)
        {
            if (LabelAssessId.Text != "label32")
            {
                var con = Configuration.getInstance().getConnection();
                //DELELTING RUBRICS
                con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("Delete AssessmentComponent where AssessmentId=@AssessmentId", con);

                cmd.Parameters.AddWithValue("@@AssessmentId", LabelAssessId.Text);
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("delete Assessment where id= @id", con);
                cmd.Parameters.AddWithValue("@id", LabelAssessId.Text);
                cmd.ExecuteNonQuery();

                viewGrid(dataGridView8, "Assessment", -1);
                textBox12.Text = "Assignement Title";
                textBox13.Text = "Total Marks";
                textBox14.Text = "Total Weightage";
                LabelAssessId.Text = "label32";
            }
        }
        private void button38_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox17.Text != "Name" && textBox16.Text != "Total Marks" && textBox15.Text != "Rubric ID" && textBox18.Text != "Assignment ID")
            {

                var con = Configuration.getInstance().getConnection();
                String query = "Select sum(AC.TotalMarks) from AssessmentComponent AC Where AC.AssessmentId = @Id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", Int32.Parse(textBox18.Text));
                SqlDataReader reader = cmd.ExecuteReader();
                int total_marks = 0;
                while (reader.Read())
                {
                    if (reader[0].ToString() == "")
                    {
                        total_marks = 0;
                    }
                    else
                    {
                        total_marks = int.Parse(reader[0].ToString());

                    }
                }
                query = "Select TotalMarks from Assessment where Id=@Id";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", Int32.Parse(textBox18.Text));
                reader = cmd.ExecuteReader();
                int total = 0;
                while (reader.Read())
                {
                    total = Int32.Parse(reader[0].ToString());
                }
                if ((total_marks + Int32.Parse(textBox16.Text)) <= total)
                {
                    setidCOrrectly("AssessmentComponent");
                    query = "insert into AssessmentComponent values(@Name,@RubricId,@TotalMarks,@DateCreated,@DateUpdated,@AssessmentId)";
                    DateTime time = DateTime.Now;              // Use current time
                    string format = "yyyy-MM-dd HH:mm:ss";
                    // String query = "insert into Clo(Name, DateCreated, DateUpdated) Values(" + textBox7.Text + ", GETDATE(), GETDATE())";
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Name", textBox17.Text);
                    cmd.Parameters.AddWithValue("@DateCreated", time.ToString(format));
                    cmd.Parameters.AddWithValue("@TotalMarks", Int32.Parse(textBox16.Text));
                    cmd.Parameters.AddWithValue("@DateUpdated", time.ToString(format));
                    cmd.Parameters.AddWithValue("@RubricId", Int32.Parse(textBox15.Text));
                    cmd.Parameters.AddWithValue("@AssessmentId", Int32.Parse(textBox18.Text));
                    cmd.ExecuteNonQuery();
                    viewGrid(dataGridView9, "AssessmentComponent", -1);
                    textBox17.Text = "Name";
                    textBox16.Text = "Total Marks";
                    textBox15.Text = "Rubric ID";
                    textBox18.Text = "Assignment ID";
                }
                else if (total_marks == total)
                {
                    MessageBox.Show("Total Marks is completed. Can't add any more components!");
                }
                else
                {
                    MessageBox.Show("Total Marks of Component is exceeding Total marks of Assessment!.\n" +
                                    "You can add Component of max number " + (total - total_marks) + " in it.");
                }
            }


        }

        private void button37_MouseClick(object sender, MouseEventArgs e)
        {
            if (LabelAssessComp.Text != "label39")
            {
                setidCOrrectly("AssessmentComponent");
                var con = Configuration.getInstance().getConnection();

                String query = "Update AssessmentComponent set Name=@Name,RubricId=@RubricId,TotalMarks=@TotalMarks,DateUpdated=@DateUpdated,AssessmentId=@AssessmentId where id=@id";

                DateTime time = DateTime.Now;              // Use current time
                string format = "yyyy-MM-dd HH:mm:ss";
                // String query = "insert into Clo(Name, DateCreated, DateUpdated) Values(" + textBox7.Text + ", GETDATE(), GETDATE())";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Name", textBox17.Text);
                cmd.Parameters.AddWithValue("@TotalMarks", Int32.Parse(textBox16.Text));
                cmd.Parameters.AddWithValue("@DateUpdated", time.ToString(format));
                cmd.Parameters.AddWithValue("@RubricId", Int32.Parse(textBox15.Text));
                cmd.Parameters.AddWithValue("@AssessmentId", Int32.Parse(textBox18.Text));
                cmd.Parameters.AddWithValue("@Id", LabelAssessComp.Text);
                cmd.ExecuteNonQuery();
                viewGrid(dataGridView9, "AssessmentComponent", -1);
                textBox17.Text = "Name";
                textBox16.Text = "Total Marks";
                textBox15.Text = "Rubric ID";
                textBox18.Text = "Assignment ID";
                LabelAssessComp.Text = "label39";
            }
        }

        private void button41_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox19.Text != "Student ID" && comboBox3.Text != "Select Assessment Component" && comboBox4.Text != "Select Rubric Level")

            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmdd = new SqlCommand("Select COUNT (*) from StudentResult WHERE StudentId='" + textBox19.Text + "' and AssessmentComponentId = '" + comboBox3.Text.Split(',')[0] + "'", con);
                int count = 0;
                count = Convert.ToInt32(cmdd.ExecuteScalar());
                if (count == 1)
                {
                    MessageBox.Show("Record Already Exist!");
                    return;
                }
                String query = "insert into StudentResult values(@StudentId,@AssessmentComponentId,@RubricMeasurementId,@EvaluationDate)";
                DateTime time = DateTime.Now;              // Use current time
                string format = "yyyy-MM-dd HH:mm:ss";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@StudentId", textBox19.Text);
                cmd.Parameters.AddWithValue("@AssessmentComponentId", comboBox3.Text.Split(',')[0]);
                cmd.Parameters.AddWithValue("@RubricMeasurementId", comboBox4.Text.Split(',')[0]);
                cmd.Parameters.AddWithValue("@EvaluationDate", time.ToString(format));
                cmd.ExecuteNonQuery();
                viewGrid(dataGridView14, "StudentResult", -1);
                textBox19.Text = "Student ID";
                comboBox3.Text = "Select Assessment Component";
                comboBox4.Text = "Select Rubric Level";

            }
        }

        private void dataGridView12_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox19.Text = dataGridView12.CurrentRow.Cells[0].Value.ToString();
        }



        private void button39_MouseClick(object sender, MouseEventArgs e)
        {
            if (dataGridView14.SelectedRows.Count == 1)
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("delete StudentResult where StudentId=@StudentId and AssessmentComponentId=@AssessmentComponentId", con);
                cmd.Parameters.AddWithValue("@AssessmentComponentId", dataGridView14.CurrentRow.Cells[1].Value.ToString());
                cmd.Parameters.AddWithValue("@StudentId", dataGridView14.CurrentRow.Cells[0].Value.ToString());
                cmd.ExecuteNonQuery();


                viewGrid(dataGridView14, "StudentResult", -1);
                textBox19.Text = "Student ID";
                comboBox3.Text = "Select Assessment Component";
                comboBox4.Text = "Select Rubric Level";

            }
        }




        ////// ---------------------  Helping Functions  --------------------- //////

        private void button2_MouseClick(object sender, MouseEventArgs e)
        {
            MainTabControl1.SelectTab(1);

            // Get lookup text into the combo box

            var con = Configuration.getInstance().getConnection();
            String query = "Select Name from Lookup where category = @category";
            SqlCommand sc = new SqlCommand(query, con);
            sc.Parameters.AddWithValue("@category", "STUDENT_STATUS");
            SqlDataReader reader = sc.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("Name", typeof(string));
            dt.Load(reader);
            comboBox1.ValueMember = "Name";
            comboBox1.DataSource = dt;

            //getting the table populated!
            viewGrid(dataGridView1, "Student", -1);
            setTextFIeldsBack();


        }

        private void button3_MouseClick(object sender, MouseEventArgs e)
        {
            MainTabControl1.SelectTab(2);
            viewGrid(dataGridView8, "Assessment", -1);
        }

        private void button4_MouseClick(object sender, MouseEventArgs e)
        {
            MainTabControl1.SelectTab(3);
        }

        private void button5_MouseClick(object sender, MouseEventArgs e)
        {
            MainTabControl1.SelectTab(4);
        }

        private void button6_MouseClick(object sender, MouseEventArgs e)
        {
            MainTabControl1.SelectTab(5);
            dataGridView15.RowTemplate.Height = 50;
            dataGridView15.Rows.Clear();

            //comboBox5.Items.Add("Clo Wise Class Result!");
            dataGridView15.Rows.Add("1", "CLO Wise Report", "PF");
            dataGridView15.Rows.Add("2", "Assessment Wise Report", "PF");
            dataGridView15.Rows.Add("3", "Attendance Report", "PF");
            dataGridView15.Rows.Add("4", "Students Report", "PF");

            dataGridView15.ClearSelection();
            dataGridView15.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridView15.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Transparent;
            // row.Cells["Download PDF"].Value = "CLO Wise Class Report";

        }





        private void dataGridView6_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox11.Text = dataGridView6.CurrentRow.Cells[0].Value.ToString();
            RubLabel.Text = dataGridView6.CurrentRow.Cells[0].Value.ToString();

        }



        private int Lookupid()
        {
            var con = Configuration.getInstance().getConnection();
            String query2 = "Select LookupId from Lookup where name Like @name";
            SqlCommand cmd2 = new SqlCommand(query2, con);
            cmd2.Parameters.AddWithValue("@name", comboBox1.SelectedValue.ToString());
           // MessageBox.Show(comboBox1.SelectedItem.ToString());
            SqlDataReader reader = cmd2.ExecuteReader();
            reader.Read();
            int d = reader.GetInt32(0);
            reader.Close();
            return d;
        }





        private void setTextFIeldsBack()
        {
            textBox1.Text = "First Name";
            textBox2.Text = "Last Name";
            textBox2.Text = "Contact";
            textBox2.Text = "Email Address";
            textBox2.Text = "Registration Number";
        }




        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button8_MouseClick(object sender, MouseEventArgs e)
        {
            tabControl1.SelectTab(0);
            viewGrid(dataGridView2, "Clo", -1);
        }

        /// <summary>
        /// This FUnction is used to set the Auto generated id of tuple to the correct count 
        /// by resetting it to the highest value of id present into the table. Otherwise the count
        /// of id went random based on how many times query has run but even when data is not inserted.
        /// </summary>
        /// <param name="table"></param>
        private void setidCOrrectly(String table)
        {
            var con = Configuration.getInstance().getConnection();

            if (table == "Student")
            {
                String query = "declare @max int select @max = max(id) from Student DBCC CHECKIDENT ('Student',RESEED, @max)";
                SqlCommand cmd = new SqlCommand(query, con);
                // con.Open();
                cmd.ExecuteNonQuery();
            }
            else if (table == "Clo")
            {
                String query = "declare @max int select @max = max(id) from Clo DBCC CHECKIDENT ('Clo',RESEED, @max)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
            }
            else if (table == "RubricLevel")
            {
                String query = "declare @max int select @max = max(id) from RubricLevel DBCC CHECKIDENT ('RubricLevel',RESEED, @max)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
            }
            else if (table == "Assessment")
            {
                String query = "declare @max int select @max = max(id) from Assessment DBCC CHECKIDENT ('Assessment',RESEED, @max)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
            }
            else if (table == "StudentResult")
            {
                String query = "declare @max int select @max = max(id) from StudentResult DBCC CHECKIDENT ('StudentResult',RESEED, @max)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
            }

        }

        /// <summary>
        /// This FUnction will receive the grid number and the table name of whose data he wants to see 
        /// and then will show data instead of writing it all over again for each grid and table.
        /// </summary>
        /// <param name="view"></param>
        /// <param name="table"></param>
        public void viewGrid(DataGridView view, String table, int id)
        {
            view.DataSource = null;
            view.Rows.Clear();
            var con = Configuration.getInstance().getConnection();
            if (table == "StudentAttendance")
            {

                String quer = "Select A.AttendanceId, S.Id, S.FirstName + ' '+ S.LastName as [Full Name], S.RegistrationNumber, A.AttendanceStatus from student S Join " + table + " A On s.Id = A.StudentId where A.AttendanceId = '" + id + "'";
                SqlCommand cmd3 = new SqlCommand(quer, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd3);
                DataTable dt = new DataTable();
                da.Fill(dt);
                view.DataSource = dt;
            }
            else
            {
                SqlCommand cmd = new SqlCommand("Select * from " + table, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                view.DataSource = dt;
            }

        }




        private void Tempshow(String date)
        {
            dataGridView3.ClearSelection();

            var con = Configuration.getInstance().getConnection();
            String query = "select t.id as [Date ID],S.id as [Student ID], S.RegistrationNumber as [Registration Number] from student S Cross Join(Select c.Id From ClassAttendance c where c.AttendanceDate = '" + date + "') AS t";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView3.DataSource = dt;

        }

        private int CountOfTable(String table)
        {
            var con = Configuration.getInstance().getConnection();
            String query = "Select count(*) from " + table;
            SqlCommand cmd = new SqlCommand(query, con);
            int RecordCount = Convert.ToInt32(cmd.ExecuteScalar());
            return RecordCount;
        }

        private int AttenID(String date)
        {
            var con = Configuration.getInstance().getConnection();
            String query = "Select Id from ClassAttendance where cast( AttendanceDate as date) = @AttendanceDate";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@AttendanceDate", date);
            int id = Convert.ToInt32(cmd.ExecuteScalar());
            return id;
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            String attendID = dataGridView3.CurrentRow.Cells[0].Value.ToString();
            String StuID = dataGridView3.CurrentRow.Cells[1].Value.ToString();
            String Name = dataGridView3.CurrentRow.Cells[2].Value.ToString();
            String regNo = dataGridView3.CurrentRow.Cells[3].Value.ToString();
            PreAttend form = new PreAttend(attendID, StuID, Name, regNo);
            form.Show();


        }

        private void button26_MouseClick(object sender, MouseEventArgs e)
        {
            viewGrid(dataGridView3, "StudentAttendance", Int32.Parse(dataGridView3.Rows[0].Cells[0].Value.ToString()));
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime time = dateTimePicker1.Value;              // Use current time
            string format = "yyyy-MM-dd";

            var con = Configuration.getInstance().getConnection();
            SqlCommand cmdd = new SqlCommand("Select COUNT (*) from ClassAttendance WHERE cast( AttendanceDate as date)='" + time.ToString(format) + "'", con);
            int count = 0;
            count = Convert.ToInt32(cmdd.ExecuteScalar());
            //MessageBox.Show(count.ToString());
            if (count == 1)
            {
                int attendID = AttenID(time.ToString(format));
                viewGrid(dataGridView3, "StudentAttendance", attendID);
                return;
            }
            dataGridView3.DataSource = null;
            dataGridView3.Rows.Clear();
        }


        private void button9_MouseClick(object sender, MouseEventArgs e)
        {
            tabControl1.SelectTab(1);
            viewGrid(dataGridView4, "Clo", -1);
            viewGrid(dataGridView5, "Rubric", -1);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            Idlabel.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            if (dataGridView1.CurrentRow.Cells[6].Value.ToString() == "5")
            {
                //MessageBox.Show(comboBox1.FindString("Active").ToString());
                comboBox1.SelectedIndex = comboBox1.FindString("Active");
            }
            else
            {
                comboBox1.SelectedIndex = comboBox1.FindString("InActive");
            }
        }

        private void dataGridView2_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            textBox7.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            label13.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
        }



        private void button29_MouseClick(object sender, MouseEventArgs e)
        {
            tabControl1.SelectTab(2);
            comboBox2.Items.Add(1);
            comboBox2.Items.Add(2);
            comboBox2.Items.Add(3);
            comboBox2.Items.Add(4);
            viewGrid(dataGridView6, "Rubric", -1);
            viewGrid(dataGridView7, "RubricLevel", -1);

        }



        private void dataGridView7_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox11.Text = dataGridView7.CurrentRow.Cells[1].Value.ToString();

            RubLabel.Text = dataGridView7.CurrentRow.Cells[1].Value.ToString();
            textBox10.Text = dataGridView7.CurrentRow.Cells[2].Value.ToString();
            RubLevelLabel.Text = dataGridView7.CurrentRow.Cells[0].Value.ToString();
            if (dataGridView7.CurrentRow.Cells[0].Value.ToString() == "1")
            {
                //MessageBox.Show(comboBox1.FindString("Active").ToStrfing());
                comboBox2.SelectedIndex = comboBox2.FindString("1");
            }
            else if (dataGridView7.CurrentRow.Cells[0].Value.ToString() == "2")
            {
                comboBox2.SelectedIndex = comboBox2.FindString("2");
            }
            else if (dataGridView7.CurrentRow.Cells[0].Value.ToString() == "3")
            {
                comboBox2.SelectedIndex = comboBox2.FindString("3");
            }
            else if (dataGridView7.CurrentRow.Cells[0].Value.ToString() == "4")
            {
                comboBox2.SelectedIndex = comboBox2.FindString("4");
            }
        }


        private void button11_MouseClick(object sender, MouseEventArgs e)
        {
            tabControl3.SelectTab(0);
            viewGrid(dataGridView8, "Assessment", -1);
        }

        private void dataGridView8_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox12.Text = dataGridView8.CurrentRow.Cells[1].Value.ToString();
            textBox13.Text = dataGridView8.CurrentRow.Cells[3].Value.ToString();
            textBox14.Text = dataGridView8.CurrentRow.Cells[4].Value.ToString();
            LabelAssessId.Text = dataGridView8.CurrentRow.Cells[0].Value.ToString();
        }


        private void button7_MouseClick(object sender, MouseEventArgs e)
        {
            tabControl3.SelectTab(1);
            viewGrid(dataGridView11, "Rubric", -1);
            viewGrid(dataGridView10, "Assessment", -1);
            viewGrid(dataGridView9, "AssessmentComponent", -1);
        }

        private void dataGridView11_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox15.Text = dataGridView11.CurrentRow.Cells[0].Value.ToString();
        }

        private void dataGridView10_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox18.Text = dataGridView10.CurrentRow.Cells[0].Value.ToString();
        }


        private void dataGridView9_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox17.Text = dataGridView9.CurrentRow.Cells[1].Value.ToString();
            textBox16.Text = dataGridView9.CurrentRow.Cells[3].Value.ToString();
            textBox15.Text = dataGridView9.CurrentRow.Cells[2].Value.ToString();
            textBox18.Text = dataGridView9.CurrentRow.Cells[6].Value.ToString();
            LabelAssessComp.Text = dataGridView9.CurrentRow.Cells[0].Value.ToString();
        }

        private void button36_MouseClick(object sender, MouseEventArgs e)
        {
            if (LabelAssessComp.Text != "label39")
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("delete AssessmentComponent where id= @id", con);
                cmd.Parameters.AddWithValue("@id", LabelAssessComp.Text);
                cmd.ExecuteNonQuery();

                viewGrid(dataGridView9, "AssessmentComponent", -1);
                textBox17.Text = "Name";
                textBox16.Text = "Total Marks";
                textBox15.Text = "Rubric ID";
                textBox18.Text = "Assignment ID";
                LabelAssessComp.Text = "label39";

            }
        }

        private void button10_MouseClick(object sender, MouseEventArgs e)
        {
            tabControl3.SelectTab(2);
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select id,FirstName,RegistrationNumber from Student", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView12.DataSource = dt;
            cmd = new SqlCommand("Select id,Title,TotalMarks from Assessment", con);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            dataGridView13.DataSource = dt;
            viewGrid(dataGridView14, "StudentResult", -1);
        }

        private void dataGridView13_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            comboBox3.Items.Clear();
            String assid = dataGridView13.CurrentRow.Cells[0].Value.ToString();
            var con = Configuration.getInstance().getConnection();
            String query = "Select cast(A.id as nvarchar) + ',' + A.Name  from AssessmentComponent A  where AssessmentId = @id";
            SqlCommand sc = new SqlCommand(query, con);
            sc.Parameters.AddWithValue("@id", assid);
            // MessageBox.Show(assid);
            SqlDataReader reader = sc.ExecuteReader();
            while (reader.Read())
            {
                comboBox3.Items.Add(reader[0].ToString());
            }
            //DataTable dt = new DataTable();
            //dt.Columns.Add("Name", typeof(string));
            //dt.Load(reader);
            //comboBox3.ValueMember = "Name";
            //comboBox3.DataSource = dt;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox4.Items.Clear();
            string str = comboBox3.Text.Split(',')[0];
            var con = Configuration.getInstance().getConnection();
            String query = "Select cast(A.id as nvarchar) + ',' + A.Details From RubricLevel A Where A.RubricId = (Select RubricId from AssessmentComponent where id = @id)";
            SqlCommand sc = new SqlCommand(query, con);
            sc.Parameters.AddWithValue("@id", str);
            //MessageBox.Show(str);
            SqlDataReader reader = sc.ExecuteReader();
            String rubId = reader.ToString();
            // MessageBox.Show(rubId);
            while (reader.Read())
            {
                comboBox4.Items.Add(reader[0].ToString());
            }
        }


        private void dataGridView5_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            textBox8.Text = dataGridView5.CurrentRow.Cells[1].Value.ToString();
            textBox9.Text = dataGridView5.CurrentRow.Cells[2].Value.ToString();
            RubLabel.Text = dataGridView5.CurrentRow.Cells[0].Value.ToString();
        }

        private void dataGridView4_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            textBox9.Text = dataGridView4.CurrentRow.Cells[1].Value.ToString();
            CloLable.Text = dataGridView4.CurrentRow.Cells[0].Value.ToString();
        }


        private void textBox20_TextChanged(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            String query = "Select * from Rubric Where id Like '%" + textBox20.Text + "%' OR Details Like '%" + textBox20.Text + "%' OR CloId Like '%" + textBox20.Text + "%' ";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView5.DataSource = dt;
        }


        ///
        ///
        ////// ---------------------  Report Making FUnctions  --------------------- //////

        private DataTable MakeTableAssessmentStuResult()
        {
            var con = Configuration.getInstance().getConnection();
            DataTable dt = new DataTable();
            String assess_id = "";
            String toatl = "";
            String query = "Select Count(*) from Student";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            int total_stu = 0;
            while (reader.Read())
            {
                total_stu = Int32.Parse(reader[0].ToString());
            }

            dt.Columns.Add("Assignment", typeof(String));
            dt.Columns.Add("Student Name", typeof(String));
            dt.Columns.Add("Obtained Marks out of (" + toatl + ")", typeof(String));
            dt.Columns.Add("Percentage", typeof(String));
            dt.Columns.Add("Total Weightage", typeof(String));
            dt.Columns.Add("Obtained Weightage", typeof(String));

            // Assignment ID
            query = "Select id from Assessment";
            cmd = new SqlCommand(query, con);
            SqlDataReader read = cmd.ExecuteReader();

            while (read.Read())
            {
                assess_id = read[0].ToString();
                ///     Assessment Id's name
                query = "Select Title from Assessment where Id=@id";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", assess_id);
                reader = cmd.ExecuteReader();
                String Assign_name = "";
                while (reader.Read())
                {
                    Assign_name = reader[0].ToString();
                }

                query = "Select TotalMarks from Assessment where Id=@id";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", assess_id);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    toatl = reader[0].ToString();
                }

                query = "Select TotalWeightage from Assessment where Id=@id";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", assess_id);
                reader = cmd.ExecuteReader();
                String wri = "";
                while (reader.Read())
                {
                    wri = reader[0].ToString();
                }

                ///  Total marks of each Each Assignment column.
                query = "Select  sum(AC.TotalMarks) from AssessmentComponent AC Where AssessmentId = @Id";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", assess_id);
                reader = cmd.ExecuteReader();
                int total_mark = 0;
                while (reader.Read())
                {
                    if (reader[0].ToString() == "")
                    {
                        total_mark = 0;
                    }
                    else
                    {
                        // MessageBox.Show(reader[0].ToString());
                        total_mark = int.Parse(reader[0].ToString());
                    }
                    //MessageBox.Show(reader[0].ToString());
                }

                query = "Select Id from Student";
                cmd = new SqlCommand(query, con);
                SqlDataReader reade = cmd.ExecuteReader();

                String Stu_id = "";
                while (reade.Read())
                {
                    Stu_id = reade[0].ToString();
                    // MessageBox.Show(Stu_id);
                    query = "Select FirstName from Student where Id=@id";
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Id", Stu_id);
                    reader = cmd.ExecuteReader();
                    String Stu_name = "";
                    while (reader.Read())
                    {
                        Stu_name = reader[0].ToString();
                    }

                    query = "Select sum(B.Obtained) From(Select  T.StudentId, (cast(T.[Student obtained rub leve] as float) / 4) * T.TotalMarks as[Obtained] From(Select S.StudentId, AC.Name, AC.RubricId, AC.TotalMarks, (Select MeasurementLevel From RubricLevel R where R.Id = S.RubricMeasurementId) as [Student obtained rub leve] from AssessmentComponent AC Join StudentResult S on AC.Id = S.AssessmentComponentId Where AssessmentId = @ass_id and S.StudentId = @stu_id) AS T) AS B";
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@ass_Id", assess_id);
                    cmd.Parameters.AddWithValue("@stu_Id", Stu_id);
                    reader = cmd.ExecuteReader();
                    float ob_mark = 0;
                    while (reader.Read())
                    {
                        if (reader[0].ToString() == "")
                        {
                            ob_mark = 0;
                        }
                        else
                        {
                            //MessageBox.Show(reader[0].ToString());
                            ob_mark = float.Parse(reader[0].ToString());
                        }
                        //MessageBox.Show(reader[0].ToString());
                    }

                    float percen = (ob_mark / total_mark) * 100;

                    // Weitage obtained!
                    query = "Select (sum(B.Obtained) / sum(B.TotalMarks)) *B.TotalWeightage From(Select  T.StudentId, T.TotalWeightage, T.TotalMarks, (cast(T.[Student obtained rub leve] as float) / 4) * T.TotalMarks as[Obtained] From(Select S.StudentId, A.TotalWeightage, AC.Name, AC.RubricId, AC.TotalMarks, (Select MeasurementLevel From RubricLevel R where R.Id = S.RubricMeasurementId) as [Student obtained rub leve] from AssessmentComponent AC Join StudentResult S on AC.Id = S.AssessmentComponentId Join Assessment A On A.Id = AC.AssessmentId Where AssessmentId = @ass_Id and S.StudentId = @stu_Id) AS T) As B Group By B.TotalWeightage";
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@ass_Id", assess_id);
                    cmd.Parameters.AddWithValue("@stu_Id", Stu_id);
                    reader = cmd.ExecuteReader();
                    float weightage = 0;
                    while (reader.Read())
                    {
                        if (reader[0].ToString() == "")
                        {
                            weightage = 0;
                        }
                        else
                        {
                            //MessageBox.Show(reader[0].ToString());
                            weightage = float.Parse(reader[0].ToString());
                        }
                        //MessageBox.Show(reader[0].ToString());
                    }
                    dt.Rows.Add(Assign_name, Stu_id + "-" + Stu_name, ob_mark, percen, wri, weightage);
                }

                dt.Rows.Add("", "", ".", "", "", "");
                dt.Rows.Add("", "", "", ".", "", "");
            }

            return dt;
        }
        private DataTable MakeTableAssessmentResult()
        {
            var con = Configuration.getInstance().getConnection();
            DataTable dt = new DataTable();
            String assess_id = "";
            String query = "Select Count(*) from Student";

            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            int total_stu = 0;
            while (reader.Read())
            {
                total_stu = Int32.Parse(reader[0].ToString());
            }

            dt.Columns.Add("Assignment", typeof(String));
            dt.Columns.Add("Assignment Components", typeof(String));
            dt.Columns.Add("Total Marks", typeof(String));
            dt.Columns.Add("Average Obtained Marks Of Class", typeof(String));
            dt.Columns.Add("Passing Criteria", typeof(String));
            dt.Columns.Add("No of Students Attained out of (" + total_stu + ")", typeof(String));

            // Assignment ID
            query = "Select id from Assessment";
            cmd = new SqlCommand(query, con);
            SqlDataReader read = cmd.ExecuteReader();

            while (read.Read())
            {
                assess_id = read[0].ToString();
                List<float> obtain_stu_marks = new List<float>();
                List<float> total_stu_marks = new List<float>();
                ///     Assessment Id's name
                query = "Select Title from Assessment where Id=@id";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", assess_id);
                reader = cmd.ExecuteReader();
                String Assign_name = "";
                while (reader.Read())
                {
                    Assign_name = reader[0].ToString();
                }

                // TO get Assignment Component Names!
                query = "Select AC.Name From AssessmentComponent AC Where AC.AssessmentId = @Id";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", assess_id);
                reader = cmd.ExecuteReader();
                String str = "";
                int i = 1;
                while (reader.Read())
                {
                    str = str + i + ": " + reader[0].ToString() + "\n";
                    i++;
                }

                ///  Total marks of each Each Assignment column.
                query = "Select  sum(AC.TotalMarks) from AssessmentComponent AC Where AssessmentId = @Id";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", assess_id);
                reader = cmd.ExecuteReader();
                int total_mark = 0;
                while (reader.Read())
                {
                    if (reader[0].ToString() == "")
                    {
                        total_mark = 0;
                    }
                    else
                    {
                        //MessageBox.Show(reader[0].ToString());
                        total_mark = int.Parse(reader[0].ToString());
                    }
                    //MessageBox.Show(reader[0].ToString());
                }

                ///  Average Obtained marks of each Assignment column.
                query = "Select sum(M.ObMarks) / count(M.ObMarks) From(Select B.StudentId, sum(B.Obtained) as obMarks From(Select  T.StudentId, (cast(T.[Student obtained rub leve] as float) / 4) * T.TotalMarks as[Obtained] From(Select S.StudentId, AC.Name, AC.RubricId, AC.TotalMarks, (Select MeasurementLevel From RubricLevel R where R.Id = S.RubricMeasurementId) as [Student obtained rub leve] from AssessmentComponent AC Join StudentResult S on AC.Id = S.AssessmentComponentId Where AssessmentId = @Id) AS T) as B Group By B.StudentId)as M";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", assess_id);
                reader = cmd.ExecuteReader();
                float total_ob_ave = 0;
                while (reader.Read())
                {
                    if (reader[0].ToString() == "")
                    {
                        total_ob_ave = 0;
                    }
                    else
                    {
                        MessageBox.Show(reader[0].ToString());
                        total_ob_ave = float.Parse(reader[0].ToString());
                    }
                }

                // Obtained of each student.
                query = "Select sum(B.Obtained) From(Select  T.StudentId, (cast(T.[Student obtained rub leve] as float) / 4) * T.TotalMarks as[Obtained] From(Select S.StudentId, AC.Name, AC.RubricId, AC.TotalMarks, (Select MeasurementLevel From RubricLevel R where R.Id = S.RubricMeasurementId) as [Student obtained rub leve] from AssessmentComponent AC Join StudentResult S on AC.Id = S.AssessmentComponentId Where AssessmentId = @Id) AS T)as B Group By B.StudentId";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", assess_id);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    obtain_stu_marks.Add(float.Parse(reader[0].ToString()));
                }

                // total of each student.
                query = "Select sum(B.Obtained) From(Select  T.StudentId, (4 / 4) * T.TotalMarks as[Obtained] From(Select S.StudentId, AC.Name, AC.RubricId, AC.TotalMarks, (Select MeasurementLevel From RubricLevel R where R.Id = S.RubricMeasurementId) as [Student obtained rub leve] from AssessmentComponent AC Join StudentResult S on AC.Id = S.AssessmentComponentId Where AssessmentId = @Id) AS T)as B Group By B.StudentId";
                cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@Id", assess_id);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    total_stu_marks.Add(float.Parse(reader[0].ToString()));
                }

                // student passed!
                int stu_passed = 0;
                //MessageBox.Show(total_stu_marks.Count.ToString());
                for (int j = 0; j < total_stu_marks.Count; j++)
                {
                    if (obtain_stu_marks[j] >= (total_stu_marks[j] * 0.50))
                    {
                        stu_passed++;
                    }

                }
                dt.Rows.Add(Assign_name, str, total_mark, total_ob_ave, "50%", stu_passed);

            }

            return dt;
        }
        private DataTable MakeTableCLOResult()
        {
            var con = Configuration.getInstance().getConnection();
            DataTable dt = new DataTable();
            /// Total Student
            /// String query = "";
            String query = "Select Count(*) from Student";

            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            int total_stu = 0;
            while (reader.Read())
            {
                total_stu = Int32.Parse(reader[0].ToString());
            }


            dt.Columns.Add("CLOs", typeof(String));
            dt.Columns.Add("CLO Attainment Checked IN", typeof(String));
            dt.Columns.Add("No of Students Attained out of (" + total_stu + ")", typeof(String));
            dt.Columns.Add("Passing Criteria", typeof(String));
            dt.Columns.Add("Average CLO Score(%) of Class", typeof(String));

            query = "Select Id from Clo";
            cmd = new SqlCommand(query, con);
            SqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                ///     Assessments in each clo.
                List<float> obtain_stu_marks = new List<float>();
                List<float> total_stu_marks = new List<float>();
                String Clo_id = read[0].ToString();
                String str = "";
                query = "Select Title From Assessment where Id in (select AssessmentId from AssessmentComponent where RubricId in (select Id from Rubric where CloId=@CloId))";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@CloId", Clo_id);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    str = str + reader[0].ToString() + ",";
                }
                //MessageBox.Show(str);
                ///     Clo Id's name
                query = "Select Name from Clo where Id=@id";

                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", Clo_id);
                reader = cmd.ExecuteReader();
                String clo_name = "";
                while (reader.Read())
                {
                    clo_name = reader[0].ToString();
                }

                ///  Obtained marks of each student column.
                query = "Select sum(N.Obtained) From(Select(cast(T.[Student obtained rub leve] as float) / 4) * T.TotalMarks as [Obtained] From(Select S.StudentId, A.Name, A.RubricId, A.TotalMarks, (Select MeasurementLevel From RubricLevel R where R.Id = S.RubricMeasurementId) as [Student obtained rub leve] From StudentResult S Join AssessmentComponent A on S.AssessmentComponentId = A.Id where A.RubricId IN(Select R.Id From Rubric R Where R.CloId = @CloId)) as T) AS N";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@CloId", Clo_id);
                reader = cmd.ExecuteReader();
                float total_ob = 0;
                while (reader.Read())
                {
                    total_ob = float.Parse(reader[0].ToString());
                }
                //MessageBox.Show(total_ob.ToString());

                // Total MArks of CLO
                query = "Select sum(N.Obtained) From(Select(4 / 4) * T.TotalMarks as [Obtained] From(Select S.StudentId, A.Name, A.RubricId, A.TotalMarks, (Select MeasurementLevel From RubricLevel R where R.Id = S.RubricMeasurementId) as [Student obtained rub leve] From StudentResult S Join AssessmentComponent A on S.AssessmentComponentId = A.Id where A.RubricId IN(Select R.Id From Rubric R Where R.CloId = @CloId)) as T) AS N";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@CloId", Clo_id);
                reader = cmd.ExecuteReader();
                float total_num = 0;
                while (reader.Read())
                {
                    total_num = float.Parse(reader[0].ToString());
                }
                //MessageBox.Show(total_num.ToString());

                float avg = (total_ob / total_num) * 100;
                //MessageBox.Show(avg.ToString());

                // Obtained of each student.
                query = "Select sum(B.Obtained) From(Select T.StudentId, (cast(T.[Student obtained rub leve] as float) / 4) * T.TotalMarks as[Obtained] From(Select S.StudentId, A.Name, A.RubricId, A.TotalMarks, (Select MeasurementLevel From RubricLevel R where R.Id = S.RubricMeasurementId) as [Student obtained rub leve] From StudentResult S Join AssessmentComponent A on S.AssessmentComponentId = A.Id where A.RubricId IN(Select R.Id From Rubric R Where R.CloId = @CloId)) as T) as B Group By B.StudentId";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@CloId", Clo_id);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    obtain_stu_marks.Add(float.Parse(reader[0].ToString()));
                }

                // total of each student.
                query = "Select sum(B.Obtained) From(Select T.StudentId, (4 / 4) * T.TotalMarks as[Obtained] From(Select S.StudentId, A.Name, A.RubricId, A.TotalMarks, (Select MeasurementLevel From RubricLevel R where R.Id = S.RubricMeasurementId) as [Student obtained rub leve] From StudentResult S Join AssessmentComponent A on S.AssessmentComponentId = A.Id where A.RubricId IN(Select R.Id From Rubric R Where R.CloId = @CloId)) as T) as B Group By B.StudentId";
                cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@CloId", Clo_id);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    total_stu_marks.Add(float.Parse(reader[0].ToString()));
                }

                // student passed!
                int stu_passed = 0;
                //MessageBox.Show(total_stu_marks.Count.ToString());
                for (int i = 0; i < total_stu_marks.Count; i++)
                {
                    if (obtain_stu_marks[i] >= (total_stu_marks[i] * 0.50))
                    {
                        stu_passed++;
                    }

                }
                dt.Rows.Add(clo_name, str, stu_passed, "50.0", avg);

                reader.Close();
            }
            // dataGridView15.DataSource = dt;

            return dt;
        }

        private DataTable MakeTableAttendanceStuResult()
        {
            var con = Configuration.getInstance().getConnection();
            DataTable dt = new DataTable();
            String Stu_id = "";


            dt.Columns.Add("Student Name", typeof(String));
            dt.Columns.Add("Total Present", typeof(String));
            dt.Columns.Add("Total Absent", typeof(String));
            dt.Columns.Add("Total Leave", typeof(String));
            dt.Columns.Add("Total Late", typeof(String));
            dt.Columns.Add("Total Present Percentage", typeof(String));

            // Assignment ID
            String query = "Select Id from Student";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader read = cmd.ExecuteReader();

            while (read.Read())
            {
                Stu_id = read[0].ToString();

                ///     Assessment Id's name
                query = " Select S.FirstName + ' ' + S.LastName as [Full Name] From Student S where S.Id = @id";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", Stu_id);
                SqlDataReader reader = cmd.ExecuteReader();
                String Stu_name = "";
                while (reader.Read())
                {
                    Stu_name = reader[0].ToString();
                }

                // TO get Total present!
                query = "Select Distinct (Select count(*) From StudentAttendance SA where SA.StudentId = @stuID and SA.AttendanceStatus = '1') from StudentAttendance S where S.StudentId = @StuId";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@StuId", Stu_id);
                reader = cmd.ExecuteReader();
                int total_pre = 0;
                while (reader.Read())
                {
                    if (reader[0].ToString() == "")
                    {
                        total_pre = 0;
                    }
                    else
                    {
                        //MessageBox.Show(reader[0].ToString());
                        total_pre = int.Parse(reader[0].ToString());
                    }
                    //MessageBox.Show(reader[0].ToString());
                }

                // TO get absent student
                query = "Select Distinct (Select count(*) From StudentAttendance SA where SA.StudentId = @stuID and SA.AttendanceStatus = '2') from StudentAttendance S where S.StudentId = @StuId";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@StuID", Stu_id);
                reader = cmd.ExecuteReader();
                int total_abs = 0;
                while (reader.Read())
                {
                    if (reader[0].ToString() == "")
                    {
                        total_abs = 0;
                    }
                    else
                    {
                        //MessageBox.Show(reader[0].ToString());
                        total_abs = int.Parse(reader[0].ToString());
                    }
                    //MessageBox.Show(reader[0].ToString());
                }

                // TO get Leave student
                query = "Select Distinct (Select count(*) From StudentAttendance SA where SA.StudentId = @stuID and SA.AttendanceStatus = '3') from StudentAttendance S where S.StudentId = @StuId";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@StuID", Stu_id);
                reader = cmd.ExecuteReader();
                int total_leave = 0;
                while (reader.Read())
                {
                    if (reader[0].ToString() == "")
                    {
                        total_leave = 0;
                    }
                    else
                    {
                        //MessageBox.Show(reader[0].ToString());
                        total_leave = int.Parse(reader[0].ToString());
                    }
                    //MessageBox.Show(reader[0].ToString());
                }

                // TO get Late student
                query = "Select Distinct (Select count(*) From StudentAttendance SA where SA.StudentId = @stuID and SA.AttendanceStatus = '4') from StudentAttendance S where S.StudentId = @StuId";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@StuID", Stu_id);
                reader = cmd.ExecuteReader();
                int total_late = 0;
                while (reader.Read())
                {
                    if (reader[0].ToString() == "")
                    {
                        total_late = 0;
                    }
                    else
                    {
                        //MessageBox.Show(reader[0].ToString());
                        total_late = int.Parse(reader[0].ToString());
                    }
                    //MessageBox.Show(reader[0].ToString());
                }

                // TO get ave of attendance student!
                query = "Select (cast(B.present+B.Late as float) /  (B.present+B.Late + B.Absent + B.Leave) ) * 100 From(Select Distinct(Select count(*) From StudentAttendance SA where SA.StudentId = @ID and SA.AttendanceStatus = '1') as present, (Select count(*) From StudentAttendance SA where SA.StudentId = @ID and SA.AttendanceStatus = '2') as Absent,(Select count(*) From StudentAttendance SA where SA.StudentId = @ID and SA.AttendanceStatus = '3') as Leave, (Select count(*) From StudentAttendance SA where SA.StudentId = @ID and SA.AttendanceStatus = '4') as Late from StudentAttendance S where S.StudentId = @ID ) AS B";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ID", Stu_id);
                reader = cmd.ExecuteReader();
                float total_pre_ave = 0;
                while (reader.Read())
                {
                    if (reader[0].ToString() == "")
                    {
                        total_pre_ave = 0;
                    }
                    else
                    {
                        //MessageBox.Show(reader[0].ToString());
                        total_pre_ave = float.Parse(reader[0].ToString());
                    }
                    //MessageBox.Show(reader[0].ToString());
                }
                // student passed!

                dt.Rows.Add(Stu_id + "-" + Stu_name, total_pre, total_abs, total_leave, total_late, total_pre_ave);

            }

            return dt;
        }


        private DataTable MakeTableAttendanceResult()
        {
            var con = Configuration.getInstance().getConnection();
            DataTable dt = new DataTable();
            String date_id = "";


            dt.Columns.Add("Date Name", typeof(String));
            dt.Columns.Add("Total Present", typeof(String));
            dt.Columns.Add("Total Absent", typeof(String));
            dt.Columns.Add("Total Leave", typeof(String));
            dt.Columns.Add("Total Late", typeof(String));
            dt.Columns.Add("Total Present Percentage", typeof(String));

            // Assignment ID
            String query = "Select Id from ClassAttendance";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader read = cmd.ExecuteReader();

            while (read.Read())
            {
                date_id = read[0].ToString();

                ///     Assessment Id's name
                query = "Select cast(AttendanceDate as date) from ClassAttendance where Id=@id";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", date_id);
                SqlDataReader reader = cmd.ExecuteReader();
                String date_name = "";
                while (reader.Read())
                {
                    date_name = reader[0].ToString();
                }

                // TO get present student
                query = "Select distinct (Select count(*) From StudentAttendance SA where SA.AttendanceId =C.Id and SA.AttendanceStatus = '1') as [Present Students]from ClassAttendance C join StudentAttendance S on C.Id = S.AttendanceId where C.Id = @ID";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ID", date_id);
                reader = cmd.ExecuteReader();
                int total_pre = 0;
                while (reader.Read())
                {
                    if (reader[0].ToString() == "")
                    {
                        total_pre = 0;
                    }
                    else
                    {
                        //MessageBox.Show(reader[0].ToString());
                        total_pre = int.Parse(reader[0].ToString());
                    }
                    //MessageBox.Show(reader[0].ToString());
                }

                // TO get absent student
                query = "Select distinct (Select count(*) From StudentAttendance SA where SA.AttendanceId =C.Id and SA.AttendanceStatus = '2') as [Present Students]from ClassAttendance C join StudentAttendance S on C.Id = S.AttendanceId where C.Id = @ID";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ID", date_id);
                reader = cmd.ExecuteReader();
                int total_abs = 0;
                while (reader.Read())
                {
                    if (reader[0].ToString() == "")
                    {
                        total_abs = 0;
                    }
                    else
                    {
                        //MessageBox.Show(reader[0].ToString());
                        total_abs = int.Parse(reader[0].ToString());
                    }
                    //MessageBox.Show(reader[0].ToString());
                }

                // TO get Leave student
                query = "Select distinct (Select count(*) From StudentAttendance SA where SA.AttendanceId =C.Id and SA.AttendanceStatus = '3') as [Present Students]from ClassAttendance C join StudentAttendance S on C.Id = S.AttendanceId where C.Id = @ID";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ID", date_id);
                reader = cmd.ExecuteReader();
                int total_leave = 0;
                while (reader.Read())
                {
                    if (reader[0].ToString() == "")
                    {
                        total_leave = 0;
                    }
                    else
                    {
                        //MessageBox.Show(reader[0].ToString());
                        total_leave = int.Parse(reader[0].ToString());
                    }
                    //MessageBox.Show(reader[0].ToString());
                }

                // TO get Late student
                query = "Select distinct (Select count(*) From StudentAttendance SA where SA.AttendanceId =C.Id and SA.AttendanceStatus = '4') as [Present Students]from ClassAttendance C join StudentAttendance S on C.Id = S.AttendanceId where C.Id = @ID";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ID", date_id);
                reader = cmd.ExecuteReader();
                int total_late = 0;
                while (reader.Read())
                {
                    if (reader[0].ToString() == "")
                    {
                        total_late = 0;
                    }
                    else
                    {
                        //MessageBox.Show(reader[0].ToString());
                        total_late = int.Parse(reader[0].ToString());
                    }
                    //MessageBox.Show(reader[0].ToString());
                }

                // TO get ave of attendance student!
                query = "Select cast(A.[Present Students] + A.[Late Students] as float) / (A.[Present Students]+A.[Absent Students]+A.[Late Students]+A.[Leave Students]) *100 From(Select Distinct C.AttendanceDate, (Select count(*) From StudentAttendance SA where SA.AttendanceId = C.Id and SA.AttendanceStatus = '1') as [Present Students], (Select count(*) From StudentAttendance SA where SA.AttendanceId = C.Id and SA.AttendanceStatus = '2') as [Absent Students], (Select count(*) From StudentAttendance SA where SA.AttendanceId = C.Id and SA.AttendanceStatus = '3') as [Leave Students], (Select count(*) From StudentAttendance SA where SA.AttendanceId = C.Id and SA.AttendanceStatus = '4') as [Late Students] from ClassAttendance C join StudentAttendance S on C.Id = S.AttendanceId where C.Id = @ID ) As A";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ID", date_id);
                reader = cmd.ExecuteReader();
                float total_pre_ave = 0;
                while (reader.Read())
                {
                    if (reader[0].ToString() == "")
                    {
                        total_pre_ave = 0;
                    }
                    else
                    {
                        //MessageBox.Show(reader[0].ToString());
                        total_pre_ave = float.Parse(reader[0].ToString());
                    }
                    //MessageBox.Show(reader[0].ToString());
                }
                // student passed!

                dt.Rows.Add(date_name, total_pre, total_abs, total_leave, total_late, total_pre_ave);

            }

            return dt;
        }

        private DataTable MakeStudentTableResult()
        {
            var con = Configuration.getInstance().getConnection();
            DataTable dt = new DataTable();
           // String date_id = "";


            dt.Columns.Add("Student ID", typeof(String));
            dt.Columns.Add("Full Name", typeof(String));
            dt.Columns.Add("Total Marks", typeof(String));
            dt.Columns.Add("Obtained Marks", typeof(String));
            dt.Columns.Add("Obtained Percentage (100%)", typeof(String));
            dt.Columns.Add("Aspected Grade", typeof(String));

            // Assignment ID
            String query = "Select N.StudentId,N.Name,N.[Total MArks],N.[Total Obtained],cast((N.[Total Obtained] / N.[Total MArks]) *100 as numeric(18,2)) as [Percentage obtained] From(Select B.StudentId, B.Name, sum(B.TotalMarks) as [Total MArks], Sum(B.[Obtained Marks]) as [Total Obtained] From(Select T.StudentId, T.Name, T.TotalMarks, (cast(T.[Student obtained rub leve] as float) / 4) * T.TotalMarks as [Obtained Marks] From(Select S.StudentId, St.FirstName + ' ' + St.LastName as[Name], A.RubricId, A.TotalMarks, (Select MeasurementLevel From RubricLevel R where R.Id = S.RubricMeasurementId) as [Student obtained rub leve] From StudentResult S Join AssessmentComponent A on S.AssessmentComponentId = A.Id join Student ST on St.Id = S.StudentId) as T) as B Group by B.StudentId,B.Name) As N  order by[Percentage obtained] DESC";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader read = cmd.ExecuteReader();

            while (read.Read())
            {
                String grade = "";
                if (float.Parse(read[4].ToString()) > 90)
                {
                    grade = "A";
                }
                else if (float.Parse(read[4].ToString()) <= 90 && float.Parse(read[4].ToString()) > 85)
                {
                    grade = "A-";
                }
                else if (float.Parse(read[4].ToString()) <= 85  && float.Parse(read[4].ToString()) > 80)
                {
                    grade = "B+";
                }
                else if (float.Parse(read[4].ToString()) <= 80 && float.Parse(read[4].ToString()) > 75)
                {
                    grade = "B";
                }
                else if (float.Parse(read[4].ToString()) <= 75 && float.Parse(read[4].ToString()) > 70)
                {
                    grade = "B-";
                }
                else if (float.Parse(read[4].ToString()) <= 70 && float.Parse(read[4].ToString()) > 65)
                {
                    grade = "C+";
                }
                else if (float.Parse(read[4].ToString()) <= 65 && float.Parse(read[4].ToString()) > 55)
                {
                    grade = "C";
                }
                else if (float.Parse(read[4].ToString()) <= 55 && float.Parse(read[4].ToString()) > 50)
                {
                    grade = "C-";
                }
                else if (float.Parse(read[4].ToString()) <= 50 && float.Parse(read[4].ToString()) > 45)
                {
                    grade = "D+";
                }
                else if (float.Parse(read[4].ToString()) <= 45 && float.Parse(read[4].ToString()) >= 40)
                {
                    grade = "D";
                }
                else if (float.Parse(read[4].ToString()) < 40)
                {
                    grade = "F";
                }
                

                

                dt.Rows.Add(read[0].ToString() , read[1].ToString(), read[2].ToString(), read[3].ToString(), read[4].ToString(), grade);

            }

            return dt;
        }

        private DataTable MakeTableCLODetails()
        {
            var con = Configuration.getInstance().getConnection();
            DataTable dt = new DataTable();

            String query = "";
            dt.Columns.Add("CLOs", typeof(String));
            dt.Columns.Add("Rubrics ", typeof(String));


            query = "Select Id from Clo";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                ///     Assessments in each clo.

                String Clo_id = read[0].ToString();
                String str = "";

                ///     Clo Id's name
                query = "Select Name from Clo where Id=@id";

                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", Clo_id);
                SqlDataReader reader = cmd.ExecuteReader();
                String clo_name = "";
                while (reader.Read())
                {
                    clo_name = reader[0].ToString();
                }

                query = "Select R.Details From Rubric R Where R.CloId = @CloId";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@CloId", Clo_id);
                reader = cmd.ExecuteReader();
                int i = 1;
                while (reader.Read())
                {
                    str = str + i + ": " + reader[0].ToString() + "\n";
                    i++;
                }
                dt.Rows.Add(clo_name, str);


            }
            return dt;
        }

        private void generate_clo_report()
        {
            DataTable tb = MakeTableCLOResult();
            DataTable tbb = MakeTableCLODetails();
            OpenFileDialog op = new OpenFileDialog();
            string folderPath = "";
            op.ValidateNames = false;
            op.CheckFileExists = false;
            op.CheckPathExists = true;
            op.FileName = "Folder Selection.";
            if (op.ShowDialog() == DialogResult.OK)
            {
                folderPath = Path.GetDirectoryName(op.FileName);
                FileStream fs = new FileStream(@"" + folderPath + @"\CloWiseReport.pdf", FileMode.Create, FileAccess.Write, FileShare.None);
                Document doc = new Document();
                doc.SetPageSize(iTextSharp.text.PageSize
                    .A4);
                PdfWriter writer = PdfWriter.GetInstance(doc, fs);
                doc.Open();

                // Report Header
                BaseFont bfothead = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.NOT_EMBEDDED);
                Font fnt1 = new Font(bfothead, 16, 1, BaseColor.BLACK);
                Font fnt3 = new Font(bfothead, 14, 1, BaseColor.BLACK);
                Paragraph prg = new Paragraph();
                prg.Alignment = Element.ALIGN_CENTER;
                prg.Add(new Chunk("University Of Engineering And Technolgy", fnt1));
                doc.Add(prg);
                prg = new Paragraph();
                prg.Alignment = Element.ALIGN_CENTER;
                Font fnt2 = new Font(bfothead, 12, 2, BaseColor.BLACK);
                prg.Add(new Chunk("Course Learning Outcome Attainment Report", fnt2));
                doc.Add(prg);
                Paragraph p = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
                doc.Add(p);
                prg = new Paragraph();
                prg.Alignment = Element.ALIGN_LEFT;
                prg.Add(new Chunk("\nCourse:   ", fnt3));
                prg.Add(new Chunk("CS-142L Programming Fundamentals", fnt2));
                prg.Add(new Chunk("\nSemester:   ", fnt3));
                prg.Add(new Chunk("Fall 2022", fnt2));
                prg.Add(new Chunk("\nLecturer:   ", fnt3));
                prg.Add(new Chunk("Samyan Qayyum Wahla\n", fnt2));

                doc.Add(prg);
                p = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
                doc.Add(p);
                prg = new Paragraph();
                prg.Alignment = Element.ALIGN_LEFT;
                prg.Add(new Chunk("\nCLO's Rubrics: \n\n", fnt3));
                doc.Add(prg);
                // Write First Table
                PdfPTable table1 = new PdfPTable(tbb.Columns.Count);
                table1.WidthPercentage = 100;
                table1.TotalWidth = 500f;
                //table header
                fnt1 = new Font(bfothead, 10, 1, BaseColor.WHITE);
                for (int i = 0; i < tbb.Columns.Count; i++)
                {
                    PdfPCell cel = new PdfPCell();
                    cel.BackgroundColor = BaseColor.DARK_GRAY;
                    cel.HorizontalAlignment = Element.ALIGN_CENTER;
                    cel.AddElement(new Chunk(tbb.Columns[i].ColumnName.ToUpper(), fnt1));
                    table1.AddCell(cel);
                }
                //table data
                for (int i = 0; i < tbb.Rows.Count; i++)
                {
                    for (int j = 0; j < tbb.Columns.Count; j++)
                    {
                        table1.AddCell(tbb.Rows[i][j].ToString());
                    }
                }
                doc.Add(table1);

                prg = new Paragraph();
                prg.Alignment = Element.ALIGN_LEFT;
                prg.Add(new Chunk("\nCLO's Wise Class Result\n\n", fnt3));
                doc.Add(prg);

                // write second table
                PdfPTable table2 = new PdfPTable(tb.Columns.Count);
                table2.WidthPercentage = 100;
                table2.TotalWidth = 500f;
                //table header
                fnt1 = new Font(bfothead, 10, 1, BaseColor.WHITE);
                for (int i = 0; i < tb.Columns.Count; i++)
                {
                    PdfPCell cel = new PdfPCell();
                    cel.BackgroundColor = BaseColor.DARK_GRAY;
                    cel.HorizontalAlignment = Element.ALIGN_CENTER;
                    cel.AddElement(new Chunk(tb.Columns[i].ColumnName.ToUpper(), fnt1));
                    table2.AddCell(cel);
                }
                //table data
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    for (int j = 0; j < tb.Columns.Count; j++)
                    {
                        table2.AddCell(tb.Rows[i][j].ToString());
                    }
                }
                doc.Add(table2);
                doc.Close();
                writer.Close();
                fs.Close();
                MessageBox.Show("Report Generated!");
            }

        }

        private void generate_assign_report()
        {
            DataTable tb = MakeTableAssessmentResult();
            DataTable tbb = MakeTableAssessmentStuResult();
            OpenFileDialog op = new OpenFileDialog();
            string folderPath = "";
            op.ValidateNames = false;
            op.CheckFileExists = false;
            op.CheckPathExists = true;
            op.FileName = "Folder Selection.";
            if (op.ShowDialog() == DialogResult.OK)
            {
                folderPath = Path.GetDirectoryName(op.FileName);
                FileStream fs = new FileStream(@"" + folderPath + @"\AssignWiseReport.pdf", FileMode.Create, FileAccess.Write, FileShare.None);
                Document doc = new Document();
                doc.SetPageSize(iTextSharp.text.PageSize
                    .A4);
                PdfWriter writer = PdfWriter.GetInstance(doc, fs);
                doc.Open();

                // Report Header
                BaseFont bfothead = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.NOT_EMBEDDED);
                Font fnt1 = new Font(bfothead, 16, 1, BaseColor.BLACK);
                Font fnt3 = new Font(bfothead, 14, 1, BaseColor.BLACK);
                Paragraph prg = new Paragraph();
                prg.Alignment = Element.ALIGN_CENTER;
                prg.Add(new Chunk("University Of Engineering And Technolgy", fnt1));
                doc.Add(prg);
                prg = new Paragraph();
                prg.Alignment = Element.ALIGN_CENTER;
                Font fnt2 = new Font(bfothead, 12, 2, BaseColor.BLACK);
                prg.Add(new Chunk("Assignment Wise Report of STudents", fnt2));
                doc.Add(prg);
                Paragraph p = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
                doc.Add(p);
                prg = new Paragraph();
                prg.Alignment = Element.ALIGN_LEFT;
                prg.Add(new Chunk("\nCourse:   ", fnt3));
                prg.Add(new Chunk("CS-142L Programming Fundamentals", fnt2));
                prg.Add(new Chunk("\nSemester:   ", fnt3));
                prg.Add(new Chunk("Fall 2022", fnt2));
                prg.Add(new Chunk("\nLecturer:   ", fnt3));
                prg.Add(new Chunk("Samyan Qayyum Wahla\n", fnt2));

                doc.Add(prg);
                p = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
                doc.Add(p);

                prg = new Paragraph();
                prg.Alignment = Element.ALIGN_LEFT;
                prg.Add(new Chunk("\nAssignment Wise Class Result\n\n", fnt3));
                doc.Add(prg);

                // write second table
                PdfPTable table2 = new PdfPTable(tb.Columns.Count);
                //table header
                table2.WidthPercentage = 100;
                table2.TotalWidth = 500f;

                fnt1 = new Font(bfothead, 10, 1, BaseColor.WHITE);
                for (int i = 0; i < tb.Columns.Count; i++)
                {
                    PdfPCell cel = new PdfPCell();
                    cel.BackgroundColor = BaseColor.DARK_GRAY;
                    cel.HorizontalAlignment = Element.ALIGN_CENTER;
                    cel.AddElement(new Chunk(tb.Columns[i].ColumnName.ToUpper(), fnt1));
                    table2.AddCell(cel);
                }
                //table data
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    for (int j = 0; j < tb.Columns.Count; j++)
                    {
                        table2.AddCell(tb.Rows[i][j].ToString());
                    }
                }
                doc.Add(table2);

                prg = new Paragraph();
                prg.Alignment = Element.ALIGN_LEFT;
                prg.Add(new Chunk("\nStudent's Result: \n\n", fnt3));
                doc.Add(prg);
                //Write First Table
                PdfPTable table1 = new PdfPTable(tbb.Columns.Count);
                table1.WidthPercentage = 100;
                table1.TotalWidth = 500f;
                //table header

                fnt1 = new Font(bfothead, 10, 1, BaseColor.WHITE);
                for (int i = 0; i < tbb.Columns.Count; i++)
                {
                    PdfPCell cel = new PdfPCell();
                    cel.BackgroundColor = BaseColor.DARK_GRAY;
                    cel.HorizontalAlignment = Element.ALIGN_CENTER;
                    cel.AddElement(new Chunk(tbb.Columns[i].ColumnName.ToUpper(), fnt1));
                    table1.AddCell(cel);
                }
                //table data
                for (int i = 0; i < tbb.Rows.Count; i++)
                {
                    for (int j = 0; j < tbb.Columns.Count; j++)
                    {
                        table1.AddCell(tbb.Rows[i][j].ToString());
                    }
                }
                doc.Add(table1);

                doc.Close();
                writer.Close();
                fs.Close();
                MessageBox.Show("Report Generated!");
            }
        }

        private void generate_Student_report()
        {
            DataTable tb = MakeStudentTableResult();
            OpenFileDialog op = new OpenFileDialog();
            string folderPath = "";
            op.ValidateNames = false;
            op.CheckFileExists = false;
            op.CheckPathExists = true;
            op.FileName = "Folder Selection.";
            if (op.ShowDialog() == DialogResult.OK)
            {
                folderPath = Path.GetDirectoryName(op.FileName);
                FileStream fs = new FileStream(@"" + folderPath + @"\StudentReport.pdf", FileMode.Create, FileAccess.Write, FileShare.None);
                Document doc = new Document();
                doc.SetPageSize(iTextSharp.text.PageSize
                    .A4);
                PdfWriter writer = PdfWriter.GetInstance(doc, fs);
                doc.Open();

                // Report Header
                BaseFont bfothead = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.NOT_EMBEDDED);
                Font fnt1 = new Font(bfothead, 16, 1, BaseColor.BLACK);
                Font fnt3 = new Font(bfothead, 14, 1, BaseColor.BLACK);
                Paragraph prg = new Paragraph();
                prg.Alignment = Element.ALIGN_CENTER;
                prg.Add(new Chunk("University Of Engineering And Technolgy", fnt1));
                doc.Add(prg);
                prg = new Paragraph();
                prg.Alignment = Element.ALIGN_CENTER;
                Font fnt2 = new Font(bfothead, 12, 2, BaseColor.BLACK);
                prg.Add(new Chunk(" Students Result Report", fnt2));
                doc.Add(prg);
                Paragraph p = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
                doc.Add(p);
                prg = new Paragraph();
                prg.Alignment = Element.ALIGN_LEFT;
                prg.Add(new Chunk("\nCourse:   ", fnt3));
                prg.Add(new Chunk("CS-142L Programming Fundamentals", fnt2));
                prg.Add(new Chunk("\nSemester:   ", fnt3));
                prg.Add(new Chunk("Fall 2022", fnt2));
                prg.Add(new Chunk("\nLecturer:   ", fnt3));
                prg.Add(new Chunk("Samyan Qayyum Wahla\n", fnt2));

                doc.Add(prg);
                p = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
                doc.Add(p);

                prg = new Paragraph();
                prg.Alignment = Element.ALIGN_LEFT;
                prg.Add(new Chunk("\nStudents Report\n\n", fnt3));
                doc.Add(prg);

                // write second table
                PdfPTable table2 = new PdfPTable(tb.Columns.Count);
                //table header
                table2.WidthPercentage = 100;
                table2.TotalWidth = 500f;

                fnt1 = new Font(bfothead, 10, 1, BaseColor.WHITE);
                for (int i = 0; i < tb.Columns.Count; i++)
                {
                    PdfPCell cel = new PdfPCell();
                    cel.BackgroundColor = BaseColor.DARK_GRAY;
                    cel.HorizontalAlignment = Element.ALIGN_CENTER;
                    cel.AddElement(new Chunk(tb.Columns[i].ColumnName.ToUpper(), fnt1));
                    table2.AddCell(cel);
                }
                //table data
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    for (int j = 0; j < tb.Columns.Count; j++)
                    {
                        table2.AddCell(tb.Rows[i][j].ToString());
                    }
                }
                doc.Add(table2);

                doc.Close();
                writer.Close();
                fs.Close();
                MessageBox.Show("Report Generated!");
            }
        }

        private void generate_atten_report()
        {
            DataTable tb = MakeTableAttendanceResult();
            DataTable tbb = MakeTableAttendanceStuResult();
            OpenFileDialog op = new OpenFileDialog();
            string folderPath = "";
            op.ValidateNames = false;
            op.CheckFileExists = false;
            op.CheckPathExists = true;
            op.FileName = "Folder Selection.";
            if (op.ShowDialog() == DialogResult.OK)
            {
                folderPath = Path.GetDirectoryName(op.FileName);
                FileStream fs = new FileStream(@"" + folderPath + @"\AssignWiseReport.pdf", FileMode.Create, FileAccess.Write, FileShare.None);
                Document doc = new Document();
                doc.SetPageSize(iTextSharp.text.PageSize
                    .A4);
                PdfWriter writer = PdfWriter.GetInstance(doc, fs);
                doc.Open();

                // Report Header
                BaseFont bfothead = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.NOT_EMBEDDED);
                Font fnt1 = new Font(bfothead, 16, 1, BaseColor.BLACK);
                Font fnt3 = new Font(bfothead, 14, 1, BaseColor.BLACK);
                Paragraph prg = new Paragraph();
                prg.Alignment = Element.ALIGN_CENTER;
                prg.Add(new Chunk("University Of Engineering And Technolgy", fnt1));
                doc.Add(prg);
                prg = new Paragraph();
                prg.Alignment = Element.ALIGN_CENTER;
                Font fnt2 = new Font(bfothead, 12, 2, BaseColor.BLACK);
                prg.Add(new Chunk("Attendance Report of STudents", fnt2));
                doc.Add(prg);
                Paragraph p = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
                doc.Add(p);
                prg = new Paragraph();
                prg.Alignment = Element.ALIGN_LEFT;
                prg.Add(new Chunk("\nCourse:   ", fnt3));
                prg.Add(new Chunk("CS-142L Programming Fundamentals", fnt2));
                prg.Add(new Chunk("\nSemester:   ", fnt3));
                prg.Add(new Chunk("Fall 2022", fnt2));
                prg.Add(new Chunk("\nLecturer:   ", fnt3));
                prg.Add(new Chunk("Samyan Qayyum Wahla\n", fnt2));

                doc.Add(prg);
                p = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
                doc.Add(p);

                prg = new Paragraph();
                prg.Alignment = Element.ALIGN_LEFT;
                prg.Add(new Chunk("\nStudent Wise Attendance \n\n", fnt3));
                doc.Add(prg);
                //Write First Table
                PdfPTable table1 = new PdfPTable(tbb.Columns.Count);
                table1.WidthPercentage = 100;
                table1.TotalWidth = 500f;
                //table header

                fnt1 = new Font(bfothead, 10, 1, BaseColor.WHITE);
                for (int i = 0; i < tbb.Columns.Count; i++)
                {
                    PdfPCell cel = new PdfPCell();
                    cel.BackgroundColor = BaseColor.DARK_GRAY;
                    cel.HorizontalAlignment = Element.ALIGN_CENTER;
                    cel.AddElement(new Chunk(tbb.Columns[i].ColumnName.ToUpper(), fnt1));
                    table1.AddCell(cel);
                }
                //table data
                for (int i = 0; i < tbb.Rows.Count; i++)
                {
                    for (int j = 0; j < tbb.Columns.Count; j++)
                    {
                        table1.AddCell(tbb.Rows[i][j].ToString());
                    }
                }
                doc.Add(table1);


                prg = new Paragraph();
                prg.Alignment = Element.ALIGN_LEFT;
                prg.Add(new Chunk("\nDate Wise Attendance\n\n", fnt3));
                doc.Add(prg);

                // write second table
                PdfPTable table2 = new PdfPTable(tb.Columns.Count);
                //table header
                table2.WidthPercentage = 100;
                table2.TotalWidth = 500f;

                fnt1 = new Font(bfothead, 10, 1, BaseColor.WHITE);
                for (int i = 0; i < tb.Columns.Count; i++)
                {
                    PdfPCell cel = new PdfPCell();
                    cel.BackgroundColor = BaseColor.DARK_GRAY;
                    cel.HorizontalAlignment = Element.ALIGN_CENTER;
                    cel.AddElement(new Chunk(tb.Columns[i].ColumnName.ToUpper(), fnt1));
                    table2.AddCell(cel);
                }
                //table data
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    for (int j = 0; j < tb.Columns.Count; j++)
                    {
                        table2.AddCell(tb.Rows[i][j].ToString());
                    }
                }
                doc.Add(table2);



                doc.Close();
                writer.Close();
                fs.Close();
                MessageBox.Show("Report Generated!");
            }
        }





        private void dataGridView15_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView15.CurrentCell.ColumnIndex == 3)
            {
                int row = dataGridView15.CurrentCell.RowIndex;
                if (row == 0)
                {
                    generate_clo_report();
                }
                else if (row == 1)
                {
                    generate_assign_report();
                }
                else if (row == 2)
                {
                    generate_atten_report();
                }
                else if (row == 3)
                {
                    generate_Student_report();
                }
            }
            else
            {

            }
        }



        ////// ---------------------    --------------------- //////

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            MainTabControl1.SelectTab(0);
            viewGrid(dataGridView2, "Clo", -1);
        }



        
        private void textBox20_Enter(object sender, EventArgs e)
        {
            if (textBox20.Text == "Search Rubrics Here")
            {
                textBox20.Text = "";
            }
        }

        private void textBox20_Leave(object sender, EventArgs e)
        {
            if (textBox20.Text == "")
            {
                textBox20.Text = "Search Rubrics Here";
            }
        }
        
    }
}
