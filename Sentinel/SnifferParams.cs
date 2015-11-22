using PcapDotNet.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sentinel {
    public class SnifferParams {
        public LivePacketDevice device;
        public String filter;
        public int count;

        public SnifferParams(LivePacketDevice device, String filter, int count) {
            this.device = device;
            this.filter = filter;
            this.count = count;
        }
    }
}
