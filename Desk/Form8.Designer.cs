namespace Desk
{
    partial class Form8
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form8));
            this.panel2 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.panel3 = new System.Windows.Forms.Panel();
            this.arrowparent = new System.Windows.Forms.PictureBox();
            this.calendarparent = new System.Windows.Forms.PictureBox();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.arrowparent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.calendarparent)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.monthCalendar1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(600, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(165, 261);
            this.panel2.TabIndex = 1;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(87, 224);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "Выход";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 195);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(156, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Отвязать тот даты";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 166);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(156, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Привязать к дате";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(0, 0);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.AutoScroll = true;
            this.panel3.Controls.Add(this.arrowparent);
            this.panel3.Controls.Add(this.calendarparent);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(600, 261);
            this.panel3.TabIndex = 2;
            this.panel3.Resize += new System.EventHandler(this.panel3_Resize);
            // 
            // arrowparent
            // 
            this.arrowparent.Image = ((System.Drawing.Image)(resources.GetObject("arrowparent.Image")));
            this.arrowparent.Location = new System.Drawing.Point(218, 87);
            this.arrowparent.Name = "arrowparent";
            this.arrowparent.Size = new System.Drawing.Size(100, 50);
            this.arrowparent.TabIndex = 2;
            this.arrowparent.TabStop = false;
            // 
            // calendarparent
            // 
            this.calendarparent.Image = global::Desk.Properties.Resources.calendar;
            this.calendarparent.Location = new System.Drawing.Point(37, 39);
            this.calendarparent.Name = "calendarparent";
            this.calendarparent.Size = new System.Drawing.Size(150, 150);
            this.calendarparent.TabIndex = 0;
            this.calendarparent.TabStop = false;
            // 
            // Form8
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 261);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Name = "Form8";
            this.Text = "Линия процессов";
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.arrowparent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.calendarparent)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.PictureBox arrowparent;
        private System.Windows.Forms.PictureBox calendarparent;
    }
}