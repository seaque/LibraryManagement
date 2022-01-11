using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using BLL;
using Entities;
using System.Text.RegularExpressions;
using System.Data.OleDb;

namespace LibraryApp
{
    public partial class Students : MaterialForm
    {
        private Student_BLL std;
        private Student_Entity std_entity;
        private LH_BLL lh;

        public Students()
        {
            std = new Student_BLL();
            std_entity = new Student_Entity();
            lh = new LH_BLL();

            InitializeComponent();

            //Material temayı uygula
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            
            //Renk seçimi
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Blue600, Primary.Blue700,
                Primary.Blue900, Accent.Blue400,
                TextShade.WHITE
            );
        }

        //Veritabanı bilgileriyle DataGridView nesnelerinin doldurulması
        private void Student_Load(object sender, EventArgs e)
        {
            dgv_std_list.DataSource = std.GetStudents();
            #region DATAGRIDVIEW COLUMN NAMES
            dgv_std_list.Columns[0].HeaderCell.Value = "ID";
            dgv_std_list.Columns[1].HeaderCell.Value = "Name";
            dgv_std_list.Columns[2].HeaderCell.Value = "Surname";
            dgv_std_list.Columns[3].HeaderCell.Value = "Mail";
            #endregion

            dgv_std_update.DataSource = std.GetStudents();
            #region DATAGRIDVIEW COLUMN NAMES
            dgv_std_update.Columns[0].HeaderCell.Value = "ID";
            dgv_std_update.Columns[1].HeaderCell.Value = "Name";
            dgv_std_update.Columns[2].HeaderCell.Value = "Surname";
            dgv_std_update.Columns[3].HeaderCell.Value = "Mail";
            #endregion

            dgv_std_delete.DataSource = std.GetStudents();
            #region DATAGRIDVIEW COLUMN NAMES
            dgv_std_delete.Columns[0].HeaderCell.Value = "ID";
            dgv_std_delete.Columns[1].HeaderCell.Value = "Name";
            dgv_std_delete.Columns[2].HeaderCell.Value = "Surname";
            dgv_std_delete.Columns[3].HeaderCell.Value = "Mail";
            #endregion

            dgv_std_history.DataSource = std.GetStudents();
            #region DATAGRIDVIEW COLUMN NAMES
            dgv_std_history.Columns[0].HeaderCell.Value = "ID";
            dgv_std_history.Columns[1].HeaderCell.Value = "Name";
            dgv_std_history.Columns[2].HeaderCell.Value = "Surname";
            dgv_std_history.Columns[3].HeaderCell.Value = "Mail";
            #endregion
        }

        //Değişiklik yapıldıktan sonra tabloların güncellenmesi sağlanır
        private void UpdateTable()
        {
            dgv_std_list.DataSource = std.GetStudents();
            dgv_std_update.DataSource = std.GetStudents();
            dgv_std_delete.DataSource = std.GetStudents();
        }

        //Formdaki bilgiler Entity objesine atanır ve ekleme sağlanır
        private void materialBtn_add_submit_Click(object sender, EventArgs e)
        {
            try
            {
                std_entity.student_ID = Int32.Parse(materialTxt_add_ID.Text);
                std_entity.student_name = materialTxt_add_name.Text;
                std_entity.student_surname = materialTxt_add_surname.Text;
                std_entity.student_mail = materialTxt_add_mail.Text;
                std.AddStudent(std_entity);
                MessageBox.Show("Student has successfully added.");
                UpdateTable();
            }
            catch (OleDbException)
            {
                MessageBox.Show("Please fill all the areas accurately.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //Ekleme fonksiyonu giriş kontrolleri
        private void materialTxt_name_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        //Ekleme fonksiyonu giriş kontrolleri
        private void materialTxt_surname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        //Mail girişi kontrolü
        private void materialTxt_mail_Leave(object sender, EventArgs e)
        {
            Regex mRegxExpression;
            if (materialTxt_add_mail.Text.Trim() != string.Empty)
            {
                mRegxExpression = new Regex(@"^([a-zA-Z0-9_\-])([a-zA-Z0-9_\-\.]*)@(\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\.){3}|((([a-zA-Z0-9\-]+)\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\])$");

                if (!mRegxExpression.IsMatch(materialTxt_add_mail.Text.Trim()))
                {
                    MessageBox.Show("E-mail address format is not correct.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    materialTxt_add_mail.Focus();
                }
            }
        }

        //Hücrede tıklanan öğrenci bilgilerini textboxlara geçirir
        private void dataGridView_Update_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgv_std_update.Rows[e.RowIndex];
                materialTxt_update_ID.Text = row.Cells[0].Value.ToString();
                materialTxt_update_name.Text = row.Cells[1].Value.ToString();
                materialTxt_update_sname.Text = row.Cells[2].Value.ToString();
                materialTxt_update_mail.Text = row.Cells[3].Value.ToString();
            }
        }

        //Hücrede tıklanan değerdeki öğrenci ID'sini textboxa geçirir
        private void dataGridView_delete_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgv_std_delete.Rows[e.RowIndex];
                materialTxt_delete.Text = row.Cells[0].Value.ToString();
            }
        }

