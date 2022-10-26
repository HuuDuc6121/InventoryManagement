

using InventoryManagement.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace InventoryManagement
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }
        private bool CheckNull()
        {
            if (comboBox1.Text == "" || comboBox2.Text == "" || comboBox3.Text == "" || sl_nhap.Text == "")
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
            if (comboBox6.Text == "" || comboBox5.Text == "" || comboBox4.Text == "" || textBox3.Text == "")
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
            List<PhieuNhapHang> list = new List<PhieuNhapHang>();
            using (InventoryManagementContext context = new InventoryManagementContext())
            {
                list = context.PhieuNhapHangs.ToList();

            }
            foreach (PhieuNhapHang item in list)
            {
                dataGridView1.Rows.Add(item.MsPhieuNhap, item.NgayLapPhieuNhap, item.MsKho, item.Msnv, item.MsMatHang, item.SlNhap);
                dataGridView2.Rows.Add(item.MsPhieuNhap, item.NgayLapPhieuNhap, item.MsKho, item.Msnv, item.MsMatHang, item.SlNhap);
                dataGridView3.Rows.Add(item.MsPhieuNhap, item.NgayLapPhieuNhap, item.MsKho, item.Msnv, item.MsMatHang, item.SlNhap);
            }
        }
        public void Resetform()
        {
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void ngay_lap_phieu_nhap_TextChanged(object sender, EventArgs e)
        {

        }

        private void Home_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void loaddata_btn_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            Slide_panel.Height = Add.Height;
            Slide_panel.Top = Add.Top;
            panel1.BringToFront();
        }



        private void Update_Click(object sender, EventArgs e)
        {
            Slide_panel.Height = Update.Height;
            Slide_panel.Top = Update.Top;
            panel3.BringToFront();

        }
        private void Delete_Click(object sender, EventArgs e)
        {
            Slide_panel.Height = Delete.Height;
            Slide_panel.Top = Delete.Top;
            panel5.BringToFront();
        }



        private void xem_Click(object sender, EventArgs e)
        {
            LoadData();
        }



        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void watch_Click(object sender, EventArgs e)
        {
            LoadData();
        }


        private void add_btn_Click_1(object sender, EventArgs e)
        {
            if (!CheckNull())
            {
                return;
            }
            add_btn.Enabled = false;
            PhieuNhapHang dt = new PhieuNhapHang();
            var id = textBox1.Text;
            dt.NgayLapPhieuNhap = dateTimePicker1.Value;
            dt.MsKho = int.Parse(comboBox1.SelectedValue.ToString());
            dt.Msnv = int.Parse(comboBox2.SelectedValue.ToString());
            dt.MsMatHang = int.Parse(comboBox3.SelectedValue.ToString());
            dt.SlNhap = int.Parse(sl_nhap.Text);
            var db = new InventoryManagementContext();
            var checkid = db.PhieuNhapHangs.Where(x => x.MsPhieuNhap.Equals(id)).FirstOrDefault();
            db.PhieuNhapHangs.Add(dt);
            db.SaveChanges();
            MessageBox.Show("Them thanh cong don");
            add_btn.Enabled = true;
            LoadData();
        }

        private void xem_Click_1(object sender, EventArgs e)
        {
            LoadData();
        }

        private void update_btn_Click_1(object sender, EventArgs e)
        {
            if (!CheckNull1())
            {
                return;
            }
            update_btn.Enabled = false;
            int id = int.Parse(textBox2.Text);
            var db = new InventoryManagementContext();
            var obj = db.PhieuNhapHangs.Where(x => x.MsPhieuNhap == id).FirstOrDefault();
            obj.NgayLapPhieuNhap = dateTimePicker2.Value;
            obj.MsKho = int.Parse(comboBox6.SelectedValue.ToString());
            obj.Msnv = int.Parse(comboBox5.SelectedValue.ToString());
            obj.MsMatHang = int.Parse(comboBox4.SelectedValue.ToString());
            obj.SlNhap = int.Parse(textBox3.Text);
            db.PhieuNhapHangs.Update(obj);
            db.SaveChanges();
            MessageBox.Show("Update thanh cong don :" + id);
            update_btn.Enabled = true;
            LoadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dataGridView2_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Text = dataGridView2.Rows[e.RowIndex].Cells["dataGridViewTextBoxColumn1"].Value.ToString();
            dateTimePicker2.Text = dataGridView2.Rows[e.RowIndex].Cells["dataGridViewTextBoxColumn2"].Value.ToString();
            var db = new InventoryManagementContext();
            var list1 = db.Khos.Select(p => new { Text = p.MsKho, Value = p.TenKho }).ToList();
            comboBox6.ValueMember = "Text";
            comboBox6.DisplayMember = "Value";
            comboBox6.DataSource = (list1.ToArray());
            var list2 = db.NhanViens.Select(p => new { Text = p.Msvn, Value = p.TenNv }).ToList();
            comboBox5.ValueMember = "Text";
            comboBox5.DisplayMember = "Value";
            comboBox5.DataSource = (list1.ToArray());
            var list3 = db.MatHangs.Select(p => new { Text = p.MsMatHang, Value = p.TenHang }).ToList();
            comboBox4.ValueMember = "Text";
            comboBox4.DisplayMember = "Value";
            comboBox4.DataSource = (list1.ToArray());
            textBox3.Text = dataGridView2.Rows[e.RowIndex].Cells["dataGridViewTextBoxColumn6"].Value.ToString();
        }

        private void delete_btn_Click_1(object sender, EventArgs e)
        {
            delete_btn.Enabled = false;
            int id = int.Parse(textBox7.Text);
            var db = new InventoryManagementContext();
            var obj = db.PhieuNhapHangs.Where(x => x.MsPhieuNhap == id).FirstOrDefault();
            if (obj != null)
            {
                DialogResult dialogResult = MessageBox.Show("Ban co chac muon xoa don", "Xoa don", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    db.PhieuNhapHangs.Remove(obj);
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

        private void xem_5_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dataGridView3_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            textBox7.Text = dataGridView3.Rows[e.RowIndex].Cells["dataGridViewTextBoxColumn7"].Value.ToString();
            dateTimePicker3.Text = dataGridView3.Rows[e.RowIndex].Cells["dataGridViewTextBoxColumn8"].Value.ToString();
            var db = new InventoryManagementContext();
            var list1 = db.Khos.Select(p => new { Text = p.MsKho, Value = p.TenKho }).ToList();
            comboBox9.ValueMember = "Text";
            comboBox9.DisplayMember = "Value";
            comboBox9.DataSource = (list1.ToArray());
            var list2 = db.NhanViens.Select(p => new { Text = p.Msvn, Value = p.TenNv }).ToList();
            comboBox8.ValueMember = "Text";
            comboBox8.DisplayMember = "Value";
            comboBox8.DataSource = (list1.ToArray());
            var list3 = db.MatHangs.Select(p => new { Text = p.MsMatHang, Value = p.TenHang }).ToList();
            comboBox7.ValueMember = "Text";
            comboBox7.DisplayMember = "Value";
            comboBox7.DataSource = (list1.ToArray());
            textBox8.Text = dataGridView3.Rows[e.RowIndex].Cells["dataGridViewTextBoxColumn12"].Value.ToString();
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            string text = textBox12.Text;
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            dataGridView3.Rows.Clear();
            var db = new InventoryManagementContext();
            List<PhieuNhapHang> list = db.PhieuNhapHangs.Where(x => x.NgayLapPhieuNhap.ToString().Contains(text)).ToList();
            foreach (PhieuNhapHang item in list)
            {
                dataGridView1.Rows.Add(item.MsPhieuNhap, item.NgayLapPhieuNhap, item.MsKho, item.Msnv, item.MsMatHang, item.SlNhap);
                dataGridView2.Rows.Add(item.MsPhieuNhap, item.NgayLapPhieuNhap, item.MsKho, item.Msnv, item.MsMatHang, item.SlNhap);
                dataGridView3.Rows.Add(item.MsPhieuNhap, item.NgayLapPhieuNhap, item.MsKho, item.Msnv, item.MsMatHang, item.SlNhap);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Out @out = new Out();
            @out.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Item item = new Item();
            item.Show();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["Column1"].Value.ToString();
            dateTimePicker1.Text = dataGridView1.Rows[e.RowIndex].Cells["Column2"].Value.ToString();
            var db = new InventoryManagementContext();
            var list1 = db.Khos.Select(p => new { Text = p.MsKho, Value = p.TenKho }).ToList();
            comboBox1.ValueMember = "Text";
            comboBox1.DisplayMember = "Value";
            comboBox1.DataSource = (list1.ToArray());
            var list2 = db.NhanViens.Select(p => new { Text = p.Msvn, Value = p.TenNv }).ToList();
            comboBox2.ValueMember = "Text";
            comboBox2.DisplayMember = "Value";
            comboBox2.DataSource = (list1.ToArray());
            var list3 = db.MatHangs.Select(p => new { Text = p.MsMatHang, Value = p.TenHang }).ToList();
            comboBox3.ValueMember = "Text";
            comboBox3.DisplayMember = "Value";
            comboBox3.DataSource = (list1.ToArray());
            sl_nhap.Text = dataGridView1.Rows[e.RowIndex].Cells["Column6"].Value.ToString();
        }
    }
}






