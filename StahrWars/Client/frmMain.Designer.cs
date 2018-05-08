using System;
using System.Windows.Forms;

namespace Client
{
    partial class frmMain
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
            this.txtIP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.panCanvas = new System.Windows.Forms.PictureBox();
            this.chkShowGrid = new System.Windows.Forms.CheckBox();
            this.txtServerMessages = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblSector = new System.Windows.Forms.Label();
            this.chkShowBackground = new System.Windows.Forms.CheckBox();
            this.grpStatus = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.picShields = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblShielsUp = new System.Windows.Forms.Label();
            this.prbHealth = new System.Windows.Forms.ProgressBar();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.panCanvas)).BeginInit();
            this.grpStatus.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picShields)).BeginInit();
            this.SuspendLayout();
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(582, 11);
            this.txtIP.Margin = new System.Windows.Forms.Padding(2);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(111, 20);
            this.txtIP.TabIndex = 1;
            this.txtIP.TabStop = false;
            this.txtIP.Text = "127.0.0.1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(527, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Server IP";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(697, 11);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(2);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(56, 22);
            this.btnConnect.TabIndex = 3;
            this.btnConnect.TabStop = false;
            this.btnConnect.Text = "Join";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(697, 469);
            this.btnQuit.Margin = new System.Windows.Forms.Padding(2);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(56, 22);
            this.btnQuit.TabIndex = 5;
            this.btnQuit.TabStop = false;
            this.btnQuit.Text = "Quit";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // panCanvas
            // 
            this.panCanvas.BackColor = System.Drawing.Color.Black;
            this.panCanvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panCanvas.Location = new System.Drawing.Point(12, 11);
            this.panCanvas.Name = "panCanvas";
            this.panCanvas.Size = new System.Drawing.Size(480, 480);
            this.panCanvas.TabIndex = 6;
            this.panCanvas.TabStop = false;
            this.panCanvas.Click += new System.EventHandler(this.panCanvas_Click);
            this.panCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.panCanvas_Paint);
            // 
            // chkShowGrid
            // 
            this.chkShowGrid.AutoSize = true;
            this.chkShowGrid.Checked = true;
            this.chkShowGrid.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowGrid.Location = new System.Drawing.Point(507, 474);
            this.chkShowGrid.Name = "chkShowGrid";
            this.chkShowGrid.Size = new System.Drawing.Size(75, 17);
            this.chkShowGrid.TabIndex = 7;
            this.chkShowGrid.Text = "Show Grid";
            this.chkShowGrid.UseVisualStyleBackColor = true;
            this.chkShowGrid.CheckedChanged += new System.EventHandler(this.chkShowGrid_CheckedChanged);
            // 
            // txtServerMessages
            // 
            this.txtServerMessages.Location = new System.Drawing.Point(507, 63);
            this.txtServerMessages.Multiline = true;
            this.txtServerMessages.Name = "txtServerMessages";
            this.txtServerMessages.ReadOnly = true;
            this.txtServerMessages.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtServerMessages.Size = new System.Drawing.Size(245, 401);
            this.txtServerMessages.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(504, 47);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Server Messages";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 494);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Sector:";
            // 
            // lblSector
            // 
            this.lblSector.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSector.ForeColor = System.Drawing.Color.Red;
            this.lblSector.Location = new System.Drawing.Point(80, 494);
            this.lblSector.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSector.Name = "lblSector";
            this.lblSector.Size = new System.Drawing.Size(67, 20);
            this.lblSector.TabIndex = 11;
            this.lblSector.Text = "--";
            this.lblSector.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkShowBackground
            // 
            this.chkShowBackground.AutoSize = true;
            this.chkShowBackground.Checked = true;
            this.chkShowBackground.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowBackground.Location = new System.Drawing.Point(378, 494);
            this.chkShowBackground.Name = "chkShowBackground";
            this.chkShowBackground.Size = new System.Drawing.Size(114, 17);
            this.chkShowBackground.TabIndex = 12;
            this.chkShowBackground.Text = "Show Background";
            this.chkShowBackground.UseVisualStyleBackColor = true;
            this.chkShowBackground.CheckedChanged += new System.EventHandler(this.chkShowBackground_CheckedChanged);
            // 
            // grpStatus
            // 
            this.grpStatus.Controls.Add(this.groupBox1);
            this.grpStatus.Controls.Add(this.prbHealth);
            this.grpStatus.Controls.Add(this.label4);
            this.grpStatus.Location = new System.Drawing.Point(782, 47);
            this.grpStatus.Name = "grpStatus";
            this.grpStatus.Size = new System.Drawing.Size(363, 416);
            this.grpStatus.TabIndex = 13;
            this.grpStatus.TabStop = false;
            this.grpStatus.Text = "Status";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.picShields);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lblShielsUp);
            this.groupBox1.Location = new System.Drawing.Point(16, 121);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(190, 133);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "System";
            // 
            // picShields
            // 
            this.picShields.Location = new System.Drawing.Point(121, 20);
            this.picShields.Name = "picShields";
            this.picShields.Size = new System.Drawing.Size(26, 26);
            this.picShields.TabIndex = 8;
            this.picShields.TabStop = false;
            this.picShields.Click += new System.EventHandler(this.picShields_Click);
            this.picShields.Paint += new System.Windows.Forms.PaintEventHandler(this.picShields_Paint);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Shields";
            // 
            // lblShielsUp
            // 
            this.lblShielsUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShielsUp.ForeColor = System.Drawing.Color.Red;
            this.lblShielsUp.Location = new System.Drawing.Point(63, 23);
            this.lblShielsUp.Name = "lblShielsUp";
            this.lblShielsUp.Size = new System.Drawing.Size(100, 23);
            this.lblShielsUp.TabIndex = 6;
            this.lblShielsUp.Text = "OFF";
            this.lblShielsUp.Click += new System.EventHandler(this.lblShielsUp_Click);
            // 
            // prbHealth
            // 
            this.prbHealth.BackColor = System.Drawing.SystemColors.Control;
            this.prbHealth.Location = new System.Drawing.Point(57, 30);
            this.prbHealth.Name = "prbHealth";
            this.prbHealth.Size = new System.Drawing.Size(290, 20);
            this.prbHealth.Step = 1;
            this.prbHealth.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.prbHealth.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Health";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1155, 683);
            this.ControlBox = false;
            this.Controls.Add(this.grpStatus);
            this.Controls.Add(this.chkShowBackground);
            this.Controls.Add(this.lblSector);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtServerMessages);
            this.Controls.Add(this.chkShowGrid);
            this.Controls.Add(this.panCanvas);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtIP);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StahrWars";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panCanvas)).EndInit();
            this.grpStatus.ResumeLayout(false);
            this.grpStatus.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picShields)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private TextBox txtIP;
        private Label label1;
        private Button btnConnect;
        private Button btnQuit;
		private PictureBox panCanvas;
		private CheckBox chkShowGrid;
		private TextBox txtServerMessages;
		private Label label2;
		private Label label3;
		private Label lblSector;
		private CheckBox chkShowBackground;
        private GroupBox grpStatus;
        private Label label4;
        private ProgressBar prbHealth;
        private GroupBox groupBox1;
        private PictureBox picShields;
        private Label label5;
        private Label lblShielsUp;
    }
}

