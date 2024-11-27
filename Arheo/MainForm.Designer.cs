using System;
using System.Drawing;
using System.Windows.Forms;

namespace Arheo
{
    partial class MainForm
    {
        private System.Windows.Forms.DataGridView _dataGridViewFiles;
        private System.Windows.Forms.TextBox _textBoxSearch;
        private System.Windows.Forms.PictureBox _pictureBoxSearchIcon;
        private System.Windows.Forms.Label _labelAppName;

        private System.ComponentModel.IContainer components = null;

        protected override void Dispose( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        private void InitializeComponent()
        {
            this._dataGridViewFiles = new System.Windows.Forms.DataGridView();
            this._textBoxSearch = new System.Windows.Forms.TextBox();
            this._pictureBoxSearchIcon = new System.Windows.Forms.PictureBox();
            this._labelAppName = new System.Windows.Forms.Label();
            ( ( System.ComponentModel.ISupportInitialize )( this._dataGridViewFiles ) ).BeginInit();
            ( ( System.ComponentModel.ISupportInitialize )( this._pictureBoxSearchIcon ) ).BeginInit();
            this.SuspendLayout();

            // 
            // _dataGridViewFiles
            // 
            this._dataGridViewFiles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this._dataGridViewFiles.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this._dataGridViewFiles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dataGridViewFiles.Name = "_dataGridViewFiles";
            this._dataGridViewFiles.TabIndex = 0;

            // 
            // _textBoxSearch
            // 
            this._textBoxSearch.Name = "_textBoxSearch";
            this._textBoxSearch.TabIndex = 1;
            this._textBoxSearch.Text = "Поиск";
            this._textBoxSearch.Enter += new EventHandler( this._textBoxSearch_Enter );
            this._textBoxSearch.Leave += new EventHandler( this._textBoxSearch_Leave );

            // 
            // _pictureBoxSearchIcon
            // 
            this._pictureBoxSearchIcon.Image = Properties.Resources.search_icon;
            this._pictureBoxSearchIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            this._pictureBoxSearchIcon.Name = "_pictureBoxSearchIcon";
            this._pictureBoxSearchIcon.TabIndex = 2;

            // 
            // _labelAppName
            // 
            this._labelAppName.Font = new System.Drawing.Font( "Arial Rounded MT Bold", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0 );
            this._labelAppName.Name = "_labelAppName";
            this._labelAppName.Text = "ARHEO";
            this._labelAppName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 12F, 25F );
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size( 1380, 800 );
            this.Controls.Add( this._dataGridViewFiles );
            this.Controls.Add( this._labelAppName );
            this.Controls.Add( this._pictureBoxSearchIcon );
            this.Controls.Add( this._textBoxSearch );
            this.Name = "MainForm";
            this.Text = "Arheo";
            this.WindowState = FormWindowState.Maximized;

            // Events
            this.Load += new EventHandler( this.MainForm_Load );
            this.Resize += new EventHandler( this.MainForm_Resize );

            ( ( System.ComponentModel.ISupportInitialize )( this._dataGridViewFiles ) ).EndInit();
            ( ( System.ComponentModel.ISupportInitialize )( this._pictureBoxSearchIcon ) ).EndInit();
            this.ResumeLayout( false );
            this.PerformLayout();
        }

        /// <summary>
        /// Initial setup after form load.
        /// </summary>
        private void MainForm_Load( object sender, EventArgs e )
        {
            UpdateLayout();
        }

        private void MainForm_Resize( object sender, EventArgs e )
        {
            UpdateLayout();
        }

        private void UpdateLayout()
        {
            int formWidth = this.ClientSize.Width;
            int formHeight = this.ClientSize.Height;

            // Margin percentages
            float horizontalMarginPercent = 0.02f; // 2% margin
            float verticalMarginPercent = 0.02f;   // 2% margin
            int marginX = ( int )( formWidth * horizontalMarginPercent );
            int marginY = ( int )( formHeight * verticalMarginPercent );

            // Label (App Name) - Top 10% of height
            _labelAppName.Location = new Point( marginX, marginY );
            _labelAppName.Size = new Size( formWidth - 2 * marginX, ( int )( formHeight * 0.05f ) );

            // Search Bar - Below the label
            int searchHeight = ( int )( formHeight * 0.02f );
            _textBoxSearch.Location = new Point( marginX + searchHeight + marginX, _labelAppName.Bottom + marginY ); // Offset by icon width
            _textBoxSearch.Size = new Size( formWidth - 3 * marginX - searchHeight, searchHeight );

            // Adjust icon size and position to match the search bar
            int iconSize = _textBoxSearch.Height; // Match the height of the TextBox
            _pictureBoxSearchIcon.Size = new Size( iconSize, iconSize );
            _pictureBoxSearchIcon.Location = new Point( marginX, _textBoxSearch.Top ); // Align with TextBox

            // DataGridView - Remaining height
            _dataGridViewFiles.Location = new Point( marginX, _textBoxSearch.Bottom + marginY );
            _dataGridViewFiles.Size = new Size( formWidth - 2 * marginX, formHeight - _dataGridViewFiles.Top - marginY );
        }

        private void _textBoxSearch_Enter( object sender, EventArgs e )
        {
        // Check if the current text is the default placeholder text
        if ( _textBoxSearch.Text == "Поиск" )
        {
            _textBoxSearch.Text = ""; // Clear the text
        }
        }

        /// <summary>
        /// Restores the default search text when the TextBox loses focus and is empty.
        /// </summary>
        /// <param name="sender">The TextBoxSearch object.</param>
        /// <param name="e">Event arguments.</param>
        private void _textBoxSearch_Leave( object sender, EventArgs e )
        {
            // If the TextBox is empty, reset the placeholder text
            if ( string.IsNullOrWhiteSpace( _textBoxSearch.Text ) )
            {
                _textBoxSearch.Text = "Поиск";
            }
        }
    }
}