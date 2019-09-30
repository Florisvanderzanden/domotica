using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OPC;
using OPCDA;
using OPCDA.NET;

namespace domotica
{
    class OPCDriver
    {
        OpcServer OpcSrv = null;

        public OPCItemDef[] Items;
        public OPCItemState[] result;

        OpcGroup OpcGrp;

        int[] ItemHandles;
        int[] errors;

        public int Connect(string Servername)
        {
            Debug.WriteLine("Try to connect to : " + Servername);
            if (OpcSrv != null)
            {
                Debug.WriteLine("Already connected");
                return -1;
            }

            try
            {
                OpcSrv = new OpcServer();
                OpcSrv.Connect(Servername);
                Debug.WriteLine("Connected to the server");
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error connecting to the server");
                OpcSrv = null;
                return -2;
            }

            /* add the items here */
            Items = new OPCItemDef[2];  // onlyone node can be selected
            Items[0] = new OPCItemDef("PLC1:PLC_PRG.doorbell", true, 0, typeof(void));
            Items[1] = new OPCItemDef("PLC1:.DO_CARDS", true, 0, typeof(void));

            Debug.WriteLine("Creating OPC group");
            ItemHandles = null;
            errors = null;
            int updRate = 500;
            int clientHandle = 1;
            int rtc;
            OpcGrp = OpcSrv.AddGroup("", true, updRate, clientHandle, out rtc);

            if (HRESULTS.Failed(rtc))
            {
                Debug.WriteLine("Error creating group");
                return rtc;
            }

            OPCItemResult[] rslt;
            rtc = OpcGrp.AddItems(Items, out rslt);
            if (HRESULTS.Failed(rtc))
            {
                Debug.WriteLine("Error adding items to the OPC group");
                return rtc;
            }

            ItemHandles = new int[rslt.Length];
            errors = new int[Items.Length];
            Debug.WriteLine("Items added");
            for (int i = 0; i < Items.Length; ++i)
            {
                ItemHandles[i] = rslt[i].HandleServer;
                errors[i] = rslt[i].Error;
            }

            return 0;
        }

        public void updateItems()
        {
            if (OpcSrv == null)
            {
                Debug.WriteLine("Not connected");
                return;
            }
            if (OpcGrp == null)
            {
                Debug.WriteLine("OPC group not created");
                return;
            }
            
            int rtc = OpcGrp.Read(OPCDATASOURCE.OPC_DS_CACHE, ItemHandles, out result);
            if (HRESULTS.Failed(rtc))
                Debug.WriteLine("Read error 0x" + rtc.ToString("X"));
            else     // display the read values
            {
                string txt = "";
                for (int i = 0; i < result.Length; ++i)
                {
                    if (i > 0)
                        txt += "\r\n";
                    if (HRESULTS.Failed(result[i].Error))
                        txt += "Error 0x" + result[i].Error.ToString("X");
                    else
                        txt += result[i].DataValue.ToString();
                }

            }
            

        }

        public object getItem(string name)
        {
            for (int i = 0; i < result.Length; ++i)
            {
                   

                if (Items[i].ItemID==name)
                {
                    
                    return result[i].DataValue;

                }
            }

            return null;
        }
    }
}
