using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLySV
{
    public partial class Form2 : Form
    {
        public delegate void MyDel(string LSH, string txt);
        public MyDel d { get; set; } 
        public Form2()
        {
            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public System.Windows.Forms.TextBox TextBoxMSSV
        {
            get { return textBoxMSSV; }
        }
        public System.Windows.Forms.TextBox TextBoxTen
        {
            get { return textBoxTen; }
        }
        public System.Windows.Forms.ComboBox ComboBoxLop
        {
            get { return comboBoxLop; }
        }
        public System.Windows.Forms.TextBox TextBoxDTB
        {
            get { return textBoxDTB; }
        }
        public RadioButton RadioButtonMale
        {
            get { return radioButtonMale; }
        }
        public RadioButton RadioButtonFemale
        {
            get { return radioButtonFemale; }
        }
        public CheckBox CheckBoxAnh
        {
            get { return checkBoxAnh; }
        }
        public CheckBox CheckBoxHB
        {
            get { return checkBoxHB; }
        }
        public CheckBox CheckBoxCCCD
        {
            get { return checkBoxCCCD; }
        }
        private void buttonOK_Click(object sender, EventArgs e)
        {
            SV sv = new SV();
            sv.MSSV = int.Parse(textBoxMSSV.Text);
            sv.Name = textBoxTen.Text;
            sv.DTB = double.Parse(textBoxDTB.Text);
            sv.CCCD = checkBoxCCCD.Checked;
            sv.Anh = checkBoxAnh.Checked;
            sv.HB = checkBoxHB.Checked;
            sv.Gender = radioButtonMale.Checked;
            sv.LopSH = comboBoxLop.SelectedItem.ToString();
            QLSinhVien qlsv = new QLSinhVien();
            qlsv.AdjustSV(sv);
            this.Close();
            //Form1 f1 = new Form1();
            //f1.ShowDialog();
            d("All", "");

        }
    }
}
