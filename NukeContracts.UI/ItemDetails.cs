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
    public partial class ItemDetails : UserControl
    {
        public ItemDetails(ContractContents item)
        {
            InitializeComponent();
            lb_itemID.Text = item.item_id.ToString();
            lb_typeID.Text = item.type_id.ToString();
        }

        public ItemDetails(ContractContents item, TypeCall typeInfo)
        {
            InitializeComponent();
            lb_itemID.Text = item.item_id.ToString();
            lb_typeID.Text = item.type_id.ToString();
            lb_TYPE.Text = typeInfo.description;
        }
    }
}
