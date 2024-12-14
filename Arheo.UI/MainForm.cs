using System;
using System.IO;
using System.Windows.Forms;

namespace Arheo.UI
{
    public partial class MainForm : Form
    {
        private Button btnAddFile;
        private Button btnPreviewFile;
        private Button btnEditMetadata;
        private Button btnDeleteFile;

        public MainForm()
        {
            InitializeComponent();
            ConfigureActionPanel();
            EnsureStorageFolder();

        }

        private void ConfigureActionPanel()
        {
            FlowLayoutPanel actionFlowPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.LeftToRight,
                Padding = new Padding( 10 )
            };

            btnAddFile = new Button
            {
                Text = "Add File",
                Width = 100,
                Margin = new Padding( 5 )
            };
            btnAddFile.Click += BtnAddFile_Click;

            btnPreviewFile = new Button
            {
                Text = "Preview File",
                Width = 100,
                Margin = new Padding( 5 )
            };
            btnPreviewFile.Click += BtnPreviewFile_Click;

            btnEditMetadata = new Button
            {
                Text = "Edit Metadata",
                Width = 120,
                Margin = new Padding( 5 )
            };
            btnEditMetadata.Click += BtnEditMetadata_Click;

            btnDeleteFile = new Button
            {
                Text = "Delete File",
                Width = 100,
                Margin = new Padding( 5 )
            };
            btnDeleteFile.Click += BtnDeleteFile_Click;

            actionFlowPanel.Controls.Add( btnAddFile );
            actionFlowPanel.Controls.Add( btnPreviewFile );
            actionFlowPanel.Controls.Add( btnEditMetadata );
            actionFlowPanel.Controls.Add( btnDeleteFile );

            MainTableLayout.Controls.Add( actionFlowPanel, 0, 2 );
        }

        // Event Handlers
        private void BtnAddFile_Click( object sender, EventArgs e )
        {
            using ( OpenFileDialog dialog = new OpenFileDialog() )
            {
                dialog.Filter = "PDF Files|*.pdf|Word Files|*.docx";
                dialog.Title = "Select a File";

                if ( dialog.ShowDialog() == DialogResult.OK )
                {
                    string sourceFilePath = dialog.FileName;
                    string destinationFolder = Path.Combine( Application.StartupPath, "UploadedFiles" );
                    string fileName = Path.GetFileName( sourceFilePath );
                    string destinationPath = Path.Combine( destinationFolder, fileName );

                    Directory.CreateDirectory( destinationFolder );

                    File.Copy( sourceFilePath, destinationPath, true );

                    var creationDate = File.GetCreationTime( sourceFilePath );
                    var fileType = fileName.EndsWith( ".pdf" ) ? "PDF" : "Word";

                    fileListControl1.AddFile( fileName, destinationPath, "Unknown Author", creationDate, fileType );
                }
            }
        }

        private void BtnPreviewFile_Click( object sender, EventArgs e )
        {
            MessageBox.Show( "File preview functionality to be implemented", "Preview File" );
            // Implement file preview logic
        }

        private void BtnEditMetadata_Click( object sender, EventArgs e )
        {
            MessageBox.Show( "Metadata editing functionality to be implemented", "Edit Metadata" );
            // Implement metadata editing logic
        }

        private void BtnDeleteFile_Click( object sender, EventArgs e )
        {
            fileListControl1.DeleteSelectedFile();
        }

        // Existing methods from designer
        private void MainForm_Load( object sender, EventArgs e )
        {
            // Any additional initialization can go here
        }

        private void MainTableLayout_Paint( object sender, PaintEventArgs e )
        {
            // Keep the existing paint method (can be left empty)
        }

        private void searchFilterControl1_Load( object sender, EventArgs e )
        {

        }

        private void EnsureStorageFolder()
        {
            string folderPath = Path.Combine( Application.StartupPath, "UploadedFiles" );
            if ( !Directory.Exists( folderPath ) )
            {
                Directory.CreateDirectory( folderPath );
            }
        }

        private void fileListControl1_Load( object sender, EventArgs e )
        {

        }

        private void searchFilterControl1_Load_1( object sender, EventArgs e )
        {

        }
    }
}