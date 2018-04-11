using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL
{
    public class Khoa_DAL
    {
        Thaotac_CSDL thaotac = new Thaotac_CSDL();
        string[] name = { };
        object[] value = { };

        public DataTable khoa_load()
        {
            //    thaotac.KetnoiCSDL();
            return thaotac.SQL_Laydulieu("khoa_load");
        }

        public DataTable khoa_select(string makhoa)
        {
            return thaotac.SQL_Timdulieu("khoa_sl", "@Makhoa", makhoa);
        }

        public DataTable khoa_find(string tenkhoa)
        {
            return thaotac.SQL_Timdulieu("khoa_find", "@findname", tenkhoa);
        }

        public int khoa_insert(string makhoa, string tenkhoa, string sdt)
        {
            //thaotac.KetnoiCSDL();
            name = new string[3];
            value = new object[3];
            name[0] = "@Makhoa"; value[0] = makhoa;
            name[1] = "@Tenkhoa"; value[1] = tenkhoa;           
            name[2] = "@sdt"; value[2] = sdt;
            return thaotac.SQL_Thuchien("khoa_is", name, value, 3);
        }

        public int khoa_update(string makhoa, string tenkhoa, string sdt)
        {
            name = new string[3];
            value = new object[3];
            name[0] = "@Makhoa"; value[0] = makhoa;
            name[1] = "@Tenkhoa"; value[1] = tenkhoa;
            name[2] = "@sdt"; value[2] = sdt;
            return thaotac.SQL_Thuchien("khoa_up", name, value, 3);
        }

        public int khoa_delete(string makhoa)
        {
            name = new string[1];
            value = new object[1];
            name[0] = "@Makhoa"; value[0] = makhoa;
            return thaotac.SQL_Thuchien("khoa_dl", name, value, 1);
        }
    }
}
