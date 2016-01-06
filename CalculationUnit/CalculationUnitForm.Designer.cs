namespace CalculationUnit
{
	partial class CalculationUnitForm
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
			this.btnRememberMe = new System.Windows.Forms.Button();
			this.txtLog = new System.Windows.Forms.TextBox();
			this.btnRunYourself = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnRememberMe
			// 
			this.btnRememberMe.Location = new System.Drawing.Point(13, 13);
			this.btnRememberMe.Name = "btnRememberMe";
			this.btnRememberMe.Size = new System.Drawing.Size(200, 23);
			this.btnRememberMe.TabIndex = 0;
			this.btnRememberMe.Text = "Подключиться";
			this.btnRememberMe.UseVisualStyleBackColor = true;
			this.btnRememberMe.Click += new System.EventHandler(this.btnRememberMe_Click);
			// 
			// txtLog
			// 
			this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtLog.Location = new System.Drawing.Point(13, 62);
			this.txtLog.Multiline = true;
			this.txtLog.Name = "txtLog";
			this.txtLog.ReadOnly = true;
			this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtLog.Size = new System.Drawing.Size(319, 214);
			this.txtLog.TabIndex = 1;
			// 
			// btnRunYourself
			// 
			this.btnRunYourself.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnRunYourself.Location = new System.Drawing.Point(13, 282);
			this.btnRunYourself.Name = "btnRunYourself";
			this.btnRunYourself.Size = new System.Drawing.Size(153, 23);
			this.btnRunYourself.TabIndex = 2;
			this.btnRunYourself.Text = "Запустить себя еще раз";
			this.btnRunYourself.UseVisualStyleBackColor = true;
			this.btnRunYourself.Click += new System.EventHandler(this.btnRunYourself_Click);
			// 
			// CalculationUnitForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(344, 316);
			this.Controls.Add(this.btnRunYourself);
			this.Controls.Add(this.txtLog);
			this.Controls.Add(this.btnRememberMe);
			this.Name = "CalculationUnitForm";
			this.Text = "Я один из считающих";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnRememberMe;
		private System.Windows.Forms.TextBox txtLog;
		private System.Windows.Forms.Button btnRunYourself;
	}
}

