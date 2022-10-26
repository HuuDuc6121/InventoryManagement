
using InventoryManagement.Models;
using Microsoft.VisualBasic.ApplicationServices;
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
    public partial class ManageInventory : Form
    {
        public ManageInventory()
        {
            InitializeComponent();
            //_Admin = admin;
            //_User = nhanvien;
            //if (admin.RoleId == 0 || nhanvien.RoleId == 1)
            //{

            //    var db = new InventoryManagementContext();
            //    var list1 = db.DiaDiems.Select(p => new { Text = p.MsDiaDiem, Value = p.DiaChi }).ToList();
            //    comboBox1.ValueMember = "Text";
            //    comboBox1.DisplayMember = "Value";
            //    comboBox1.DataSource = (list1.ToArray());
            //    var list2 = db.LoaiHangs.Select(p => new { Text = p.MsLoaiHang, Value = p.TenLoaiHang }).ToList();
            //    comboBox2.ValueMember = "Text";
            //    comboBox2.DisplayMember = "Value";
            //    comboBox2.DataSource = (list2.ToArray());
            //    button3.Enabled = false;
            //    button5.Enabled = false;

            //}

        }

        public void LoadData()
        {
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            dataGridView3.Rows.Clear();
            List<Kho> list = new List<Kho>();
            using (InventoryManagementContext context = new InventoryManagementContext())
            {
                list = context.Khos.ToList();
            }
            foreach (Kho item in list)
            {
                dataGridView1.Rows.Add(item.MsKho, item.TenKho, item.SdtKho, item.MsDiaDiem, item.Msnv, item.MsLoaiHang);
                dataGridView2.Rows.Add(item.MsKho, item.TenKho, item.SdtKho, item.MsDiaDiem, item.Msnv, item.MsLoaiHang);
                dataGridView3.Rows.Add(item.MsKho, item.TenKho, item.SdtKho, item.MsDiaDiem, item.Msnv, item.MsLoaiHang);
            }
        }

        private void ManageInventory_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["Column1"].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["Column2"].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["Column3"].Value.ToString();
            var db = new InventoryManagementContext();
            var list1 = db.DiaDiems.Select(p => new { Text = p.MsDiaDiem, Value = p.DiaChi }).ToList();
            comboBox1.ValueMember = "Text";
            comboBox1.DisplayMember = "Value";
            comboBox1.DataSource = (list1.ToArray());
            numericUpDown1.Value = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells["Column5"].Value.ToString());
            var list2 = db.LoaiHangs.Select(p => new { Text = p.MsLoaiHang, Value = p.TenLoaiHang }).ToList();
            comboBox2.ValueMember = "Text";
            comboBox2.DisplayMember = "Value";
            comboBox2.DataSource = (list2.ToArray());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Kho k = new Kho();
            k.TenKho = textBox2.Text;
            k.SdtKho = textBox3.Text;
            k.MsDiaDiem = int.Parse(comboBox1.SelectedValue.ToString());
            k.Msnv = int.Parse(numericUpDown1.Value.ToString());
            k.MsLoaiHang = int.Parse(comboBox2.SelectedValue.ToString());
            using (var context = new InventoryManagementContext())
            {
                context.Khos.Add(k);
                context.SaveChanges();
                MessageBox.Show("Tao Kho thanh cong");
            }
            LoadData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel4.Height = button2.Height;
            panel4.Top = button2.Top;
            panel1.BringToFront();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel4.Height = button4.Height;
            panel4.Top = button4.Top;
            panel2.BringToFront();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells["Column1"].Value.ToString();
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells["Column2"].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["Column3"].Value.ToString();
            var db = new InventoryManagementContext();
            var list1 = db.DiaDiems.Select(p => new { Text = p.MsDiaDiem, Value = p.DiaChi }).ToList();
            comboBox4.ValueMember = "Text";
            comboBox4.DisplayMember = "Value";
            comboBox4.DataSource = (list1.ToArray());
            numericUpDown2.Value = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells["Column5"].Value.ToString());
            var list2 = db.LoaiHangs.Select(p => new { Text = p.MsLoaiHang, Value = p.TenLoaiHang }).ToList();
            comboBox3.ValueMember = "Text";
            comboBox3.DisplayMember = "Value";
            comboBox3.DataSource = (list2.ToArray());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox6.Text);
            using (var context = new InventoryManagementContext())
            {
                Kho k = context.Khos.Where(x => x.MsKho == id).FirstOrDefault();
                k.TenKho = textBox5.Text;
                k.SdtKho = textBox4.Text;
                k.MsDiaDiem = int.Parse(comboBox4.SelectedValue.ToString());
                k.Msnv = int.Parse(numericUpDown1.Value.ToString());
                k.MsLoaiHang = int.Parse(comboBox3.SelectedValue.ToString());
                context.Khos.Update(k);
                context.SaveChanges();
                MessageBox.Show("Sua thanh cong kho " + id);
            }
            LoadData();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel4.Height = button6.Height;
            panel4.Top = button6.Top;
            panel5.BringToFront();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox9.Text);
            using (var context = new InventoryManagementContext())
            {
                Kho k = context.Khos.Where(x => x.MsKho == id).FirstOrDefault();
                if (k == null)
                {
                    MessageBox.Show("Khong tim thay kho!!!" + id);
                }
                else
                {
                    List<PhieuNhapHang> list1 = context.PhieuNhapHangs.Where(x => x.MsKho == id).ToList();
                    List<PhieuXuatHang> list2 = context.PhieuXuatHangs.Where(x => x.MsKho == id).ToList();
                    if (list1.Count > 1 || list2.Count > 1)
                    {
                        DialogResult r = MessageBox.Show($"{k.TenKho} co phieu nhap hang va xuat hang! Ban co muon xoa", "Thong bao", MessageBoxButtons.YesNo);
                        if (r == DialogResult.Yes)
                        {
                            context.PhieuNhapHangs.RemoveRange(list1);
                            context.PhieuXuatHangs.RemoveRange(list2);
                            context.Khos.Remove(k);
                            MessageBox.Show("Xoa thanh cong kho " + id);
                        }
                    }
                    else
                    {
                        context.Khos.Remove(k);
                        MessageBox.Show("Xoa thanh cong kho " + id);
                    }
                    context.SaveChanges();
                    LoadData();
                }
            }
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox9.Text = dataGridView1.Rows[e.RowIndex].Cells["Column1"].Value.ToString();
            textBox8.Text = dataGridView1.Rows[e.RowIndex].Cells["Column2"].Value.ToString();
            textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells["Column3"].Value.ToString();
            var db = new InventoryManagementContext();
            var list1 = db.DiaDiems.Select(p => new { Text = p.MsDiaDiem, Value = p.DiaChi }).ToList();
            comboBox6.ValueMember = "Text";
            comboBox6.DisplayMember = "Value";
            comboBox6.DataSource = (list1.ToArray());
            numericUpDown3.Value = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells["Column5"].Value.ToString());
            var list2 = db.LoaiHangs.Select(p => new { Text = p.MsLoaiHang, Value = p.TenLoaiHang }).ToList();
            comboBox5.ValueMember = "Text";
            comboBox5.DisplayMember = "Value";
            comboBox5.DataSource = (list2.ToArray());
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            string text = textBox10.Text;
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            dataGridView3.Rows.Clear();
            var db = new InventoryManagementContext();
            List<Kho> list = db.Khos.Where(x => x.TenKho.Contains(text)).ToList();
            foreach (Kho item in list)
            {
                dataGridView1.Rows.Add(item.MsKho, item.TenKho, item.SdtKho, item.MsDiaDiem, item.Msnv, item.MsLoaiHang);
                dataGridView2.Rows.Add(item.MsKho, item.TenKho, item.SdtKho, item.MsDiaDiem, item.Msnv, item.MsLoaiHang);
                dataGridView3.Rows.Add(item.MsKho, item.TenKho, item.SdtKho, item.MsDiaDiem, item.Msnv, item.MsLoaiHang);
            }
        }

    }
}
