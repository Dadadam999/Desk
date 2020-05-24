using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desk
{
    public partial class Form8 : Form
    {

        public static Form8 SelfRef8
        {
            get;
            set;
        }
        public Form8()
        {
            InitializeComponent();
            arrowparent.Visible = false;
            calendarparent.Visible = false;
            createprocess();

        }

       public void createprocess() {
            panel3.Controls.Clear();
            int lastlocationX = 0;
            Label l;
            PictureBox pic, pic2;
            if (Form1.SelfRef != null)
                for (int i = 0; i < Form1.SelfRef.tab.Length; i++) {
                        pic = new PictureBox();
                        pic.Image = Properties.Resources.calendar;
                        pic.Width = 150;
                        pic.Height = 150;
                        pic.Top = panel3.Height / 2 - pic.Height / 2;
                        pic.Left = lastlocationX + 20;
                        panel3.Controls.Add(pic);

                        l = new Label();
                        l.Text = Form1.SelfRef.tab[i].Text;
                        l.Top = panel3.Height / 2 - l.Height / 2 + 95;
                        l.Left = lastlocationX + 20;
                        panel3.Controls.Add(l);

                        if (i < Form1.SelfRef.tab.Length - 1)
                        {
                            pic2 = new PictureBox();
                            pic2.Image = Properties.Resources.array;
                            pic2.Width = 100;
                            pic2.Height = 50;
                            pic2.Top = panel3.Height / 2 - pic2.Height / 2;
                            pic2.Left = pic.Left + pic.Width + 20;
                            lastlocationX = pic2.Left + pic2.Width;
                            panel3.Controls.Add(pic2);
                        }
                }
                    
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        Panel[] timeobj = new Panel[0];
        void addtimeobj() { 
        
        }

        private void panel3_Resize(object sender, EventArgs e)
        {
            createprocess();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Процесс привязан к дате", "Оповещение", MessageBoxButtons.OK);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Процесс отвязан от даты", "Оповещение", MessageBoxButtons.OK);
        }
    }
}
