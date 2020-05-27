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
    }
}
