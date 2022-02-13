using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RubricsBasedEvalutation.Frames
{
    public partial class Student : Form
    {
        public Student()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

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

        private void pictureBox3_MouseClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(133, 224, 133);
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

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(105, 105, 105);
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.BackColor = Color.FromArgb(105, 105, 105);
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            button5.BackColor = Color.FromArgb(105, 105, 105);
        }

      

        private void button6_MouseLeave_1(object sender, EventArgs e)
        {
            button6.BackColor = Color.FromArgb(105, 105, 105);
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            tabControl1.SelectTab(0);
        }

        private void button4_MouseClick(object sender, MouseEventArgs e)
        {
            tabControl1.SelectTab(1);
        }

        private void button5_MouseClick(object sender, MouseEventArgs e)
        {
            tabControl1.SelectTab(2);
        }

        private void button2_MouseClick(object sender, MouseEventArgs e)
        {
            tabControl2.SelectTab(0);
        }

        private void button3_MouseClick(object sender, MouseEventArgs e)
        {
            tabControl2.SelectTab(1);
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.BackColor = Color.FromArgb(133, 224, 133);
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.BackColor = Color.FromArgb(133, 224, 133);
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.FromArgb(105, 105, 105);
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.FromArgb(105, 105, 105);
        }
    }
}
