
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
    public partial class Staff : Form
    {
        public Staff()
        {
            InitializeComponent();
        }

        private bool CheckNull()
        {
            if (textBox1.Text == "" || textBox6.Text == "" || textBox5.Text == "" || textBox4.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("All Input is not Null, please try again", "Notification", MessageBoxButtons.OK);
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool CheckNull1()
        {
            if (textBox7.Text == "" || textBox12.Text == "" || textBox11.Text == "" || textBox10.Text == "" || textBox10.Text == "")
            {
                MessageBox.Show("All Input is not Null, please try again", "Notification", MessageBoxButtons.OK);
                return false;
            }
            else
            {
                return true;
            }
        }
        public void LoadData()
        {


            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            dataGridView3.Rows.Clear();
            List<NhanVien> list = new List<NhanVien>();
            using (InventoryManagementContext context = new InventoryManagementContext())
            {
                list = context.NhanViens.ToList();

            }
            foreach (NhanVien item in list)
            {
                dataGridView1.Rows.Add(item.Msvn, item.TaiKhoan, item.MatKhau, item.TenNv, item.Tuoi, item.Sdt);
                dataGridView2.Rows.Add(item.Msvn, item.TaiKhoan, item.MatKhau, item.TenNv, item.Tuoi, item.Sdt);
                dataGridView3.Rows.Add(item.Msvn, item.TaiKhoan, item.MatKhau, item.TenNv, item.Tuoi, item.Sdt);
            }


        }
        private void Staff_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            if (!CheckNull())
            {
                return;
            }
            add_btn.Enabled = false;
            NhanVien dt = new NhanVien();
            var id = textBox2.Text;
            dt.TaiKhoan = textBox1.Text;
            dt.MatKhau = textBox6.Text;
            dt.TenNv = textBox5.Text;
            dt.Tuoi = textBox4.Text;
            dt.Sdt = textBox3.Text;
            dt.RoleId = 1;
            var db = new InventoryManagementContext();
            var checkid = db.NhanViens.Where(x => x.Msvn.Equals(id)).FirstOrDefault();
            db.NhanViens.Add(dt);
            db.SaveChanges();
            MessageBox.Show("Them thanh cong NV");
            add_btn.Enabled = true;
            LoadData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void Update_btn_Click(object sender, EventArgs e)
        {
            if (!CheckNull1())
            {
                return;
            }
            Update_btn.Enabled = false;
            int id = int.Parse(textBox8.Text);
            var db = new InventoryManagementContext();
            var obj = db.NhanViens.Where(x => x.Msvn == id).FirstOrDefault();
            obj.Msvn = int.Parse(textBox8.Text);
            obj.TaiKhoan = textBox7.Text;
            obj.MatKhau = textBox12.Text;
            obj.TenNv = textBox11.Text;
            obj.Tuoi = textBox10.Text;
            obj.Sdt = textBox9.Text;
            db.NhanViens.Update(obj);
            db.SaveChanges();
            MessageBox.Show("Update thanh NV :" + id);
            LoadData();
        }

        private void Xem_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox8.Text = dataGridView2.Rows[e.RowIndex].Cells["dataGridViewTextBoxColumn1"].Value.ToString();
            textBox7.Text = dataGridView2.Rows[e.RowIndex].Cells["dataGridViewTextBoxColumn2"].Value.ToString();
            textBox12.Text = dataGridView2.Rows[e.RowIndex].Cells["dataGridViewTextBoxColumn3"].Value.ToString();
            textBox11.Text = dataGridView2.Rows[e.RowIndex].Cells["dataGridViewTextBoxColumn4"].Value.ToString();
            textBox10.Text = dataGridView2.Rows[e.RowIndex].Cells["dataGridViewTextBoxColumn5"].Value.ToString();
            textBox9.Text = dataGridView2.Rows[e.RowIndex].Cells["dataGridViewTextBoxColumn6"].Value.ToString();
        }

        private void Delete_btn_Click(object sender, EventArgs e)
        {
            Delete_btn.Enabled = false;
            int id = int.Parse(textBox14.Text);
            var db = new InventoryManagementContext();
            var obj = db.NhanViens.Where(x => x.Msvn == id).FirstOrDefault();
            var checkrole = db.NhanViens.Where(x => x.RoleId == 0).FirstOrDefault();
            if (obj != null)
            {
                DialogResult dialogResult = MessageBox.Show("Ban co chac muon xoa don", "Xoa don", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    db.NhanViens.Remove(obj);
                    MessageBox.Show("Xoa NV thanh cong :" + id);
                    db.SaveChanges();
                    LoadData();
                }
                else if (dialogResult == DialogResult.No)
                {
                    // ko lam gi
                }
            }
            Delete_btn.Enabled = true;
        }

        private void watch_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox14.Text = dataGridView3.Rows[e.RowIndex].Cells["dataGridViewTextBoxColumn7"].Value.ToString();
            textBox13.Text = dataGridView3.Rows[e.RowIndex].Cells["dataGridViewTextBoxColumn8"].Value.ToString();
            textBox18.Text = dataGridView3.Rows[e.RowIndex].Cells["dataGridViewTextBoxColumn9"].Value.ToString();
            textBox17.Text = dataGridView3.Rows[e.RowIndex].Cells["dataGridViewTextBoxColumn10"].Value.ToString();
            textBox16.Text = dataGridView3.Rows[e.RowIndex].Cells["dataGridViewTextBoxColumn11"].Value.ToString();
            textBox15.Text = dataGridView3.Rows[e.RowIndex].Cells["dataGridViewTextBoxColumn12"].Value.ToString();
        }

        private void add_Click(object sender, EventArgs e)
        {
            Slide_panel.Height = add.Height;
            Slide_panel.Top = add.Top;
            panel3.BringToFront();
        }

        private void Update_Click(object sender, EventArgs e)
        {
            Slide_panel.Height = Update.Height;
            Slide_panel.Top = Update.Top;
            panel5.BringToFront();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Slide_panel.Height = button1.Height;
            Slide_panel.Top = button1.Top;
            panel6.BringToFront();
        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {
            string text = textBox19.Text;
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            dataGridView3.Rows.Clear();
            using (var context = new InventoryManagementContext())
            {
                List<NhanVien> list = context.NhanViens.Where(x => x.TenNv.ToLower().Contains(text.ToLower())).ToList();
                foreach (NhanVien item in list)
                {
                    dataGridView1.Rows.Add(item.Msvn, item.TaiKhoan, item.MatKhau, item.TenNv, item.Tuoi, item.Sdt);
                    dataGridView2.Rows.Add(item.Msvn, item.TaiKhoan, item.MatKhau, item.TenNv, item.Tuoi, item.Sdt);
                    dataGridView3.Rows.Add(item.Msvn, item.TaiKhoan, item.MatKhau, item.TenNv, item.Tuoi, item.Sdt);
                }
            }
        }
    }
}
