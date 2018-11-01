using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NukeContracts.Business.Models.Contracts;

namespace NukeContracts.UI.Controls
{
    public partial class ItemDetails : UserControl
    {
        public ItemDetails(ContractItem item)
        {
            InitializeComponent();
            lb_itemID.Text = item.ItemId.ToString();
            lb_typeID.Text = item.TypeId.ToString();
            lb_TYPE.Text = item.Type?.ToString() ?? "type not loaded";
        }
    }
}
