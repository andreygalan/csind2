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
    public partial class rasp : Form
    {
        public rasp()
        {
            InitializeComponent();
        }


        public void refresh()
        {
            List<string> id = new List<string>();
            List<string> idgr = new List<string>();
            List<string> idteach = new List<string>();
            List<string> idsubj = new List<string>();
            List<string> iday = new List<string>();

            dataGridView1.Rows.Clear();

            DB db = new DB();

            MySqlCommand command = new MySqlCommand("SELECT q.`id`,p.`fio` ,x.`numgr` ,z.`subj` , w.`day`,q.`numpar` FROM `schedule` q, `group` x, `teacher` y, `subject` z, `week` w,`person` p WHERE x.`idgr` = q.`idrg` AND y.`idteach` = q.`idteach` AND z.`idsubject` = q.`idsubject` AND w.`iday` = q.`iday`AND y.`idperson`=p.`idperson`", db.getConnection());
            db.openConnection();
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                dataGridView1.Rows.Add();
                dataGridView1[0, dataGridView1.Rows.Count - 1].Value = reader[0].ToString();
                dataGridView1[1, dataGridView1.Rows.Count - 1].Value = reader[1].ToString();
                dataGridView1[2, dataGridView1.Rows.Count - 1].Value = reader[2].ToString();
                dataGridView1[3, dataGridView1.Rows.Count - 1].Value = reader[3].ToString();
                dataGridView1[4, dataGridView1.Rows.Count - 1].Value = reader[4].ToString();
                dataGridView1[5, dataGridView1.Rows.Count - 1].Value = reader[5].ToString();
            }
            reader.Close();
            db.closeConnection();

            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            comboBox4.Items.Clear();
            comboBox5.Items.Clear();

            command = new MySqlCommand("SELECT * FROM `week` WHERE 1", db.getConnection());
           db.openConnection();
           reader = command.ExecuteReader();

            while (reader.Read())
            {
                comboBox4.Items.Add(reader[1]);
            }
            reader.Close();

            command = new MySqlCommand("SELECT p.`fio` FROM `teacher` t,`person` p WHERE t.`idperson`=p.`idperson`", db.getConnection());
           
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                comboBox2.Items.Add(reader[0].ToString());
            }
            reader.Close();

            command = new MySqlCommand("SELECT * FROM `subject` WHERE 1", db.getConnection());

            
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                comboBox3.Items.Add(reader[1]);
            }
            reader.Close();
            command = new MySqlCommand("SELECT * FROM `group` WHERE 1", db.getConnection());

            
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                comboBox1.Items.Add(reader[1]);
            }
            reader.Close();
            command = new MySqlCommand("SELECT * FROM `numpar` WHERE 1", db.getConnection());

            
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                comboBox5.Items.Add(reader[0]);
            }
            reader.Close();
            db.closeConnection();

        }

        private void rasp_Load(object sender, EventArgs e)
        {
            refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "" && comboBox2.Text != "" && comboBox3.Text != "" && comboBox4.Text != "" && comboBox5.Text != "")
            {
                string gr = comboBox1.Text;
                string tch = comboBox2.Text;
                string day = comboBox4.Text;
                string subj = comboBox3.Text;

                DB db = new DB();
                MySqlCommand command = new MySqlCommand("SELECT `iday` FROM `week` WHERE `day`='" + day + "'", db.getConnection());
                db.openConnection();
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    day = reader[0].ToString();
                }
                reader.Close();

                command = new MySqlCommand("SELECT `idgr` FROM `group` WHERE `numgr`=" + gr, db.getConnection());

                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    gr = reader[0].ToString();
                }
                reader.Close();
                command = new MySqlCommand("SELECT `idsubject` FROM `subject` WHERE `subj`='" + subj + "'", db.getConnection());
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    subj = reader[0].ToString();
                }
                reader.Close();
                string[] name = tch.Split(new char[] { ' ' });

                command = new MySqlCommand("SELECT t.`idteach` FROM `teacher` t, `person` p WHERE p.`fio`='" + comboBox2.Text + "' AND t.`idperson`=p.`idperson`", db.getConnection());

                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    tch = reader[0].ToString();
                }
                reader.Close();


                command = new MySqlCommand("INSERT INTO `ind2`.`schedule` (`idrg`, `idteach`, `idsubject`,`iday`,`numpar`) VALUES(@irg, @itc, @isb,@iday,@numpar)", db.getConnection());
                command.Parameters.Add("@irg", MySqlDbType.Int16).Value = Convert.ToInt16(gr);
                command.Parameters.Add("@itc", MySqlDbType.Int16).Value = Convert.ToInt16(tch);
                command.Parameters.Add("@isb", MySqlDbType.Int16).Value = Convert.ToInt16(subj);
                command.Parameters.Add("@iday", MySqlDbType.Int16).Value = Convert.ToInt16(day);
                command.Parameters.Add("@numpar", MySqlDbType.Int16).Value = Convert.ToInt16(comboBox5.Text);


                db.openConnection();
                if (command.ExecuteNonQuery() == 1)
                    MessageBox.Show("Запись создана");
                else MessageBox.Show("error");

                db.closeConnection();
                refresh();
            }
            else MessageBox.Show("Заполните все поля");
        }
    }
}
