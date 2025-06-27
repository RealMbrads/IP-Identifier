using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace IP_Identifier_WindowsForms
{
    public partial class Form1 : Form
    {
        private const string ipInfoToken = "";     // Put your ipinfo.io token here
        private const string vpnApiKey = "";         // Put your vpnapi.io key here

        public Form1()
        {
            InitializeComponent();
            this.txtIP.KeyPress += new KeyPressEventHandler(txtIP_KeyPress);
        }

        private async void btnLookup_Click(object sender, EventArgs e)
        {
            string ip = txtIP.Text.Trim();
            if (string.IsNullOrEmpty(ip))
            {
                MessageBox.Show("Please enter an IP address.");
                return;
            }

            try
            {
                // Step 1: Get general info from ipinfo.io
                string ipInfoUrl = $"https://ipinfo.io/{ip}/json?token={ipInfoToken}";
                IpInfoResponse ipInfoData;
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage ipInfoResponse = await client.GetAsync(ipInfoUrl);
                    ipInfoResponse.EnsureSuccessStatusCode();
                    string ipInfoJson = await ipInfoResponse.Content.ReadAsStringAsync();
                    ipInfoData = JsonConvert.DeserializeObject<IpInfoResponse>(ipInfoJson);
                }

                // Step 2: Get VPN info from vpnapi.io
                string vpnApiUrl = $"https://vpnapi.io/api/{ip}?key={vpnApiKey}";
                VpnApiResponse vpnData;
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage vpnResponse = await client.GetAsync(vpnApiUrl);
                    vpnResponse.EnsureSuccessStatusCode();
                    string vpnJson = await vpnResponse.Content.ReadAsStringAsync();
                    vpnData = JsonConvert.DeserializeObject<VpnApiResponse>(vpnJson);
                }

                // Build combined results string
                string results = $"IP: {ipInfoData.ip}\n" +
                                 $"Country: {ipInfoData.country}\n" +
                                 $"Region: {ipInfoData.region}\n" +
                                 $"City: {ipInfoData.city}\n" +
                                 $"Postal Code: {ipInfoData.postal}\n" +
                                 $"Coordinates: {ipInfoData.loc}\n" +
                                 $"ISP: {ipInfoData.org}\n" +
                                 $"Timezone: {ipInfoData.timezone}\n" +
                                 $"VPN: {(vpnData.security.vpn ? "Yes" : "No")}\n" +
                                 $"Proxy: {(vpnData.security.proxy ? "Yes" : "No")}\n" +
                                 $"TOR: {(vpnData.security.tor ? "Yes" : "No")}\n";

                rtbResults.Text = results;

                // Update map link using ipinfo.io coords
                if (!string.IsNullOrEmpty(ipInfoData.loc))
                {
                    string[] coords = ipInfoData.loc.Split(',');
                    if (coords.Length == 2)
                    {
                        linkLabelMaps.Text = $"Open Map: {coords[0]}, {coords[1]}";
                        linkLabelMaps.Tag = $"https://www.google.com/maps/?q={coords[0]},{coords[1]}";
                        linkLabelMaps.LinkColor = System.Drawing.Color.Blue;
                    }
                    else
                    {
                        linkLabelMaps.Text = "";
                        linkLabelMaps.Tag = null;
                    }
                }
                else
                {
                    linkLabelMaps.Text = "";
                    linkLabelMaps.Tag = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private async void btnMyIP_Click(object sender, EventArgs e)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string myIP = await client.GetStringAsync("https://api.ipify.org");
                    txtIP.Text = myIP;
                    btnLookup.PerformClick();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to get your IP: " + ex.Message);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void linkLabelMaps_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (linkLabelMaps.Tag != null)
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = linkLabelMaps.Tag.ToString(),
                    UseShellExecute = true
                });
            }
        }

        private void txtIP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                btnLookup.PerformClick();
            }
        }
    }

    // ipinfo.io response model
    public class IpInfoResponse
    {
        public string ip { get; set; }
        public string city { get; set; }
        public string region { get; set; }
        public string country { get; set; }
        public string loc { get; set; }
        public string org { get; set; }
        public string postal { get; set; }
        public string timezone { get; set; }
    }

    // vpnapi.io response model
    public class VpnApiResponse
    {
        public string ip { get; set; }
        public Location location { get; set; }
        public Security security { get; set; }
    }

    public class Location
    {
        public string country { get; set; }
        public string region { get; set; }
        public string city { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
    }

    public class Security
    {
        public bool vpn { get; set; }
        public bool proxy { get; set; }
        public bool tor { get; set; }
        public string isp { get; set; }
    }
}
