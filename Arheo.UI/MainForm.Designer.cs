namespace Arheo.UI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose();
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
            this.MainTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.fileListControl1 = new Arheo.UI.FileListControl();
            this.searchFilterControl1 = new Arheo.UI.SearchFilterControl();
            this.MainTableLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainTableLayout
            // 
            this.MainTableLayout.ColumnCount = 1;
            this.MainTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTableLayout.Controls.Add(this.fileListControl1, 0, 1);
            this.MainTableLayout.Controls.Add(this.searchFilterControl1, 0, 0);
            this.MainTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTableLayout.Location = new System.Drawing.Point(0, 0);
            this.MainTableLayout.Name = "MainTableLayout";
            this.MainTableLayout.RowCount = 3;
            this.MainTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.MainTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.MainTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.MainTableLayout.Size = new System.Drawing.Size(1995, 1292);
            this.MainTableLayout.TabIndex = 0;
            this.MainTableLayout.Paint += new System.Windows.Forms.PaintEventHandler(this.MainTableLayout_Paint);
            // 
            // fileListControl1
            // 
            this.fileListControl1.Location = new System.Drawing.Point(3, 196);
            this.fileListControl1.Name = "fileListControl1";
            this.fileListControl1.Size = new System.Drawing.Size(1989, 963);
            this.fileListControl1.TabIndex = 1;
            this.fileListControl1.Load += new System.EventHandler(this.fileListControl1_Load);
            // 
            // searchFilterControl1
            // 
            this.searchFilterControl1.Location = new System.Drawing.Point(3, 3);
            this.searchFilterControl1.Name = "searchFilterControl1";
            this.searchFilterControl1.Size = new System.Drawing.Size(1989, 110);
            this.searchFilterControl1.TabIndex = 2;
            this.searchFilterControl1.Load += new System.EventHandler(this.searchFilterControl1_Load_1);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1995, 1292);
            this.Controls.Add(this.MainTableLayout);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MainTableLayout.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel MainTableLayout;
        private FileListControl fileListControl1;
        private SearchFilterControl searchFilterControl1;
    }
}