using System;
using System.Drawing;
using System.Windows.Forms;

namespace POS_System
{
    public partial class Analytics : Form
    {
        private Connector _connector;
        public Analytics()
        {
            InitializeComponent();
            _connector = new Connector();
            _connector.InitState();
            WindowState = FormWindowState.Maximized;
            FormBorderStyle = FormBorderStyle.None;
            label3.BackColor = pictureBox1.BackColor;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            
        }
    }
}