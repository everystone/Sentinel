using PcapDotNet.Core;
using PcapDotNet.Packets;
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
    public partial class Sentinel : Form {
        DeviceList deviceList;
        PacketCapture packetCapture;
        private BackgroundWorker worker;
        private int packet_number = 0;

        public Sentinel() {
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
            packetCapture.Listen((LivePacketDevice)e.Argument, 5);
        }



        private void gui_btn_start_Click(object sender, EventArgs e) {
            packet_number = 0;
            var selected = gui_ComboAdapter.SelectedItem.ToString();
            var adapter = deviceList.deviceFromDescription(selected);
            Console.WriteLine(String.Format("Starting capture on {0}", adapter.Description));
            worker.RunWorkerAsync(adapter);
        }

        void packetCapture_packetEvent(object sender, PacketArgs e) {
            /* probably needs to be invoked.
            if (InvokeRequired) {
                Invoke(new Action<object, PacketArgs>(packetCapture_packetEvent), sender, e);
            }*/

            var packet = e.packet;
            packet_number++;
            ListViewItem item = new ListViewItem();
            item.Text = packet_number.ToString();
            //Date
            item.SubItems.Add(packet.Timestamp.ToString("yyyy-MM-dd hh:mm:ss.fff"));
            //From
            item.SubItems.Add(packet.Ethernet.IpV4.Source.ToString());
            //To
            item.SubItems.Add(packet.Ethernet.IpV4.Destination.ToString());
            //Protocol
            item.SubItems.Add(packet.Ethernet.IpV4.Protocol.ToString());
            //Size
            item.SubItems.Add(packet.Length.ToString());
            //Data
            item.SubItems.Add(packet.IpV4.Payload.ToHexadecimalString());

            this.Invoke((MethodInvoker)delegate {
                packetListView.Items.Add(item); // runs on UI thread
            });
            
            Console.WriteLine(e.packet.Timestamp.ToString("yyyy-MM-dd hh:mm:ss.fff") + " length:" + e.packet.Length);
        }

        private void gui_btn_stop_Click(object sender, EventArgs e) {

        }
    }
}
