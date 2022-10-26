
using InventoryManagement.Models;
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
    public partial class Signup : Form
    {
        public Signup()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var _username = textBox1.Text;
            var _password = textBox2.Text;
            var _repasssword = textBox3.Text;
            button1.Enabled = false;
            var db = new InventoryManagementContext();
            NhanVien dt = new NhanVien();
            dt.TaiKhoan = textBox1.Text;
            dt.MatKhau = textBox2.Text;
            dt.RoleId = 1;
            db.NhanViens.Add(dt);
            if (_repasssword != _password)
            {
                MessageBox.Show("You are wrong Retype Password, Please enter again", "Login Failed", MessageBoxButtons.OK);
                button1.Enabled = true;
                return;
            }
            db.SaveChanges();
            MessageBox.Show("You have successfully registered", "Register Success", MessageBoxButtons.OK);
            Login login = new Login();
            login.Show();
            this.Hide();

        }
    }
}
