using Serilog;
using SmartInspect.SerilogSink;
using System;
using System.Windows.Forms;

namespace NuGetSamples.SerilogSink
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Log.Logger = new LoggerConfiguration()
                .WriteTo.SmartInspectConsoleSink("localhost", 4228)
                .CreateLogger();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Log.Information("Testing SerilogSink");
        }
    }
}
