using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Csind2
{
    public partial class addForm : Form
    {
        public addForm()
        {
            InitializeComponent();
        }

        
            private void button1_Click(object sender, EventArgs e)
            {

                string lname = textBox1.Text;
                string fname = textBox2.Text;
                string mname = textBox3.Text;
                string dep = textBox4.Text;
                string pos = textBox5.Text;
                DB db = new DB();

                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                MySqlCommand command = new MySqlCommand("INSERT INTO `ind2`.`teacher` (`last names`, `first name`, `middle names`, `department`, `position`) VALUES(@ln, @fn, @mn, @dp, @pos)", db.getConnection());
                command.Parameters.Add("@ln", MySqlDbType.VarChar).Value = lname;
                command.Parameters.Add("@fn", MySqlDbType.VarChar).Value = fname;
                command.Parameters.Add("@mn", MySqlDbType.VarChar).Value = mname;
                command.Parameters.Add("@dp", MySqlDbType.Text).Value = dep;
                command.Parameters.Add("@pos", MySqlDbType.Text).Value = pos;

                db.openConnection();

                if (command.ExecuteNonQuery() == 1)
                    MessageBox.Show("Запись создана");
                else MessageBox.Show("error");

                db.closeConnection();

            }

        private void button2_Click(object sender, EventArgs e)
        {
            string ng = ngrouptext.Text;
            string ns = numstt.Text;
            string hm = headmn.Text;
           

            DB db = new DB();

            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("INSERT INTO `ind2`.`group` (`numgr`, `numstud`, `headman`) VALUES(@ng, @ns, @hm)", db.getConnection());
            command.Parameters.Add("@ng", MySqlDbType.VarChar).Value = ng;
            command.Parameters.Add("@ns", MySqlDbType.VarChar).Value = ns;
            command.Parameters.Add("@hm", MySqlDbType.VarChar).Value = hm;
           

            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
                MessageBox.Show("Запись создана");
            else MessageBox.Show("error");

            db.closeConnection();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sb = dispt.Text;
          


            DB db = new DB();

            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("INSERT INTO `ind2`.`subject` (`subj`) VALUES(@sb)", db.getConnection());
            command.Parameters.Add("@sb", MySqlDbType.VarChar).Value = sb;
          
           


            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
                MessageBox.Show("Запись создана");
            else MessageBox.Show("error");

            db.closeConnection();
        }
    }
    
}
