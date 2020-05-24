using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ControlManager;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace Desk {

   
    public partial class Form1 : Form {

#region 'Глобальные переменные' 
       public Loan[] masob = new Loan[0];
       public TabPage[] tab = new TabPage[0];
       int k = 0;
       bool deskmove, isDownobj;
       Point startcursor;
       Graphics gr;
       public int[] obj_index = new int[0];
       public int[] obj_border = new int[0];
       bool tempcheck1, tempcheck2;
       public int indexendlink, bordend, indexstartlink, bordst; //bord 1 - up, 2 - down, 3 - left, 4 - right
#endregion

#region 'Создание формы'
       public static Form1 SelfRef {
           get;
           set;
       }

       public Form1() {
           InitializeComponent();
           SelfRef = this;
           checkBox1.Enabled = false;
           addtab();
           this.DoubleBuffered = true;
       }
#endregion

#region 'Доски'
       public void addtab() {
           if (k == 0) {
               Array.Resize(ref tab, tab.Length + 1);
               tab[tab.Length - 1] = new TabPage();
               tab[tab.Length - 1].Name = "tabPage0";
               tab[tab.Length - 1].Text = "Начальна область";
               tab[tab.Length - 1].BackColor = Color.White;
               tab[tab.Length - 1].MouseDown += new MouseEventHandler(desk_MouseDown);
               tab[tab.Length - 1].MouseUp += new MouseEventHandler(desk_MouseUp);
               tab[tab.Length - 1].MouseMove += new MouseEventHandler(desk_MouseMove);
               tabControl1.TabPages.Add(tab[tab.Length - 1]);
               k++;
               if (Form8.SelfRef8 != null) Form8.SelfRef8.createprocess();  
           }
           else {
               if (Form3.SelfRef3 != null)
                   if (checkсopynametab(Form3.SelfRef3.textBox1.Text)) MessageBox.Show("Вкладка с таким именем уже существует", "Ошибка", MessageBoxButtons.OK);
                   else {
                       Array.Resize(ref tab, tab.Length + 1);
                       tab[tab.Length - 1] = new TabPage();
                       tab[tab.Length - 1].Text = Form3.SelfRef3.textBox1.Text;
                       tab[tab.Length - 1].Name = "tabPage" + Convert.ToString(k);
                       tab[tab.Length - 1].BackColor = Color.White;
                       tab[tab.Length - 1].MouseDown += new MouseEventHandler(desk_MouseDown);
                       tab[tab.Length - 1].MouseUp += new MouseEventHandler(desk_MouseUp);
                       tab[tab.Length - 1].MouseMove += new MouseEventHandler(desk_MouseMove);
                       tabControl1.TabPages.Add(tab[tab.Length - 1]);
                       k++;
                   }
             }      
        }

       bool checkсopynametab(String name) {
           bool flag = false;
           foreach(TabPage t in tab)
               if (tab[tab.Length - 1].Text == name) {
                   flag = true;
                   break;
               };
           return flag;
       }

       private void tabControl1_Selected(object sender, TabControlEventArgs e) {
           gr = ((TabControl)sender).SelectedTab.CreateGraphics();
           gr.Clear(Color.White);
           gr.Dispose();
       }

       private void tabControl1_SelectedIndexChanged(object sender, EventArgs e) {
           if(checkBox1.Checked) paintsqrobj();
           paintlinks();
       }
#endregion

#region 'Создание сущностей'
       private void obj_MouseDown(object sender, MouseEventArgs e) {
                isDownobj = true;
                sqrpic.Parent = this;
                sqrpic.BringToFront();
            }

            private void obj_MouseMove(object sender, MouseEventArgs e) {
                if (isDownobj) sqrpic.Location = this.PointToClient(Control.MousePosition);
            }

            private void obj_MouseUp(object sender, MouseEventArgs e) {
                isDownobj = false;

                Array.Resize(ref masob, masob.Length + 1);
                masob[masob.Length - 1] = new Loan();
                masob[masob.Length - 1].Height = 50;
                masob[masob.Length - 1].Width = 50;
                masob[masob.Length - 1].Left = sqrpic.Left - 1;
                masob[masob.Length - 1].Top = sqrpic.Top - sqrpic.Height;
                masob[masob.Length - 1].DoubleClick += new EventHandler(obj_doubleclick);
                masob[masob.Length - 1].Resize += new EventHandler(obj_resize);
                masob[masob.Length - 1].Move += new EventHandler(obj_move);
                masob[masob.Length - 1].BackColor = Color.Gray;

                Label lb = new Label();
                lb.Text = "Нажмите на сущность что бы изменить ее";
                lb.ForeColor = System.Drawing.Color.White;
                lb.Dock = DockStyle.Fill;
                lb.Enabled = false;
                masob[masob.Length - 1].Controls.Add(lb);

                this.tabControl1.SelectedTab.Controls.Add(masob[masob.Length - 1]);
                dragandmove.Init(masob[masob.Length - 1]);

                panel1.Controls.Add(sqrpic);
                sqrpic.BringToFront();
                sqrpic.Top = sqrpicend.Top;
                sqrpic.Left = sqrpicend.Left;

                if (masob.Length - 1 >= 1) {
                    checkBox1.Enabled = true;
                    checkBox2.Enabled = true;
                }
            }

            private void obj_resize(object sender, EventArgs e) {
                gr = this.tabControl1.SelectedTab.CreateGraphics();
                gr.Clear(Color.White);
                gr.Dispose();
                if (masob.Length - 1 >= 1) paintlinks();
            }

            private void obj_move(object sender, EventArgs e) {
                gr = this.tabControl1.SelectedTab.CreateGraphics();
                gr.Clear(Color.White);
                gr.Dispose();
                if (masob.Length - 1 >= 1) paintlinks();
            }

            private void obj_doubleclick(object sender, EventArgs e) {
                Form4 f4 = new Form4();
                f4.Show();
                Form4.SelfRef4.timer1.Enabled = true;
                Form4.SelfRef4.backcolorrr(((Panel)sender));
            }
#endregion
           
#region 'Menu'
            private void премещениеИИзменеиеРазмераToolStripMenuItem_Click(object sender, EventArgs e) {
                dragandmove.WorkType = dragandmove.MoveOrResize.MoveAndResize;
            }

            private void толькоПеремещениеToolStripMenuItem_Click(object sender, EventArgs e) {
                dragandmove.WorkType = dragandmove.MoveOrResize.Move;
            }

            private void толькоИзмениеРазмераToolStripMenuItem_Click(object sender, EventArgs e) {
                dragandmove.WorkType = dragandmove.MoveOrResize.Resize;
            }

            private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e) {
                MessageBox.Show("Мы бедные студенты колледжа, создали эту программу в надежеде повторить успех Ramus\'а", "О нас", MessageBoxButtons.OK);
            }

            private void выходToolStripMenuItem_Click(object sender, EventArgs e) {
                Close();
            }

            private void помощьToolStripMenuItem_Click(object sender, EventArgs e) {
                Form2 f = new Form2();
                f.Show();
            }

            private void добавитьToolStripMenuItem_Click(object sender, EventArgs e) {
                Form3 f = new Form3();
                f.Show();
            }

            private void новыйToolStripMenuItem_Click(object sender, EventArgs e) {
                tabControl1.TabPages.Clear();
            }

            private void форматироватьToolStripMenuItem_Click(object sender, EventArgs e) {
                      this.tabControl1.SelectedTab.Controls.Clear();
            }

            private void button2_Click(object sender, EventArgs e) {
                Form8 f8 = new Form8();
                f8.Show();
            }
#endregion

#region 'Связи'
            private void desk_MouseMove(object sender, MouseEventArgs e) {
                if (deskmove && checkBox1.Checked) {
                    Graphics grr = this.tabControl1.SelectedTab.CreateGraphics();
                    grr.Clear(Color.White);
                    paintsqrobj();
                    paintlinks();
                    Pen pen = new Pen(Color.Black, 2);
                    grr.DrawLine(pen, startcursor, this.tabControl1.SelectedTab.PointToClient(Control.MousePosition));
                    grr.Dispose();
                }
            }

            private void desk_MouseDown(object sender, MouseEventArgs e) {
                if (checkBox1.Checked && checksqhover()) {
                    deskmove = true;
                    startcursor = this.tabControl1.SelectedTab.PointToClient(Control.MousePosition);
                }

                if (checkBox2.Checked) deletelink();
            }

            private void desk_MouseUp(object sender, MouseEventArgs e) {
                if (checkBox1.Checked && deskmove) {
                    if (checksqhoverend() && checkduplink()) {
                        Array.Resize(ref obj_index, obj_index.Length + 2);
                        Array.Resize(ref obj_border, obj_border.Length + 2);
                        obj_index[obj_index.Length - 2] = indexstartlink;
                        obj_index[obj_index.Length - 1] = indexendlink;
                        obj_border[obj_border.Length - 2] = bordst;
                        obj_border[obj_border.Length - 1] = bordend;
                    }
                        deskmove = false;
                        gr = this.tabControl1.SelectedTab.CreateGraphics();
                        gr.Clear(Color.White);
                        gr.Dispose();
                        paintsqrobj();
                        paintlinks();
                }
            }

            private bool checkduplink() {
                bool flag = true;
                for(int i = 0; i < obj_index.Length; i=i+2)
                    if (obj_index[i] == indexstartlink && obj_index[i + 1] == indexendlink) {
                        flag = false;
                        MessageBox.Show("Эти сущности уже имеют связь","Предупреждение");
                        break;
                    } 
                return flag;
            }

            private void paintlinks() {
                Graphics grrr = this.tabControl1.SelectedTab.CreateGraphics();  
                Pen pen = new Pen(Color.Black, 2);
                for (int i = 0; i < obj_border.Length; i = i + 2) {
                    if (masob[obj_index[i]].Parent == this.tabControl1.SelectedTab) {
                        if (obj_border[i] == 1 && obj_border[i + 1] == 1) grrr.DrawLine(pen, masob[obj_index[i]].Left + masob[obj_index[i]].Width / 2 + 5, masob[obj_index[i]].Top - 5, masob[obj_index[i + 1]].Left + masob[obj_index[i + 1]].Width / 2 + 5, masob[obj_index[i + 1]].Top - 5);
                        if (obj_border[i] == 1 && obj_border[i + 1] == 2) grrr.DrawLine(pen, masob[obj_index[i]].Left + masob[obj_index[i]].Width / 2 + 5, masob[obj_index[i]].Top - 5, masob[obj_index[i + 1]].Left + masob[obj_index[i + 1]].Width / 2 + 5, masob[obj_index[i + 1]].Top + masob[obj_index[i + 1]].Height + 5);
                        if (obj_border[i] == 1 && obj_border[i + 1] == 3) grrr.DrawLine(pen, masob[obj_index[i]].Left + masob[obj_index[i]].Width / 2 + 5, masob[obj_index[i]].Top - 5, masob[obj_index[i + 1]].Left - 5, masob[obj_index[i + 1]].Top + masob[i + 1].Height / 2 + 5);
                        if (obj_border[i] == 1 && obj_border[i + 1] == 4) grrr.DrawLine(pen, masob[obj_index[i]].Left + masob[obj_index[i]].Width / 2 + 5, masob[obj_index[i]].Top - 5, masob[obj_index[i + 1]].Left + masob[obj_index[i + 1]].Width + 5, masob[obj_index[i + 1]].Top + masob[obj_index[i + 1]].Height / 2 + 5);

                        if (obj_border[i] == 2 && obj_border[i + 1] == 1) grrr.DrawLine(pen, masob[obj_index[i]].Left + masob[obj_index[i]].Width / 2 + 5, masob[obj_index[i]].Top + masob[obj_index[i]].Height + 5, masob[obj_index[i + 1]].Left + masob[obj_index[i + 1]].Width / 2 + 5, masob[obj_index[i + 1]].Top - 5);
                        if (obj_border[i] == 2 && obj_border[i + 1] == 2) grrr.DrawLine(pen, masob[obj_index[i]].Left + masob[obj_index[i]].Width / 2 + 5, masob[obj_index[i]].Top + masob[obj_index[i]].Height + 5, masob[obj_index[i + 1]].Left + masob[obj_index[i + 1]].Width / 2 + 5, masob[obj_index[i + 1]].Top + masob[obj_index[i + 1]].Height + 5);
                        if (obj_border[i] == 2 && obj_border[i + 1] == 3) grrr.DrawLine(pen, masob[obj_index[i]].Left + masob[obj_index[i]].Width / 2 + 5, masob[obj_index[i]].Top + masob[obj_index[i]].Height + 5, masob[obj_index[i + 1]].Left - 5, masob[obj_index[i + 1]].Top + masob[obj_index[i + 1]].Height / 2 + 5);
                        if (obj_border[i] == 2 && obj_border[i + 1] == 4) grrr.DrawLine(pen, masob[obj_index[i]].Left + masob[obj_index[i]].Width / 2 + 5, masob[obj_index[i]].Top + masob[obj_index[i]].Height + 5, masob[obj_index[i + 1]].Left + masob[obj_index[i + 1]].Width + 5, masob[obj_index[i + 1]].Top + masob[obj_index[i + 1]].Height / 2 + 5);

                        if (obj_border[i] == 3 && obj_border[i + 1] == 1) grrr.DrawLine(pen, masob[obj_index[i]].Left - 5, masob[obj_index[i]].Top + masob[obj_index[i]].Height / 2 + 5, masob[obj_index[i + 1]].Left + masob[obj_index[i + 1]].Width / 2 + 5, masob[obj_index[i + 1]].Top - 5);
                        if (obj_border[i] == 3 && obj_border[i + 1] == 2) grrr.DrawLine(pen, masob[obj_index[i]].Left - 5, masob[obj_index[i]].Top + masob[obj_index[i]].Height / 2 + 5, masob[obj_index[i + 1]].Left + masob[obj_index[i + 1]].Width / 2 + 5, masob[obj_index[i + 1]].Top + masob[obj_index[i + 1]].Height + 5);
                        if (obj_border[i] == 3 && obj_border[i + 1] == 3) grrr.DrawLine(pen, masob[obj_index[i]].Left - 5, masob[obj_index[i]].Top + masob[obj_index[i]].Height / 2 + 5, masob[obj_index[i + 1]].Left - 5, masob[obj_index[i + 1]].Top + masob[obj_index[i + 1]].Height / 2 + 5);
                        if (obj_border[i] == 3 && obj_border[i + 1] == 4) grrr.DrawLine(pen, masob[obj_index[i]].Left - 5, masob[obj_index[i]].Top + masob[obj_index[i]].Height / 2 + 5, masob[obj_index[i + 1]].Left + masob[obj_index[i + 1]].Width + 5, masob[obj_index[i + 1]].Top + masob[obj_index[i + 1]].Height / 2 + 5);

                        if (obj_border[i] == 4 && obj_border[i + 1] == 1) grrr.DrawLine(pen, masob[obj_index[i]].Left + masob[obj_index[i]].Width + 5, masob[obj_index[i]].Top + masob[obj_index[i]].Height / 2 + 5, masob[obj_index[i + 1]].Left + masob[obj_index[i + 1]].Width / 2 + 5, masob[obj_index[i + 1]].Top - 5);
                        if (obj_border[i] == 4 && obj_border[i + 1] == 2) grrr.DrawLine(pen, masob[obj_index[i]].Left + masob[obj_index[i]].Width + 5, masob[obj_index[i]].Top + masob[obj_index[i]].Height / 2 + 5, masob[obj_index[i + 1]].Left + masob[obj_index[i + 1]].Width / 2 + 5, masob[obj_index[i + 1]].Top + masob[obj_index[i + 1]].Height + 5);
                        if (obj_border[i] == 4 && obj_border[i + 1] == 3) grrr.DrawLine(pen, masob[obj_index[i]].Left + masob[obj_index[i]].Width + 5, masob[obj_index[i]].Top + masob[obj_index[i]].Height / 2 + 5, masob[obj_index[i + 1]].Left - 5, masob[obj_index[i + 1]].Top + masob[obj_index[i + 1]].Height / 2 + 5);
                        if (obj_border[i] == 4 && obj_border[i + 1] == 4) grrr.DrawLine(pen, masob[obj_index[i]].Left + masob[obj_index[i]].Width + 5, masob[obj_index[i]].Top + masob[obj_index[i]].Height / 2 + 5, masob[obj_index[i + 1]].Left + masob[obj_index[i + 1]].Width + 5, masob[obj_index[i + 1]].Top + masob[obj_index[i + 1]].Height / 2 + 5);
                    }
                }

                for (int i2 = 0; i2 < obj_border.Length; i2++)
                   if (masob[obj_index[i2]].Parent == this.tabControl1.SelectedTab)
                    switch (obj_border[i2]) {
                        case 1: {
                                grrr.FillRectangle(Brushes.Green, masob[obj_index[i2]].Width / 2 + masob[obj_index[i2]].Left - 5, masob[obj_index[i2]].Top - 10, 10, 10); //up
                                break;
                            };
                        case 2: {
                                grrr.FillRectangle(Brushes.Green, masob[obj_index[i2]].Width / 2 + masob[obj_index[i2]].Left - 5, masob[obj_index[i2]].Top + masob[obj_index[i2]].Height, 10, 10);
                                break;
                            };
                        case 3: {
                                grrr.FillRectangle(Brushes.Green, masob[obj_index[i2]].Left - 10, masob[obj_index[i2]].Top + masob[obj_index[i2]].Height / 2 - 5, 10, 10);
                                break;
                            };
                        case 4: {
                                grrr.FillRectangle(Brushes.Green, masob[obj_index[i2]].Width + masob[obj_index[i2]].Left, masob[obj_index[i2]].Top + masob[obj_index[i2]].Height / 2 - 5, 10, 10);
                                break;
                            };
                    }
                    grrr.Dispose();
            }

            private void checkBox1_CheckedChanged(object sender, EventArgs e) {
               
                    if (checkBox1.Checked) {
                        foreach (Panel p in masob) p.Enabled = false;

                        tempcheck2 = checkBox2.Checked;
                        checkBox2.Checked = false; 
                        checkBox2.Enabled = false;
 
                        sqrpic.Enabled = false;

                        paintsqrobj();
                        paintlinks();
                    } else {
                        foreach (Panel p in masob) p.Enabled = true;

                        checkBox2.Checked = tempcheck2; 
                        checkBox2.Enabled = true; 

                        sqrpic.Enabled = true;

                        gr = this.tabControl1.SelectedTab.CreateGraphics();
                        gr.Clear(Color.White);
                        gr.Dispose();
                        paintlinks();
                    }
            }

            private void checkBox2_CheckedChanged(object sender, EventArgs e) {
                if (checkBox2.Checked) {
                    gr = this.tabControl1.SelectedTab.CreateGraphics();
                    gr.Clear(Color.White);
                    gr.Dispose();

                    tempcheck1 = checkBox1.Checked;
                    checkBox1.Checked = false;
                    checkBox1.Enabled = false;

                    paintlinks();
                } else {
                    checkBox1.Checked = tempcheck1; 
                    checkBox1.Enabled = true; 

                    gr = this.tabControl1.SelectedTab.CreateGraphics();
                    gr.Clear(Color.White);
                    gr.Dispose();
                    paintlinks();
                }
            }

            private void deletelink() {
                int ktemp = 0;
                foreach (Panel p in masob) {
                    if (p.Parent == this.tabControl1.SelectedTab) {
                        if (this.tabControl1.SelectedTab.PointToClient(Control.MousePosition).Y >= p.Top - 10)
                            if (this.tabControl1.SelectedTab.PointToClient(Control.MousePosition).Y <= p.Top)
                                if (this.tabControl1.SelectedTab.PointToClient(Control.MousePosition).X >= p.Left + p.Width / 2 - 5)
                                    if (this.tabControl1.SelectedTab.PointToClient(Control.MousePosition).X <= p.Left + p.Width / 2 + 5) {
                                        for (int i = 0; i < obj_index.Length; i++)
                                            if (obj_index[i] == ktemp && obj_border[i] == 1)
                                                if (i % 2 == 0) {
                                                    for (int del = i; del < obj_index.Length - 1; del++) obj_index[del] = obj_index[del + 1];
                                                    for (int del = i; del < obj_index.Length - 2; del++) obj_index[del] = obj_index[del + 1];
                                                    for (int del = i; del < obj_border.Length - 1; del++) obj_border[del] = obj_border[del + 1];
                                                    for (int del = i; del < obj_border.Length - 2; del++) obj_border[del] = obj_border[del + 1];
                                                    Array.Resize(ref obj_index, obj_index.Length - 2);
                                                    Array.Resize(ref obj_border, obj_border.Length - 2);
                                                } else {
                                                    for (int del = i - 1; del < obj_index.Length - 1; del++) obj_index[del] = obj_index[del + 1];
                                                    for (int del = i - 1; del < obj_index.Length - 2; del++) obj_index[del] = obj_index[del + 1];
                                                    for (int del = i - 1; del < obj_border.Length - 1; del++) obj_border[del] = obj_border[del + 1];
                                                    for (int del = i - 1; del < obj_border.Length - 2; del++) obj_border[del] = obj_border[del + 1];
                                                    Array.Resize(ref obj_index, obj_index.Length - 2);
                                                    Array.Resize(ref obj_border, obj_border.Length - 2);
                                                }
                                        break;
                                    }

                        if (this.tabControl1.SelectedTab.PointToClient(Control.MousePosition).Y >= p.Top + p.Height)
                            if (this.tabControl1.SelectedTab.PointToClient(Control.MousePosition).Y <= p.Top + p.Height + 10)
                                if (this.tabControl1.SelectedTab.PointToClient(Control.MousePosition).X >= p.Left + p.Width / 2 - 5)
                                    if (this.tabControl1.SelectedTab.PointToClient(Control.MousePosition).X <= p.Left + p.Width / 2 + 5) {
                                        for (int i = 0; i < obj_index.Length; i++)
                                            if (obj_index[i] == ktemp && obj_border[i] == 1)
                                                if (i % 2 == 0) {
                                                    for (int del = i; del < obj_index.Length - 1; del++) obj_index[del] = obj_index[del + 1];
                                                    for (int del = i; del < obj_index.Length - 2; del++) obj_index[del] = obj_index[del + 1];
                                                    for (int del = i; del < obj_border.Length - 1; del++) obj_border[del] = obj_border[del + 1];
                                                    for (int del = i; del < obj_border.Length - 2; del++) obj_border[del] = obj_border[del + 1];
                                                    Array.Resize(ref obj_index, obj_index.Length - 2);
                                                    Array.Resize(ref obj_border, obj_border.Length - 2);
                                                } else {
                                                    for (int del = i - 1; del < obj_index.Length - 1; del++) obj_index[del] = obj_index[del + 1];
                                                    for (int del = i - 1; del < obj_index.Length - 2; del++) obj_index[del] = obj_index[del + 1];
                                                    for (int del = i - 1; del < obj_border.Length - 1; del++) obj_border[del] = obj_border[del + 1];
                                                    for (int del = i - 1; del < obj_border.Length - 2; del++) obj_border[del] = obj_border[del + 1];
                                                    Array.Resize(ref obj_index, obj_index.Length - 2);
                                                    Array.Resize(ref obj_border, obj_border.Length - 2);
                                                }
                                        break;
                                    }

                        if (this.tabControl1.SelectedTab.PointToClient(Control.MousePosition).Y >= p.Top + p.Height / 2 - 5)
                            if (this.tabControl1.SelectedTab.PointToClient(Control.MousePosition).Y <= p.Top + p.Height / 2 + 5)
                                if (this.tabControl1.SelectedTab.PointToClient(Control.MousePosition).X >= p.Left - 10)
                                    if (this.tabControl1.SelectedTab.PointToClient(Control.MousePosition).X <= p.Left) {
                                        for (int i = 0; i < obj_index.Length; i++)
                                            if (obj_index[i] == ktemp && obj_border[i] == 1)
                                                if (i % 2 == 0) {
                                                    for (int del = i; del < obj_index.Length - 1; del++) obj_index[del] = obj_index[del + 1];
                                                    for (int del = i; del < obj_index.Length - 2; del++) obj_index[del] = obj_index[del + 1];
                                                    for (int del = i; del < obj_border.Length - 1; del++) obj_border[del] = obj_border[del + 1];
                                                    for (int del = i; del < obj_border.Length - 2; del++) obj_border[del] = obj_border[del + 1];
                                                    Array.Resize(ref obj_index, obj_index.Length - 2);
                                                    Array.Resize(ref obj_border, obj_border.Length - 2);
                                                } else {
                                                    for (int del = i - 1; del < obj_index.Length - 1; del++) obj_index[del] = obj_index[del + 1];
                                                    for (int del = i - 1; del < obj_index.Length - 2; del++) obj_index[del] = obj_index[del + 1];
                                                    for (int del = i - 1; del < obj_border.Length - 1; del++) obj_border[del] = obj_border[del + 1];
                                                    for (int del = i - 1; del < obj_border.Length - 2; del++) obj_border[del] = obj_border[del + 1];
                                                    Array.Resize(ref obj_index, obj_index.Length - 2);
                                                    Array.Resize(ref obj_border, obj_border.Length - 2);
                                                }
                                        break;
                                    }

                        if (this.tabControl1.SelectedTab.PointToClient(Control.MousePosition).Y >= p.Top + p.Height / 2 - 5)
                            if (this.tabControl1.SelectedTab.PointToClient(Control.MousePosition).Y <= p.Top + p.Height / 2 + 5)
                                if (this.tabControl1.SelectedTab.PointToClient(Control.MousePosition).X >= p.Left + p.Width)
                                    if (this.tabControl1.SelectedTab.PointToClient(Control.MousePosition).X <= p.Left + p.Width + 10) {
                                        for (int i = 0; i < obj_index.Length; i++)
                                            if (obj_index[i] == ktemp && obj_border[i] == 1)
                                                if (i % 2 == 0) {
                                                    for (int del = i; del < obj_index.Length - 1; del++) obj_index[del] = obj_index[del + 1];
                                                    for (int del = i; del < obj_index.Length - 2; del++) obj_index[del] = obj_index[del + 1];
                                                    for (int del = i; del < obj_border.Length - 1; del++) obj_border[del] = obj_border[del + 1];
                                                    for (int del = i; del < obj_border.Length - 2; del++) obj_border[del] = obj_border[del + 1];
                                                    Array.Resize(ref obj_index, obj_index.Length - 2);
                                                    Array.Resize(ref obj_border, obj_border.Length - 2);
                                                } else {
                                                    for (int del = i - 1; del < obj_index.Length - 1; del++) obj_index[del] = obj_index[del + 1];
                                                    for (int del = i - 1; del < obj_index.Length - 2; del++) obj_index[del] = obj_index[del + 1];
                                                    for (int del = i - 1; del < obj_border.Length - 1; del++) obj_border[del] = obj_border[del + 1];
                                                    for (int del = i - 1; del < obj_border.Length - 2; del++) obj_border[del] = obj_border[del + 1];
                                                    Array.Resize(ref obj_index, obj_index.Length - 2);
                                                    Array.Resize(ref obj_border, obj_border.Length - 2);
                                                }
                                        break;
                                    }
                        ktemp++;
                    }
                }

                if (masob.Length - 1 <= 1) checkBox2.Enabled = false;
                if (!checkBox1.Enabled) checkBox1.Enabled = true;
                if (checkBox2.Checked) checkBox2.Checked = false; 
                gr = this.tabControl1.SelectedTab.CreateGraphics();
                gr.Clear(Color.White);
                gr.Dispose();
                paintlinks();
            }

            private void Form1_Resize(object sender, EventArgs e) {
                if (checkBox1.Checked)  {
                    paintsqrobj();
                    paintlinks();
                } else {
                    gr = this.tabControl1.SelectedTab.CreateGraphics();
                    gr.Clear(Color.White);
                    gr.Dispose();
                    paintlinks();
                }
            }

            private void paintsqrobj() {
                foreach(Panel p in masob) {
                    if (p.Parent == this.tabControl1.SelectedTab) {
                        gr = this.tabControl1.SelectedTab.CreateGraphics();
                        gr.FillRectangle(Brushes.Red, p.Left - 10, p.Top + p.Height / 2 - 5, 10, 10);
                        gr.FillRectangle(Brushes.Red, p.Width + p.Left, p.Top + p.Height / 2 - 5, 10, 10);

                        gr.FillRectangle(Brushes.Red, p.Width / 2 + p.Left - 5, p.Top - 10, 10, 10);
                        gr.FillRectangle(Brushes.Red, p.Width / 2 + p.Left - 5, p.Top + p.Height, 10, 10);
                        gr.Dispose();
                    }
                }
            }
        
            private bool checksqhover() { 
            bool flag = false;
            int ktemp=0;
            foreach(Panel p in masob) {
                if(this.tabControl1.SelectedTab.PointToClient(Control.MousePosition).Y >= p.Top-10)
                    if(this.tabControl1.SelectedTab.PointToClient(Control.MousePosition).Y <= p.Top)
                        if(this.tabControl1.SelectedTab.PointToClient(Control.MousePosition).X >= p.Left+p.Width/2-5)
                            if(this.tabControl1.SelectedTab.PointToClient(Control.MousePosition).X <= p.Left+p.Width/2+5) {
                                flag = true;
                                indexstartlink = ktemp;
                                bordst = 1;
                                break;
                            }
                if (this.tabControl1.SelectedTab.PointToClient(Control.MousePosition).Y >= p.Top + p.Height)
                    if (this.tabControl1.SelectedTab.PointToClient(Control.MousePosition).Y <= p.Top + p.Height + 10)
                        if (this.tabControl1.SelectedTab.PointToClient(Control.MousePosition).X >= p.Left + p.Width / 2 - 5)
                            if (this.tabControl1.SelectedTab.PointToClient(Control.MousePosition).X <= p.Left + p.Width / 2 + 5) {
                                flag = true;
                                indexstartlink = ktemp;
                                bordst = 2;
                                break;
                            }
                if (this.tabControl1.SelectedTab.PointToClient(Control.MousePosition).Y >= p.Top + p.Height/2 - 5)
                    if (this.tabControl1.SelectedTab.PointToClient(Control.MousePosition).Y <= p.Top + p.Height/2 + 5)
                        if (this.tabControl1.SelectedTab.PointToClient(Control.MousePosition).X >= p.Left - 10)
                            if (this.tabControl1.SelectedTab.PointToClient(Control.MousePosition).X <= p.Left) {
                                flag = true;
                                indexstartlink = ktemp;
                                bordst = 3;
                                break;
                            }
                if (this.tabControl1.SelectedTab.PointToClient(Control.MousePosition).Y >= p.Top + p.Height / 2 - 5)
                    if (this.tabControl1.SelectedTab.PointToClient(Control.MousePosition).Y <= p.Top + p.Height / 2 + 5)
                        if (this.tabControl1.SelectedTab.PointToClient(Control.MousePosition).X >= p.Left + p.Width)
                            if (this.tabControl1.SelectedTab.PointToClient(Control.MousePosition).X <= p.Left + p.Width + 10) {
                                flag = true;
                                indexstartlink = ktemp;
                                bordst = 4;
                                break;
                            }
                ktemp++;
            }
            return flag;
            }

            private bool checksqhoverend() {
                bool flag = false;
                int ktemp = 0;
                foreach (Panel p in masob) {
                    if (this.tabControl1.SelectedTab.PointToClient(Control.MousePosition).Y >= p.Top - 10)
                        if (this.tabControl1.SelectedTab.PointToClient(Control.MousePosition).Y <= p.Top)
                            if (this.tabControl1.SelectedTab.PointToClient(Control.MousePosition).X >= p.Left + p.Width / 2 - 5)
                                if (this.tabControl1.SelectedTab.PointToClient(Control.MousePosition).X <= p.Left + p.Width / 2 + 5) {
                                    flag = true;
                                    indexendlink = ktemp;
                                    bordend = 1;
                                    break;
                                }
                    if (this.tabControl1.SelectedTab.PointToClient(Control.MousePosition).Y >= p.Top + p.Height)
                        if (this.tabControl1.SelectedTab.PointToClient(Control.MousePosition).Y <= p.Top + p.Height + 10)
                            if (this.tabControl1.SelectedTab.PointToClient(Control.MousePosition).X >= p.Left + p.Width / 2 - 5)
                                if (this.tabControl1.SelectedTab.PointToClient(Control.MousePosition).X <= p.Left + p.Width / 2 + 5) {
                                    flag = true;
                                    indexendlink = ktemp;
                                    bordend = 2;
                                    break;
                                }
                    if (this.tabControl1.SelectedTab.PointToClient(Control.MousePosition).Y >= p.Top + p.Height / 2 - 5)
                        if (this.tabControl1.SelectedTab.PointToClient(Control.MousePosition).Y <= p.Top + p.Height / 2 + 5)
                            if (this.tabControl1.SelectedTab.PointToClient(Control.MousePosition).X >= p.Left - 10)
                                if (this.tabControl1.SelectedTab.PointToClient(Control.MousePosition).X <= p.Left) {
                                    flag = true;
                                    indexendlink = ktemp;
                                    bordend = 3;
                                    break;
                                }
                    if (this.tabControl1.SelectedTab.PointToClient(Control.MousePosition).Y >= p.Top + p.Height / 2 - 5)
                        if (this.tabControl1.SelectedTab.PointToClient(Control.MousePosition).Y <= p.Top + p.Height / 2 + 5)
                            if (this.tabControl1.SelectedTab.PointToClient(Control.MousePosition).X >= p.Left + p.Width)
                                if (this.tabControl1.SelectedTab.PointToClient(Control.MousePosition).X <= p.Left + p.Width + 10) {
                                    flag = true;
                                    indexendlink = ktemp;
                                    bordend = 4;
                                    break;
                                }
                    ktemp++;
                }
                return flag;
            }

#endregion

    }
}
