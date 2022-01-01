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
using System.Data.OleDb;

namespace LibraryApp
{
    public partial class LendHand : MaterialForm
    {
        private Book_BLL bk;
        private Student_BLL std;
        private LH_BLL lh;

        public LendHand()
        {
            bk = new Book_BLL();
            std = new Student_BLL();
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

        private void LendHand_Load(object sender, EventArgs e)
        {
            dgv_lh_books.DataSource = bk.GetBooks();
            #region DATAGRIDVIEW COLUMN NAMES
            dgv_lh_books.Columns[0].HeaderCell.Value = "ISBN";
            dgv_lh_books.Columns[1].HeaderCell.Value = "Name";
            dgv_lh_books.Columns[2].HeaderCell.Value = "Category";
            dgv_lh_books.Columns[3].HeaderCell.Value = "Pages";
            dgv_lh_books.Columns[4].HeaderCell.Value = "Year";
            dgv_lh_books.Columns[5].HeaderCell.Value = "Writer";
            dgv_lh_books.Columns[6].HeaderCell.Value = "Publisher";
            #endregion 

            dgv_lh_students.DataSource = std.GetStudents();
            #region DATAGRIDVIEW COLUMN NAMES & FORMATTING
            dgv_lh_students.Columns[0].HeaderCell.Value = "ID";
            dgv_lh_students.Columns[1].HeaderCell.Value = "Name";
            dgv_lh_students.Columns[2].HeaderCell.Value = "Surname";
            dgv_lh_students.Columns[3].HeaderCell.Value = "Mail";
            dgv_lh_students.Columns[0].FillWeight = 30;
            dgv_lh_students.Columns[1].FillWeight = 40;
            dgv_lh_students.Columns[2].FillWeight = 50;
            #endregion

            dgv_lh_list.DataSource = lh.GetRecords();
            #region DATAGRIDVIEW COLUMN NAMES
            dgv_lh_list.Columns[0].HeaderCell.Value = "ISBN";
            dgv_lh_list.Columns[1].HeaderCell.Value = "Book Name";
            dgv_lh_list.Columns[2].HeaderCell.Value = "Lend ID";
            dgv_lh_list.Columns[2].DisplayIndex = 0; //ID sütununu en sola getirir
            dgv_lh_list.Columns[3].HeaderCell.Value = "Student ID";
            dgv_lh_list.Columns[4].HeaderCell.Value = "Name";
            dgv_lh_list.Columns[5].HeaderCell.Value = "Surname";
            dgv_lh_list.Columns[6].HeaderCell.Value = "Lend Date";
            dgv_lh_list.Columns[7].HeaderCell.Value = "Last Date";
            dgv_lh_list.Columns[8].HeaderCell.Value = "Hand Date";
            dgv_lh_list.Columns[9].HeaderCell.Value = "Late Fee";
            dgv_lh_list.Columns[10].HeaderCell.Value = "Hand Status";
            #endregion

            dgv_hand.DataSource = lh.GetRecords();
            #region DATAGRIDVIEW COLUMN NAMES
            dgv_hand.Columns[0].HeaderCell.Value = "ISBN";
            dgv_hand.Columns[1].HeaderCell.Value = "Book Name";
            dgv_hand.Columns[2].HeaderCell.Value = "Lend ID";
            dgv_hand.Columns[2].DisplayIndex = 0; //ID sütununu en sola getirir
            dgv_hand.Columns[3].HeaderCell.Value = "Student ID";
            dgv_hand.Columns[4].HeaderCell.Value = "Name";
            dgv_hand.Columns[5].HeaderCell.Value = "Surname";
            dgv_hand.Columns[6].HeaderCell.Value = "Lend Date";
            dgv_hand.Columns[7].HeaderCell.Value = "Last Date";
            dgv_hand.Columns[8].HeaderCell.Value = "Hand Date";
            dgv_hand.Columns[9].HeaderCell.Value = "Late Fee";
            dgv_hand.Columns[10].HeaderCell.Value = "Hand Status";
            #endregion

            UpdateTable();
        }

        private void UpdateTable()
        {
            lh.SetLateFee();

            dgv_lh_list.DataSource = lh.GetRecords();
            dgv_lh_books.DataSource = bk.GetBooks();
            dgv_lh_students.DataSource = std.GetStudents();
            dgv_hand.DataSource = lh.GetRecords();

            ColorTable(dgv_hand);
            ColorTable(dgv_lh_list);
        }

        private void ColorTable(DataGridView dg)
        {
            DateTime now = DateTime.Now;

            for (int i = 0; i < dg.Rows.Count; i++)
            {
                DateTime date = Convert.ToDateTime(dg.Rows[i].Cells[7].Value.ToString());
                System.TimeSpan differ = date.Subtract(now);
                int value = Convert.ToInt32(differ.Days.ToString());
                
                if (Boolean.Parse(dg.Rows[i].Cells[10].Value.ToString()) == true)
                {
                    dg.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(80, 225, 60);
                }
                else if (value > 2)
                {
                    dg.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(242, 242, 242);
                }
                else if (value <= 2 && value >= 0)
                {
                    dg.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(250, 210, 10);
                }
                else if (value < 0)
                {
                    dg.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(250, 85, 85);
                }
            }
        }

        private void dgv_lh_students_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgv_lh_students.Rows[e.RowIndex];
                materialLabel_ID.Text = row.Cells[0].Value.ToString();
                materialLabel10.Text = row.Cells[1].Value.ToString();
                materialLabel11.Text = row.Cells[2].Value.ToString();
                materialLabel12.Text = row.Cells[3].Value.ToString();
            }
        }

