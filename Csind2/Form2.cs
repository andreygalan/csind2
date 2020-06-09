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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            refresh();
        }
        private void refresh()
        {
            dataGridView1.Rows.Clear();
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("SELECT `numgr` FROM `group` WHERE 1", db.getConnection());
            db.openConnection();
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                comboBox1.Items.Add(reader[0]);
            }
            reader.Close();
            command = new MySqlCommand("SELECT `fio` FROM `person` WHERE 1", db.getConnection());
            db.openConnection();
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                comboBox2.Items.Add(reader[0]);
            }
            reader.Close();
            db.closeConnection();
            dataGridView1.Rows.Clear();
            
             command = new MySqlCommand("SELECT s.`idstudent`,p.`fio`,g.`numgr`  FROM `person` p,`student` s, `group` g WHERE p.`idperson`=s.`idperson` AND g.`idgr`=s.`idgroup`", db.getConnection());
            db.openConnection();
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                dataGridView1.Rows.Add(reader[0].ToString(), reader[1].ToString(),reader[2].ToString());
            }
            db.closeConnection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "" && comboBox2.Text != "")
            {
                DB db = new DB();
                MySqlCommand command = new MySqlCommand("SELECT `idgr` FROM `group` WHERE `numgr`='" + comboBox1.Text.ToString() + "'", db.getConnection());
                db.openConnection();
                MySqlDataReader reader = command.ExecuteReader();
                int idgr = 0;
                while (reader.Read())
                {
                    idgr = Convert.ToInt16(reader[0]);
                }
                reader.Close();
                command = new MySqlCommand("SELECT `idperson` FROM `person` WHERE `fio`='" + comboBox2.Text.ToString() + "'", db.getConnection());
                db.openConnection();
                reader = command.ExecuteReader();
                int idstud = 0;
                if (reader.Read())
                {
                    idstud = Convert.ToInt16(reader[0]);
                    reader.Close();

                    command = new MySqlCommand("INSERT INTO `ind2`.`student` (`idperson`,`idgroup`) VALUES(@idp,@idgr)", db.getConnection());
                    command.Parameters.Add("@idp", MySqlDbType.Int16).Value = Convert.ToInt16(idstud);
                    command.Parameters.Add("@idgr", MySqlDbType.Int16).Value = Convert.ToInt16(idgr);
                    if (command.ExecuteNonQuery() == 1)
                        MessageBox.Show("Запись создана");
                    else MessageBox.Show("error");
                }
                else
                {
                    reader.Close();

                    if (MessageBox.Show("Человека с данным именем нет в базе данных. Добавить?", "Подтвердите!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        command = new MySqlCommand("INSERT INTO `ind2`.`person` (`fio`) VALUES(@fio)", db.getConnection());
                        command.Parameters.Add("@fio", MySqlDbType.VarChar).Value = comboBox2.Text;

                        if (command.ExecuteNonQuery() == 1)
                            MessageBox.Show("Запись создана");
                        else MessageBox.Show("error");

                        db.closeConnection();
                        command = new MySqlCommand("SELECT `idperson` FROM `person` WHERE `fio`='" + comboBox2.Text.ToString() + "'", db.getConnection());
                        db.openConnection();
                        reader = command.ExecuteReader();
                        while (reader.Read())
                            idstud = Convert.ToInt16(reader[0]);
                        reader.Close();

                        command = new MySqlCommand("INSERT INTO `ind2`.`student` (`idperson`,`idgroup`) VALUES(@idp,@idgr)", db.getConnection());
                        command.Parameters.Add("@idp", MySqlDbType.Int16).Value = Convert.ToInt16(idstud);
                        command.Parameters.Add("@idgr", MySqlDbType.Int16).Value = Convert.ToInt16(idgr);

                        if (command.ExecuteNonQuery() == 1)
                            MessageBox.Show("Запись создана");
                        else MessageBox.Show("error");
                    }



                }
                refresh();
            }
            else MessageBox.Show("Заполните все поля");
        }
    }
}
