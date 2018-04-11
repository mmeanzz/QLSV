using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;

namespace BLL
{
    public class Khoa_BLL
    {
        Khoa_DAL kdal = new Khoa_DAL();

        public DataTable Khoa_Load()
        {
            return kdal.khoa_load();
        }

        public DataTable Khoa_Select(string makhoa)
        {
            return kdal.khoa_select(makhoa);
        }

        public DataTable Khoa_Find(string tenkhoa)
        {
            return kdal.khoa_find(tenkhoa);
        }

        public int Khoa_Insert(string makhoa, string tenkhoa, string sdt)
        {
            return kdal.khoa_insert(makhoa, tenkhoa, sdt);
        }

        public int Khoa_Update(string makhoa, string tenkhoa, string sdt)
        {
            return kdal.khoa_update(makhoa, tenkhoa, sdt);
        }

        public int Khoa_Delete(string makhoa)
        {
            return kdal.khoa_delete(makhoa);
        }

    }
}
