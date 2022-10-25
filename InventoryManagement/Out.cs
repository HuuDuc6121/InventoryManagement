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
    public partial class Out : Form
    {
        public Out()
        {
            InitializeComponent();
        }

        private bool CheckNull1()
        {
            if (textBox6.Text == "" || textBox5.Text == "" || textBox4.Text == "" || textBox3.Text == "")
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
            List<PhieuXuatHang> list = new List<PhieuXuatHang>();
            using (InventoryManagementContext context = new InventoryManagementContext())
            {
                list = context.PhieuXuatHangs.ToList();

            }
            foreach (PhieuXuatHang item in list)
            {
                dataGridView1.Rows.Add(item.MsPhieuXuat, item.NgayLapPhieuXuat, item.MsKho, item.Msnv, item.MsMatHang, item.SlXuat);
                dataGridView2.Rows.Add(item.MsPhieuXuat, item.NgayLapPhieuXuat, item.MsKho, item.Msnv, item.MsMatHang, item.SlXuat);
                dataGridView3.Rows.Add(item.MsPhieuXuat, item.NgayLapPhieuXuat, item.MsKho, item.Msnv, item.MsMatHang, item.SlXuat);
            }
        }
        private void add_btn_Click(object sender, EventArgs e)
        {
            add_btn.Enabled = false;
            PhieuXuatHang dt = new PhieuXuatHang();
            var id = textBox1.Text;
            dt.NgayLapPhieuXuat = dateTimePicker1.Value;
            dt.MsKho = int.Parse(ms_kho.Text);
            dt.Msnv = int.Parse(msnv.Text);
            dt.MsMatHang = int.Parse(ms_mat_hang.Text);
            dt.SlXuat = int.Parse(sl_nhap.Text);
            var db = new InventoryManagementContext();
            db.PhieuXuatHangs.Add(dt);
            db.SaveChanges();
            MessageBox.Show("Them thanh cong don");
            add_btn.Enabled = true;
            LoadData();
        }

        private void xem_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Text = dataGridView2.Rows[e.RowIndex].Cells["dataGridViewTextBoxColumn1"].Value.ToString();
            dateTimePicker2.Text = dataGridView2.Rows[e.RowIndex].Cells["dataGridViewTextBoxColumn2"].Value.ToString();
            textBox6.Text = dataGridView2.Rows[e.RowIndex].Cells["dataGridViewTextBoxColumn3"].Value.ToString();
            textBox5.Text = dataGridView2.Rows[e.RowIndex].Cells["dataGridViewTextBoxColumn4"].Value.ToString();
            textBox4.Text = dataGridView2.Rows[e.RowIndex].Cells["dataGridViewTextBoxColumn5"].Value.ToString();
            textBox3.Text = dataGridView2.Rows[e.RowIndex].Cells["dataGridViewTextBoxColumn6"].Value.ToString();
        }

        private void update_btn_Click(object sender, EventArgs e)
        {
            if (!CheckNull1())
            {
                return;
            }
            update_btn.Enabled = false;
            int id = int.Parse(textBox2.Text);
            var db = new InventoryManagementContext();
            var obj = db.PhieuXuatHangs.Where(x => x.MsPhieuXuat == id).FirstOrDefault();
            obj.NgayLapPhieuXuat = dateTimePicker2.Value;
            obj.MsKho = int.Parse(textBox6.Text);
            obj.Msnv = int.Parse(textBox5.Text);
            obj.MsMatHang = int.Parse(textBox4.Text);
            obj.SlXuat = int.Parse(textBox3.Text);
            db.PhieuXuatHangs.Update(obj);
            db.SaveChanges();
            MessageBox.Show("Update thanh cong don :" + id);
            update_btn.Enabled = true;
            LoadData();
        }

        private void watch_1_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void add_Click(object sender, EventArgs e)
        {
            Slide_panel.Height = add.Height;
            Slide_panel.Top = add.Top;
            panel1.BringToFront();
        }

        private void update_Click(object sender, EventArgs e)
        {
            Slide_panel.Height = update.Height;
            Slide_panel.Top = update.Top;
            panel3.BringToFront();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            Slide_panel.Height = delete.Height;
            Slide_panel.Top = delete.Top;
            panel5.BringToFront();
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox7.Text = dataGridView3.Rows[e.RowIndex].Cells["dataGridViewTextBoxColumn7"].Value.ToString();
            dateTimePicker3.Text = dataGridView3.Rows[e.RowIndex].Cells["dataGridViewTextBoxColumn8"].Value.ToString();
            textBox11.Text = dataGridView3.Rows[e.RowIndex].Cells["dataGridViewTextBoxColumn9"].Value.ToString();
            textBox10.Text = dataGridView3.Rows[e.RowIndex].Cells["dataGridViewTextBoxColumn10"].Value.ToString();
            textBox9.Text = dataGridView3.Rows[e.RowIndex].Cells["dataGridViewTextBoxColumn11"].Value.ToString();
            textBox8.Text = dataGridView3.Rows[e.RowIndex].Cells["dataGridViewTextBoxColumn12"].Value.ToString();
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
                delete_btn.Enabled = false;
                int id = int.Parse(textBox7.Text);
                var db = new InventoryManagementContext();
                var obj = db.PhieuXuatHangs.Where(x => x.MsPhieuXuat == id).FirstOrDefault();
                if (obj != null)
                {
                    DialogResult dialogResult = MessageBox.Show("Ban co chac muon xoa don", "Xoa don", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        db.PhieuXuatHangs.Remove(obj);
                        MessageBox.Show("Xoa don thanh cong :" + id);
                        db.SaveChanges();
                        LoadData();
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        // ko lam gi
                    }
                }

                delete_btn.Enabled = true;
        }

        private void watch_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            string text = textBox12.Text;
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            dataGridView3.Rows.Clear();
            var db = new InventoryManagementContext();
            List<PhieuXuatHang> list = db.PhieuXuatHangs.Where(x => x.NgayLapPhieuXuat.ToString().Contains(text)).ToList();
            foreach (PhieuXuatHang item in list)
            {
                dataGridView1.Rows.Add(item.MsPhieuXuat, item.NgayLapPhieuXuat, item.MsKho, item.Msnv, item.MsMatHang, item.SlXuat);
                dataGridView2.Rows.Add(item.MsPhieuXuat, item.NgayLapPhieuXuat, item.MsKho, item.Msnv, item.MsMatHang, item.SlXuat);
                dataGridView3.Rows.Add(item.MsPhieuXuat, item.NgayLapPhieuXuat, item.MsKho, item.Msnv, item.MsMatHang, item.SlXuat);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }
    }
}
