using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;               // For prcesss related information
using System.Runtime.InteropServices;   // For DLL importing

namespace myform
{
    public partial class Form1 : Form
    {
        Process p;
        [DllImport("User32")]
        private static extern int ShowWindow(int hwnd, int nCmdShow);
        [DllImport("user32.dll")]
        static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent); 


        private const int SW_HIDE = 0; 
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int hWnd;
            p = new Process();
            p.StartInfo.FileName = "wrk.lnk";
            p.Start();
            hWnd = p.MainWindowHandle.ToInt32();
            ShowWindow(hWnd, SW_HIDE);

            p.WaitForInputIdle();
            while (p.MainWindowHandle == IntPtr.Zero)
            {
                p.Refresh();
            }
            SetParent(p.MainWindowHandle, this.panel1.Handle);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            p.Kill();
            p.Close();
        }
    }
}
