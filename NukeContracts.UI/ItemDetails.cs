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
        public TypeCall typeInfo();
        public ItemDetails(ContractContents item)
        {
            InitializeComponent();
        }
    }
}
