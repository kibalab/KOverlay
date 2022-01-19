using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestPlugin;
using System.Windows.Forms;
using System.Drawing;
using Plugins;

namespace TestPlugin
{
    public class TestPlugin : Plugin
    {
        public void run()//플러그인 dll파일 입니다
        {
            //WindowsFormsApp1.Form1 frm = new WindowsFormsApp1.Form1();
            Button btn = new Button();
            //frm.btn.Location = new System.Drawing.Point(154, 8);
            //frm.btn.Name = "button1";
            //frm.btn.Size = new System.Drawing.Size(75, 23);
            //frm.btn.TabIndex = 3;
            //frm.btn.Text = "p_test";
            //frm.btn.UseVisualStyleBackColor = true;
            btn.Visible = true;
            MessageBox.Show("test");
        }

        public string PluginName()
        {
            return "testPlugin_1";
        }
    }
}
