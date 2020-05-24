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
    public partial class Form3 : Form {
      public static Form3 SelfRef3 {
           get;
           set;
       }

       public Form3() {
           InitializeComponent();
           SelfRef3 = this;
       }

        void click() {
            if (String.IsNullOrEmpty(textBox1.Text)) MessageBox.Show("Имя вкладки пустое", "Ошибка", MessageBoxButtons.OK);
            else {
                if (Form1.SelfRef != null) Form1.SelfRef.addtab();
                this.Close();
            }
        }
        private void button2_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e) {
            click();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == (char)Keys.Enter) 
                click();   
        }
    }
}
