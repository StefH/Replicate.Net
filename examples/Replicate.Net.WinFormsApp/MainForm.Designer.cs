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
			this.btnGenerate = new System.Windows.Forms.Button();
			this.picture1 = new System.Windows.Forms.PictureBox();
			this.txtPrompt = new System.Windows.Forms.TextBox();
			this.picture2 = new System.Windows.Forms.PictureBox();
			this.picture3 = new System.Windows.Forms.PictureBox();
			this.picture4 = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.picture1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.picture2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.picture3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.picture4)).BeginInit();
			this.SuspendLayout();
			// 
			// btnGenerate
			// 
			this.btnGenerate.Location = new System.Drawing.Point(999, 46);
			this.btnGenerate.Name = "btnGenerate";
			this.btnGenerate.Size = new System.Drawing.Size(112, 59);
			this.btnGenerate.TabIndex = 0;
			this.btnGenerate.Text = "Generate";
			this.btnGenerate.UseVisualStyleBackColor = true;
			this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
			// 
			// picture1
			// 
			this.picture1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.picture1.ImageLocation = "";
			this.picture1.Location = new System.Drawing.Point(41, 142);
			this.picture1.Name = "picture1";
			this.picture1.Size = new System.Drawing.Size(512, 512);
			this.picture1.TabIndex = 1;
			this.picture1.TabStop = false;
			// 
			// txtPrompt
			// 
			this.txtPrompt.Location = new System.Drawing.Point(41, 46);
			this.txtPrompt.Multiline = true;
			this.txtPrompt.Name = "txtPrompt";
			this.txtPrompt.Size = new System.Drawing.Size(913, 59);
			this.txtPrompt.TabIndex = 2;
			this.txtPrompt.Text = "multicolor hyperspace";
			// 
			// picture2
			// 
			this.picture2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.picture2.ImageLocation = "";
			this.picture2.Location = new System.Drawing.Point(599, 142);
			this.picture2.Name = "picture2";
			this.picture2.Size = new System.Drawing.Size(512, 512);
			this.picture2.TabIndex = 3;
			this.picture2.TabStop = false;
			// 
			// picture3
			// 
			this.picture3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.picture3.ImageLocation = "";
			this.picture3.Location = new System.Drawing.Point(41, 697);
			this.picture3.Name = "picture3";
			this.picture3.Size = new System.Drawing.Size(512, 512);
			this.picture3.TabIndex = 4;
			this.picture3.TabStop = false;
			// 
			// picture4
			// 
			this.picture4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.picture4.ImageLocation = "";
			this.picture4.Location = new System.Drawing.Point(599, 697);
			this.picture4.Name = "picture4";
			this.picture4.Size = new System.Drawing.Size(512, 512);
			this.picture4.TabIndex = 5;
			this.picture4.TabStop = false;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1147, 1242);
			this.Controls.Add(this.picture4);
			this.Controls.Add(this.picture3);
			this.Controls.Add(this.picture2);
			this.Controls.Add(this.txtPrompt);
			this.Controls.Add(this.picture1);
			this.Controls.Add(this.btnGenerate);
			this.Name = "MainForm";
			this.Text = "MainForm";
			((System.ComponentModel.ISupportInitialize)(this.picture1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.picture2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.picture3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.picture4)).EndInit();
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
	}
}