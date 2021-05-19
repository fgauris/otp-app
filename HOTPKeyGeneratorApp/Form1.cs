using System;
using System.Windows.Forms;

namespace HOTPKeyGeneratorApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            //if the form is minimized  
            //hide it from the task bar  
            //and show the system tray icon (represented by the NotifyIcon control)  
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon.Visible = true;
            }
        }

        private void GenerateKeyMenuItem_Click(object sender, System.EventArgs e)
        {
            var key = BusinessLogic.GenerateKey();
            Clipboard.SetText(key);
        }

        private void ExitMenuItem_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }

        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                traymenu.Select();
                traymenu.Show();
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            // minimize window
            this.WindowState = FormWindowState.Minimized;

            // hide from taskbar
            this.Hide();
        }
    }
}
