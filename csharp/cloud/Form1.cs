/*
 *  Copyright (C) Gurock Software GmbH. All rights reserved.
 *
 *  Description:
 *
 *  This example is the source code of the getting started tutorial
 *  included in the online help. Please see the tutorial for more
 *  information.
 *
 */

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Gurock.SmartInspect;
using Gurock.SmartInspect.Cloud;

namespace Gurock.SmartInspect.Examples.CSharpTutorial
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			//
			// button1
			//
			this.button1.Location = new System.Drawing.Point(112, 96);
			this.button1.Name = "button1";
			this.button1.TabIndex = 0;
			this.button1.Text = "button1";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			//
			// Form1
			//
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 266);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.button1});
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			CloudProtocol a;

			SiAuto.Si.Connections = new CloudConnectionStringBuilder().AddCloudProtocol()
			 .SetRegion("eu-central-1")
			 .SetWriteKey("48bf82f7-aa82-4074-83f5-d17950453e14")
			 // .AddCustomLabel("User", "Bob")
			 // .AddCustomLabel("Version", "0.0.1")
			 .And().Build();

			// SiAuto.Si.Connections = "tcp()";

			SiAuto.Si.Enabled = true;
			SiAuto.Main.EnterProcess("CSharpTutorial");
			try
			{
				Application.Run(new Form1());
			}
			finally
			{
				SiAuto.Main.LeaveProcess("CSharpTutorial");
			}
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			SiAuto.Main.EnterMethod(this, "button1_Click");
			try
			{
				SiAuto.Main.LogMessage("This is my first SmartInspect cloud message!");
			}
			finally
			{
				SiAuto.Main.LeaveMethod(this, "button1_Click");
			}
		}
	}
}
