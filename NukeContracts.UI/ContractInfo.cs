using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows.Forms;
using NukeContracts.Business;
using NukeESI;

namespace NukeContracts.UI
{
    public partial class ContractInfo : UserControl
    {
        public ContractInfo(Contract contract)
        {
            CultureInfo isk = CultureInfo.CreateSpecificCulture("is-IS");
            isk.NumberFormat.CurrencyGroupSeparator = ",";
            isk.NumberFormat.CurrencyDecimalSeparator = ".";

            InitializeComponent();
            lb_ContractName.Text = contract.info.title;
            lb_Type.Text = contract.info.type;
            lb_Price.Text = contract.info.price.ToString("C2",isk);
            lb_Volume.Text = contract.info.volume.ToString();
            lb_date_issued.Text = contract.info.date_issued;
            lb_Expires.Text = contract.info.date_expired;
            lb_Location.Text = contract.info.start_location_id.ToString();
        }
    }
}