        //Hücrede tıklanan öğrencinin aldığı kitapları gösterir
        private void dataGridView_history_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgv_std_history.Rows[e.RowIndex];
                dgv_std_bookhst.DataSource = lh.GetStudentHistory(Int32.Parse(row.Cells[0].Value.ToString()));

                #region DATAGRIDVIEW COLUMN NAMES & FORMATTING
                dgv_std_bookhst.Columns["lh_ID"].Visible = false;
                dgv_std_bookhst.Columns["student_ID"].Visible = false;
                dgv_std_bookhst.Columns["student_name"].Visible = false;
                dgv_std_bookhst.Columns["student_surname"].Visible = false;

                dgv_std_bookhst.Columns[0].HeaderCell.Value = "ISBN";
                dgv_std_bookhst.Columns[1].HeaderCell.Value = "Name";
                dgv_std_bookhst.Columns[5].HeaderCell.Value = "Surname";
                dgv_std_bookhst.Columns[6].HeaderCell.Value = "Lend Date";
                dgv_std_bookhst.Columns[7].HeaderCell.Value = "Last Date";
                dgv_std_bookhst.Columns[8].HeaderCell.Value = "Hand Date";
                dgv_std_bookhst.Columns[9].HeaderCell.Value = "Late Fee";
                dgv_std_bookhst.Columns[10].HeaderCell.Value = "Hand Status";
                #endregion
            }
        }

        //İlgili öğrenciyi sağlanan bilgilerle günceller
        private void materialBtn_update_Click(object sender, EventArgs e)
        {
            try
            {
                std_entity.student_ID = Int32.Parse(materialTxt_update_ID.Text);
                std_entity.student_name = materialTxt_update_name.Text;
                std_entity.student_surname = materialTxt_update_sname.Text;
                std_entity.student_mail = materialTxt_update_mail.Text;
                std.UpdateStudent(std_entity);
                MessageBox.Show("Student has successfully updated.");
                UpdateTable();
            }
            catch (OleDbException)
            {
                MessageBox.Show("Please fill all the areas accurately.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //İlgili öğrenciyi ID numarasına göre siler
        private void materialBtn_delete_Click(object sender, EventArgs e)
        {
            std.DeleteStudent(Int32.Parse(materialTxt_delete.Text));
            MessageBox.Show("Student has successfully deleted.");
            UpdateTable();
        }

        //Arama kutuları fonksiyonları
        private void materialTxt_ListSearch_TextChanged(object sender, EventArgs e)
        {
            dgv_std_list.DataSource = std.SearchStudent(materialCBox_ListSearch.Text, materialTxt_ListSearch.Text);
        }
        private void materialTxt_UpdSearch_TextChanged(object sender, EventArgs e)
        {
            dgv_std_update.DataSource = std.SearchStudent(materialCBox_UpdSearch.Text, materialTxt_UpdSearch.Text);
        }

        private void materialTxt_HstSearch_TextChanged(object sender, EventArgs e)
        {
            dgv_std_history.DataSource = std.SearchStudent(materialCBox_HstSearch.Text, materialTxt_HstSearch.Text);
        }

        private void materialTxt_DelSearch_TextChanged_1(object sender, EventArgs e)
        {
            dgv_std_delete.DataSource = std.SearchStudent("student_ID", materialTxt_DelSearch.Text);
        }
    }
}
