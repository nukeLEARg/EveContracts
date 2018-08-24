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
            var client = new RestClient();
            client.BaseUrl = new System.Uri("https://esi.evetech.net/latest/");
            var request = new RestRequest("contracts/public/10000002 /?datasource=tranquility&page=1");
            var response = client.Execute<ContractCall>(request);
            
        }
    }
}
