
namespace VNIIA.Client
{
	partial class Main
	{
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this.MainSplitContainer = new System.Windows.Forms.SplitContainer();
			this.dgw_Documents = new System.Windows.Forms.DataGridView();
			this.dgw_DocumentPositions = new System.Windows.Forms.DataGridView();
			((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer)).BeginInit();
			this.MainSplitContainer.Panel1.SuspendLayout();
			this.MainSplitContainer.Panel2.SuspendLayout();
			this.MainSplitContainer.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgw_Documents)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgw_DocumentPositions)).BeginInit();
			this.SuspendLayout();
			// 
			// MainSplitContainer
			// 
			this.MainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.MainSplitContainer.Location = new System.Drawing.Point(0, 0);
			this.MainSplitContainer.Name = "MainSplitContainer";
			this.MainSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// MainSplitContainer.Panel1
			// 
			this.MainSplitContainer.Panel1.Controls.Add(this.dgw_Documents);
			// 
			// MainSplitContainer.Panel2
			// 
			this.MainSplitContainer.Panel2.Controls.Add(this.dgw_DocumentPositions);
			this.MainSplitContainer.Size = new System.Drawing.Size(800, 450);
			this.MainSplitContainer.SplitterDistance = 221;
			this.MainSplitContainer.TabIndex = 0;
			// 
			// dgw_Documents
			// 
			this.dgw_Documents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgw_Documents.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgw_Documents.Location = new System.Drawing.Point(0, 0);
			this.dgw_Documents.Name = "dgw_Documents";
			this.dgw_Documents.Size = new System.Drawing.Size(800, 221);
			this.dgw_Documents.TabIndex = 0;
			// 
			// dgw_DocumentPositions
			// 
			this.dgw_DocumentPositions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgw_DocumentPositions.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgw_DocumentPositions.Location = new System.Drawing.Point(0, 0);
			this.dgw_DocumentPositions.Name = "dgw_DocumentPositions";
			this.dgw_DocumentPositions.Size = new System.Drawing.Size(800, 225);
			this.dgw_DocumentPositions.TabIndex = 0;
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.MainSplitContainer);
			this.Name = "Main";
			this.Text = "VNIIA WinClient";
			this.MainSplitContainer.Panel1.ResumeLayout(false);
			this.MainSplitContainer.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer)).EndInit();
			this.MainSplitContainer.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgw_Documents)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgw_DocumentPositions)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer MainSplitContainer;
		private System.Windows.Forms.DataGridView dgw_Documents;
		private System.Windows.Forms.DataGridView dgw_DocumentPositions;
	}
}

