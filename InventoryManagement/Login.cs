
using InventoryManagement.Models;
using MySql.Data.MySqlClient;
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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Signup signup = new Signup();
            signup.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            var _username = textBox1.Text;
            var _password = textBox2.Text;
            button1.Enabled = false;
            var db = new InventoryManagementContext();
            var _check = db.NhanViens.Where(x => x.TaiKhoan.Equals(_username) && x.MatKhau.Equals(_password) && x.RoleId == 0).FirstOrDefault();
            var _checknv = db.NhanViens.Where(x => x.TaiKhoan.Equals(_username) && x.MatKhau.Equals(_password) && x.RoleId == 1).FirstOrDefault();
            if (_check != null)
            {
                Admin admin = new Admin();
                admin.Show();
                this.Hide();
            }
            else if (_checknv != null)
            {
                Home home = new Home();
                home.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("You are not allow to access this function", "Login Failed", MessageBoxButtons.OK);
                button1.Enabled = true;
            }

        }
    }
}

