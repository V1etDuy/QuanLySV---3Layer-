using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLySV
{
    internal class CSDL
    {
        public DataTable dataTableSV { get; set; }
        
        public DataTable DB
        {
            get { return dataTableSV; }
            private set { }
        }
        private static CSDL _Instance;
        public static CSDL Instance
        {
            get
            {
                if (_Instance == null) _Instance = new CSDL();
                return _Instance;
            }
            private set { }
        }
        private CSDL()
        {
            SV[] sv = new SV[]
            {
                new SV { MSSV = 100, Name = "Duy Việt", LopSH = "21TCLC_DT1", DTB = 9.9, Gender = true, Anh = true, CCCD = true, HB = true },
                new SV { MSSV = 101, Name = "Phan Tấn Trung", LopSH = "21TCLC_DT1", DTB = 3.3, Gender = true, Anh = true, CCCD = false, HB = false },
                new SV { MSSV = 102, Name = "Vĩ Phạm", LopSH = "21TCLC_DT1", DTB = 5.5, Gender = false, Anh = true, CCCD = true, HB = false },
                new SV { MSSV = 103, Name = "Anh Tuấn", LopSH = "20TCLC_DT1", DTB = 6.6, Gender = true, Anh = false, CCCD = true, HB = true },
                new SV { MSSV = 104, Name = "Baroibeo", LopSH = "20TCLC_DT1", DTB = 10, Gender = false, Anh = true, CCCD = true, HB = false },
                new SV { MSSV = 105, Name = "3 Gà", LopSH = "20TCLC_DT1", DTB = 1.1, Gender = true, Anh = true, CCCD = false, HB = false },
                new SV { MSSV = 106, Name = "Hói Phan", LopSH = "19TCLC_DT1", DTB = 4.4, Gender = true, Anh = true, CCCD = true, HB = false },
                new SV { MSSV = 107, Name = "TheShy Sa Đéc", LopSH = "19TCLC_DT1", DTB = 7.7, Gender = true, Anh = false, CCCD = true, HB = true },
                new SV { MSSV = 108, Name = "3G", LopSH = "19TCLC_DT1", DTB = 8.8, Gender = true, Anh = true, CCCD = true, HB = true },
                new SV { MSSV = 109, Name = "Phan Túng Trân", LopSH = "19TCLC_DT1", DTB = 2.2, Gender = false, Anh = true, CCCD = true, HB = false },
            };
            List<SV> list = new List<SV>();
            list.AddRange(sv);
            dataTableSV = new DataTable();
            dataTableSV.Columns.AddRange(new DataColumn[]
            {
                new DataColumn{ColumnName = "MSSV", DataType = typeof(int) },
                new DataColumn{ColumnName = "Name", DataType = typeof(string) },
                new DataColumn{ColumnName = "LopSH", DataType = typeof(string) },
                new DataColumn{ColumnName = "DTB", DataType = typeof(double) },
                new DataColumn{ColumnName = "Gender", DataType = typeof(bool) },
                new DataColumn{ColumnName = "Anh", DataType = typeof(bool) },
                new DataColumn{ColumnName = "HB", DataType = typeof(bool) },
                new DataColumn{ColumnName = "CCCD", DataType = typeof(bool) },
            });
            foreach (SV i in sv)
            {
                dataTableSV.Rows.Add(i.MSSV, i.Name, i.LopSH, i.DTB, i.Gender, i.Anh, i.CCCD, i.HB);

            }
        }

        public List<SV> GetALlSV() //Nên để hàm này trong CSDL
        {
            List<SV> li = new List<SV>();
            foreach (DataRow i in dataTableSV.Rows)
            {
                li.Add(new SV
                {
                    MSSV = i.Field<int>("MSSV"),
                    Name = i.Field<string>("Name"),
                    LopSH = i.Field<string>("LopSH"),
                    DTB = i.Field<double>("DTB"),
                    Gender = i.Field<bool>("Gender"),
                    Anh = i.Field<bool>("Anh"),
                    HB = i.Field<bool>("HB"),
                    CCCD = i.Field<bool>("CCCD"),
                });
            }
            return li;
        }

        public void Del_CSDL(string s)
        {
            for (int i = 0; i < dataTableSV.Rows.Count; i++)
            {
                if (dataTableSV.Rows[i]["MSSV"].ToString() == s)
                {
                    // xoa dataRow tai vi tri thu i 
                    dataTableSV.Rows.RemoveAt(i);
                }
            }

        }
        public void Adjust_CSDL(SV sv)
        {
            bool found = false;

            for (int i = 0; i < dataTableSV.Rows.Count; i++)
            {
                if (dataTableSV.Rows[i]["MSSV"].ToString() == sv.MSSV.ToString())
                {
                    //Tim thay MSSV trong CSDL -> Edit
                    found = true;
                    DataRow row = dataTableSV.Rows[i];
                    row["MSSV"] = sv.MSSV.ToString();
                    row["LopSH"] = sv.LopSH.ToString();
                    row["Name"] = sv.Name;
                    row["DTB"] = sv.DTB.ToString();
                    row["Gender"] = sv.Gender;
                    row["Anh"] = sv.Anh;
                    row["HB"] = sv.HB;
                    row["CCCD"] = sv.CCCD;
                    dataTableSV.AcceptChanges();
                    break;

                }
            }
            // Khong tim thay -> Add
            if (found == false)
            {
                dataTableSV.Rows.Add(sv.MSSV, sv.Name, sv.LopSH, sv.DTB, sv.Gender, sv.Anh, sv.CCCD, sv.HB);
            }
            
        }


    }
}
