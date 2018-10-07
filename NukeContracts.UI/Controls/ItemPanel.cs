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
using NukeContracts.Business;
using NukeContracts.Business.Models.Contracts;

namespace NukeContracts.UI.Controls
{
    public partial class ItemPanel : UserControl
    {
        /*
         * If the item images are not showing up please download the Types.zip from here: https://developers.eveonline.com/resource/resources
         * And extract it to the build folder and rename it to Items
         */
        public ContractItem Item { get; set; }
        
        public ItemPanel(ContractItem item)
        {
            InitializeComponent();
            Item = item;
            GenerateText(item);
        }

        private void GenerateText(ContractItem item)
        {
            lb_Amount.Text = "x" + item.Quantity.ToString();
            lb_ItemName.Text = IDSearch.Items[item.TypeId.ToString()] ?? "No Item Name";
            String path = $"Items\\{item.TypeId}_64.png";
            if (File.Exists(path))
                pb_Icon.Load(path);
        }
    }
}
