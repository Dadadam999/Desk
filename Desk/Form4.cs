using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desk {
    public partial class Form4 : Form {

        object objbaccolor;
        Label lb = new Label();
        int ktime = 0;

        public static Form4 SelfRef4 {
           get;
           set;
       }

       public Form4() {
           InitializeComponent();
           SelfRef4 = this;
       }

        private void button1_Click(object sender, EventArgs e) {
            if (colorDialog1.ShowDialog() == DialogResult.OK) ((Panel)objbaccolor).BackColor = colorDialog1.Color;   
            //((Panel)objbaccolor).C
        }

        public void backcolorrr(object sender) {
            objbaccolor = sender;
        }


        private void button2_Click(object sender, EventArgs e) {
            if (textBox1.Text == "") lb.Text = "Нажмите на сущность что бы изменить ее";
            else {
                str = textBox1.Text;
                createlabel();
            }
        }

        private void button3_Click(object sender, EventArgs e) {
            if (fontDialog1.ShowDialog() == DialogResult.OK) {
                font = fontDialog1.Font;
                createlabel();
            }
        }


        private void timer1_Tick(object sender, EventArgs e) {
            ktime++;
            if (ktime == 500) {
                MessageBox.Show("Ты долго думал.", "Ой все!!", MessageBoxButtons.OK);
                Close();
            }
        }

        private void button2_Click_1(object sender, EventArgs e) {
            Close();
        }

        Font font;
        String str;
        void createlabel()
        {
            lb.Font = font;
            lb.Dock = DockStyle.Fill;
            lb.Enabled = false;
            lb.Text = str;
            lb.Margin = new Padding(10);
            ((Panel)objbaccolor).Controls.Clear();
            ((Panel)objbaccolor).Controls.Add(lb);
        }
    }
}
