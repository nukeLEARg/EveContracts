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
using NukeESI;

namespace NukeContracts.UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void tv_Main_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            JitaExchange jita = new JitaExchange();
            jita.Pull();
            foreach(Contract contract in jita.Contracts)
            {
                if (contract.info.title == "")
                    tv_MainView.Nodes.Add(new TreeNode(contract.info.contract_id.ToString()));
                else
                    tv_MainView.Nodes.Add(new TreeNode(contract.info.title));

            }
        }
        
    }
}
