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
            List<string> id = new List<string>();
            List<string> idgr = new List<string>();
            List<string> idteach = new List<string>();
            List<string> idsubj = new List<string>();
            List<string> iday = new List<string>();
          

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

        private void add1_Click(object sender, EventArgs e)
        {
            addForm newForm = new addForm();
            newForm.Show();
        }

        private void edit1_Click(object sender, EventArgs e)
        {
            edForm newForm = new edForm();
            newForm.Show();
        }

        private void del1_Click(object sender, EventArgs e)
        {
            delForm newForm = new delForm();
            newForm.Show();
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
    }
}
