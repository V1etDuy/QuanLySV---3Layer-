using System;
using System.Collections.Generic;
using System.Windows.Forms;
//SetCBB
//KHÔNG BAO GIỜ CODE CHỨC NĂNG Ở ĐÂY
namespace QuanLySV
{
    public partial class Form1 : Form
    {
        //BindingSource bindingSource1 = new BindingSource();
        List<SV> List1;
        public Form1()
        {
            InitializeComponent();
            LoadDGV("All", "");
        }
        private static Form1 _Instance;
        public static Form1 Instance
        {
            get
            {
                if (_Instance == null) _Instance = new Form1();
                return _Instance;
            }
            private set { }
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.d += new Form2.MyDel(LoadDGV);
            form2.Show();
            

        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            int i = 0;
            string[] cellValue = new string[8];

            if (dataGridView1.SelectedRows.Count == 1)
            {
                Form2 form2 = new Form2();
                form2.d += new Form2.MyDel(LoadDGV);
                form2.Show();
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        cellValue[i] = cell.Value.ToString();
                        i++;
                    }
                    form2.TextBoxMSSV.Text = cellValue[0];
                    form2.TextBoxTen.Text = cellValue[1];
                    form2.ComboBoxLop.Text = cellValue[2];
                    form2.TextBoxDTB.Text = cellValue[3];
                    bool myBool = bool.Parse(cellValue[4]);
                    if (myBool)
                    {
                        form2.RadioButtonMale.Checked = myBool;
                    }
                    else
                    {
                        form2.RadioButtonMale.Checked = true;
                    }
                    myBool = bool.Parse(cellValue[5]);
                    if (myBool)
                    {
                        form2.CheckBoxAnh.Checked = myBool;
                    }
                    myBool = bool.Parse(cellValue[6]);
                    if (myBool)
                    {
                        form2.CheckBoxHB.Checked = myBool;
                    }
                    myBool = bool.Parse(cellValue[7]);
                    if (myBool)
                    {
                        form2.CheckBoxCCCD.Checked = myBool;
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn duy nhất 1 đối tượng sinh viên để edit", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void buttonSeach_Click(object sender, EventArgs e)
        {
            LoadDGV(comboBoxLopSH.SelectedItem.ToString(), TextSearch.Text);

        }

        private void buttonSort_Click(object sender, EventArgs e)
        {
            QLSinhVien qlsv = new QLSinhVien();
            string sortby = comboBoxSort.Text;
            List<string> list = new List<string>();
            foreach (DataGridViewRow i in dataGridView1.Rows)
            {
                list.Add(i.Cells["MSSV"].Value.ToString());
            }
            dataGridView1.DataSource = qlsv.SortSV(list, sortby);

        }
        public void LoadDGV(string LSH, string txt)
        {
            QLSinhVien e = new QLSinhVien();
            List1 = new List<SV>(e.ListSVShow(LSH, txt));
            dataGridView1.DataSource = List1;
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            QLSinhVien qlsv = new QLSinhVien();
            if (dataGridView1.SelectedRows.Count > 0)
            {
                List<string> list = new List<string>();
                foreach (DataGridViewRow i in dataGridView1.SelectedRows)
                {
                    list.Add(i.Cells["MSSV"].Value.ToString());
                }
                qlsv.DelSV(list);

                //Reload lai data
                LoadDGV(comboBoxLopSH.SelectedItem.ToString(), TextSearch.Text);
            }
        }

        internal void LoadDGV()
        {
            LoadDGV(comboBoxLopSH.SelectedItem.ToString(), TextSearch.Text);
        }
    }
}
