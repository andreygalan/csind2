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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            refresh();
        }

        private void refresh()
        {
            dataGridView1.Rows.Clear();
            comboBox2.Items.Clear();
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("SELECT `fio` FROM `person` WHERE 1", db.getConnection());
            db.openConnection();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                comboBox2.Items.Add(reader[0]);
            }
            reader.Close();
            db.closeConnection();
            dataGridView1.Rows.Clear();

            command = new MySqlCommand("SELECT t.`idteach`,p.`fio`,t.`department`,t.`position`  FROM `person` p,`teacher` t WHERE p.`idperson`=t.`idperson`", db.getConnection());
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
            if (comboBox2.Text != "" && textBox1.Text != "" && textBox2.Text != "")
            {
                DB db = new DB();
                MySqlCommand command = new MySqlCommand("SELECT `idperson` FROM `person` WHERE `fio`='" + comboBox2.Text.ToString() + "'", db.getConnection());
                db.openConnection();
                MySqlDataReader reader = command.ExecuteReader();
                int idper = 0;           
                if (reader.Read())
                {
                    idper = Convert.ToInt16(reader[0]);
                    reader.Close();

                    command = new MySqlCommand("INSERT INTO `ind2`.`teacher` (`idperson`,`department`,`position`) VALUES(@idp,@dep,@pos)", db.getConnection());
                    command.Parameters.Add("@idp", MySqlDbType.Int16).Value = Convert.ToInt16(idper);
                    command.Parameters.Add("@dep", MySqlDbType.Text).Value = textBox1.Text;
                    command.Parameters.Add("@pos", MySqlDbType.Text).Value = textBox2.Text;
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
                            idper = Convert.ToInt16(reader[0]);
                        reader.Close();

                        command = new MySqlCommand("INSERT INTO `ind2`.`teacher` (`idperson`,`department`,`position`) VALUES(@idp,@dep,@pos)", db.getConnection());
                        command.Parameters.Add("@idp", MySqlDbType.Int16).Value = Convert.ToInt16(idper);
                        command.Parameters.Add("@dep", MySqlDbType.Text).Value = textBox1.Text;
                        command.Parameters.Add("@pos", MySqlDbType.Text).Value = textBox2.Text;

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
