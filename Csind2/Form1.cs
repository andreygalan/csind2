using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Csind2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            
            InitializeComponent();
            refresh();



        }




        public void refresh()
        {
            refreshrasp();
            refreshpers();
            refreshteach();
            refreshst();
            refreshgr();
            refreshsub();
        }

        private void преподавательToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 newform = new Form3();
            newform.Show();
        }

        private void студентToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 newform = new Form2();
            newform.StartPosition = FormStartPosition.Manual;
            newform.Location = this.Location;
            newform.Show();
        }

        private void человекToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pers newform = new pers();
            newform.StartPosition = FormStartPosition.Manual;
            newform.Location = this.Location;
            newform.Show();
        }

        private void расписаниеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rasp newform = new rasp();
            newform.StartPosition = FormStartPosition.Manual;
            newform.Location = this.Location;
            newform.Show();
        }

        private void дисциплинаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            subj newform = new subj();
            newform.StartPosition = FormStartPosition.Manual;
            newform.Location = this.Location;
            newform.Show();
        }

        private void группаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            group newform = new group();
            newform.StartPosition = FormStartPosition.Manual;
            newform.Location = this.Location;
            newform.Show();

        }

        private void редактироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            edForm newForm = new edForm(this);
            newForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Height += 100;
            button1.Hide();
            refreshzapros();
            label1.Show();
            label2.Show();
            comboBox1.Show();
            comboBox2.Show();
            button3.Show();
            button2.Show();
            button4.Show();

        }
        private void refreshrasp()
        {

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

                

        }
        private void refreshpers()
        {
            dataGridView6.Rows.Clear();
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `person` WHERE 1", db.getConnection());
            db.openConnection();
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                dataGridView6.Rows.Add(reader[0].ToString(), reader[1].ToString());
            }
            db.closeConnection();
        }
        private void refreshteach()
        {
            dataGridView2.Rows.Clear();
            
            DB db = new DB();
                       
            MySqlCommand command = new MySqlCommand("SELECT t.`idteach`,p.`fio`,t.`department`,t.`position`  FROM `person` p,`teacher` t WHERE p.`idperson`=t.`idperson`", db.getConnection());
           db.openConnection();
           MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                dataGridView2.Rows.Add(reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString());
            }
            db.closeConnection();
        }
        private void refreshst()
        {
            dataGridView3.Rows.Clear();   
            DB db = new DB();
                  
            MySqlCommand  command = new MySqlCommand("SELECT s.`idstudent`,p.`fio`,g.`numgr`  FROM `person` p,`student` s, `group` g WHERE p.`idperson`=s.`idperson` AND g.`idgr`=s.`idgroup`", db.getConnection());
            db.openConnection();
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                dataGridView3.Rows.Add(reader[0].ToString(), reader[1].ToString(), reader[2].ToString());
            }
            db.closeConnection();
        }
        private void refreshgr()
        {
            dataGridView4.Rows.Clear();
            DB db = new DB();

            MySqlCommand command = new MySqlCommand("SELECT g.`idgr`, g.`numgr`, g.`numstud`,p.`fio` FROM `person` p,`student` s, `group` g WHERE s.`idstudent`=g.`headman` AND p.`idperson`=s.`idperson`", db.getConnection());
            db.openConnection();
            MySqlDataReader reader = command.ExecuteReader();


            while (reader.Read())
            {
                dataGridView4.Rows.Add(reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString());
            }

            db.closeConnection();
        }
        private void refreshsub()
        {
            dataGridView5.Rows.Clear();
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `subject` WHERE 1", db.getConnection());
            db.openConnection();
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                dataGridView5.Rows.Add(reader[0].ToString(), reader[1].ToString());
            }
            db.closeConnection();
        }
        private void refreshzapros()
        {
            comboBox2.Items.Clear();
            comboBox1.Items.Clear();

            DB db = new DB();

            MySqlCommand command = new MySqlCommand("SELECT p.`fio` FROM `teacher` t,`person` p WHERE t.`idperson`=p.`idperson`", db.getConnection());
            db.openConnection();
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                comboBox2.Items.Add(reader[0].ToString());
            }
            reader.Close();

            command = new MySqlCommand("SELECT * FROM `group` WHERE 1", db.getConnection());
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                comboBox1.Items.Add(reader[1]);
            }
            reader.Close();
            db.closeConnection();
        }

        private void button3_Click(object sender, EventArgs e)
        { if (comboBox1.Text != "")
            {
                dataGridView1.Rows.Clear();

                DB db = new DB();

                MySqlCommand command = new MySqlCommand("SELECT q.`id`,p.`fio` ,x.`numgr` ,z.`subj` , w.`day`,q.`numpar` FROM `schedule` q, `group` x, `teacher` y, `subject` z, `week` w,`person` p WHERE x.`idgr` = q.`idrg` AND y.`idteach` = q.`idteach` AND z.`idsubject` = q.`idsubject` AND w.`iday` = q.`iday` AND y.`idperson`=p.`idperson` AND x.`numgr`='" + comboBox1.Text + "' ORDER BY q.`iday` ASC", db.getConnection());
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
            }
            else MessageBox.Show("Заполните поле");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {
                dataGridView1.Rows.Clear();

            DB db = new DB();

            MySqlCommand command = new MySqlCommand("SELECT q.`id`,p.`fio` ,x.`numgr` ,z.`subj` , w.`day`,q.`numpar` FROM `schedule` q, `group` x, `teacher` y, `subject` z, `week` w,`person` p WHERE x.`idgr` = q.`idrg` AND y.`idteach` = q.`idteach` AND z.`idsubject` = q.`idsubject` AND w.`iday` = q.`iday` AND y.`idperson`=p.`idperson` AND p.`fio`='" + comboBox2.Text + "' ORDER BY q.`iday` ASC", db.getConnection());
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
            }
            else MessageBox.Show("Заполните поле");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Height -= 100;
            button1.Show();
            refreshzapros();
            label1.Hide();
            label2.Hide();
            comboBox1.Hide();
            comboBox2.Hide();
            button3.Hide();
            button2.Hide();
            button4.Hide();
            refreshrasp();
        }
    }
}
