using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NukeContracts.Business;


namespace NukeContracts.UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            JitaExchange test = new JitaExchange();
            test.Pull();
            textHeader.Text += test.header;
            testText.Text += test.content;
        }
    }
}
