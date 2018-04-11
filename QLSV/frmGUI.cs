using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;

namespace QLSV
{
    public partial class frmGUI : Form
    {
        SinhVien_BLL svbll = new SinhVien_BLL();
        Lop_BLL lopbll = new Lop_BLL();
        Khoa_BLL kbll = new Khoa_BLL();
        public frmGUI()
        {
            InitializeComponent();
        }

        private void FrmGUI_Load(object sender, EventArgs e)
        {
            cbxSVTenkhoa.DataSource = svbll.Khoa_Load();
            cbxSVTenkhoa.DisplayMember = "TenKhoa";
            cbxSVTenkhoa.ValueMember = "Makhoa";

            cbxLTenkhoa.DataSource = lopbll.Khoa_Load();
            cbxLTenkhoa.DisplayMember = "TenKhoa";
            cbxLTenkhoa.ValueMember = "Makhoa";
            dtgvLop.DataSource = lopbll.Lop_Load();

            dtgvKhoa.DataSource = kbll.Khoa_Load();
        }

        #region SinhVien
        private void btnSVShow_Click(object sender, EventArgs e)
        {
            dtgv_SV.DataSource = svbll.SinhVien_Load();
        }

        private void btnSVFind_Click(object sender, EventArgs e)
        {
            dtgv_SV.DataSource= svbll.SinhVien_Find(tbxSVFind.Text);
        }

        private void btnSVAdd_Click(object sender, EventArgs e)
        {
            tbxSVMaLop.Text = "";
            tbxSVHoTen.Text = "";
            tbxSVMaSV.Text = "";
            dtpNgaySinh.Value = DateTime.Now;
            rdbtNam.Checked = false;
            rdbtNu.Checked = false;
            tbxSVMaLop.Focus();
            btnSVSave.Enabled = true;
        }

       

