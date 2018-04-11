using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;

namespace BLL
{
    public class SinhVien_BLL
    {
        SinhVien_DAL svdal = new SinhVien_DAL();
        //phương thức này gọi phương thức sv_choose() ở lớp SinhVien_DAL (tầng DAL)
        public DataTable SinhVien_Load()
        {
            return svdal.sv_load();
        }

        public DataTable Khoa_Load()
        {
            return svdal.khoa_load();
        }

        public DataTable Lop_Load(string makhoa)
        {
            return svdal.lop_load(makhoa);
        }

        //phương thức này gọi phương thức sv_select() ở lớp SinhVien_DAL (tầng DAL)
        public DataTable SinhVien_Select(string malop)
        {
            return svdal.sv_select(malop);
        }

        public DataTable SinhVien_Find(string hoten)
        {
            return svdal.sv_find(hoten);
        }
        //phương thức này gọi phương thức sv_insert() ở lớp SinhVien_DAL (tầng DAL)
        public int SinhVien_Insert(string masv, string hoten, byte gioitinh, DateTime ngaysinh, string malop)
        {
            return svdal.sv_insert( masv, hoten, gioitinh, ngaysinh, malop);
        }

        //phương thức này gọi phương thức sv_update() ở lớp SinhVien_DAL (tầng DAL)
        public int SinhVien_Update(string masv, string hoten, byte gioitinh, DateTime ngaysinh, string malop)
        {
            return svdal.sv_update(masv, hoten, gioitinh, ngaysinh, malop);
        }

        //phương thức này gọi phương thức sv_delete() ở lớp SinhVien_DAL (tầng DAL)
        public int SinhVien_Delete(string masv)
        {
            return svdal.sv_delete(masv);

        }

    }
}
