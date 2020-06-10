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
    public partial class subj : Form
    {
        public subj()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                DB db = new DB();


                MySqlCommand command = new MySqlCommand("INSERT INTO `ind2`.`subject` (`subj`) VALUES(@subj)", db.getConnection());
                command.Parameters.Add("@subj", MySqlDbType.VarChar).Value = textBox1.Text;

                db.openConnection();

                if (command.ExecuteNonQuery() == 1)
                    MessageBox.Show("Запись создана");
                else MessageBox.Show("error");

                db.closeConnection();
                textBox1.Clear();
                refresh();
            }
            else MessageBox.Show("Заполните все поля");
        }
        private void refresh()
        {
            dataGridView1.Rows.Clear();
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `subject` WHERE 1", db.getConnection());
            db.openConnection();
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                dataGridView1.Rows.Add(reader[0].ToString(), reader[1].ToString());
            }
            db.closeConnection();            
        }
        private void subj_Load(object sender, EventArgs e)
        {
            refresh();
        }
       
    }
}