        private void dgv_lh_books_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dgv_lh_books.Rows[e.RowIndex];
            materialLabel_ISBN.Text = row.Cells[0].Value.ToString();
            materialLabel16.Text = row.Cells[1].Value.ToString();
            materialLabel18.Text = row.Cells[2].Value.ToString();
            materialLabel20.Text = row.Cells[3].Value.ToString();
            materialLabel22.Text = row.Cells[4].Value.ToString();
            materialLabel24.Text = row.Cells[5].Value.ToString();
            materialLabel26.Text = row.Cells[6].Value.ToString();
        }

        private void materialTextBox1_TextChanged(object sender, EventArgs e)
        {
            #region LEGACY SEARCH

            /*dataGrid_land_students.CurrentCell = null;
            dataGrid_land_students.ClearSelection();
            dataGrid_land_students.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            try
            {
                foreach (DataGridViewRow row in dataGrid_land_students.Rows)
                {
                    var cellValue = row.Cells[0].Value;
                    if (cellValue != null && cellValue.ToString() == materialTextBox1.Text.ToUpper())
                    {
                        row.Selected = true;
                        row.Visible = true;
                    }
                    else
                        row.Visible = false;

                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }*/

            #endregion

            dgv_lh_students.DataSource = std.SearchStudent(materialCBox_LendSearchStd.Text, materialTxt_LendSearchStd.Text);
        }

        private void materialTextBox2_TextChanged(object sender, EventArgs e)
        {
            dgv_lh_books.DataSource = bk.SearchBook(materialCBox_LendSearchBook.Text, materialTxt_LendSearchBook.Text);
        }

        private void materialTextBox3_TextChanged(object sender, EventArgs e)
        {
            dgv_hand.DataSource = lh.SearchRecords(materialCBox_HandSearch.Text, materialTxt_HandSearch.Text);
        }
        private void materialCBox_list_filter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (materialCBox_list_filter.Text == "All")
                dgv_lh_list.DataSource = lh.GetRecords();
            if (materialCBox_list_filter.Text == "Green")
                dgv_lh_list.DataSource = lh.SearchRecords("hand_status", "true");
            if (materialCBox_list_filter.Text == "Red")
                dgv_lh_list.DataSource = lh.SearchRecords("hand_status", "false");
            else if (materialCBox_list_filter.Text == "Yellow")
                dgv_lh_list.DataSource = lh.SearchRecords("hand_status", "limbo");
        }

        private void materialCBox_filter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (materialCBox_filter.Text == "All")
                dgv_hand.DataSource = lh.GetRecords();
            if (materialCBox_filter.Text == "Green")
                dgv_hand.DataSource = lh.SearchRecords("hand_status", "true");
            if (materialCBox_filter.Text == "Red")
                dgv_hand.DataSource = lh.SearchRecords("hand_status", "false");
            else if (materialCBox_filter.Text == "Yellow")
                dgv_hand.DataSource = lh.SearchRecords("hand_status", "limbo");
        }

        private void materialTextBox4_TextChanged(object sender, EventArgs e)
        {
            dgv_lh_list.DataSource = lh.SearchRecords(materialCBox_ListSearch.Text, materialTxt_ListSearch.Text);
        }

        private void dgv_hand_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dgv_hand.Rows[e.RowIndex];

            if (Boolean.Parse(row.Cells[10].Value.ToString()) == true)
            {
                MessageBox.Show("Already handed.");
            }
            else
            {
                materialLabel32.Text = row.Cells[3].Value.ToString();
                materialLabel33.Text = row.Cells[4].Value.ToString();
                materialLabel34.Text = row.Cells[5].Value.ToString();
                materialLabel35.Text = row.Cells[0].Value.ToString();
                materialLabel36.Text = row.Cells[1].Value.ToString();
                materialLabel38.Text = row.Cells[2].Value.ToString();
            }
        }

        private void materialBtn_lend_Click(object sender, EventArgs e)
        {
            LH_Entity lh_entity = new LH_Entity();
            try
            {
                lh_entity.book_ISBN = materialLabel_ISBN.Text;
                lh_entity.student_ID = Int32.Parse(materialLabel_ID.Text);
                lh.AddRecord(lh_entity);
                MessageBox.Show("Book has successfully lent.");
                UpdateTable();
            }
            catch (FormatException)
            {
                MessageBox.Show("Select both book and student.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void materialBtn_hand_Click(object sender, EventArgs e)
        {
            try
            {
                lh.HandBook(Int32.Parse(materialLabel38.Text));
                MessageBox.Show("Book has successfully handed.");
                UpdateTable();
            }
            catch (FormatException)
            {
                MessageBox.Show("Select a record.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgv_hand_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            ColorTable(dgv_hand);
        }

        private void dgv_lh_list_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            ColorTable(dgv_lh_list);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            dgv_hand.DataSource = lh.GetRecords();
            materialCBox_filter.Text = "All";
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            dgv_lh_list.DataSource = lh.GetRecords();
            materialCBox_filter.Text = "All";
        }
    }
}
