using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestSharp;

namespace EveContractTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ESIClass esi = new ESIClass();
            List<ContractCall> call = esi.GetContracts("10000002");
            for (int i = 0; i < 100; i++)
            {
                if(call.ElementAt(i).type.Equals("item_exchange"))
                    testText.Text += call.ElementAt(i).ToString();
            }
        }
    }
}
