using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace SchnauzerMonitor
{
    public partial class PortForm : Form
    {
        public PortForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool flag = false;
            flag = new FileHelp(Port.Text).DoSaveFile();
            if (flag) this.Close();
        }

        private void PortForm_Load(object sender, EventArgs e)
        {
            string result = FileHelp.DoReadFile();

            Port.Text = result;
        }
    }
}
