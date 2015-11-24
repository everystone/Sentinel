using PcapDotNet.Core;
using PcapDotNet.Packets;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Sentinel {
    public partial class Sentinel : Form {
        DeviceList deviceList;
        PacketCapture packetCapture;
        private BackgroundWorker worker;
        private int packet_number = 0;
        Dictionary<int, Packet> packets;

        public Sentinel() {
            InitializeComponent();

            deviceList = new DeviceList();
            packetCapture = new PacketCapture();
            packetCapture.packetEvent += packetCapture_packetEvent;
            worker = new BackgroundWorker();
            worker.DoWork += worker_DoWork;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            packets = new Dictionary<int, Packet>();
            
            // Populate GUI fields.
            foreach (var adapter in deviceList.getDevices()) {
               // gui_ComboAdapter.Items.Add(String.Format("{0} ({1})", adapter.Key, adapter.Value.Description));
                gui_ComboAdapter.Items.Add(adapter.Value.Description);
            }

            //debuging @TODO: Save this number, auto-select adapter next time program runs.
            gui_ComboAdapter.SelectedIndex = 2;
            filterBox.Text = "tcp && dst port 5005";
        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            gui_btn_start.Enabled = true;
        }

        void worker_DoWork(object sender, DoWorkEventArgs e) {
            // Receive packets in a backgroundworker to prevent blocking of GUI thread.
            //var params = (SnifferParams)e.Argument;
            SnifferParams parameters = (SnifferParams)e.Argument;
            packetCapture.Listen(parameters.device, parameters.filter, parameters.count);
        }



        private void gui_btn_start_Click(object sender, EventArgs e) {
            //packet_number = 0;
            //packets.Clear();
            var selected = gui_ComboAdapter.SelectedItem.ToString();
            var adapter = deviceList.deviceFromDescription(selected);
            var filter = filterBox.Text;
            var count = Int32.Parse(gui_packetNumberBox.Text);

            Console.WriteLine(String.Format("Starting capture on {0} with filter: {1}", adapter.Description, filter));
            worker.RunWorkerAsync(new SnifferParams(adapter, filter, count));
            gui_btn_start.Enabled = false;
        }

        void packetCapture_packetEvent(object sender, PacketArgs e) {

            /**
             * packet.Ethernet.EtherType - ipv6, ipv4, arp
             * packet.Ethernet.IpV4.Protocol - HopByhopOption
             */
            //var protocol = packet.Ethernet.IpV4.Protocol == PcapDotNet.Packets.IpV4.IpV4Protocol.Tcp ? "TCP" : "UDP";
            var packet = e.packet;
            var protocol = "";
            var source = "";
            var destination = "";
            Datagram payload;
            switch (packet.Ethernet.IpV4.Protocol) {
                case PcapDotNet.Packets.IpV4.IpV4Protocol.Tcp:
                    protocol = "TCP";
                    source = String.Format("{0}:{1}", packet.Ethernet.IpV4.Source, packet.Ethernet.IpV4.Tcp.SourcePort);
                    destination = String.Format("{0}:{1}", packet.Ethernet.IpV4.Destination, packet.Ethernet.IpV4.Tcp.DestinationPort);
                    payload = packet.Ethernet.IpV4.Tcp.Payload;
                    break;
                case PcapDotNet.Packets.IpV4.IpV4Protocol.Udp:
                    protocol = "UDP";
                    source = String.Format("{0}:{1}", packet.Ethernet.IpV4.Source, packet.Ethernet.IpV4.Udp.SourcePort);
                    destination = String.Format("{0}:{1}", packet.Ethernet.IpV4.Destination, packet.Ethernet.IpV4.Udp.DestinationPort);
                    payload = packet.Ethernet.IpV4.Udp.Payload;
                    break;
                default:
                    // Ignore anything thats not UDP or TCP @TODO: Add this to Settings
                    return;
                    protocol = packet.Ethernet.IpV4.Protocol.ToString();
                    source = packet.Ethernet.IpV4.Source.ToString();
                    break;
            }

            //Skip packets with zero data payload @TODO: Config this
            // Skip TCP SYN, ACK etc. spam
            if (payload.Length == 0) return;

           
            packet_number++;
            packets.Add(packet_number, packet);
            ListViewItem item = new ListViewItem();
            item.Text = packet_number.ToString();
            //Date
            item.SubItems.Add(packet.Timestamp.ToString("yyyy-MM-dd hh:mm:ss.fff"));
            //Source
            item.SubItems.Add(source);
            //Destination
            item.SubItems.Add(destination);
            //Protocol
            item.SubItems.Add(protocol);
            //Size ( of payload data )
            item.SubItems.Add(payload.Length.ToString());
            //Payload
            item.SubItems.Add(payload.ToString());

            this.Invoke((MethodInvoker)delegate {
                packetListView.Items.Add(item); // runs on UI thread
            });
            
            Console.WriteLine(e.packet.Timestamp.ToString("yyyy-MM-dd hh:mm:ss.fff") + " length:" + e.packet.Length);
        }

        private void gui_btn_stop_Click(object sender, EventArgs e) {

        }

        private void packetListView_SelectedIndexChanged(object sender, EventArgs e) {
            if (packetListView.SelectedItems.Count > 0) {
                var selectedPacket = this.packetListView.SelectedItems[0];
                //MessageBox.Show(selectedPacket.SubItems[0].Text);
                var no = Int32.Parse(selectedPacket.SubItems[0].Text); // packet #
                var packet = packets[no];
                var hexString = "";
   
                if (packet.Ethernet.IpV4.Protocol == PcapDotNet.Packets.IpV4.IpV4Protocol.Tcp) {
                    hexString = packet.Ethernet.IpV4.Tcp.Payload.ToHexadecimalString();
                }
                else if (packet.Ethernet.IpV4.Protocol == PcapDotNet.Packets.IpV4.IpV4Protocol.Udp) {
                    hexString = packet.Ethernet.IpV4.Udp.Payload.ToHexadecimalString();
                }
                else {
                    // only UDP and Tcp are supported atm.
                    return;
                }

                var ascii = hexToStr(hexString);
                ascii = StringUtil.RemoveSpecialCharacters(ascii);
                

                
               // asciiDetails.Text = ascii;
                //hexDetails.Text = hexString;
                asciiDetails.Text = Regex.Replace(ascii, ".{2}", "$0 ");
                hexDetails.Text = Regex.Replace(hexString, ".{2}", "$0 ");
               // Console.WriteLine(ascii);
                
            }


        }
        private String hexToStr(String hexString) {
            String result = String.Empty;
             for (int i = 0; i < hexString.Length; i += 2) {
                string hs = hexString.Substring(i, 2);
                result += (Convert.ToChar(Convert.ToUInt32(hs, 16)));
            }
             return result;
        }


        private void richTextBox1_TextChanged(object sender, EventArgs e) {

        }

        private void Sentinel_Load(object sender, EventArgs e) {

            ToolTip toolTip = new ToolTip();
            toolTip.AutoPopDelay = 15000;
            toolTip.InitialDelay = 200;
            toolTip.ReshowDelay = 500;
            toolTip.ShowAlways = true;

            toolTip.SetToolTip(filterBox, "Set a filter using WinPcap expression syntax\nexamples:\nsrc host 10.0.0.1\ndst port 27000");
            toolTip.SetToolTip(gui_packetNumberBox, "Number of packets to capture");
        }

        /* Selects text in Ascii box that represents HEX values */
        private void selectText(String color = null) {
            var start = hexDetails.Text.IndexOf(hexDetails.SelectedText);
            asciiDetails.Select(start / 2, hexDetails.SelectedText.Length / 2);
            if(color != null){
                hexDetails.SelectionBackColor = Color.FromName(color);
                asciiDetails.SelectionBackColor = Color.FromName(color);
                deSelect();
            }
            Console.WriteLine(String.Format("Selecting from {0} -> {1}", start / 2, hexDetails.SelectedText.Length / 2));

        }
        /* Deselects selection in hex and ascii */
        private void deSelect() {
            hexDetails.DeselectAll();
            asciiDetails.DeselectAll();
        }
        private void hexDetails_SelectionChanged(object sender, EventArgs e) {
            if (hexDetails.SelectedText.Length > 0) {
                //Console.WriteLine(hexDetails.SelectedText);
                // Find index of selected text
                gui_bytes_selected.Text = (Regex.Replace(hexDetails.SelectedText, @"\s+", "").Length / 2).ToString() + " Bytes selected";
                selectText();
            }
            //MessageBox.Show(hexDetails.SelectedText);
        }

        private void decodeSelection() {
            // Grab Hex selection and remove all spaces
            var hex = Regex.Replace(hexDetails.SelectedText, @"\s+", "");
            var byteCount = hex.Length / 2;
            byte[] bytes = StringUtil.StringToByteArray(hex);
            Console.WriteLine("Bytes: " + bytes);
            var result = "";

                switch (byteCount) {
                    case 0:
                    case 1:
                        result += PacketUtils.isObjectOfType(bytes, PacketUtils.ValueType.Boolean);
                        break;
                    case 2: // in16, uint16
                        result += PacketUtils.isObjectOfType(bytes, PacketUtils.ValueType.Int16);
                        result += PacketUtils.isObjectOfType(bytes, PacketUtils.ValueType.UInt16);
                        break;
                    case 4: // uint32, int32, float
                        result += PacketUtils.isObjectOfType(bytes, PacketUtils.ValueType.Int32);
                        result += PacketUtils.isObjectOfType(bytes, PacketUtils.ValueType.UInt32);
                        result += PacketUtils.isObjectOfType(bytes, PacketUtils.ValueType.Float);
                        break;
                    case 6:

                        break;
                    case 8: // double
                        result += PacketUtils.isObjectOfType(bytes, PacketUtils.ValueType.Double);
                        break;
                }
            


            gui_label_calc.Text = result;
        }
        private void decodeToolStripMenuItem_Click(object sender, EventArgs e) {
            decodeSelection();
        }

        private void yellowToolStripMenuItem_Click(object sender, EventArgs e) {
            selectText("yellow");            
        }

        private void blueToolStripMenuItem_Click(object sender, EventArgs e) {
            selectText("blue");
        }

        private void redToolStripMenuItem_Click(object sender, EventArgs e) {
            selectText("red");
        }

        private void greenToolStripMenuItem_Click(object sender, EventArgs e) {
            selectText("green");
        }

        private void orangeToolStripMenuItem_Click(object sender, EventArgs e) {
            selectText("orange");
        }
    }
}
