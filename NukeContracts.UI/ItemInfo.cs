using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NukeESI;

namespace NukeContracts.UI
{
    public partial class ItemInfo : UserControl
    {
        public ItemInfo(ContractContents item)
        {
            InitializeComponent();
            lb_item_id.Text = item.type_id.ToString();
            lb_Quantity.Text = item.quantity.ToString();
        }
    }
}
