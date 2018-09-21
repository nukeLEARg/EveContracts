using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NukeESI;
using NukeContracts.Business;

namespace NukeContracts.UI
{
    public partial class ItemPanel : UserControl
    {
        public ItemPanel(ContractContents item, IDSearch search)
        {
            InitializeComponent();
            lb_Amount.Text = item.quantity.ToString();
            lb_ItemName.Text = search.getName(item.type_id);
            String path = $"Items\\{item.type_id}_64.png";
            if (File.Exists(path))
                pb_Icon.Load(path);
        }
    }
}
