using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NukeContracts.Business;
using NukeESI;

namespace NukeContracts.UI
{
    public partial class ContractInfo : UserControl
    {
        public ContractInfo(Contract contract)
        {
            InitializeComponent();
            lb_ContractName.Text = contract.info.title;
            lb_Price.Text = contract.info.price.ToString("00.00");
            lb_Volume.Text = contract.info.volume.ToString();
            lb_date_issued.Text = contract.info.date_issued.ToString();
        }
    }
}
