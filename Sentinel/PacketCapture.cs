using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PcapDotNet.Core;
using PcapDotNet.Packets;
using System.Windows.Forms;


namespace Sentinel {
    class PacketCapture {

        public event EventHandler<PacketArgs> packetEvent;
        private LivePacketDevice adapter;
        public PacketCapture() {

        }
        // Filter syntax: https://www.winpcap.org/docs/docs_40_2/html/group__language.html
        public void Listen(LivePacketDevice adapter, String filter, int count) {
            this.adapter = adapter;
            using (PacketCommunicator communicator = adapter.Open(65536, PacketDeviceOpenAttributes.Promiscuous, 1000)) {
                try {
                    communicator.SetFilter(filter); }
                catch (Exception e) {
                    MessageBox.Show(null, e.Message, "Filter Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                communicator.ReceivePackets(count, PacketHandler);
            }
        }

        private void PacketHandler(Packet packet) {
            // If someone is subscribed to our packetEvent, raise it.
            Console.WriteLine("packet received..");
            EventHandler<PacketArgs> handler = packetEvent;
            if (handler != null) {
                handler(null, new PacketArgs(packet));
            }
           // Console.WriteLine(packet.Timestamp.ToString("yyyy-MM-dd hh:mm:ss.fff") + " length:" + packet.Length);
        }
    }
}
