﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NukeContracts.Business;

namespace NukeContracts.UI
{
    public partial class ContractInfo : UserControl
    {
        public ContractInfo(Contract contract)
        {
            InitializeComponent();
        }
    }
}
