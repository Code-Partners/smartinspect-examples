namespace SmartInspectNuGetDemos.SDK
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            btnOpen=new Button();
            openFileDialog1=new OpenFileDialog();
            dataGridView1=new DataGridView();
            Level=new DataGridViewTextBoxColumn();
            Size=new DataGridViewTextBoxColumn();
            Content=new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // btnOpen
            // 
            btnOpen.Location=new Point(12, 12);
            btnOpen.Name="btnOpen";
            btnOpen.Size=new Size(75, 23);
            btnOpen.TabIndex=0;
            btnOpen.Text="Open file";
            btnOpen.UseVisualStyleBackColor=true;
            btnOpen.Click+=button1_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.DefaultExt="sil";
            openFileDialog1.FileName="openFileDialog1";
            openFileDialog1.Filter="SmartInspect sil files|*.sil|All files|*.*";
            openFileDialog1.Title="Open file";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows=false;
            dataGridView1.AllowUserToDeleteRows=false;
            dataGridView1.Anchor=AnchorStyles.Top|AnchorStyles.Bottom|AnchorStyles.Left|AnchorStyles.Right;
            dataGridView1.ColumnHeadersHeightSizeMode=DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Level, Size, Content });
            dataGridView1.Location=new Point(12, 41);
            dataGridView1.Name="dataGridView1";
            dataGridViewCellStyle2.WrapMode=DataGridViewTriState.True;
            dataGridView1.RowsDefaultCellStyle=dataGridViewCellStyle2;
            dataGridView1.RowTemplate.Height=100;
            dataGridView1.Size=new Size(642, 387);
            dataGridView1.TabIndex=1;
            // 
            // Level
            // 
            Level.HeaderText="Level";
            Level.Name="Level";
            // 
            // Size
            // 
            Size.HeaderText="Size";
            Size.Name="Size";
            // 
            // Content
            // 
            dataGridViewCellStyle1.WrapMode=DataGridViewTriState.True;
            Content.DefaultCellStyle=dataGridViewCellStyle1;
            Content.HeaderText="Content";
            Content.Name="Content";
            Content.Width=200;
            // 
            // Form1
            // 
            AutoScaleDimensions=new SizeF(7F, 15F);
            AutoScaleMode=AutoScaleMode.Font;
            ClientSize=new Size(666, 440);
            Controls.Add(dataGridView1);
            Controls.Add(btnOpen);
            Name="Form1";
            StartPosition=FormStartPosition.CenterScreen;
            Text="Sil Viewer";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnOpen;
        private OpenFileDialog openFileDialog1;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Level;
        private DataGridViewTextBoxColumn Size;
        private DataGridViewTextBoxColumn Content;
    }
}