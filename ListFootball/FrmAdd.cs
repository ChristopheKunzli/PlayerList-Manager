using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListFootball
{
    public partial class FrmAdd : Form
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNum { get; set; }

        public FrmAdd(Player player)
        {
            InitializeComponent();

            txtFirstName.Text = player.FirstName;
            txtlastName.Text = player.LastName;
            txtPhoneNum.Text = player.PhoneNumber;
        }

        public FrmAdd()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {
            FirstName = txtFirstName.Text;
        }

        private void txtlastName_TextChanged(object sender, EventArgs e)
        {
            LastName = txtlastName.Text;
        }

        private void txtPhoneNum_TextChanged(object sender, EventArgs e)
        {
            PhoneNum = txtPhoneNum.Text;
        }
    }
}
