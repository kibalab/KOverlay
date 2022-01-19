using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Reflection;

namespace WindowsFormsApp1
{
    public partial class Setting : Form
    {

        [DllImport("user32.dll", SetLastError = true)]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        overlay frm = new overlay();
        public Setting()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.TopLevel = true;
            //this.WindowState = FormWindowState.Maximized;
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        private bool frmFT = false;
        GlobalKeyboardHook gHook;
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked == true)
            {
                gHook.hook();
            }
            else
            {
                gHook.unhook();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Opacity = 0.1;
            timer1.Start();
            //this.TopMost = true;
            this.Opacity = 1;
            //this.BackColor = Color.Wheat;
            //this.TransparencyKey = Color.Wheat;
            //int initialStyle = GetWindowLong(this.Handle, -20);
            //SetWindowLong(this.Handle, -20, initialStyle | 0x80000 | 0x20);
            //frm.Owner = this;

            gHook = new GlobalKeyboardHook(); // Create a new GlobalKeyboardHook
                                              // Declare a KeyDown Event
            gHook.KeyDown += new KeyEventHandler(gHook_KeyDown);
            // Add the keys you want to hook to the HookedKeys list
            foreach (Keys key in Enum.GetValues(typeof(Keys)))
                gHook.HookedKeys.Add(key);
            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            gHook.unhook();
        }

        public void gHook_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F3 && (Control.ModifierKeys & Keys.Shift) == Keys.Shift && frm.Visible == false)
            {
                frm.Show();
                frmFT = true;
            }
            else if (frm.Visible == true && (e.KeyCode == Keys.F3 || e.KeyCode == Keys.Escape))
            {
                frm.Hide();
                frmFT = false;
                frm.Opacity = 0;
            }
            else if (e.KeyCode == Keys.F4)
            {
                Bitmap bitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
                Graphics g = Graphics.FromImage(bitmap);
                g.CopyFromScreen(0, 0, 0, 0, bitmap.Size);
                frm.pictureBox1.Image = bitmap;
                frm.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                frm.pictureBox1.Visible = true;
                frm.Show();
                
              
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.Opacity <= 1.0)
            {
                this.Opacity += 0.025;
            }
            else
            {
                timer1.Stop();
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)//플러그인 어셈블리로 불러와서 플러그인 인터페이스에 전달
        {
            //Assembly a = Assembly.LoadFrom(openFileDialog1.FileName);
            Assembly.LoadFrom(openFileDialog1.FileName);
            foreach(Assembly a in AppDomain.CurrentDomain.GetAssemblies())
            {
                foreach(Type t in a.GetTypes())
                {
                    if(t.GetInterface("Plugin") != null)
                    {
                        //Plugin p = Activator.CreateInstance(t) as Plugin;
                        //label1.Text = p.PluginName();
                        //p.run();
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();// 플러그인 가져오기
        }

    }
}
