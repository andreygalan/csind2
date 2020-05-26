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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // add1
            // 
            this.add1.Location = new System.Drawing.Point(674, 41);
            this.add1.Name = "add1";
            this.add1.Size = new System.Drawing.Size(75, 23);
            this.add1.TabIndex = 0;
            this.add1.Text = "Добавить запись";
            this.add1.UseVisualStyleBackColor = true;
            this.add1.Click += new System.EventHandler(this.add1_Click);
            // 
            // edit1
            // 
            this.edit1.Location = new System.Drawing.Point(674, 70);
            this.edit1.Name = "edit1";
            this.edit1.Size = new System.Drawing.Size(75, 23);
            this.edit1.TabIndex = 1;
            this.edit1.Text = "Изменить";
            this.edit1.UseVisualStyleBackColor = true;
            this.edit1.Click += new System.EventHandler(this.edit1_Click);
            // 
            // del1
            // 
            this.del1.Location = new System.Drawing.Point(674, 99);
            this.del1.Name = "del1";
            this.del1.Size = new System.Drawing.Size(75, 23);
            this.del1.TabIndex = 2;
            this.del1.Text = "Удалить";
            this.del1.UseVisualStyleBackColor = true;
            this.del1.Click += new System.EventHandler(this.del1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(601, 385);
            this.dataGridView1.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.del1);
            this.Controls.Add(this.edit1);
            this.Controls.Add(this.add1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button add1;
        private System.Windows.Forms.Button edit1;
        private System.Windows.Forms.Button del1;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}

