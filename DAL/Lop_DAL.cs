using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL
{
    public class Lop_DAL
    {
        Thaotac_CSDL thaotac = new Thaotac_CSDL();
        string[] name = { };
        object[] value = { };

        public DataTable lop_load()
        {
            //    thaotac.KetnoiCSDL();
            return thaotac.SQL_Laydulieu("Lop_load");
        }

        public DataTable khoa_load()
        {
            return thaotac.SQL_Laydulieu("Khoa_load");
        }

        public DataTable lop_select(string makhoa)
        {
            return thaotac.SQL_Timdulieu("lop_sl", "@Makhoa", makhoa);
        }

        public DataTable lop_find(string tenlop)
        {
            return thaotac.SQL_Timdulieu("lop_find", "@findname", tenlop);
        }

        public int lop_insert(string malop, string tenlop, string makhoa, int siso)
        {
            //thaotac.KetnoiCSDL();
            name = new string[4];
            value = new object[4];
            name[0] = "@Malop"; value[0] = malop;
            name[1] = "@Tenlop"; value[1] = tenlop;
            //@HoTen,... là các tham số phải giống với tham số khai báo ở Stores Procedures trong CSDL
            name[2] = "@makhoa"; value[2] = makhoa;
            name[3] = "@siso"; value[3] = siso;
            return thaotac.SQL_Thuchien("Lop_is", name, value, 4);
        }

        public int lop_update(string malop, string tenlop, string makhoa, int siso)
        {
            name = new string[4];
            value = new object[4];
            name[0] = "@Malop"; value[0] = malop;
            name[1] = "@Tenlop"; value[1] = tenlop;
            //@HoTen,... là các tham số phải giống với tham số khai báo ở Stores Procedures trong CSDL
            name[2] = "@makhoa"; value[2] = makhoa;
            name[3] = "@siso"; value[3] = siso;
            return thaotac.SQL_Thuchien("Lop_up", name, value, 4);
        }

        public int lop_delete(string malop)
        {
            name = new string[1];
            value = new object[1];
            name[0] = "@Malop"; value[0] = malop;
            return thaotac.SQL_Thuchien("lop_dl", name, value, 1);
        }

    }
}
