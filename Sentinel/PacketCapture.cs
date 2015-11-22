using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PcapDotNet.Core;
using PcapDotNet.Packets;


namespace Sentinel {
    class PacketCapture {

        private LivePacketDevice adapter;
        public PacketCapture(LivePacketDevice adapter) {
            this.adapter = adapter;
            Open();
        }

        private void Open() {
            using (PacketCommunicator communicator = adapter.Open(65536, PacketDeviceOpenAttributes.Promiscuous, 1000)) {
                communicator.ReceivePackets(0, PacketHandler);
            }
        }

        private static void PacketHandler(Packet packet) {
            Console.WriteLine(packet.Timestamp.ToString("yyyy-MM-dd hh:mm:ss.fff") + " length:" + packet.Length);
        }
    }
}
