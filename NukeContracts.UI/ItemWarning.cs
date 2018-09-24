using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NukeContracts.UI
{
    public partial class ItemWarning : UserControl
    {
        public ItemWarning()
        {
            InitializeComponent();
            lb_Warning.Text = "Items still loading from api";
        }
    }
}
