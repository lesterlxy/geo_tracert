using System;
using System.Diagnostics;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TracertDemo {
    public partial class MainForm : Form {
        public MainForm() {
            InitializeComponent();
        }

        private void close_Click(object sender, EventArgs e) {
            Close();
        }

        private async Task<IpApiJson> ipToLocData(IPAddress addr) {
            const string reqUrl = "http://ip-api.com/json/";
            const string reqUrlEnd = "?fields=status,message,countryCode,regionName,city,isp,org,asname,reverse";
            WebRequest req = WebRequest.Create(reqUrl + addr.ToString() + reqUrlEnd);
            req.Method = "GET";
            WebResponse response = await req.GetResponseAsync();
            System.IO.Stream stream = response.GetResponseStream();
            System.IO.StreamReader reader = new System.IO.StreamReader(stream);
            string data = reader.ReadToEnd();
            IpApiJson jsonData = JsonSerializer.Deserialize<IpApiJson>(data);
            return jsonData;
        }

        private void startTrace_Click(object sender, EventArgs e) {
            try {
                tracert.HostNameOrAddress = destination.Text;
                routeList.Items.Clear();
                tracert.Trace();
                startTrace.Enabled = false;
            } catch (SocketException ex) {
                _ = MessageBox.Show(ex.Message, "Tracert Demo");
            }
        }

        private delegate void ThreadSwitch();

        private void OnGetHostEntry(IAsyncResult ar) {
            try {
                ListViewItem.ListViewSubItem hostNameItem = ar.AsyncState as ListViewItem.ListViewSubItem;
                ThreadSwitch delg = delegate {
                    try {
                        hostNameItem.Text = Dns.EndGetHostEntry(ar).HostName;
                    } catch {
                        hostNameItem.Text = "-"; // HACK
                    }
                };
                _ = Invoke(delg);
            } catch (SocketException ex) {
                Trace.WriteLine(ex.ToString());
            }
        }

        private async void tracert_RouteNodeFound(object sender, VRK.Net.RouteNodeFoundEventArgs e) {
            ListViewItem item = routeList.Items.Add(e.Node.Address.ToString());

            IpApiJson ip_json = await ipToLocData(e.Node.Address);

            _ = item.SubItems.Add((item.Index + 1).ToString());
            ListViewItem.ListViewSubItem hostNameItem = item.SubItems.Add(string.Empty);
            _ = item.SubItems.Add(e.Node.Status == IPStatus.Success ? e.Node.RoundTripTime.ToString() : "*");

            _ = item.SubItems.Add(ip_json.countryCode + ", " + ip_json.regionName + ", " + ip_json.city);
            _ = item.SubItems.Add(ip_json.isp + ", " + ip_json.org + ", " + ip_json.asname);
            _ = item.SubItems.Add(ip_json.reverse);

            if (e.Node.Status == IPStatus.Success) {
                _ = Dns.BeginGetHostEntry(e.Node.Address, new AsyncCallback(OnGetHostEntry), hostNameItem);
            }
        }

        private void tracert_Done(object sender, EventArgs e) {
            startTrace.Enabled = true;
        }

        public class IpApiJson {
            public string status { get; set; }
            public string message { get; set; }
            public string countryCode { get; set; }
            public string regionName { get; set; }
            public string city { get; set; }
            public string isp { get; set; }
            public string org { get; set; }
            public string asname { get; set; }
            public string reverse { get; set; }
        }

        private void destination_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                startTrace_Click(sender, e);
            }
        }
    }
}