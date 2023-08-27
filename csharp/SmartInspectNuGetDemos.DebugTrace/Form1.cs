using Gurock.SmartInspect;
using SmartInspect.DebugTrace;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace NuGetSamples.DebugTrace
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            SiAuto.Si.Enabled = true;
            
            // Remove the default listener.
            Trace.Listeners.Clear();
            
            // Add a new SmartInspect trace listener which
            // uses SiAuto.Main as session.
            Trace.Listeners.Add(new SmartInspectTraceListener());
            
            // Write messages to the session using indentation.
            Trace.Write("Test Message");
            Trace.Indent();
            Trace.Write("Test Message");
            Trace.Write("Test Message");
            Trace.Unindent();
            Trace.Write("Test Message");
            
            // Write test failures.
            Trace.Fail("This is a Failure");
            Trace.Fail("This is a Failure", "Detailed Failure ... ");
        }
    }
}
