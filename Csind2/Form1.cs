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
            MySqlCommand command = new MySqlCommand("SELECT * FROM `schedule` WHERE 1", db.getConnection());
            db.openConnection();
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                id.Add(reader[0].ToString());
                idgr.Add(reader[1].ToString());
                idteach.Add(reader[2].ToString());
                idsubj.Add(reader[3].ToString());
                iday.Add(reader[4].ToString());
            }
            db.closeConnection();


            for (int i = 0; i < id.Count; i++)
            {
                command = new MySqlCommand("SELECT `numgr` FROM `group` WHERE `id`='" + idgr[i] + "'", db.getConnection());
                db.openConnection();
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    dataGridView1.Rows.Add();
                    dataGridView1[0, dataGridView1.Rows.Count - 1].Value = id[i];
                    dataGridView1[1, dataGridView1.Rows.Count - 1].Value = reader[0].ToString();
                }
                reader.Close();

                command = new MySqlCommand("SELECT `last names` , `first name` , `middle names` FROM `teacher` WHERE `id`='" + idteach[i] + "'", db.getConnection());

                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    dataGridView1[2, dataGridView1.Rows.Count - 1].Value = reader[0].ToString() + " " + reader[1].ToString() + " " + reader[2].ToString();
                }
                reader.Close();

                command = new MySqlCommand("SELECT `subj` FROM `subject` WHERE `id`='" + idsubj[i] + "'", db.getConnection());

                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    dataGridView1[3, dataGridView1.Rows.Count - 1].Value = reader[0].ToString();
                }
                reader.Close();

                command = new MySqlCommand("SELECT `day` FROM `week` WHERE `id`='" + iday[i] + "'", db.getConnection());

                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    dataGridView1[4, dataGridView1.Rows.Count - 1].Value = reader[0].ToString();
                }
                reader.Close();


                db.closeConnection();
            }
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
            addForm newForm = new addForm();
            newForm.Show();
        }
    }
}
