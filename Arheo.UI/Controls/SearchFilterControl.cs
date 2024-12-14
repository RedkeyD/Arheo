using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arheo.UI
{
    public partial class SearchFilterControl : UserControl
    {
        public SearchFilterControl()
        {
            InitializeComponent();
        }

        private void txtSearch_TextChanged( object sender, EventArgs e )
        {

        }

        private void cmbFilter_SelectedIndexChanged( object sender, EventArgs e )
        {

        }

        private void btnSearch_Click( object sender, EventArgs e )
        {
            MessageBox.Show( $"Searching for {txtSearch.Text} with filter {cmbFilter.SelectedItem}" );
        }

        private void flowLayoutPanel1_Paint( object sender, PaintEventArgs e )
        {

        }
    }
}
