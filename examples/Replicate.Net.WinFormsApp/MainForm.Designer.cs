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
			this.btnGenerate = new System.Windows.Forms.Button();
			this.picture1 = new System.Windows.Forms.PictureBox();
			this.txtPrompt = new System.Windows.Forms.TextBox();
			this.picture2 = new System.Windows.Forms.PictureBox();
			this.picture3 = new System.Windows.Forms.PictureBox();
			this.picture4 = new System.Windows.Forms.PictureBox();
			this.rightClickMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.toolStripMenuItemSave = new System.Windows.Forms.ToolStripMenuItem();
			this.buttonSaveAll = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.picture1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.picture2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.picture3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.picture4)).BeginInit();
			this.rightClickMenuStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnGenerate
			// 
			this.btnGenerate.Location = new System.Drawing.Point(999, 46);
			this.btnGenerate.Name = "btnGenerate";
			this.btnGenerate.Size = new System.Drawing.Size(112, 50);
			this.btnGenerate.TabIndex = 0;
			this.btnGenerate.Text = "Generate";
			this.btnGenerate.UseVisualStyleBackColor = true;
			this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
			// 
			// picture1
			// 
			this.picture1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.picture1.ImageLocation = "";
			this.picture1.Location = new System.Drawing.Point(41, 175);
			this.picture1.Name = "picture1";
			this.picture1.Size = new System.Drawing.Size(512, 512);
			this.picture1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.picture1.TabIndex = 1;
			this.picture1.TabStop = false;
			this.picture1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picture_MouseDown);
			// 
			// txtPrompt
			// 
			this.txtPrompt.Location = new System.Drawing.Point(41, 46);
			this.txtPrompt.Multiline = true;
			this.txtPrompt.Name = "txtPrompt";
			this.txtPrompt.Size = new System.Drawing.Size(913, 90);
			this.txtPrompt.TabIndex = 2;
			this.txtPrompt.Text = "multicolor hyperspace";
			this.txtPrompt.TextChanged += new System.EventHandler(this.txtPrompt_TextChanged);
			// 
			// picture2
			// 
			this.picture2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.picture2.ImageLocation = "";
			this.picture2.Location = new System.Drawing.Point(599, 175);
			this.picture2.Name = "picture2";
			this.picture2.Size = new System.Drawing.Size(512, 512);
			this.picture2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.picture2.TabIndex = 3;
			this.picture2.TabStop = false;
			this.picture2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picture_MouseDown);
			// 
			// picture3
			// 
			this.picture3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.picture3.ImageLocation = "";
			this.picture3.Location = new System.Drawing.Point(41, 730);
			this.picture3.Name = "picture3";
			this.picture3.Size = new System.Drawing.Size(512, 512);
			this.picture3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.picture3.TabIndex = 4;
			this.picture3.TabStop = false;
			this.picture3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picture_MouseDown);
			// 
			// picture4
			// 
			this.picture4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.picture4.ImageLocation = "";
			this.picture4.Location = new System.Drawing.Point(599, 730);
			this.picture4.Name = "picture4";
			this.picture4.Size = new System.Drawing.Size(512, 512);
			this.picture4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.picture4.TabIndex = 5;
			this.picture4.TabStop = false;
			this.picture4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picture_MouseDown);
			// 
			// rightClickMenuStrip
			// 
			this.rightClickMenuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
			this.rightClickMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemSave});
			this.rightClickMenuStrip.Name = "contextMenuStrip";
			this.rightClickMenuStrip.Size = new System.Drawing.Size(122, 36);
			this.rightClickMenuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.rightClickMenuStrip_ItemClicked);
			// 
			// toolStripMenuItemSave
			// 
			this.toolStripMenuItemSave.Name = "toolStripMenuItemSave";
			this.toolStripMenuItemSave.Size = new System.Drawing.Size(121, 32);
			this.toolStripMenuItemSave.Text = "Save";
			// 
			// buttonSaveAll
			// 
			this.buttonSaveAll.Location = new System.Drawing.Point(999, 1259);
			this.buttonSaveAll.Name = "buttonSaveAll";
			this.buttonSaveAll.Size = new System.Drawing.Size(112, 50);
			this.buttonSaveAll.TabIndex = 6;
			this.buttonSaveAll.Text = "Save All";
			this.buttonSaveAll.UseVisualStyleBackColor = true;
			this.buttonSaveAll.Click += new System.EventHandler(this.buttonSaveAll_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1148, 1334);
			this.Controls.Add(this.buttonSaveAll);
			this.Controls.Add(this.picture4);
			this.Controls.Add(this.picture3);
			this.Controls.Add(this.picture2);
			this.Controls.Add(this.txtPrompt);
			this.Controls.Add(this.picture1);
			this.Controls.Add(this.btnGenerate);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MainForm";
			this.Text = "Stable Diffusion";
			((System.ComponentModel.ISupportInitialize)(this.picture1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.picture2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.picture3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.picture4)).EndInit();
			this.rightClickMenuStrip.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Button btnGenerate;
		private PictureBox picture1;
		private TextBox txtPrompt;
		private PictureBox picture2;
		private PictureBox picture3;
		private PictureBox picture4;
		private ContextMenuStrip rightClickMenuStrip;
		private ToolStripMenuItem toolStripMenuItemSave;
		private Button buttonSaveAll;
	}
}