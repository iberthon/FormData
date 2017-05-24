namespace FormData
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.MessageGrid = new System.Windows.Forms.DataGridView();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.PanelButtons = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StatusLabelCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusSpring = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusProgress1 = new System.Windows.Forms.ToolStripProgressBar();
            this.BtnReply = new System.Windows.Forms.Button();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.BtnExport = new System.Windows.Forms.Button();
            this.PanelMain = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MessageGrid)).BeginInit();
            this.PanelButtons.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.PanelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.MessageGrid);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.richTextBox1);
            this.splitContainer1.Size = new System.Drawing.Size(983, 496);
            this.splitContainer1.SplitterDistance = 327;
            this.splitContainer1.TabIndex = 0;
            this.splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer1_SplitterMoved);
            // 
            // MessageGrid
            // 
            this.MessageGrid.AllowUserToAddRows = false;
            this.MessageGrid.AllowUserToDeleteRows = false;
            this.MessageGrid.AllowUserToOrderColumns = true;
            this.MessageGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.MessageGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MessageGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MessageGrid.Location = new System.Drawing.Point(0, 0);
            this.MessageGrid.Name = "MessageGrid";
            this.MessageGrid.ReadOnly = true;
            this.MessageGrid.RowHeadersVisible = false;
            this.MessageGrid.Size = new System.Drawing.Size(327, 496);
            this.MessageGrid.TabIndex = 0;
            this.MessageGrid.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.MessageGrid_DataBindingComplete);
            this.MessageGrid.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.MessageGrid_RowEnter);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(0, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(652, 496);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // PanelButtons
            // 
            this.PanelButtons.Controls.Add(this.statusStrip1);
            this.PanelButtons.Controls.Add(this.BtnReply);
            this.PanelButtons.Controls.Add(this.BtnDelete);
            this.PanelButtons.Controls.Add(this.BtnExport);
            this.PanelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanelButtons.Location = new System.Drawing.Point(0, 496);
            this.PanelButtons.Name = "PanelButtons";
            this.PanelButtons.Size = new System.Drawing.Size(983, 63);
            this.PanelButtons.TabIndex = 1;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabelCount,
            this.StatusSpring,
            this.StatusProgress1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 41);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(983, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // StatusLabelCount
            // 
            this.StatusLabelCount.Name = "StatusLabelCount";
            this.StatusLabelCount.Size = new System.Drawing.Size(33, 17);
            this.StatusLabelCount.Text = "Total";
            // 
            // StatusSpring
            // 
            this.StatusSpring.Name = "StatusSpring";
            this.StatusSpring.Size = new System.Drawing.Size(833, 17);
            this.StatusSpring.Spring = true;
            // 
            // StatusProgress1
            // 
            this.StatusProgress1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.StatusProgress1.Name = "StatusProgress1";
            this.StatusProgress1.Size = new System.Drawing.Size(100, 16);
            this.StatusProgress1.Step = 1;
            // 
            // BtnReply
            // 
            this.BtnReply.Location = new System.Drawing.Point(249, 12);
            this.BtnReply.Name = "BtnReply";
            this.BtnReply.Size = new System.Drawing.Size(75, 23);
            this.BtnReply.TabIndex = 2;
            this.BtnReply.Text = "Reply";
            this.BtnReply.UseVisualStyleBackColor = true;
            this.BtnReply.Click += new System.EventHandler(this.BtnReply_Click);
            // 
            // BtnDelete
            // 
            this.BtnDelete.Location = new System.Drawing.Point(12, 12);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(95, 23);
            this.BtnDelete.TabIndex = 1;
            this.BtnDelete.Text = "Delete Message";
            this.BtnDelete.UseVisualStyleBackColor = true;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // BtnExport
            // 
            this.BtnExport.Location = new System.Drawing.Point(867, 12);
            this.BtnExport.Name = "BtnExport";
            this.BtnExport.Size = new System.Drawing.Size(104, 23);
            this.BtnExport.TabIndex = 0;
            this.BtnExport.Text = "MailChimp Export";
            this.BtnExport.UseVisualStyleBackColor = true;
            this.BtnExport.Click += new System.EventHandler(this.BtnExport_Click);
            // 
            // PanelMain
            // 
            this.PanelMain.Controls.Add(this.splitContainer1);
            this.PanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelMain.Location = new System.Drawing.Point(0, 0);
            this.PanelMain.Name = "PanelMain";
            this.PanelMain.Size = new System.Drawing.Size(983, 496);
            this.PanelMain.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(983, 559);
            this.Controls.Add(this.PanelMain);
            this.Controls.Add(this.PanelButtons);
            this.Name = "Form1";
            this.Text = "HO Soccer Form Data v1.0";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MessageGrid)).EndInit();
            this.PanelButtons.ResumeLayout(false);
            this.PanelButtons.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.PanelMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.DataGridView MessageGrid;
        private System.Windows.Forms.Panel PanelButtons;
        private System.Windows.Forms.Button BtnReply;
        private System.Windows.Forms.Button BtnDelete;
        private System.Windows.Forms.Button BtnExport;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabelCount;
        private System.Windows.Forms.Panel PanelMain;
        private System.Windows.Forms.ToolStripStatusLabel StatusSpring;
        private System.Windows.Forms.ToolStripProgressBar StatusProgress1;
    }
}

