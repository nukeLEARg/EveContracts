﻿using System;
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
        private List<ItemPanel> itemPanels = new List<ItemPanel>();

        public ContractInfo(Contract contract,IDSearch itemSearch)
        {
            InitializeComponent();
            genText(contract);
            genItemPanels(contract, itemSearch);
        }

        private void genText(Contract contract)
        {
            lb_ContractName.Text = contract.info.title;
            lb_Type.Text = contract.info.type;
            lb_Price.Text = contract.info.price.ToString("C2");
            lb_Volume.Text = contract.info.volume.ToString();
            lb_date_issued.Text = contract.info.date_issued;
            lb_Expires.Text = contract.info.date_expired;
            lb_Location.Text = contract.info.start_location_id.ToString();
        }

        private void genItemPanels(Contract contract, IDSearch itemSearch)
        {
            /*ScrollBar vScrollBar1 = new VScrollBar();
            vScrollBar1.Dock = DockStyle.Right;
            vScrollBar1.Scroll += (sender, e) => { pnl_ItemWindow.VerticalScroll.Value = vScrollBar1.Value; };
            pnl_ItemWindow.Controls.Add(vScrollBar1);
            */
            int itemCount = 0;
            int top = 0;
            int left = 0;
            int height = 50;
            int width = 400;
            foreach (ContractContents item in contract.contents)
            {
                ItemPanel panelToAdd = new ItemPanel(item, itemSearch);
                panelToAdd.Top = top;
                panelToAdd.Left = left;
                panelToAdd.Height = height;
                panelToAdd.Width = width;
                pnl_ItemWindow.Controls.Add(panelToAdd);
                itemPanels.Add(panelToAdd);
                top += height;
                itemCount++;
            }
        }
    }
}
