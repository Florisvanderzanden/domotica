using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace domotica
{
    public partial class Form1 : Form
    {
        OPCDriver OPCServer = new OPCDriver();
        public Form1()
        {
            InitializeComponent();
        }

        private void TestConnectionButton_Click(object sender, EventArgs e)
        {
            OPCServer.Connect("CoDeSys.OPC.02");
            timer1.Start();
            
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            OPCServer.updateItems();
            for (int i = 0; i < OPCServer.Items.Count(); i++)
            {
                testConnectionListBox.Items.Add(OPCServer.Items[i].ItemID);
            }
            Debug.WriteLine(OPCServer.getItem("PLC1:PLC_PRG.doorbell").ToString());
        }
    }
}
