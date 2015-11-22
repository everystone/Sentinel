using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PcapDotNet.Core;

namespace Sentinel {
/*
* This Class keeps track of all Adapter Devices
*/

    class DeviceList {

        private Dictionary<String, LivePacketDevice> devices;
        public Dictionary<String, LivePacketDevice> getDevices() {
            return devices;
        }
        public DeviceList() {
            devices = new Dictionary<string, LivePacketDevice>();
            createList();
        }

        public void createList(){
            IList<LivePacketDevice> allDevices = LivePacketDevice.AllLocalMachine;
            if (allDevices.Count == 0) {
                Console.WriteLine("No Interfaces found");
                return;
            }

            devices.Clear();
            for (int i = 0; i != allDevices.Count; i++) {
                LivePacketDevice device = allDevices[i];
                devices.Add(device.Name, device);

                Console.WriteLine(i + ". " + device.Name);

                //check if description exist
                if (device.Description != null) {
                    Console.WriteLine(" (" + device.Description + ")");
                }                
            }
        }

        public LivePacketDevice deviceFromDescription(String desc) {
            foreach (var adapter in devices) {
                if (adapter.Value.Description.Equals(desc))
                    return adapter.Value;
            }
            return null;
        }
    }
}