        private void btnSVEdit_Click(object sender, EventArgs e)
        {
            DialogResult key = MessageBox.Show("Bạn có muốn sửa hay không?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (key == DialogResult.Yes)
            {
                try
                {
                    byte gioitinh;
                    if (rdbtNam.Checked == true) { gioitinh = 1; }
                    else gioitinh = 0;
                    svbll.SinhVien_Update(tbxSVMaSV.Text, tbxSVHoTen.Text, gioitinh, DateTime.Parse(dtpNgaySinh.Text), tbxSVMaLop.Text);
                    cbxSVTenLop_SelectedIndexChanged(sender, e);
                    
                }
                catch (Exception LOI)
                {
                    MessageBox.Show(LOI.Message, "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSVDel_Click(object sender, EventArgs e)
        {
            DialogResult key = MessageBox.Show("Bạn có muốn xóa hay không?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (key == DialogResult.Yes)
            {
                try
                {
                    svbll.SinhVien_Delete(tbxSVMaSV.Text);
                    cbxSVTenLop_SelectedIndexChanged(sender, e);
                }
                catch (Exception LOI)
                {
                    MessageBox.Show(LOI.Message, "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSVSave_Click(object sender, EventArgs e)
        {
            DialogResult key = MessageBox.Show("Bạn có muốn lưu hay không?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (key == DialogResult.Yes)
            {
                try
                {
                    byte gioitinh;
                    if (rdbtNam.Checked == true) { gioitinh = 1; }
                    gioitinh = 0; 
                    svbll.SinhVien_Insert(tbxSVMaSV.Text, tbxSVHoTen.Text, gioitinh, DateTime.Parse(dtpNgaySinh.Text), tbxSVMaLop.Text);
                    //gọi lại hàm hiển thị để xem kết quả sau khi Thêm Sinh Viên
                    cbxSVTenLop_SelectedIndexChanged(sender, e);
                    btnSVSave.Enabled = false;
                }
                catch (Exception LOI)
                {
                    MessageBox.Show(LOI.Message, "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dtgv_SV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = dtgv_SV.CurrentCell.RowIndex;
            tbxSVMaSV.Text = dtgv_SV.Rows[e.RowIndex].Cells[0].Value.ToString();
            tbxSVHoTen.Text = dtgv_SV.Rows[e.RowIndex].Cells[1].Value.ToString();
            if ((bool)dtgv_SV.Rows[rowIndex].Cells[2].Value == true)
                rdbtNam.Checked = true;
            else
                rdbtNu.Checked = true;
            tbxSVMaLop.Text = dtgv_SV.Rows[e.RowIndex].Cells[3].Value.ToString();
            DateTime dt = DateTime.Parse(dtgv_SV.Rows[rowIndex].Cells[4].Value.ToString(),
                System.Globalization.CultureInfo.InvariantCulture);
            dtpNgaySinh.Value = dt;
        }

        private void cbxSVTenkhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbxSVTenLop.DataSource = svbll.Lop_Load(cbxSVTenkhoa.SelectedValue.ToString());
            cbxSVTenLop.DisplayMember = "TenLop";
            cbxSVTenLop.ValueMember = "MaLop";
            dtgv_SV.DataSource = svbll.SinhVien_Load();
        }

        private void cbxSVTenLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtgv_SV.DataSource = svbll.SinhVien_Select(cbxSVTenLop.SelectedValue.ToString());
        }

        #endregion

        #region Lop
        private void btnLShow_Click(object sender, EventArgs e)
        {
            dtgvLop.DataSource = lopbll.Lop_Load();
        }

        private void btnLAdd_Click(object sender, EventArgs e)
        {
            tbxLMalop.Text = "";
            tbxLTenlop.Text = "";
            tbxLMakhoa.Text = "";
            tbxLSiso.Text = "";
            tbxLMalop.Focus();
            btnLSave.Enabled = true;
        }

        private void btnLEdit_Click(object sender, EventArgs e)
        {
            DialogResult key = MessageBox.Show("Bạn có muốn sửa hay không?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (key == DialogResult.Yes)
            {
                try
                {
                    lopbll.Lop_Update(tbxLMalop.Text, tbxLTenlop.Text, tbxLMakhoa.Text, int.Parse(tbxLSiso.Text));
                    cbxLTenkhoa_SelectedIndexChanged(sender, e);
                }
                catch (Exception LOI)
                {
                    MessageBox.Show(LOI.Message, "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLDel_Click(object sender, EventArgs e)
        {
            DialogResult key = MessageBox.Show("Bạn có muốn xóa hay không?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (key == DialogResult.Yes)
            {
                try
                {
                    lopbll.Lop_Delete(tbxLMalop.Text);
                    cbxLTenkhoa_SelectedIndexChanged(sender, e);
                }
                catch (Exception LOI)
                {
                    MessageBox.Show(LOI.Message, "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLSave_Click(object sender, EventArgs e)
        {
            DialogResult key = MessageBox.Show("Bạn có muốn lưu hay không?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (key == DialogResult.Yes)
            {
                try
                {
                    lopbll.Lop_Insert(tbxLMalop.Text, tbxLTenlop.Text, tbxLMakhoa.Text, int.Parse(tbxLSiso.Text));
                    cbxLTenkhoa_SelectedIndexChanged(sender, e);
                    btnLSave.Enabled = false;
                }
                catch (Exception LOI)
                {
                    MessageBox.Show(LOI.Message, "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLFind_Click(object sender, EventArgs e)
        {
            dtgvLop.DataSource = lopbll.Lop_Find(tbxLFind.Text);
        }

        private void dtgvLop_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbxLMalop.Text = dtgvLop.Rows[e.RowIndex].Cells[0].Value.ToString();
            tbxLTenlop.Text = dtgvLop.Rows[e.RowIndex].Cells[1].Value.ToString();
            tbxLMakhoa.Text = dtgvLop.Rows[e.RowIndex].Cells[2].Value.ToString();
            tbxLSiso.Text = dtgvLop.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private void cbxLTenkhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtgvLop.DataSource = lopbll.Lop_Select(cbxLTenkhoa.SelectedValue.ToString());
        }
        #endregion

        #region Khoa
        private void dtgvKhoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbxKMaKhoa.Text = dtgvKhoa.Rows[e.RowIndex].Cells[0].Value.ToString();
            tbxKTenkhoa.Text = dtgvKhoa.Rows[e.RowIndex].Cells[1].Value.ToString();
            tbxKSdt.Text = dtgvKhoa.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        string LayMaKhoa(string maKhoa)
        {
            string[] text = maKhoa.Split(' ');
            for (int i = 0; i < text.Length; i++)
            {
                text[i] = text[i].Substring(0, 1);
                tbxKMaKhoa.Text += text[i];
            }

            tbxKMaKhoa.Text = tbxKMaKhoa.Text.ToUpper();
            return tbxKMaKhoa.Text;
        }

        private void btnKShow_Click(object sender, EventArgs e)
        {
            dtgvKhoa.DataSource = kbll.Khoa_Load();
        }

        private void btnKAdd_Click(object sender, EventArgs e)
        {
            tbxKMaKhoa.Clear();
            tbxKMaKhoa.Enabled = false;
            tbxKTenkhoa.Text = "";
            tbxKSdt.Text = "";
            tbxKMaKhoa.Focus();
            btnKSave.Enabled = true;

        }

        private void btnKEdit_Click(object sender, EventArgs e)
        {
            DialogResult key = MessageBox.Show("Bạn có muốn sửa hay không?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (key == DialogResult.Yes)
            {
                try
                {
                    kbll.Khoa_Update(tbxKMaKhoa.Text, tbxKTenkhoa.Text, tbxKSdt.Text);
                    dtgvKhoa.DataSource = kbll.Khoa_Load();
                    FrmGUI_Load(sender, e);
                }
                catch (Exception LOI)
                {
                    MessageBox.Show(LOI.Message, "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnKDel_Click(object sender, EventArgs e)
        {
            DialogResult key = MessageBox.Show("Bạn có muốn xóa hay không?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (key == DialogResult.Yes)
            {
                try
                {
                    kbll.Khoa_Delete(tbxKMaKhoa.Text);
                    dtgvKhoa.DataSource = kbll.Khoa_Load();
                    FrmGUI_Load(sender, e);
                }
                catch (Exception LOI)
                {
                    MessageBox.Show(LOI.Message, "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnKSave_Click(object sender, EventArgs e)
        {
            DialogResult key = MessageBox.Show("Bạn có muốn lưu hay không?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (key == DialogResult.Yes)
            {
                try
                {
                    
                    kbll.Khoa_Insert(LayMaKhoa(tbxKTenkhoa.Text), tbxKTenkhoa.Text, tbxKSdt.Text);
                    dtgvKhoa.DataSource = kbll.Khoa_Load();
                    btnKSave.Enabled = false;
                    tbxKMaKhoa.Enabled = true;
                    FrmGUI_Load(sender, e);
                }
                catch (Exception LOI)
                {
                    MessageBox.Show(LOI.Message, "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void btnKFind_Click(object sender, EventArgs e)
        {
            dtgvKhoa.DataSource = kbll.Khoa_Find(tbxKFind.Text);
        }

        #endregion


    }
}
