namespace Desk
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.режимыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.премещениеИИзменеиеРазмераToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.толькоПеремещениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.толькоИзмениеРазмераToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.доскаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.форматироватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.помощьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.sqrpic = new System.Windows.Forms.PictureBox();
            this.sqrpicend = new System.Windows.Forms.PictureBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sqrpic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sqrpicend)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.режимыToolStripMenuItem,
            this.доскаToolStripMenuItem,
            this.помощьToolStripMenuItem,
            this.оПрограммеToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(915, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // режимыToolStripMenuItem
            // 
            this.режимыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.премещениеИИзменеиеРазмераToolStripMenuItem,
            this.толькоПеремещениеToolStripMenuItem,
            this.толькоИзмениеРазмераToolStripMenuItem});
            this.режимыToolStripMenuItem.Name = "режимыToolStripMenuItem";
            this.режимыToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.режимыToolStripMenuItem.Text = "Режимы";
            // 
            // премещениеИИзменеиеРазмераToolStripMenuItem
            // 
            this.премещениеИИзменеиеРазмераToolStripMenuItem.Name = "премещениеИИзменеиеРазмераToolStripMenuItem";
            this.премещениеИИзменеиеРазмераToolStripMenuItem.Size = new System.Drawing.Size(263, 22);
            this.премещениеИИзменеиеРазмераToolStripMenuItem.Text = "Премещение и изменеие размера";
            this.премещениеИИзменеиеРазмераToolStripMenuItem.Click += new System.EventHandler(this.премещениеИИзменеиеРазмераToolStripMenuItem_Click);
            // 
            // толькоПеремещениеToolStripMenuItem
            // 
            this.толькоПеремещениеToolStripMenuItem.Name = "толькоПеремещениеToolStripMenuItem";
            this.толькоПеремещениеToolStripMenuItem.Size = new System.Drawing.Size(263, 22);
            this.толькоПеремещениеToolStripMenuItem.Text = "Только перемещение";
            this.толькоПеремещениеToolStripMenuItem.Click += new System.EventHandler(this.толькоПеремещениеToolStripMenuItem_Click);
            // 
            // толькоИзмениеРазмераToolStripMenuItem
            // 
            this.толькоИзмениеРазмераToolStripMenuItem.Name = "толькоИзмениеРазмераToolStripMenuItem";
            this.толькоИзмениеРазмераToolStripMenuItem.Size = new System.Drawing.Size(263, 22);
            this.толькоИзмениеРазмераToolStripMenuItem.Text = "Только измение размера";
            this.толькоИзмениеРазмераToolStripMenuItem.Click += new System.EventHandler(this.толькоИзмениеРазмераToolStripMenuItem_Click);
            // 
            // доскаToolStripMenuItem
            // 
            this.доскаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьToolStripMenuItem,
            this.форматироватьToolStripMenuItem});
            this.доскаToolStripMenuItem.Name = "доскаToolStripMenuItem";
            this.доскаToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.доскаToolStripMenuItem.Text = "Доска";
            // 
            // добавитьToolStripMenuItem
            // 
            this.добавитьToolStripMenuItem.Name = "добавитьToolStripMenuItem";
            this.добавитьToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.добавитьToolStripMenuItem.Text = "Добавить";
            this.добавитьToolStripMenuItem.Click += new System.EventHandler(this.добавитьToolStripMenuItem_Click);
            // 
            // форматироватьToolStripMenuItem
            // 
            this.форматироватьToolStripMenuItem.Name = "форматироватьToolStripMenuItem";
            this.форматироватьToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.форматироватьToolStripMenuItem.Text = "Форматировать";
            this.форматироватьToolStripMenuItem.Click += new System.EventHandler(this.форматироватьToolStripMenuItem_Click);
            // 
            // помощьToolStripMenuItem
            // 
            this.помощьToolStripMenuItem.Name = "помощьToolStripMenuItem";
            this.помощьToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.помощьToolStripMenuItem.Text = "Помощь";
            this.помощьToolStripMenuItem.Click += new System.EventHandler(this.помощьToolStripMenuItem_Click);
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.оПрограммеToolStripMenuItem.Text = "О нас";
            this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.оПрограммеToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(848, 341);
            this.tabControl1.TabIndex = 3;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            this.tabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl1_Selected);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.sqrpic);
            this.panel1.Controls.Add(this.sqrpicend);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(848, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(67, 371);
            this.panel1.TabIndex = 2;
            // 
            // sqrpic
            // 
            this.sqrpic.BackgroundImage = global::Desk.Properties.Resources.iconstandartobject;
            this.sqrpic.Location = new System.Drawing.Point(9, 3);
            this.sqrpic.Name = "sqrpic";
            this.sqrpic.Size = new System.Drawing.Size(50, 50);
            this.sqrpic.TabIndex = 0;
            this.sqrpic.TabStop = false;
            this.sqrpic.MouseDown += new System.Windows.Forms.MouseEventHandler(this.obj_MouseDown);
            this.sqrpic.MouseMove += new System.Windows.Forms.MouseEventHandler(this.obj_MouseMove);
            this.sqrpic.MouseUp += new System.Windows.Forms.MouseEventHandler(this.obj_MouseUp);
            // 
            // sqrpicend
            // 
            this.sqrpicend.BackgroundImage = global::Desk.Properties.Resources.iconstandartobject;
            this.sqrpicend.Location = new System.Drawing.Point(9, 3);
            this.sqrpicend.Name = "sqrpicend";
            this.sqrpicend.Size = new System.Drawing.Size(50, 50);
            this.sqrpicend.TabIndex = 2;
            this.sqrpicend.TabStop = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(3, 7);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(56, 17);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "связи";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Enabled = false;
            this.checkBox2.Location = new System.Drawing.Point(65, 7);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(102, 17);
            this.checkBox2.TabIndex = 4;
            this.checkBox2.Text = "Удалить связь";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 24);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(848, 30);
            this.panel2.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.checkBox1);
            this.panel3.Controls.Add(this.checkBox2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(680, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(166, 28);
            this.panel3.TabIndex = 7;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(113, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Линия процессов";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.tabControl1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 54);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(848, 341);
            this.panel4.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 395);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(412, 382);
            this.Name = "Form1";
            this.Text = "Формализатор процессов";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sqrpic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sqrpicend)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        public System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.ToolStripMenuItem доскаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem форматироватьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem помощьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox sqrpic;
        private System.Windows.Forms.PictureBox sqrpicend;
        private System.Windows.Forms.ToolStripMenuItem режимыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem премещениеИИзменеиеРазмераToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem толькоПеремещениеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem толькоИзмениеРазмераToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
    }
}

