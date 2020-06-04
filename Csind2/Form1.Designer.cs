namespace Csind2
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.add1 = new System.Windows.Forms.Button();
            this.edit1 = new System.Windows.Forms.Button();
            this.del1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.добавитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.преподавательToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.группаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.дисциплинаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.расписаниеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.человекToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.студентToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изменитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.преподавательToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.группаToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.дисциплинаToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.расписаниеToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.человекToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.студентToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.преподавательToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.группаToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.дисциплинаToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.расписаниеToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.человекToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.студентToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // add1
            // 
            this.add1.Location = new System.Drawing.Point(116, 415);
            this.add1.Name = "add1";
            this.add1.Size = new System.Drawing.Size(75, 23);
            this.add1.TabIndex = 0;
            this.add1.Text = "Добавить запись";
            this.add1.UseVisualStyleBackColor = true;
            this.add1.Click += new System.EventHandler(this.add1_Click);
            // 
            // edit1
            // 
            this.edit1.Location = new System.Drawing.Point(292, 415);
            this.edit1.Name = "edit1";
            this.edit1.Size = new System.Drawing.Size(75, 23);
            this.edit1.TabIndex = 1;
            this.edit1.Text = "Изменить";
            this.edit1.UseVisualStyleBackColor = true;
            this.edit1.Click += new System.EventHandler(this.edit1_Click);
            // 
            // del1
            // 
            this.del1.Location = new System.Drawing.Point(634, 415);
            this.del1.Name = "del1";
            this.del1.Size = new System.Drawing.Size(75, 23);
            this.del1.TabIndex = 2;
            this.del1.Text = "Удалить";
            this.del1.UseVisualStyleBackColor = true;
            this.del1.Click += new System.EventHandler(this.del1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dataGridView1.Location = new System.Drawing.Point(12, 27);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(776, 370);
            this.dataGridView1.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Column2";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Column3";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Column4";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Column5";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьToolStripMenuItem,
            this.изменитьToolStripMenuItem,
            this.удалитьToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // добавитьToolStripMenuItem
            // 
            this.добавитьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.преподавательToolStripMenuItem,
            this.группаToolStripMenuItem,
            this.дисциплинаToolStripMenuItem,
            this.расписаниеToolStripMenuItem,
            this.человекToolStripMenuItem,
            this.студентToolStripMenuItem});
            this.добавитьToolStripMenuItem.Name = "добавитьToolStripMenuItem";
            this.добавитьToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.добавитьToolStripMenuItem.Text = "Добавить";
            // 
            // преподавательToolStripMenuItem
            // 
            this.преподавательToolStripMenuItem.Name = "преподавательToolStripMenuItem";
            this.преподавательToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.преподавательToolStripMenuItem.Text = "Преподаватель";
            this.преподавательToolStripMenuItem.Click += new System.EventHandler(this.преподавательToolStripMenuItem_Click);
            // 
            // группаToolStripMenuItem
            // 
            this.группаToolStripMenuItem.Name = "группаToolStripMenuItem";
            this.группаToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.группаToolStripMenuItem.Text = "Группа";
            // 
            // дисциплинаToolStripMenuItem
            // 
            this.дисциплинаToolStripMenuItem.Name = "дисциплинаToolStripMenuItem";
            this.дисциплинаToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.дисциплинаToolStripMenuItem.Text = "Дисциплина";
            // 
            // расписаниеToolStripMenuItem
            // 
            this.расписаниеToolStripMenuItem.Name = "расписаниеToolStripMenuItem";
            this.расписаниеToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.расписаниеToolStripMenuItem.Text = "Расписание";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(464, 415);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Запросы";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // человекToolStripMenuItem
            // 
            this.человекToolStripMenuItem.Name = "человекToolStripMenuItem";
            this.человекToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.человекToolStripMenuItem.Text = "Человек";
            // 
            // студентToolStripMenuItem
            // 
            this.студентToolStripMenuItem.Name = "студентToolStripMenuItem";
            this.студентToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.студентToolStripMenuItem.Text = "Студент";
            // 
            // изменитьToolStripMenuItem
            // 
            this.изменитьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.преподавательToolStripMenuItem1,
            this.группаToolStripMenuItem1,
            this.дисциплинаToolStripMenuItem1,
            this.расписаниеToolStripMenuItem1,
            this.человекToolStripMenuItem1,
            this.студентToolStripMenuItem1});
            this.изменитьToolStripMenuItem.Name = "изменитьToolStripMenuItem";
            this.изменитьToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.изменитьToolStripMenuItem.Text = "Изменить";
            // 
            // преподавательToolStripMenuItem1
            // 
            this.преподавательToolStripMenuItem1.Name = "преподавательToolStripMenuItem1";
            this.преподавательToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.преподавательToolStripMenuItem1.Text = "Преподаватель";
            // 
            // группаToolStripMenuItem1
            // 
            this.группаToolStripMenuItem1.Name = "группаToolStripMenuItem1";
            this.группаToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.группаToolStripMenuItem1.Text = "Группа";
            // 
            // дисциплинаToolStripMenuItem1
            // 
            this.дисциплинаToolStripMenuItem1.Name = "дисциплинаToolStripMenuItem1";
            this.дисциплинаToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.дисциплинаToolStripMenuItem1.Text = "Дисциплина";
            // 
            // расписаниеToolStripMenuItem1
            // 
            this.расписаниеToolStripMenuItem1.Name = "расписаниеToolStripMenuItem1";
            this.расписаниеToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.расписаниеToolStripMenuItem1.Text = "Расписание";
            // 
            // человекToolStripMenuItem1
            // 
            this.человекToolStripMenuItem1.Name = "человекToolStripMenuItem1";
            this.человекToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.человекToolStripMenuItem1.Text = "Человек";
            // 
            // студентToolStripMenuItem1
            // 
            this.студентToolStripMenuItem1.Name = "студентToolStripMenuItem1";
            this.студентToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.студентToolStripMenuItem1.Text = "Студент";
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.преподавательToolStripMenuItem2,
            this.группаToolStripMenuItem2,
            this.дисциплинаToolStripMenuItem2,
            this.расписаниеToolStripMenuItem2,
            this.человекToolStripMenuItem2,
            this.студентToolStripMenuItem2});
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.удалитьToolStripMenuItem.Text = "Удалить";
            // 
            // преподавательToolStripMenuItem2
            // 
            this.преподавательToolStripMenuItem2.Name = "преподавательToolStripMenuItem2";
            this.преподавательToolStripMenuItem2.Size = new System.Drawing.Size(180, 22);
            this.преподавательToolStripMenuItem2.Text = "Преподаватель";
            // 
            // группаToolStripMenuItem2
            // 
            this.группаToolStripMenuItem2.Name = "группаToolStripMenuItem2";
            this.группаToolStripMenuItem2.Size = new System.Drawing.Size(180, 22);
            this.группаToolStripMenuItem2.Text = "Группа";
            // 
            // дисциплинаToolStripMenuItem2
            // 
            this.дисциплинаToolStripMenuItem2.Name = "дисциплинаToolStripMenuItem2";
            this.дисциплинаToolStripMenuItem2.Size = new System.Drawing.Size(180, 22);
            this.дисциплинаToolStripMenuItem2.Text = "Дисциплина";
            // 
            // расписаниеToolStripMenuItem2
            // 
            this.расписаниеToolStripMenuItem2.Name = "расписаниеToolStripMenuItem2";
            this.расписаниеToolStripMenuItem2.Size = new System.Drawing.Size(180, 22);
            this.расписаниеToolStripMenuItem2.Text = "Расписание";
            // 
            // человекToolStripMenuItem2
            // 
            this.человекToolStripMenuItem2.Name = "человекToolStripMenuItem2";
            this.человекToolStripMenuItem2.Size = new System.Drawing.Size(180, 22);
            this.человекToolStripMenuItem2.Text = "Человек";
            // 
            // студентToolStripMenuItem2
            // 
            this.студентToolStripMenuItem2.Name = "студентToolStripMenuItem2";
            this.студентToolStripMenuItem2.Size = new System.Drawing.Size(180, 22);
            this.студентToolStripMenuItem2.Text = "Студент";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.del1);
            this.Controls.Add(this.edit1);
            this.Controls.Add(this.add1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button add1;
        private System.Windows.Forms.Button edit1;
        private System.Windows.Forms.Button del1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem добавитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem преподавательToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem группаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem дисциплинаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem расписаниеToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem человекToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem студентToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem изменитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem преподавательToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem группаToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem дисциплинаToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem расписаниеToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem человекToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem студентToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem преподавательToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem группаToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem дисциплинаToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem расписаниеToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem человекToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem студентToolStripMenuItem2;
    }
}

