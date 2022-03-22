using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RubricsBasedProject.Frames
{
    public partial class PreAttend : Form
    {
        private String atteID;
        private String StuI;
        //private String Naam;
        MainFrame cs = new MainFrame();
        //private String RegNo;

        public PreAttend(String attendID,String StuID,String Name,String regNo)
        {
            InitializeComponent();
           
            textBox3.Text = attendID;
            textBox1.Text = Name;
            this.StuI = StuID;
            this.atteID = attendID;
            showCOmboLookUp();
        }

        private void showCOmboLookUp()
        {
            var con = Configuration.getInstance().getConnection();
            String query = "Select Name from Lookup where category = @category";
            SqlCommand sc = new SqlCommand(query, con);
            sc.Parameters.AddWithValue("@category", "ATTENDANCE_STATUS");
            SqlDataReader reader = sc.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("Name", typeof(string));
            dt.Load(reader);
            comboBox1.ValueMember = "Name";
            comboBox1.DataSource = dt;
        }

        private void button12_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        private void button16_MouseClick(object sender, MouseEventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("UPDATE StudentAttendance set AttendanceStatus=@AttendanceStatus where AttendanceId=@AttendanceId AND StudentId=@StudentId", con);
            cmd.Parameters.AddWithValue("@AttendanceId", textBox3.Text);
            cmd.Parameters.AddWithValue("@StudentId", this.StuI);
            cmd.Parameters.AddWithValue("@AttendanceStatus", Lookupid());
            cmd.ExecuteNonQuery();
            this.Close();
        }

        private int Lookupid()
        {
            var con = Configuration.getInstance().getConnection();
            String query2 = "Select LookupId from Lookup where name Like @name";
            SqlCommand cmd2 = new SqlCommand(query2, con);
            cmd2.Parameters.AddWithValue("@name", comboBox1.SelectedValue.ToString());
          //  MessageBox.Show(comboBox1.SelectedItem.ToString());
            SqlDataReader reader = cmd2.ExecuteReader();
            reader.Read();
            int d = reader.GetInt32(0);
            reader.Close();
            return d;
        }
    }
}
