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

namespace NukeContracts.UI
{
    public partial class ItemPanel : UserControl
    {
        /*
         * If the item images are not showing up please download the Types.zip from here: https://developers.eveonline.com/resource/resources
         * And extract it to the build folder and rename it to Items
         */
        public ContractItem item { get; set; }
        
        public ItemPanel(ContractItem item)
        {
            InitializeComponent();
            this.item = item;
            genText(item);
        }

        private void genText(ContractItem item)
        {
            lb_Amount.Text = "x" + item.Quantity.ToString();
            //lb_ItemName.Text = IDSearch.getName(item.type_id); TODO Names
            String path = $"Items\\{item.TypeId}_64.png";
            if (File.Exists(path))
                pb_Icon.Load(path);
        }
    }
}
