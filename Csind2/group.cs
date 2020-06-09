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
    public partial class group : Form
    {
        public group()
        {
            InitializeComponent();
        }

        private void group_Load(object sender, EventArgs e)
        {
            refresh();
        }

        private void refresh()
        {
            dataGridView1.Rows.Clear();
            comboBox1.Items.Clear();
         
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("SELECT p.`fio` FROM `student` t,`person` p WHERE t.`idperson`=p.`idperson`", db.getConnection());
            db.openConnection();
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                comboBox1.Items.Add(reader[0]);
            }
            reader.Close();          
            db.closeConnection();
            dataGridView1.Rows.Clear();

            command = new MySqlCommand("SELECT g.`idgr`, g.`numgr`, g.`numstud`,p.`fio` FROM `person` p,`student` s, `group` g WHERE s.`idstudent`=g.`headman` AND p.`idperson`=s.`idperson`", db.getConnection());
            db.openConnection();
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                dataGridView1.Rows.Add(reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString());
            }
            db.closeConnection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "" && textBox1.Text != "" && textBox2.Text != "")
            {
                DB db = new DB();
                MySqlCommand command = new MySqlCommand("SELECT s.`idstudent` FROM `student` s, `person` p WHERE p.`fio`='" + comboBox1.Text + "' AND s.`idperson`=p.`idperson`", db.getConnection());
                db.openConnection();
                MySqlDataReader reader = command.ExecuteReader();
                int idstud = 0;
                while (reader.Read())
                {
                    idstud = Convert.ToInt16(reader[0]);
                }
                reader.Close();


                command = new MySqlCommand("INSERT INTO `ind2`.`group` (`numgr`, `numstud`, `headman`) VALUES(@numgr, @numstud, @headman)", db.getConnection());
                command.Parameters.Add("@numgr", MySqlDbType.VarChar).Value = textBox1.Text;
                command.Parameters.Add("@numstud", MySqlDbType.Int16).Value = Convert.ToInt16(textBox2.Text);
                command.Parameters.Add("@headman", MySqlDbType.Int16).Value = Convert.ToInt16(idstud);




                if (command.ExecuteNonQuery() == 1)
                    MessageBox.Show("Запись создана");
                else MessageBox.Show("error");
                refresh();
            }
            else MessageBox.Show("Заполните все поля");
        }
       
    }
}
