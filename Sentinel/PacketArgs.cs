using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PcapDotNet.Packets;

namespace Sentinel {

    public enum EventType {
        Packet
    }

    class PacketArgs : EventArgs {
        private Packet _packet;

        public PacketArgs(Packet packet) {
            this._packet = packet;
        }

        public Packet packet {
            get { return _packet; }
            set { _packet = packet; }
        }
    }
}
