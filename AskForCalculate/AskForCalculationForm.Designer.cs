namespace AskForCalculate
{
	partial class AskForCalculationForm
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
			this.txtStart = new System.Windows.Forms.TextBox();
			this.txtEnd = new System.Windows.Forms.TextBox();
			this.btnCalculate = new System.Windows.Forms.Button();
			this.txtResult = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// txtStart
			// 
			this.txtStart.Location = new System.Drawing.Point(37, 34);
			this.txtStart.Name = "txtStart";
			this.txtStart.Size = new System.Drawing.Size(100, 20);
			this.txtStart.TabIndex = 0;
			this.txtStart.Text = "1";
			// 
			// txtEnd
			// 
			this.txtEnd.Location = new System.Drawing.Point(37, 97);
			this.txtEnd.Name = "txtEnd";
			this.txtEnd.Size = new System.Drawing.Size(100, 20);
			this.txtEnd.TabIndex = 1;
			this.txtEnd.Text = "5";
			// 
			// btnCalculate
			// 
			this.btnCalculate.Location = new System.Drawing.Point(37, 142);
			this.btnCalculate.Name = "btnCalculate";
			this.btnCalculate.Size = new System.Drawing.Size(100, 23);
			this.btnCalculate.TabIndex = 2;
			this.btnCalculate.Text = "Calculate";
			this.btnCalculate.UseVisualStyleBackColor = true;
			this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
			// 
			// txtResult
			// 
			this.txtResult.Location = new System.Drawing.Point(165, 34);
			this.txtResult.Multiline = true;
			this.txtResult.Name = "txtResult";
			this.txtResult.ReadOnly = true;
			this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtResult.Size = new System.Drawing.Size(185, 187);
			this.txtResult.TabIndex = 3;
			// 
			// AskForCalculationForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(362, 250);
			this.Controls.Add(this.txtResult);
			this.Controls.Add(this.btnCalculate);
			this.Controls.Add(this.txtEnd);
			this.Controls.Add(this.txtStart);
			this.Name = "AskForCalculationForm";
			this.Text = "I ask server for calculation";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtStart;
		private System.Windows.Forms.TextBox txtEnd;
		private System.Windows.Forms.Button btnCalculate;
		private System.Windows.Forms.TextBox txtResult;
	}
}

