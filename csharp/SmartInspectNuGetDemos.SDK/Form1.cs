using Gurock.SmartInspect;
using SmartInspect.SDK;

namespace SmartInspectNuGetDemos.SDK
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                OpenSilFile(openFileDialog1.FileName);
            }
        }

        private void OpenSilFile(string fileName)
        {
            // Clear existing rows in the DataGridView
            dataGridView1.Rows.Clear();

            // Open the log file using the LogFile class
            // The 'using' statement ensures the log is properly disposed after use
            using (ILog log = new LogFile(fileName))
            {
                foreach (Packet packet in log)
                {
                    // Check if the packet is a LogEntry
                    if (packet is LogEntry logEntry)
                    {
                        // If it is a LogEntry, add a new row to the DataGridView
                        // with the LogEntry's level, size, and title properties
                        dataGridView1.Rows.Add(
                            logEntry.Level.ToString(),
                            logEntry.Size,
                            logEntry.Title
                        );
                    }
                }
            }

        }
    }
}