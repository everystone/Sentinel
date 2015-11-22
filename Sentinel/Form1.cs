using PcapDotNet.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Sentinel {
    public partial class Form1 : Form {
        DeviceList deviceList;
        PacketCapture packetCapture;
        private BackgroundWorker worker;

        public Form1() {
            InitializeComponent();

            deviceList = new DeviceList();
            packetCapture = new PacketCapture();
            packetCapture.packetEvent += packetCapture_packetEvent;
            worker = new BackgroundWorker();
            worker.DoWork += worker_DoWork;
            
            // Populate GUI fields.
            foreach (var adapter in deviceList.getDevices()) {
               // gui_ComboAdapter.Items.Add(String.Format("{0} ({1})", adapter.Key, adapter.Value.Description));
                gui_ComboAdapter.Items.Add(adapter.Value.Description);
            }
        }

        void worker_DoWork(object sender, DoWorkEventArgs e) {
            // Receive packets in a backgroundworker to prevent blocking of GUI thread.
            packetCapture.Listen((LivePacketDevice)e.Argument);
        }



        private void gui_btn_start_Click(object sender, EventArgs e) {
            var selected = gui_ComboAdapter.SelectedItem.ToString();
            var adapter = deviceList.deviceFromDescription(selected);
            Console.WriteLine(String.Format("Starting capture on {0}", adapter.Description));
            worker.RunWorkerAsync(adapter);
        }

        void packetCapture_packetEvent(object sender, PacketArgs e) {
            Console.WriteLine(e.packet.Timestamp.ToString("yyyy-MM-dd hh:mm:ss.fff") + " length:" + e.packet.Length);
        }
    }
}
