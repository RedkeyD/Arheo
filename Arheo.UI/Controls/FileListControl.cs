using System;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace Arheo.UI
{
    public partial class FileListControl : UserControl
    {
        private ListView listView;
        public FileListControl()
        {
            InitializeComponent();
            ConfigureListView();

        }

        private void ConfigureListView()
        {
            listView = new ListView
            {
                Dock = DockStyle.Fill,
                View = View.Details,
                FullRowSelect = true,
                GridLines = true
            };

            listView.SmallImageList = imageList1;


            listView.Columns.Clear();
            listView.Columns.Add( "Icon", 50, HorizontalAlignment.Center );
            listView.Columns.Add( "Name", 200, HorizontalAlignment.Left );
            listView.Columns.Add( "Author", 100, HorizontalAlignment.Left );
            listView.Columns.Add( "Date", 100, HorizontalAlignment.Left );
            listView.Columns.Add( "Type", 100, HorizontalAlignment.Left );


            ListViewItem pdfItem = new ListViewItem( new string[]
            {
                "", "SamplePDF.pdf", "John Doe", "12/04/2023", "PDF"
            }, 1 ); 

            ListViewItem docItem = new ListViewItem( new string[]
            {
                "", "SampleDoc.docx", "Jane Smith", "12/03/2023", "Word"
            }, 0 ); // Index 0 corresponds to "doc.png"

            listView.Items.Add( pdfItem );
            listView.Items.Add( docItem );

            // Optional: Add double-click event
            listView.DoubleClick += ListView_DoubleClick;

            // Replace the TableLayoutPanel with ListView
            this.Controls.Clear();
            this.Controls.Add( listView );
        }

        private void ListView_DoubleClick( object sender, EventArgs e )
        {
            ListView listView = sender as ListView;
            if ( listView?.SelectedItems.Count > 0 )
            {
                ListViewItem selectedItem = listView.SelectedItems[ 0 ];
                MessageBox.Show(
                    $"Selected File: {selectedItem.SubItems[ 1 ].Text}",
                    "File Selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }

        // Keep the empty Paint method from the original implementation
        private void listViewFiles_Paint( object sender, PaintEventArgs e )
        {
            // This method can be left empty or implemented as needed
        }

        // Method to add new file items
        public void AddFileItem( string name, string author, DateTime date, string type, int iconIndex = -1 )
        {
            if ( this.Controls.Count > 0 && this.Controls[ 0 ] is ListView listView )
            {
                ListViewItem item = new ListViewItem( new string[]
                {
                    "",
                    name,
                    author,
                    date.ToShortDateString(),
                    type
                } );

                if ( iconIndex >= 0 )
                {
                    item.ImageIndex = iconIndex;
                }

                listView.Items.Add( item );
            }
        }

        private void FileListControl_Load( object sender, EventArgs e )
        {

        }

        public void AddFile( string fileName, string filePath, string author, DateTime creationDate, string fileType )
        {
            var listViewItem = new ListViewItem( new[]
            {
                "", 
                fileName,
                author,
                creationDate.ToString("dd/MM/yyyy"),
                fileType
            }, 0 );

            listViewItem.ImageKey = fileType; 

            listView.Items.Add( listViewItem );
        }

        public void DeleteSelectedFile()
        {
            if ( listView.SelectedItems.Count == 0 )
            {
                MessageBox.Show( "Please select a file to delete.", "Delete File", MessageBoxButtons.OK, MessageBoxIcon.Warning );
                return;
            }

            var selectedItem = listView.SelectedItems[ 0 ];
            var confirmResult = MessageBox.Show( $"Are you sure you want to delete {selectedItem.SubItems[ 1 ].Text}?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question );

            if ( confirmResult == DialogResult.Yes )
            {
                string filePath = selectedItem.SubItems[ 2 ].Text; 
                listView.Items.Remove( selectedItem );

                if ( !string.IsNullOrEmpty( filePath ) && File.Exists( filePath ) )
                {
                    try
                    {
                        File.Delete( filePath );
                        MessageBox.Show( "File deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information );
                    }
                    catch ( Exception ex )
                    {
                        MessageBox.Show( $"Error deleting file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
                    }
                }
            }
        }




    }
}