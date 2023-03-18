using QuanLySV;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace QuanLySV
{
    internal class QLSinhVien
    {
        
        public List<string> GetALlLSH()
        {
            List<string> li = new List<string>();
            foreach (SV i in CSDL.Instance.GetALlSV())
            {
                li.Add(i.LopSH);
            }
            return li.Distinct().ToList(); //Distinc= loại những lớp trùng
                                           //ToList() -> chuyen sang list
        }
        public List<SV> ListSVShow(string LSH, string txt)
        {
            // Lay cac sinh vien thuoc lop sinh hoat
            List<SV> li = new List<SV>();
            foreach (SV i in CSDL.Instance.GetALlSV())
            {
                if (i.Name.Contains(txt) || i.MSSV.ToString().Contains(txt))
                {
                    if (LSH == "All")
                    {
                        li.Add(i);
                    }
                    else if (LSH != "All")
                    {
                        if (i.LopSH == LSH) li.Add(i);
                    }

                }

            }
            return li;
        }
        public List<SV> ListSVNow(List<string> li)
        {
            List<SV> db = new List<SV>();
            foreach(string i in li)
            {
                foreach(SV j in CSDL.Instance.GetALlSV())
                {
                    if(i == j.MSSV.ToString()) db.Add(j);
                    Console.WriteLine(j.Name);
                }
            }
            return db;
        }

        public void DelSV(List<string> list)
        {
            foreach (string s in list)
            {
                CSDL.Instance.Del_CSDL(s);
            }
        }
        public void AdjustSV(SV sv)
        {
            CSDL.Instance.Adjust_CSDL(sv);
        }
        public List<SV> SortSV(List<string> listMSSV, string sortby)
        {
            List<SV> list = new List<SV>();
            list = ListSVNow(listMSSV);
            
            if (sortby == "Điểm trung bình")
            {
                list.Sort((x, y) => x.DTB.CompareTo(y.DTB));
            }
            if (sortby == "Tên")
            {
                list.Sort((x, y) => x.Name.CompareTo(y.Name));
            }
            if (sortby == "Lớp")
            {
                list.Sort((x, y) => x.LopSH.CompareTo(y.LopSH));
            }
            return list;

        }
    }
}


