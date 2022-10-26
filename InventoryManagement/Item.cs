
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace InventoryManagement
{
    public partial class Item : Form
    {
        public Item()
        {
            InitializeComponent();
        }
        public void LoadData()
        {
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            dataGridView3.Rows.Clear();
            List<MatHang> list = new List<MatHang>();
            using (InventoryManagementContext context = new InventoryManagementContext())
            {
                list = context.MatHangs.ToList();
            }
            foreach (MatHang item in list)
            {
                dataGridView1.Rows.Add(item.MsMatHang, item.MsLoaiHang, item.TenHang);
                dataGridView2.Rows.Add(item.MsMatHang, item.MsLoaiHang, item.TenHang);
                dataGridView3.Rows.Add(item.MsMatHang, item.MsLoaiHang, item.TenHang);

            }
        }

        private bool CheckNull1()
        {
            if (textBox4.Text == "" || textBox3.Text == "" || comboBox2.Text == "")
            {
                MessageBox.Show("All Input is not Null, please try again", "Notification", MessageBoxButtons.OK);
                return false;
            }
            else
            {
                return true;
            }
        }
        private bool CheckNull()
        {
            if (comboBox1.Text == "" || textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("All Input is not Null, please try again", "Notification", MessageBoxButtons.OK);
                return false;
            }
            else
            {
                return true;
            }
        }
        private void Item_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void add_mh_btn_Click(object sender, EventArgs e)
        {
            if (!CheckNull())
            {
                return;
            }
            add_mh_btn.Enabled = false;
            MatHang dt = new MatHang();
            var id = textBox1.Text;
            dt.MsLoaiHang = int.Parse(comboBox1.SelectedValue.ToString());
            dt.TenHang = textBox2.Text;
            var db = new InventoryManagementContext();
            db.MatHangs.Add(dt);
            db.SaveChanges();
            MessageBox.Show("Them thanh cong don");
            add_mh_btn.Enabled = true;
            LoadData();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox4.Text = dataGridView2.Rows[e.RowIndex].Cells["dataGridViewTextBoxColumn1"].Value.ToString();
            var db = new InventoryManagementContext();
            var list1 = db.LoaiHangs.Select(p => new { Text = p.MsLoaiHang, Value = p.TenLoaiHang }).ToList();
            comboBox2.ValueMember = "Text";
            comboBox2.DisplayMember = "Value";
            comboBox2.DataSource = (list1.ToArray());
            textBox3.Text = dataGridView2.Rows[e.RowIndex].Cells["dataGridViewTextBoxColumn3"].Value.ToString();
        }

        private void update_mh_btn_Click(object sender, EventArgs e)
        {
            if (!CheckNull1())
            {
                return;
            }
            update_mh_btn.Enabled = false;
            int id = int.Parse(textBox4.Text);
            var db = new InventoryManagementContext();
            var obj = db.MatHangs.Where(x => x.MsMatHang == id).FirstOrDefault();
            obj.MsLoaiHang = int.Parse(comboBox2.SelectedValue.ToString());
            obj.TenHang = textBox3.Text;
            db.MatHangs.Update(obj);
            db.SaveChanges();
            MessageBox.Show("Update thanh cong don :" + id);
            update_mh_btn.Enabled = true;
            LoadData();
        }

        private void add_mh_Click(object sender, EventArgs e)
        {
            Slide_panel.Height = add_mh.Height;
            Slide_panel.Top = add_mh.Top;
            panel1.BringToFront();
        }

        private void update_mh_Click(object sender, EventArgs e)
        {
            Slide_panel.Height = update_mh.Height;
            Slide_panel.Top = update_mh.Top;
            panel3.BringToFront();
        }

        private void delete_mh_Click(object sender, EventArgs e)
        {
            Slide_panel.Height = delete_mh.Height;
            Slide_panel.Top = delete_mh.Top;
            panel5.BringToFront();
        }

        private void dataGridView3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox6.Text = dataGridView3.Rows[e.RowIndex].Cells["dataGridViewTextBoxColumn4"].Value.ToString();
            var db = new InventoryManagementContext();
            var list1 = db.LoaiHangs.Select(p => new { Text = p.MsLoaiHang, Value = p.TenLoaiHang }).ToList();
            comboBox2.ValueMember = "Text";
            comboBox2.DisplayMember = "Value";
            comboBox2.DataSource = (list1.ToArray());
            textBox5.Text = dataGridView3.Rows[e.RowIndex].Cells["dataGridViewTextBoxColumn6"].Value.ToString();
        }

        private void delete_mh_btn_Click(object sender, EventArgs e)
        {
            delete_mh_btn.Enabled = false;
            int id = int.Parse(textBox6.Text);
            var db = new InventoryManagementContext();
            var obj = db.MatHangs.Where(x => x.MsMatHang == id).FirstOrDefault();
            if (obj != null)
            {
                DialogResult dialogResult = MessageBox.Show("Ban co chac muon xoa mat hang", "Mat Hang", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    db.MatHangs.Remove(obj);
                    MessageBox.Show("Xoa mat hang thanh cong :" + id);
                    db.SaveChanges();
                    LoadData();
                }
                else if (dialogResult == DialogResult.No)
                {
                    // ko lam gi
                }
            }

            delete_mh_btn.Enabled = true;
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            string text = textBox12.Text;
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            dataGridView3.Rows.Clear();
            var db = new InventoryManagementContext();
            List<MatHang> list = db.MatHangs.Where(x => x.TenHang.Contains(text)).ToList();
            foreach (MatHang item in list)
            {
                dataGridView1.Rows.Add(item.MsMatHang, item.MsLoaiHang, item.TenHang);
                dataGridView2.Rows.Add(item.MsMatHang, item.MsLoaiHang, item.TenHang);
                dataGridView3.Rows.Add(item.MsMatHang, item.MsLoaiHang, item.TenHang);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["Column1"].Value.ToString();
            var db = new InventoryManagementContext();
            var list1 = db.LoaiHangs.Select(p => new { Text = p.MsLoaiHang, Value = p.TenLoaiHang }).ToList();
            comboBox1.ValueMember = "Text";
            comboBox1.DisplayMember = "Value";
            comboBox1.DataSource = (list1.ToArray());
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["Column3"].Value.ToString();
        }
    }
}
