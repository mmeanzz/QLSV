using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class Thaotac_CSDL
    {
        SqlConnection GetConnection;
        private void KetnoiCSDL()
        {
            GetConnection = new SqlConnection(@"Data Source=DESKTOP-V9CUBI3\SQLEXPRESS;Initial Catalog=QuanLySinhVien;Integrated Security=True");
            GetConnection.Open();
        }
        private void NgatKetNoi()
        {
            GetConnection.Close();
            GetConnection.Dispose();
        }
        //phương thức thực thi Select dữ liệu
        public DataTable SQL_Laydulieu(string TenSP)
        {
            KetnoiCSDL();
            //thực thi lấy dữ liệu từ CSDL
            SqlCommand cmd = new SqlCommand(TenSP, GetConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            //ngắt kết nối
            NgatKetNoi();
            //trả về bảng chứa dữ liệu lấy được.
            return dt;
        }

        public DataTable SQL_Timdulieu(string TenSP, string name, string value)
        {
            KetnoiCSDL();
            SqlCommand cmd = new SqlCommand(TenSP, GetConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue(name, value);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.SelectCommand = cmd;
            da.Fill(dt);

            NgatKetNoi();
            return dt;
        }

        public DataTable ExecuteQuery(string query, object[] parameter = null)
        {
            DataTable dt = new DataTable();
            KetnoiCSDL();
            SqlCommand cmd = new SqlCommand(query, GetConnection);

            if (parameter != null)
            {
                string[] listPara = query.Split(' ');
                int i = 0;
                foreach (string item in listPara)
                {
                    if (item.Contains('@'))
                    {
                        cmd.Parameters.AddWithValue(item, parameter[i]);
                        i++;
                    }
                }
            }
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            NgatKetNoi();
            return dt;

        }

        //phương thức thực thi Insert, Update, Delete
        public int SQL_Thuchien(string TenSP, string[] name, object[] value, int Npara)
        {
            KetnoiCSDL();
            SqlCommand cmd = new SqlCommand(TenSP, GetConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < Npara; i++)
            {
                cmd.Parameters.AddWithValue(name[i], value[i]);
            }
            return cmd.ExecuteNonQuery();
        }

    }
}
