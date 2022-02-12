using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RubricsBasedEvalutation
{
    public partial class Admin : Form
    {
        public Admin()
        {
            
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        // This Function will maximize the window if window is of Normal custom size and if it is
        // of maximium size than to normal size
        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
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

        // This Function will close the Window.
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        // This function will minimize the window.
        private void pictureBox3_MouseClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(3);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(4);
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(133, 224, 133);
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            //button1.BackColor = Color.FromName();
            button1.BackColor = Color.FromArgb(105,105,105);
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {

            button2.BackColor = Color.FromArgb(133, 224, 133);
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.BackColor = Color.FromArgb(133, 224, 133);
        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {

            button4.BackColor = Color.FromArgb(133, 224, 133);
        }

        private void button5_MouseEnter(object sender, EventArgs e)
        {

            button5.BackColor = Color.FromArgb(133, 224, 133);
        }

        private void button6_MouseEnter(object sender, EventArgs e)
        {

            button6.BackColor = Color.FromArgb(133, 224, 133);
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.FromArgb(105, 105, 105);
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.FromArgb(105, 105, 105);
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.BackColor = Color.FromArgb(105, 105, 105);
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            button5.BackColor = Color.FromArgb(105, 105, 105);
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button6_MouseLeave(object sender, EventArgs e)
        {
            button6.BackColor = Color.FromArgb(105, 105, 105);
        }
    }
}
