using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BrightFrame.UI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            // This is where we will start the Hotkey Service later
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OverlayForm overlay = new OverlayForm();
            this.Hide();

            if (overlay.ShowDialog() == DialogResult.OK)
            {
                this.Close();
            }

            
        }
    }
}
