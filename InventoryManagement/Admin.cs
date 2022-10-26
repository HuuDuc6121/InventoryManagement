using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagement
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void Kho_Click(object sender, EventArgs e)
        {
            ManageInventory manageInventory = new ManageInventory();
            manageInventory.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Staff staff = new Staff();
            staff.Show();
        }

        private void Don_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
        }

        private void mathang_Click(object sender, EventArgs e)
        {
            Item item = new Item();
            item.Show();
        }
    }
}
