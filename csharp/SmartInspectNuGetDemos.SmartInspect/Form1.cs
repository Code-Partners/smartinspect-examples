using System;
using System.Windows.Forms;
using Gurock.SmartInspect;

namespace NuGetSamples.SmartInspectDemo
{
    public partial class Form1 : Form
    {
        private readonly SmartInspect _smartInspect;
        private readonly Session _session;

        public Form1()
        {
            InitializeComponent();

            // Initializing the SmartInspect instance with the application name
            _smartInspect = new SmartInspect("MyApp");
            _session = new Session(_smartInspect, "MySession");
            _smartInspect.Error += new Gurock.SmartInspect.ErrorEventHandler(EventHandler);
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            SendMessage(txtMessage.Text);
        }

        private void SendMessage(string message)
        {
            _session.EnterMethod("button1_Click"); // Starting a SmartInspect method trace
            _session.LogMessage(message); // Logs a text message
            _session.LeaveMethod("button1_Click"); // Ending the SmartInspect method trace
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            _smartInspect.Connections = "tcp(host=\""+txtHost.Text+"\", port="+txtPort.Text+")"; // Configuring a TCP connection to the SmartInspect Console
            _smartInspect.Enabled = true; // Enabling SmartInspect logging           
        }

        public void EventHandler(object sender, Gurock.SmartInspect.ErrorEventArgs args)
        {
            MessageBox.Show(args.Exception.Message);
        }

    }
}
