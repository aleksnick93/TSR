namespace DiplomProj
{
    partial class Sign
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.srcImgBox = new System.Windows.Forms.PictureBox();
            this.detimgBox = new Emgu.CV.UI.ImageBox();
            this.signBox = new System.Windows.Forms.PictureBox();
            this.Load_button = new System.Windows.Forms.Button();
            this.Do_button = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Comp_button = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Stat_textBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel = new System.Windows.Forms.Panel();
            this.roadsignDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.road_sign_DataSet = new DiplomProj.Road_sign_DataSet();
            this.Inf_textBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.srcImgBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.detimgBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.signBox)).BeginInit();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.roadsignDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.road_sign_DataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // srcImgBox
            // 
            this.srcImgBox.BackColor = System.Drawing.Color.Transparent;
            this.srcImgBox.BackgroundImage = global::DiplomProj.Properties.Resources.Fly;
            this.srcImgBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.srcImgBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.srcImgBox.Cursor = System.Windows.Forms.Cursors.Cross;
            this.srcImgBox.Location = new System.Drawing.Point(0, 0);
            this.srcImgBox.Name = "srcImgBox";
            this.srcImgBox.Size = new System.Drawing.Size(461, 331);
            this.srcImgBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.srcImgBox.TabIndex = 0;
            this.srcImgBox.TabStop = false;
            this.srcImgBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.srcImgBox_MouseDown);
            this.srcImgBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.srcImgBox_MouseMove);
            this.srcImgBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.srcImgBox_MouseUp);
            // 
            // detimgBox
            // 
            this.detimgBox.BackColor = System.Drawing.Color.Transparent;
            this.detimgBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.detimgBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.detimgBox.Cursor = System.Windows.Forms.Cursors.Cross;
            this.detimgBox.Location = new System.Drawing.Point(23, 228);
            this.detimgBox.Name = "detimgBox";
            this.detimgBox.Size = new System.Drawing.Size(120, 120);
            this.detimgBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.detimgBox.TabIndex = 1;
            this.detimgBox.TabStop = false;
            // 
            // signBox
            // 
            this.signBox.BackColor = System.Drawing.Color.Transparent;
            this.signBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.signBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.signBox.Cursor = System.Windows.Forms.Cursors.Cross;
            this.signBox.Location = new System.Drawing.Point(21, 438);
            this.signBox.Name = "signBox";
            this.signBox.Size = new System.Drawing.Size(120, 120);
            this.signBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.signBox.TabIndex = 2;
            this.signBox.TabStop = false;
            // 
            // Load_button
            // 
            this.Load_button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Load_button.BackColor = System.Drawing.Color.White;
            this.Load_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Load_button.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Load_button.FlatAppearance.BorderSize = 2;
            this.Load_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.Load_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Load_button.Location = new System.Drawing.Point(23, 17);
            this.Load_button.Name = "Load_button";
            this.Load_button.Size = new System.Drawing.Size(111, 38);
            this.Load_button.TabIndex = 3;
            this.Load_button.Text = "Открыть";
            this.Load_button.UseCompatibleTextRendering = true;
            this.Load_button.UseVisualStyleBackColor = false;
            this.Load_button.Click += new System.EventHandler(this.Load_button_Click);
            // 
            // Do_button
            // 
            this.Do_button.BackColor = System.Drawing.Color.White;
            this.Do_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Do_button.Enabled = false;
            this.Do_button.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Do_button.FlatAppearance.BorderSize = 2;
            this.Do_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.Do_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Do_button.Location = new System.Drawing.Point(23, 66);
            this.Do_button.Name = "Do_button";
            this.Do_button.Size = new System.Drawing.Size(111, 38);
            this.Do_button.TabIndex = 4;
            this.Do_button.Text = "Преобразовать";
            this.Do_button.UseCompatibleTextRendering = true;
            this.Do_button.UseVisualStyleBackColor = false;
            this.Do_button.Click += new System.EventHandler(this.Do_button_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Title = "Графические файлы";
            // 
            // progressBar
            // 
            this.progressBar.BackColor = System.Drawing.Color.White;
            this.progressBar.ForeColor = System.Drawing.Color.Lime;
            this.progressBar.Location = new System.Drawing.Point(20, 171);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(121, 23);
            this.progressBar.Step = 5;
            this.progressBar.TabIndex = 5;
            this.progressBar.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(29, 150);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "Выполнение";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(160, 351);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Путь к файлу";
            // 
            // Comp_button
            // 
            this.Comp_button.BackColor = System.Drawing.Color.White;
            this.Comp_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Comp_button.Enabled = false;
            this.Comp_button.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Comp_button.FlatAppearance.BorderSize = 2;
            this.Comp_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.Comp_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Comp_button.Location = new System.Drawing.Point(32, 357);
            this.Comp_button.Name = "Comp_button";
            this.Comp_button.Size = new System.Drawing.Size(102, 33);
            this.Comp_button.TabIndex = 8;
            this.Comp_button.Text = "Распознать";
            this.Comp_button.UseVisualStyleBackColor = false;
            this.Comp_button.Click += new System.EventHandler(this.Comp_button_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(17, 419);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "Распознанный знак";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(308, 372);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(163, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "Информация по знаку";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(828, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 18);
            this.label5.TabIndex = 12;
            this.label5.Text = "Статистика";
            // 
            // Stat_textBox
            // 
            this.Stat_textBox.AcceptsReturn = true;
            this.Stat_textBox.AcceptsTab = true;
            this.Stat_textBox.BackColor = System.Drawing.Color.White;
            this.Stat_textBox.Font = new System.Drawing.Font("Lucida Console", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Stat_textBox.Location = new System.Drawing.Point(640, 38);
            this.Stat_textBox.Multiline = true;
            this.Stat_textBox.Name = "Stat_textBox";
            this.Stat_textBox.ReadOnly = true;
            this.Stat_textBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.Stat_textBox.Size = new System.Drawing.Size(444, 520);
            this.Stat_textBox.TabIndex = 13;
            this.Stat_textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Stat_textBox.WordWrap = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(22, 209);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 16);
            this.label6.TabIndex = 14;
            this.label6.Text = "Идентификация";
            // 
            // panel
            // 
            this.panel.AutoScroll = true;
            this.panel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel.BackColor = System.Drawing.Color.Transparent;
            this.panel.Controls.Add(this.srcImgBox);
            this.panel.Location = new System.Drawing.Point(163, 17);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(461, 331);
            this.panel.TabIndex = 15;
            // 
            // roadsignDataSetBindingSource
            // 
            this.roadsignDataSetBindingSource.DataSource = this.road_sign_DataSet;
            this.roadsignDataSetBindingSource.Position = 0;
            // 
            // road_sign_DataSet
            // 
            this.road_sign_DataSet.DataSetName = "Road_sign_DataSet";
            this.road_sign_DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Inf_textBox
            // 
            this.Inf_textBox.AcceptsReturn = true;
            this.Inf_textBox.AcceptsTab = true;
            this.Inf_textBox.BackColor = System.Drawing.Color.White;
            this.Inf_textBox.Font = new System.Drawing.Font("Garamond", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Inf_textBox.Location = new System.Drawing.Point(163, 391);
            this.Inf_textBox.Multiline = true;
            this.Inf_textBox.Name = "Inf_textBox";
            this.Inf_textBox.ReadOnly = true;
            this.Inf_textBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Inf_textBox.Size = new System.Drawing.Size(461, 167);
            this.Inf_textBox.TabIndex = 16;
            // 
            // Sign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = global::DiplomProj.Properties.Resources.Fly;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1108, 570);
            this.Controls.Add(this.Inf_textBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Load_button);
            this.Controls.Add(this.Stat_textBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Comp_button);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.Do_button);
            this.Controls.Add(this.signBox);
            this.Controls.Add(this.detimgBox);
            this.Controls.Add(this.panel);
            this.Name = "Sign";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Распознаватель указательных знаков";
            this.Load += new System.EventHandler(this.Sign_Load);
            ((System.ComponentModel.ISupportInitialize)(this.srcImgBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.detimgBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.signBox)).EndInit();
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.roadsignDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.road_sign_DataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox srcImgBox;
        private Emgu.CV.UI.ImageBox detimgBox;
        private System.Windows.Forms.PictureBox signBox;
        private System.Windows.Forms.Button Load_button;
        private System.Windows.Forms.Button Do_button;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Comp_button;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Stat_textBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.BindingSource roadsignDataSetBindingSource;
        private Road_sign_DataSet road_sign_DataSet;
        protected System.Windows.Forms.TextBox Inf_textBox;
    }
}

