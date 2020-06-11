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
    public partial class edForm : Form
    {
        Form1 form;
        public edForm(Form1 pform)
        {
            InitializeComponent();
            form = pform;
        }

        private void edForm_Load(object sender, EventArgs e)
        {
            refreshrasp();
            refreshteach();
            refreshst();
            refreshgr();
            refreshsub();
            refreshpers();
        }
        private void edForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            form.refresh();
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
            try
            {
                idr = Convert.ToInt16(dataGridView1.SelectedRows[0].Cells[0].Value);
                comboBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                comboBox1.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                comboBox3.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                comboBox4.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                comboBox5.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            }
            catch { }

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
            comboBox6.Items.Clear();
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("SELECT `fio` FROM `person` WHERE 1", db.getConnection());
            db.openConnection();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                comboBox6.Items.Add(reader[0]);
            }
            reader.Close();
            db.closeConnection();
            dataGridView2.Rows.Clear();

            command = new MySqlCommand("SELECT t.`idteach`,p.`fio`,t.`department`,t.`position`  FROM `person` p,`teacher` t WHERE p.`idperson`=t.`idperson`", db.getConnection());
            db.openConnection();
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                dataGridView2.Rows.Add(reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString());
            }
            db.closeConnection();
        }
        private void refreshst()
        {
            dataGridView3.Rows.Clear();
            stcomboBox1.Items.Clear();
            stcomboBox2.Items.Clear();
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("SELECT `numgr` FROM `group` WHERE 1", db.getConnection());
            db.openConnection();
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                stcomboBox2.Items.Add(reader[0]);
            }
            reader.Close();
            command = new MySqlCommand("SELECT `fio` FROM `person` WHERE 1", db.getConnection());
            db.openConnection();
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                stcomboBox1.Items.Add(reader[0]);
            }
            reader.Close();
            db.closeConnection();
            dataGridView3.Rows.Clear();

            command = new MySqlCommand("SELECT s.`idstudent`,p.`fio`,g.`numgr`  FROM `person` p,`student` s, `group` g WHERE p.`idperson`=s.`idperson` AND g.`idgr`=s.`idgroup`", db.getConnection());
            db.openConnection();
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                dataGridView3.Rows.Add(reader[0].ToString(), reader[1].ToString(), reader[2].ToString());
            }
            db.closeConnection();
        }
        private void refreshgr()
        {
            dataGridView4.Rows.Clear();
            grcomboBox.Items.Clear();

            DB db = new DB();
            MySqlCommand command = new MySqlCommand("SELECT p.`fio` FROM `student` s,`person` p WHERE s.`idperson`=p.`idperson`", db.getConnection());
            db.openConnection();
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                grcomboBox.Items.Add(reader[0]);
            }
            reader.Close();

            dataGridView4.Rows.Clear();

            command = new MySqlCommand("SELECT g.`idgr`, g.`numgr`, g.`numstud`,p.`fio` FROM `person` p,`student` s, `group` g WHERE s.`idstudent`=g.`headman` AND p.`idperson`=s.`idperson`", db.getConnection());

            reader = command.ExecuteReader();

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


        private int idr = 0;
        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                idr = Convert.ToInt16(dataGridView1.SelectedRows[0].Cells[0].Value);
                comboBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                comboBox1.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                comboBox3.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                comboBox4.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                comboBox5.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            }
            catch { }
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


                command = new MySqlCommand("UPDATE `ind2`.`schedule` SET `idrg` = @irg,`idteach` = @itc,`idsubject` = @isb,`iday` = @iday,`numpar` = @numpar WHERE `schedule`.`id` =" + idr.ToString(), db.getConnection());
                command.Parameters.Add("@irg", MySqlDbType.Int16).Value = Convert.ToInt16(gr);
                command.Parameters.Add("@itc", MySqlDbType.Int16).Value = Convert.ToInt16(tch);
                command.Parameters.Add("@isb", MySqlDbType.Int16).Value = Convert.ToInt16(subj);
                command.Parameters.Add("@iday", MySqlDbType.Int16).Value = Convert.ToInt16(day);
                command.Parameters.Add("@numpar", MySqlDbType.Int16).Value = Convert.ToInt16(comboBox5.Text);


                db.openConnection();
                if (command.ExecuteNonQuery() == 1)
                    MessageBox.Show("Запись изменена");
                else MessageBox.Show("error");

                db.closeConnection();
                refreshrasp();
            }
            else MessageBox.Show("Заполните все поля");
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Удалить запись?", "Подтвердите!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DB db = new DB();
                MySqlCommand command = new MySqlCommand("DELETE FROM `ind2`.`schedule` WHERE `schedule`.`id` =" + idr.ToString(), db.getConnection());
                db.openConnection();
                if (command.ExecuteNonQuery() == 1)
                    MessageBox.Show("Запись удалена");
                else MessageBox.Show("error");

                db.closeConnection();
                refreshrasp();
            }
        }

        

        private int idt = 0;

        private void deltbutton_Click(object sender, EventArgs e)
        {


            if (MessageBox.Show("Удалить запись и все связанные записи?", "Подтвердите!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DB db = new DB();
                MySqlCommand command = new MySqlCommand("DELETE `t`, `s`  FROM `ind2`.`teacher` `t` LEFT JOIN `ind2`.`schedule` `s` ON `s`.`idteach`=`t`.`idteach` where `t`.`idteach`=" + idt.ToString(), db.getConnection());
                db.openConnection();
                if (command.ExecuteNonQuery() == 1)
                    MessageBox.Show("Запись удалена");
                else MessageBox.Show("error");

                db.closeConnection();
                refreshteach();
            }
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                idt = Convert.ToInt16(dataGridView2.SelectedRows[0].Cells[0].Value);
                comboBox6.Text = dataGridView2.SelectedRows[0].Cells[1].Value.ToString();
                textBox2.Text = dataGridView2.SelectedRows[0].Cells[2].Value.ToString();
                textBox3.Text = dataGridView2.SelectedRows[0].Cells[3].Value.ToString();

            }
            catch { }
        }

        private void edtbutton_Click(object sender, EventArgs e)
        {
            if (comboBox6.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                DB db = new DB();
                MySqlCommand command = new MySqlCommand("SELECT `idperson` FROM `person` WHERE `fio`='" + comboBox6.Text.ToString() + "'", db.getConnection());
                db.openConnection();
                MySqlDataReader reader = command.ExecuteReader();
                int idper = 0;
                while(reader.Read())
                         idper = Convert.ToInt16(reader[0]);
                reader.Close();
                command = new MySqlCommand("UPDATE `ind2`.`teacher` SET `idperson`=@idp,`department`=@dep,`position`=@pos WHERE `teacher`.`idteach` =" + idt.ToString(), db.getConnection());
                command.Parameters.Add("@idp", MySqlDbType.Int16).Value = Convert.ToInt16(idper);
                command.Parameters.Add("@dep", MySqlDbType.Text).Value = textBox2.Text;
                command.Parameters.Add("@pos", MySqlDbType.Text).Value = textBox3.Text;
                if (command.ExecuteNonQuery() == 1)
                    MessageBox.Show("Запись изменена");
                else MessageBox.Show("error");
            }
            else MessageBox.Show("Заполните все поля");



            refreshteach();
            refreshrasp();
        }

       
        private int idst;
        private void dataGridView3_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                idst = Convert.ToInt16(dataGridView3.SelectedRows[0].Cells[0].Value);
                stcomboBox1.Text = dataGridView3.SelectedRows[0].Cells[1].Value.ToString();
                stcomboBox2.Text = dataGridView3.SelectedRows[0].Cells[2].Value.ToString();
                
            }
            catch { }
        }

        private void stdelbutton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Удалить запись?", "Подтвердите!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DB db = new DB();
                MySqlCommand command = new MySqlCommand("DELETE FROM `ind2`.`student` WHERE `student`.`idstudent` =" + idst.ToString(), db.getConnection());
                db.openConnection();
                if (command.ExecuteNonQuery() == 1)
                    MessageBox.Show("Запись удалена");
                else MessageBox.Show("error");

                db.closeConnection();
                refreshrasp();
            }
        }

        private void stedbutton_Click(object sender, EventArgs e)
        {
            if (stcomboBox1.Text != "" && stcomboBox2.Text != "")
            {
                DB db = new DB();
                MySqlCommand command = new MySqlCommand("SELECT `idgr` FROM `group` WHERE `numgr`='" + stcomboBox2.Text.ToString() + "'", db.getConnection());
                db.openConnection();
                MySqlDataReader reader = command.ExecuteReader();
                int idgr = 0;
                while (reader.Read())
                {
                    idgr = Convert.ToInt16(reader[0]);
                }
                reader.Close();
                command = new MySqlCommand("SELECT `idperson` FROM `person` WHERE `fio`='" + stcomboBox1.Text.ToString() + "'", db.getConnection());
                db.openConnection();
                reader = command.ExecuteReader();
                int idstud = 0;
                while(reader.Read())               
                    idstud = Convert.ToInt16(reader[0]);

                reader.Close();

                command = new MySqlCommand("UPDATE `ind2`.`student` SET `idperson` = @idp,`idgroup` =@idgr WHERE `student`.`idstudent` = " + idst.ToString(), db.getConnection());
                command.Parameters.Add("@idp", MySqlDbType.Int16).Value = Convert.ToInt16(idstud);
                command.Parameters.Add("@idgr", MySqlDbType.Int16).Value = Convert.ToInt16(idgr);
                if (command.ExecuteNonQuery() == 1)
                        MessageBox.Show("Запись изменена");
                else MessageBox.Show("error");
                
            } else MessageBox.Show("Заполните все поля");
            refreshst();
        }

        
        private int idgr=0;
        private void dataGridView4_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                idgr = Convert.ToInt16(dataGridView4.SelectedRows[0].Cells[0].Value);
                grtextBox1.Text = dataGridView4.SelectedRows[0].Cells[1].Value.ToString();
                grtextBox2.Text = dataGridView4.SelectedRows[0].Cells[2].Value.ToString();
                grcomboBox.Text = dataGridView4.SelectedRows[0].Cells[3].Value.ToString();

            }
            catch { }
        }

        private void gredbutton_Click(object sender, EventArgs e)
        {
            if (grcomboBox.Text != "" && grtextBox1.Text != "" && grtextBox2.Text != "")
            {
                DB db = new DB();
                MySqlCommand command = new MySqlCommand("SELECT s.`idstudent` FROM `student` s, `person` p WHERE p.`fio`='" + grcomboBox.Text + "' AND s.`idperson`=p.`idperson`", db.getConnection());
                db.openConnection();
                MySqlDataReader reader = command.ExecuteReader();
                int idstud = 0;
                while (reader.Read())
                {
                    idstud = Convert.ToInt16(reader[0]);
                }
                reader.Close();


                command = new MySqlCommand("UPDATE `ind2`.`group` SET `numgr`=@numgr, `numstud`=@numstud, `headman`=@headman WHERE `group`.`idgr` =" + idgr.ToString(), db.getConnection());
                command.Parameters.Add("@numgr", MySqlDbType.VarChar).Value = grtextBox1.Text;
                command.Parameters.Add("@numstud", MySqlDbType.Int16).Value = Convert.ToInt16(grtextBox2.Text);
                command.Parameters.Add("@headman", MySqlDbType.Int16).Value = Convert.ToInt16(idstud);


                if (command.ExecuteNonQuery() == 1)
                    MessageBox.Show("Запись изменена");
                else MessageBox.Show("error");
                refreshgr();
                refreshrasp();
            }
            else MessageBox.Show("Заполните все поля");
        }

        private void grdelbutton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Удалить запись и все связанные записи?", "Подтвердите!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DB db = new DB();
                MySqlCommand command = new MySqlCommand("DELETE `t`, `s`  FROM `ind2`.`group` `t` LEFT JOIN `ind2`.`schedule` `s` ON `s`.`idrg`=`t`.`idgr` where `t`.`idgr`=" + idgr.ToString(), db.getConnection());
                db.openConnection();
                if (command.ExecuteNonQuery() == 1)
                    MessageBox.Show("Запись удалена");
                else MessageBox.Show("error");

                db.closeConnection();
                refreshgr();
                refreshrasp();
            }
        }
        private int idsub;
        private void dataGridView5_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                idsub = Convert.ToInt16(dataGridView5.SelectedRows[0].Cells[0].Value);
                subtextBox.Text = dataGridView5.SelectedRows[0].Cells[1].Value.ToString();          
            }
            catch { }
        }
      

        private void subedbutton_Click(object sender, EventArgs e)
        {
            if (subtextBox.Text != "")
            {
                DB db = new DB();


                MySqlCommand command = new MySqlCommand("UPDATE `ind2`.`subject` SET `subj`=@subj WHERE `subject`.`idsubject`="+idsub.ToString(), db.getConnection());
                command.Parameters.Add("@subj", MySqlDbType.VarChar).Value = subtextBox.Text;

                db.openConnection();

                if (command.ExecuteNonQuery() == 1)
                    MessageBox.Show("Запись изменена");
                else MessageBox.Show("error");

                db.closeConnection();
                subtextBox.Clear();
                refreshsub();
                refreshrasp();
            }
            else MessageBox.Show("Заполните все поля");
        }

        private void subdelbutton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Удалить запись и все связанные записи?", "Подтвердите!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DB db = new DB();
                MySqlCommand command = new MySqlCommand("DELETE `t`, `s`  FROM `ind2`.`subject` `t` LEFT JOIN `ind2`.`schedule` `s` ON `s`.`idsubject`=`t`.`idsubject` where `t`.`idsubject`=" + idsub.ToString(), db.getConnection());
                db.openConnection();
                if (command.ExecuteNonQuery() == 1)
                    MessageBox.Show("Запись удалена");
                else MessageBox.Show("error");

                db.closeConnection();
                refreshgr();
                refreshrasp();
            }
        }
        private int idpers;
        private void dataGridView6_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                idpers = Convert.ToInt16(dataGridView6.SelectedRows[0].Cells[0].Value);
                perstextBox.Text = dataGridView6.SelectedRows[0].Cells[1].Value.ToString();
            }
            catch { }
        }

        

        private void persedbutton_Click(object sender, EventArgs e)
        {
            if (perstextBox.Text != "")
            {
                DB db = new DB();


                MySqlCommand command = new MySqlCommand("UPDATE `ind2`.`person` SET `fio`=@pr WHERE `person`.`idperson`=" + idpers.ToString(), db.getConnection());
                command.Parameters.Add("@pr", MySqlDbType.VarChar).Value = perstextBox.Text;

                db.openConnection();

                if (command.ExecuteNonQuery() == 1)
                    MessageBox.Show("Запись изменена");
                else MessageBox.Show("error");

                db.closeConnection();
                perstextBox.Clear();
               
            }
            else MessageBox.Show("Заполните все поля");
            refreshpers();
        }

        private void persdelbutton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Удалить запись и все связанные записи?", "Подтвердите!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DB db = new DB();
                MySqlCommand command = new MySqlCommand("DELETE FROM `ind2`.`person` WHERE `person`.`idperson` =" + idpers.ToString(), db.getConnection());
                db.openConnection();
                if (command.ExecuteNonQuery() == 1)
                    MessageBox.Show("Запись удалена");
                else MessageBox.Show("error");

                db.closeConnection();
                refreshgr();
                refreshrasp();
                refreshpers();
            }
        }
    }
}
