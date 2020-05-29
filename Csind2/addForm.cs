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

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            comboBox4.Items.Clear();
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `week` WHERE 1", db.getConnection());
            db.openConnection();
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                comboBox4.Items.Add(reader[1]);

            }
            db.closeConnection();

            command = new MySqlCommand("SELECT * FROM `teacher` WHERE 1", db.getConnection());
            db.openConnection();
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                comboBox2.Items.Add(reader[1].ToString()+" "+reader[2].ToString()+" "+reader[3].ToString());
            }
            db.closeConnection();

            command = new MySqlCommand("SELECT * FROM `subject` WHERE 1", db.getConnection());

            db.openConnection();
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                comboBox3.Items.Add(reader[1]);
            }
            db.closeConnection();
            command = new MySqlCommand("SELECT * FROM `group` WHERE 1", db.getConnection());

            db.openConnection();
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                comboBox1.Items.Add(reader[1]);
            }
            db.closeConnection();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string gr = comboBox1.Text;
            string id;
            string tch = comboBox2.Text;
            string day = comboBox4.Text;
            string subj = comboBox3.Text;

            DB db = new DB();
            MySqlCommand command = new MySqlCommand("SELECT `id` FROM `week` WHERE `day`='" + day+"'", db.getConnection());
            db.openConnection();
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                day = reader[0].ToString();
            }
            db.closeConnection();

            command = new MySqlCommand("SELECT `id` FROM `group` WHERE `numgr`=" + gr, db.getConnection());
            db.openConnection();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                gr = reader[0].ToString();
            }
            db.closeConnection();
            command = new MySqlCommand("SELECT `id` FROM `subject` WHERE `subj`='" + subj+"'", db.getConnection());
            db.openConnection();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                subj = reader[0].ToString();
            }
            db.closeConnection();
            string[] name = tch.Split(new char[] { ' ' });
            string ln = name[0];
            string fn = name[1];
            string mn = name[2];
            command = new MySqlCommand("SELECT `id` FROM `teacher` WHERE `last names`='" + ln+ "' AND `first name`='"+fn+ "' AND `middle names`='"+mn+"'", db.getConnection());
            db.openConnection();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                tch = reader[0].ToString();
            }
            db.closeConnection();
            command = new MySqlCommand("INSERT INTO `ind2`.`schedule` (`idrg`, `idteach`, `idsubject`,`iday`) VALUES(@irg, @itc, @isb,@iday)", db.getConnection());
            command.Parameters.Add("@irg", MySqlDbType.Int16).Value = Convert.ToInt16(gr);
            command.Parameters.Add("@itc", MySqlDbType.Int16).Value = Convert.ToInt16(tch);
            command.Parameters.Add("@isb", MySqlDbType.Int16).Value = Convert.ToInt16(subj);
            command.Parameters.Add("@iday", MySqlDbType.Int16).Value = Convert.ToInt16(day);


            db.openConnection();
            if (command.ExecuteNonQuery() == 1)
                MessageBox.Show("Запись создана");
            else MessageBox.Show("error");

            db.closeConnection();


        }
    }
    
}
