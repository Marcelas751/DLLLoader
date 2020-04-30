namespace DLLLoader
{
    partial class CoreForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CoreForm));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button_changeModDir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button_changeModDirCompress = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.Compress = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 7.25F);
            this.textBox1.Location = new System.Drawing.Point(182, 171);
            this.textBox1.MaxLength = 3276700;
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(776, 116);
            this.textBox1.TabIndex = 38;
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.CausesValidation = false;
            this.textBox2.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.textBox2.Location = new System.Drawing.Point(7, 51);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(590, 15);
            this.textBox2.TabIndex = 40;
            this.textBox2.TabStop = false;
            // 
            // textBox3
            // 
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.CausesValidation = false;
            this.textBox3.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.textBox3.Location = new System.Drawing.Point(7, 51);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(590, 15);
            this.textBox3.TabIndex = 41;
            this.textBox3.TabStop = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Segoe Print", 6.25F, System.Drawing.FontStyle.Bold);
            this.label15.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label15.Location = new System.Drawing.Point(110, 26);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(189, 16);
            this.label15.TabIndex = 61;
            this.label15.Text = "kindly supported by veles_de, Marcelas";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(108, 6);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(151, 25);
            this.label9.TabIndex = 62;
            this.label9.Text = "TSG ModLoader";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.button_changeModDir);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Location = new System.Drawing.Point(11, 47);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(450, 119);
            this.panel1.TabIndex = 63;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox2.ErrorImage = null;
            this.pictureBox2.Image = global::DLLLoader.Properties.Resources.tap_extract;
            this.pictureBox2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox2.InitialImage = null;
            this.pictureBox2.Location = new System.Drawing.Point(7, 16);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 25);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 65;
            this.pictureBox2.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.label4.Location = new System.Drawing.Point(51, 28);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(261, 13);
            this.label4.TabIndex = 46;
            this.label4.Text = "(например : D:\\A3A\\@TSG_MODs\\@SGTu_MODs)";
            // 
            // button_changeModDir
            // 
            this.button_changeModDir.AutoSize = true;
            this.button_changeModDir.BackColor = System.Drawing.Color.Gainsboro;
            this.button_changeModDir.BackgroundImage = global::DLLLoader.Properties.Resources.bbackground;
            this.button_changeModDir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_changeModDir.FlatAppearance.BorderSize = 0;
            this.button_changeModDir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.button_changeModDir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_changeModDir.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.button_changeModDir.ForeColor = System.Drawing.Color.Transparent;
            this.button_changeModDir.Location = new System.Drawing.Point(7, 71);
            this.button_changeModDir.Name = "button_changeModDir";
            this.button_changeModDir.Size = new System.Drawing.Size(109, 38);
            this.button_changeModDir.TabIndex = 43;
            this.button_changeModDir.Text = "Сменить";
            this.button_changeModDir.UseVisualStyleBackColor = false;
            this.button_changeModDir.Click += new System.EventHandler(this.button_changeModDir_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(51, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(280, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Путь к папке, где находятся обновления ::";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGray;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.pictureBox3);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.button_changeModDirCompress);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.textBox3);
            this.panel2.Location = new System.Drawing.Point(508, 47);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(450, 119);
            this.panel2.TabIndex = 64;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox3.ErrorImage = null;
            this.pictureBox3.Image = global::DLLLoader.Properties.Resources.tap_extract_to;
            this.pictureBox3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox3.InitialImage = null;
            this.pictureBox3.Location = new System.Drawing.Point(7, 15);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(32, 25);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 66;
            this.pictureBox3.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.label3.Location = new System.Drawing.Point(51, 28);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(304, 13);
            this.label3.TabIndex = 45;
            this.label3.Text = "(например : D:\\Compressed\\@TSG_MODs\\@SGTu_MODs)";
            // 
            // button_changeModDirCompress
            // 
            this.button_changeModDirCompress.AutoSize = true;
            this.button_changeModDirCompress.BackColor = System.Drawing.Color.Gainsboro;
            this.button_changeModDirCompress.BackgroundImage = global::DLLLoader.Properties.Resources.bbackground;
            this.button_changeModDirCompress.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_changeModDirCompress.FlatAppearance.BorderSize = 0;
            this.button_changeModDirCompress.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.button_changeModDirCompress.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_changeModDirCompress.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.button_changeModDirCompress.ForeColor = System.Drawing.Color.Transparent;
            this.button_changeModDirCompress.Location = new System.Drawing.Point(7, 71);
            this.button_changeModDirCompress.Name = "button_changeModDirCompress";
            this.button_changeModDirCompress.Size = new System.Drawing.Size(109, 38);
            this.button_changeModDirCompress.TabIndex = 44;
            this.button_changeModDirCompress.Text = "Сменить";
            this.button_changeModDirCompress.UseVisualStyleBackColor = false;
            this.button_changeModDirCompress.Click += new System.EventHandler(this.button_changeModDirCompress_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(51, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(387, 19);
            this.label2.TabIndex = 40;
            this.label2.Text = "Путь к папке, куда нужно отправить сжатые обновления ::";
            // 
            // Compress
            // 
            this.Compress.AutoSize = true;
            this.Compress.BackColor = System.Drawing.Color.LightGray;
            this.Compress.BackgroundImage = global::DLLLoader.Properties.Resources.baktiv;
            this.Compress.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Compress.FlatAppearance.BorderSize = 0;
            this.Compress.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.Compress.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Compress.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Compress.ForeColor = System.Drawing.Color.Transparent;
            this.Compress.Location = new System.Drawing.Point(11, 170);
            this.Compress.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Compress.Name = "Compress";
            this.Compress.Size = new System.Drawing.Size(166, 39);
            this.Compress.TabIndex = 39;
            this.Compress.Text = "Сжать и посчитать хеш";
            this.Compress.UseVisualStyleBackColor = false;
            this.Compress.Click += new System.EventHandler(this.Button2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Image = global::DLLLoader.Properties.Resources.logo_tsg_dev;
            this.pictureBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(11, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(91, 36);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 60;
            this.pictureBox1.TabStop = false;
            // 
            // CoreForm
            // 
            this.AccessibleName = "";
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(969, 297);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.Compress);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "CoreForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TSG ModLoader";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        internal System.Windows.Forms.TextBox textBox1;
        internal System.Windows.Forms.TextBox textBox2;
        internal System.Windows.Forms.TextBox textBox3;
        internal System.Windows.Forms.PictureBox pictureBox1;
        internal System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Button button_changeModDir;
        internal System.Windows.Forms.Button button_changeModDirCompress;
        internal System.Windows.Forms.Button Compress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.PictureBox pictureBox2;
        internal System.Windows.Forms.PictureBox pictureBox3;
    }
}

