using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;

namespace BLL
{
    public class Lop_BLL
    {
        Lop_DAL lopdal = new Lop_DAL();

        public DataTable Lop_Load()
        {
            return lopdal.lop_load();
        }

        public DataTable Khoa_Load()
        {
            return lopdal.khoa_load();
        }

        public DataTable Lop_Select(string makhoa)
        {
            return lopdal.lop_select(makhoa);
        }

        public DataTable Lop_Find(string tenlop)
        {
            return lopdal.lop_find(tenlop);
        }

        public int Lop_Insert(string malop, string tenlop, string makhoa, int siso)
        {
            return lopdal.lop_insert(malop, tenlop, makhoa, siso);
        }

        public int Lop_Update(string malop, string tenlop, string makhoa, int siso)
        {
            return lopdal.lop_update(malop, tenlop, makhoa, siso);
        }

        public int Lop_Delete(string malop)
        {
            return lopdal.lop_delete(malop);

        }

    }
}
