using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL
{
    public class SinhVien_DAL
    {
        Thaotac_CSDL thaotac = new Thaotac_CSDL();
        //khai báo 2 mảng để truyền tên tham số và giá trị tham số vào Stored Procedures
        string[] name = { };
        object[] value = { };
        //phương thức này gọi phương thức SQL_Laydulieu ở lớp ThaoTac_CoSoDuLieu để thực hiện lấy dữ liệu
        public DataTable sv_load()
        {
            //    thaotac.KetnoiCSDL();
            return thaotac.SQL_Laydulieu("SV_load");
        }

        public DataTable khoa_load()
        {
            return thaotac.SQL_Laydulieu("khoa_load");
        }

        public DataTable lop_load(string makhoa)
        {
            return thaotac.SQL_Timdulieu("Lop_sl","@Makhoa",makhoa);
        }

        public DataTable sv_select(string malop)
        {
            return thaotac.SQL_Timdulieu("SV_sl", "@MaLop", malop);
        }

        public DataTable sv_find(string hoten)
        {
            return thaotac.SQL_Timdulieu("SV_find", "@findname", hoten);
        }

        //phương thức này gọi phương thức SQL_Thuchien ở lớp ThaoTac_CoSoDuLieu để thực hiện insert
        public int sv_insert(string masv,string hoten, byte gioitinh, DateTime ngaysinh, string malop)
        {
            //thaotac.KetnoiCSDL();
            name = new string[5];
            value = new object[5];
            name[0] = "@MaSV"; value[0] = masv;
            name[1] = "@Ten"; value[1] = hoten;
                  //@HoTen,... là các tham số phải giống với tham số khai báo ở Stores Procedures trong CSDL
            name[2] = "@GT"; value[2] = gioitinh;
            name[3] = "@Malop"; value[3] = malop;
            name[4] = "@NS"; value[4] = ngaysinh;

            return thaotac.SQL_Thuchien("SV_is", name, value, 5);
        }
        //phương thức này gọi phương thức SQL_Thuchien ở lớp ThaoTac_CoSoDuLieu để thực hiện update
        public int sv_update(string masv, string hoten, byte gioitinh, DateTime ngaysinh, string malop)
        {
            name = new string[5];
            value = new object[5];
            name[0] = "@MaSV"; value[0] = masv;
            name[1] = "@Ten"; value[1] = hoten;
            //@HoTen,... là các tham số phải giống với tham số khai báo ở Stores Procedures trong CSDL
            name[2] = "@GT"; value[2] = gioitinh;
            name[3] = "@Malop"; value[3] = malop;
            name[4] = "@NS"; value[4] = ngaysinh;
            
            return thaotac.SQL_Thuchien("SV_up", name, value, 5);
        }
        //phương thức này gọi phương thức SQL_Thuchien ở lớp ThaoTac_CoSoDuLieu để thực hiện delete
        public int sv_delete(string masv)
        {
            name = new string[1];
            value = new object[1];
            name[0] = "@MaSV"; value[0] = masv;
            return thaotac.SQL_Thuchien("SV_Dl", name, value, 1);
        }
    }
}
