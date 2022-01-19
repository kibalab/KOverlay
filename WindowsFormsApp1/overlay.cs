using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Etier.IconHelper;
using System.Diagnostics;
using IWshRuntimeLibrary;

namespace WindowsFormsApp1
{
    public partial class overlay : Form
    {
        private List<string> FilName = new List<string>();
        private bool WMP = false;
        public overlay()
        {
            InitializeComponent();
        }

        private void overlay_Load(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            textBox2.Visible = false;
            this.Opacity = 0;
            timer2.Start();
            this.BackColor = Color.Black;
            this.TransparencyKey = Color.Wheat;
            //this.TopMost = true;
            //this.Opacity = 0.50;
            this.StartPosition = FormStartPosition.Manual;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            timer1.Start();
            //this.BackgroundImageLayout.
            this.KeyPreview = true;
            this.KeyPress += new KeyPressEventHandler(overlay_KeyPress);


            label1.BackColor = Color.Transparent;
            label1.Parent = this;

            label2.BackColor = Color.Transparent;
            label2.Parent = this;

            //textBox1.BackColor = Color.Transparent;
            textBox1.Parent = this;

            //trackBar1.BackColor = Color.Transparent;
            trackBar1.Parent = this;

            string[] array2 = System.IO.Directory.GetFiles(@"./lnk/", "*.lnk");

            imageList1.ImageSize = new Size(43, 43);
        }

        void overlay_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString("HH:mm:ss");
            label2.Text = DateTime.Now.ToString("yy년 MM월 dd일");
        }
        
        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            //label5.text = new performanceCounter1("Memory", "Available Mbytes");
        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {
            if(WMP == false)
            {
                axWindowsMediaPlayer1.Ctlcontrols.play();
                WMP = true;
            }
            else
            {
                axWindowsMediaPlayer1.Ctlcontrols.pause();
                WMP = false;
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            axWindowsMediaPlayer1.URL = openFileDialog1.FileName;
            axWindowsMediaPlayer1.Ctlcontrols.play();
            textBox1.Text = axWindowsMediaPlayer1.Ctlcontrols.currentItem.name;
            axWindowsMediaPlayer1.settings.volume = 5;
            trackBar1.Value = 5;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.settings.volume = trackBar1.Value;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (this.Opacity <= 1.0)
            {
                this.Opacity += 0.1;
            }
            else
            {
                timer2.Stop();
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (textBox2.Visible == false)
            {
                textBox2.Visible = true;
            }
            else
                textBox2.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Visible == false)
            {
                openFileDialog2.ShowDialog();
                pictureBox1.Visible = true;
            }
            else
                pictureBox1.Visible = false;
        }

        private void openFileDialog2_FileOk(object sender, CancelEventArgs e)
        {
            pictureBox1.Image = Image.FromFile(openFileDialog2.FileName);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            if(pictureBox1.Visible == false)
            {
                pictureBox1.Visible = true;
            }
            else
                pictureBox1.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Title = "경로를 지정하세요";
            saveFileDialog1.Filter = "*.png|*jpg";
            saveFileDialog1.OverwritePrompt = true;
            saveFileDialog1.ShowDialog();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            pictureBox1.Image.Save(saveFileDialog1.FileName);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        
    }
}

