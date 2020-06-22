using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Memory;
using System.Threading;
using System.Windows.Forms.VisualStyles;
using System.Runtime.InteropServices;
using ovrly;

namespace ovrly
{
    public partial class Form1 : Form
    {

        public const string WINDOW_NAME = "AssaultCube";
        public const string health = "ac_client.exe+0x0109B74,F8";
        public const string ammo = "ac_client.exe+0x0109B74,150";

        

        Mem m = new Mem();

        

        


        

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            this.BackColor = Color.Wheat;
            this.TransparencyKey = Color.Wheat;
            this.FormBorderStyle = FormBorderStyle.None;
            this.TopMost = true;

            int initialStyle = imports.GetWindowLong(this.Handle, -20);
            imports.SetWindowLong(this.Handle, -20, initialStyle | 0x8000 | 0x20);

            imports.GetWindowRect(imports.handle, out imports.rect);
            this.Size = new Size(imports.rect.right - imports.rect.left, imports.rect.bottom - imports.rect.top);
            this.Left = imports.rect.left;

            this.Top = imports.rect.top;
            





            int PID = m.GetProcIdFromName("ac_client");
            if (PID > 0)
            {
                m.OpenProcess(PID);
                backgroundWorker1.RunWorkerAsync();
                backgroundWorker2.RunWorkerAsync();
                setnewSize.RunWorkerAsync();
                hotkeys.RunWorkerAsync();

            }
           
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                if (checkBox1.Checked)
                {
                    m.WriteMemory(health, "int", "1337");
                    Thread.Sleep(100);
                    m.WriteMemory(health, "int", "420");
                    Thread.Sleep(100);
                    m.WriteMemory(health, "int", "69");
                    Thread.Sleep(100);
                }
            }
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                if (checkBox2.Checked)
                {
                    animationwrite(ammo);
                    
                    Thread.Sleep(100);
                }
                Thread.Sleep(100);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox1.ForeColor = System.Drawing.Color.Green;
            } else
            {
                checkBox1.ForeColor = System.Drawing.Color.Red;
            }
        }
        

        private void setnewSize_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                
                imports.GetWindowRect(imports.handle, out imports.rect);
                this.Size = new Size(imports.rect.right - imports.rect.left, imports.rect.bottom - imports.rect.top);
                this.Left = imports.rect.left;
                
                this.Top = imports.rect.top;
                this.TopMost = true;
                Thread.Sleep(10);

            }
        }

        private void hotkeys_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                if (imports.GetAsyncKeyState(Keys.F1)<0)
                {
                    if (checkBox1.Checked)
                    {
                        checkBox1.Checked = false;
                        Thread.Sleep(300);
                    }
                    else

                    {
                        checkBox1.Checked = true;
                        Thread.Sleep(300);
                    }
                   
                    }
                else if (imports.GetAsyncKeyState(Keys.F2) < 0)
                {
                    if (checkBox2.Checked)
                    {
                        checkBox2.Checked = false;
                        Thread.Sleep(300);


                    }
                    else
                    {
                        checkBox2.Checked = true;
                        Thread.Sleep(300);
                    }
                    Thread.Sleep(300);
                }
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                checkBox2.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                checkBox2.ForeColor = System.Drawing.Color.Red;
            }
        }
        private void animationwrite(string addy)
        {
            m.WriteMemory(addy, "int", "111111119");
            Thread.Sleep(100);
            m.WriteMemory(addy, "int", "111111181");
            Thread.Sleep(100);
            m.WriteMemory(addy, "int", "111111711");
            Thread.Sleep(100);
            m.WriteMemory(addy, "int", "111116111");
            Thread.Sleep(100);
            m.WriteMemory(addy, "int", "111151111");
            Thread.Sleep(100);
            m.WriteMemory(addy, "int", "111411111");
            Thread.Sleep(100);
            m.WriteMemory(ammo, "int", "113111111");
            Thread.Sleep(100);
            m.WriteMemory(addy, "int", "121111111");
            Thread.Sleep(100);
            m.WriteMemory(addy, "int", "111111111");
            Thread.Sleep(100);
        }
    }
}
