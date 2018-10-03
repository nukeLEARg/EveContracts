using System;
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
using NukeContracts.Business.Models.Contracts;

namespace NukeContracts.UI
{
    public partial class ContractInfo : UserControl
    {
        private List<ItemPanel> itemPanels = new List<ItemPanel>();
        private Contract contract;

        public ContractInfo(Contract contract)
        {
            InitializeComponent();
            this.contract = contract;
            genText();
            if (contract.Items.Count > 0)
                genItemPanels();
            else
                genNotLoaded();
        }

        private void genText()
        {
            lb_ContractName.MaximumSize = new Size(150,0);
            lb_ContractName.Text = contract.Title;
            lb_Type.Text = contract.Type;
            lb_Price.Text = $"{contract.Price:#,##0.00} ISK";
            lb_Volume.Text = contract.Volume.ToString();
            lb_date_issued.Text = contract.DateIssued.ToString();
            lb_Expires.Text = contract.DateExpired.ToString();
            lb_Location.MaximumSize = new Size(184, 0);
            lb_Location.Text = contract?.Station?.Name ?? contract.StartLocationId.ToString();
        }

        private void genNotLoaded()
        {
            ItemWarning panelToAdd = new ItemWarning();
            pnl_ItemWindow.Controls.Add(panelToAdd);
        }

        private void genItemPanels()
        {
            int itemCount = 0;
            int top = 0;
            int left = 0;
            int height = 50;
            int width = 400;
            foreach (ContractItem item in contract.Items)
            {
                ItemPanel panelToAdd = new ItemPanel(item);
                panelToAdd.Top = top;
                panelToAdd.Left = left;
                panelToAdd.Height = height;
                panelToAdd.Width = width;
                panelToAdd.Click += i_Click;
                foreach(Control cont in panelToAdd.Controls)
                {
                    cont.Click += c_Click;
                }
                pnl_ItemWindow.Controls.Add(panelToAdd);
                itemPanels.Add(panelToAdd);
                top += height;
                itemCount++;
            }
        }
        
        void c_Click(object sender, EventArgs e)
        {
            Control cont = (Control)sender;
            i_Click (cont.Parent,e);
        }

        void i_Click(object sender, EventArgs e)
        {
            pnl_ItemDetails.Controls.Clear();
            foreach (ItemPanel otherPanel in itemPanels)
            {
                otherPanel.BackColor = SystemColors.Control;
            }
            ItemPanel item = (ItemPanel)sender;
            item.BackColor = Color.CadetBlue;
            int hold = contract.Items.IndexOf(item.item);
            pnl_ItemDetails.Controls.Add(new ItemDetails(item.item));
        }
    }
}
