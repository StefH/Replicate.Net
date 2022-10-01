namespace Replicate.Net.WinFormsApp
{
	partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.picture0 = new System.Windows.Forms.PictureBox();
            this.txtPrompt = new System.Windows.Forms.TextBox();
            this.picture1 = new System.Windows.Forms.PictureBox();
            this.picture2 = new System.Windows.Forms.PictureBox();
            this.picture3 = new System.Windows.Forms.PictureBox();
            this.rightClickMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemSave = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonSaveAll = new System.Windows.Forms.Button();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.lblProvider = new System.Windows.Forms.Label();
            this.lblWidth = new System.Windows.Forms.Label();
            this.lblHeight = new System.Windows.Forms.Label();
            this.cmbWidth = new System.Windows.Forms.ComboBox();
            this.cmbProvider = new System.Windows.Forms.ComboBox();
            this.cmbHeight = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblSeed = new System.Windows.Forms.Label();
            this.txtSeed = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.picture0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture3)).BeginInit();
            this.rightClickMenuStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // picture0
            // 
            this.picture0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picture0.ImageLocation = "";
            this.picture0.Location = new System.Drawing.Point(11, 93);
            this.picture0.Margin = new System.Windows.Forms.Padding(2);
            this.picture0.Name = "picture0";
            this.picture0.Size = new System.Drawing.Size(400, 400);
            this.picture0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picture0.TabIndex = 1;
            this.picture0.TabStop = false;
            this.picture0.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picture_MouseDown);
            // 
            // txtPrompt
            // 
            this.txtPrompt.Location = new System.Drawing.Point(11, 11);
            this.txtPrompt.Margin = new System.Windows.Forms.Padding(2);
            this.txtPrompt.Multiline = true;
            this.txtPrompt.Name = "txtPrompt";
            this.txtPrompt.Size = new System.Drawing.Size(815, 68);
            this.txtPrompt.TabIndex = 2;
            this.txtPrompt.Text = "multicolor hyperspace";
            this.txtPrompt.TextChanged += new System.EventHandler(this.txtPrompt_TextChanged);
            // 
            // picture1
            // 
            this.picture1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picture1.ImageLocation = "";
            this.picture1.Location = new System.Drawing.Point(426, 93);
            this.picture1.Margin = new System.Windows.Forms.Padding(2);
            this.picture1.Name = "picture1";
            this.picture1.Size = new System.Drawing.Size(400, 400);
            this.picture1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picture1.TabIndex = 3;
            this.picture1.TabStop = false;
            this.picture1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picture_MouseDown);
            // 
            // picture2
            // 
            this.picture2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picture2.ImageLocation = "";
            this.picture2.Location = new System.Drawing.Point(11, 510);
            this.picture2.Margin = new System.Windows.Forms.Padding(2);
            this.picture2.Name = "picture2";
            this.picture2.Size = new System.Drawing.Size(400, 400);
            this.picture2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picture2.TabIndex = 4;
            this.picture2.TabStop = false;
            this.picture2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picture_MouseDown);
            // 
            // picture3
            // 
            this.picture3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picture3.ImageLocation = "";
            this.picture3.Location = new System.Drawing.Point(426, 510);
            this.picture3.Margin = new System.Windows.Forms.Padding(2);
            this.picture3.Name = "picture3";
            this.picture3.Size = new System.Drawing.Size(400, 400);
            this.picture3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picture3.TabIndex = 5;
            this.picture3.TabStop = false;
            this.picture3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picture_MouseDown);
            // 
            // rightClickMenuStrip
            // 
            this.rightClickMenuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.rightClickMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemSave});
            this.rightClickMenuStrip.Name = "contextMenuStrip";
            this.rightClickMenuStrip.Size = new System.Drawing.Size(99, 26);
            this.rightClickMenuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.rightClickMenuStrip_ItemClicked);
            // 
            // toolStripMenuItemSave
            // 
            this.toolStripMenuItemSave.Name = "toolStripMenuItemSave";
            this.toolStripMenuItemSave.Size = new System.Drawing.Size(98, 22);
            this.toolStripMenuItemSave.Text = "Save";
            // 
            // buttonSaveAll
            // 
            this.buttonSaveAll.Location = new System.Drawing.Point(82, 224);
            this.buttonSaveAll.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSaveAll.Name = "buttonSaveAll";
            this.buttonSaveAll.Size = new System.Drawing.Size(78, 30);
            this.buttonSaveAll.TabIndex = 6;
            this.buttonSaveAll.Text = "Save All";
            this.buttonSaveAll.UseVisualStyleBackColor = true;
            this.buttonSaveAll.Click += new System.EventHandler(this.buttonSaveAll_Click);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(82, 155);
            this.btnGenerate.Margin = new System.Windows.Forms.Padding(2);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(78, 30);
            this.btnGenerate.TabIndex = 0;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // lblProvider
            // 
            this.lblProvider.AutoSize = true;
            this.lblProvider.Location = new System.Drawing.Point(3, 17);
            this.lblProvider.Name = "lblProvider";
            this.lblProvider.Size = new System.Drawing.Size(51, 15);
            this.lblProvider.TabIndex = 0;
            this.lblProvider.Text = "Provider";
            // 
            // lblWidth
            // 
            this.lblWidth.AutoSize = true;
            this.lblWidth.Location = new System.Drawing.Point(3, 49);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(39, 15);
            this.lblWidth.TabIndex = 1;
            this.lblWidth.Text = "Width";
            // 
            // lblHeight
            // 
            this.lblHeight.AutoSize = true;
            this.lblHeight.Location = new System.Drawing.Point(3, 84);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(43, 15);
            this.lblHeight.TabIndex = 2;
            this.lblHeight.Text = "Height";
            // 
            // cmbWidth
            // 
            this.cmbWidth.FormattingEnabled = true;
            this.cmbWidth.Items.AddRange(new object[] {
            "512",
            "768"});
            this.cmbWidth.Location = new System.Drawing.Point(65, 41);
            this.cmbWidth.Name = "cmbWidth";
            this.cmbWidth.Size = new System.Drawing.Size(95, 23);
            this.cmbWidth.TabIndex = 9;
            this.cmbWidth.Text = "512";
            // 
            // cmbProvider
            // 
            this.cmbProvider.FormattingEnabled = true;
            this.cmbProvider.Items.AddRange(new object[] {
            "custom",
            "replicate.com"});
            this.cmbProvider.Location = new System.Drawing.Point(65, 9);
            this.cmbProvider.Name = "cmbProvider";
            this.cmbProvider.Size = new System.Drawing.Size(95, 23);
            this.cmbProvider.TabIndex = 7;
            this.cmbProvider.Text = "custom";
            // 
            // cmbHeight
            // 
            this.cmbHeight.FormattingEnabled = true;
            this.cmbHeight.Items.AddRange(new object[] {
            "512",
            "768"});
            this.cmbHeight.Location = new System.Drawing.Point(65, 76);
            this.cmbHeight.Name = "cmbHeight";
            this.cmbHeight.Size = new System.Drawing.Size(95, 23);
            this.cmbHeight.TabIndex = 10;
            this.cmbHeight.Text = "512";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblSeed);
            this.panel1.Controls.Add(this.txtSeed);
            this.panel1.Controls.Add(this.cmbHeight);
            this.panel1.Controls.Add(this.buttonSaveAll);
            this.panel1.Controls.Add(this.cmbProvider);
            this.panel1.Controls.Add(this.cmbWidth);
            this.panel1.Controls.Add(this.lblHeight);
            this.panel1.Controls.Add(this.lblWidth);
            this.panel1.Controls.Add(this.lblProvider);
            this.panel1.Controls.Add(this.btnGenerate);
            this.panel1.Location = new System.Drawing.Point(842, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(170, 898);
            this.panel1.TabIndex = 8;
            // 
            // lblSeed
            // 
            this.lblSeed.AutoSize = true;
            this.lblSeed.Location = new System.Drawing.Point(3, 118);
            this.lblSeed.Name = "lblSeed";
            this.lblSeed.Size = new System.Drawing.Size(32, 15);
            this.lblSeed.TabIndex = 12;
            this.lblSeed.Text = "Seed";
            // 
            // txtSeed
            // 
            this.txtSeed.Location = new System.Drawing.Point(65, 115);
            this.txtSeed.Name = "txtSeed";
            this.txtSeed.Size = new System.Drawing.Size(95, 23);
            this.txtSeed.TabIndex = 11;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1019, 921);
            this.Controls.Add(this.picture3);
            this.Controls.Add(this.picture2);
            this.Controls.Add(this.picture1);
            this.Controls.Add(this.txtPrompt);
            this.Controls.Add(this.picture0);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stable Diffusion";
            ((System.ComponentModel.ISupportInitialize)(this.picture0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture3)).EndInit();
            this.rightClickMenuStrip.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion
		private PictureBox picture0;
		private TextBox txtPrompt;
		private PictureBox picture1;
		private PictureBox picture2;
		private PictureBox picture3;
		private ContextMenuStrip rightClickMenuStrip;
		private ToolStripMenuItem toolStripMenuItemSave;
		private Button buttonSaveAll;
        private Button btnGenerate;
        private Label lblProvider;
        private Label lblWidth;
        private Label lblHeight;
        private ComboBox cmbWidth;
        private ComboBox cmbProvider;
        private ComboBox cmbHeight;
        private Panel panel1;
        private Label lblSeed;
        private TextBox txtSeed;
    }
}