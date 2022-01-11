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
    public partial class Books : MaterialForm
    {
        private Book_BLL bk;
        private Book_Entity bk_entity;
        private LH_BLL lh;
        private int ClickCount = 0;
        public Books()
        {
            bk = new Book_BLL();
            bk_entity = new Book_Entity();
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
        
        private void Books_Load(object sender, EventArgs e)
        {
            //DataGridView veri ataması ve sütun isimleri kontrolleri
            dgv_books_list.DataSource = bk.GetBooks();
            #region DATAGRIDVIEW COLUMN NAMES & FORMATTING
            dgv_books_list.Columns[0].HeaderCell.Value = "ISBN";
            dgv_books_list.Columns[1].HeaderCell.Value = "Name";
            dgv_books_list.Columns[2].HeaderCell.Value = "Category";
            dgv_books_list.Columns[3].HeaderCell.Value = "Pages";
            dgv_books_list.Columns[4].HeaderCell.Value = "Year";
            dgv_books_list.Columns[5].HeaderCell.Value = "Writer";
            dgv_books_list.Columns[6].HeaderCell.Value = "Publisher";
            dgv_books_list.Columns[3].FillWeight = 40;
            dgv_books_list.Columns[4].FillWeight = 40;
            #endregion

            dgv_books_upd.DataSource = bk.GetBooks();
            #region DATAGRIDVIEW COLUMN NAMES
            dgv_books_upd.Columns[0].HeaderCell.Value = "ISBN";
            dgv_books_upd.Columns[1].HeaderCell.Value = "Name";
            dgv_books_upd.Columns[2].HeaderCell.Value = "Category";
            dgv_books_upd.Columns[3].HeaderCell.Value = "Pages";
            dgv_books_upd.Columns[4].HeaderCell.Value = "Year";
            dgv_books_upd.Columns[5].HeaderCell.Value = "Writer";
            dgv_books_upd.Columns[6].HeaderCell.Value = "Publisher";
            #endregion

            dgv_books_rmv.DataSource = bk.GetBooks();
            #region DATAGRIDVIEW COLUMN NAMES
            dgv_books_rmv.Columns[0].HeaderCell.Value = "ISBN";
            dgv_books_rmv.Columns[1].HeaderCell.Value = "Name";
            dgv_books_rmv.Columns[2].HeaderCell.Value = "Category";
            dgv_books_rmv.Columns[3].HeaderCell.Value = "Pages";
            dgv_books_rmv.Columns[4].HeaderCell.Value = "Year";
            dgv_books_rmv.Columns[5].HeaderCell.Value = "Writer";
            dgv_books_rmv.Columns[6].HeaderCell.Value = "Publisher";
            #endregion

            dgv_books_hst.DataSource = bk.GetBooks();
            #region DATAGRIDVIEW COLUMN NAMES
            dgv_books_hst.Columns[0].HeaderCell.Value = "ISBN";
            dgv_books_hst.Columns[1].HeaderCell.Value = "Name";
            dgv_books_hst.Columns[2].HeaderCell.Value = "Category";
            dgv_books_hst.Columns[3].HeaderCell.Value = "Pages";
            dgv_books_hst.Columns[4].HeaderCell.Value = "Year";
            dgv_books_hst.Columns[5].HeaderCell.Value = "Writer";
            dgv_books_hst.Columns[6].HeaderCell.Value = "Publisher";
            #endregion

            //Ekleme ve güncelleme sayfalarında ComboBox güncellemesi
            UpdateComboBox();
        }

        //Kategori, Yazar, Yayınevi ekleme kısmının + sembolü ile kontrolü
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //Döngüsel görünüm
            ClickCount = ClickCount + 1;

            if (ClickCount % 2 == 0)
            {
                groupBox_radiobtn.Visible = false;
                materialBtn_AddCWP.Visible = false;
                materialTxt_plus.Visible = false;
            }
            else if (ClickCount % 2 != 0)
            {
                groupBox_radiobtn.Visible = true;
                materialBtn_AddCWP.Visible = true;
                materialTxt_plus.Visible = true;
            }
            Application.DoEvents();
        }

        //Kategori, Yazar, Yayınevi ekleme
        private void materialBtn_AddCWP_Click(object sender, EventArgs e)
        {
            //Radyo butonunda seçilen değer kontrolü
            if (materialRadiobtn_category.Checked == true)
            {
                bk_entity.book_category = materialTxt_plus.Text;

                if (materialTxt_plus.Text.Length == 0 || materialTxt_plus.Text == "Add Category")
                {
                    MessageBox.Show("Please fill the area.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    bk.AddCategory(bk_entity);
                }
                materialCBox_add_category.DataSource = bk.GetCategories();
            }
            if (materialRadioBtn_writer.Checked == true)
            {
                bk_entity.book_writer = materialTxt_plus.Text;

                if (materialTxt_plus.Text.Length == 0 || materialTxt_plus.Text == "Add Writer")
                {
                    MessageBox.Show("Please fill the area.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    bk.AddWriter(bk_entity);
                }
                materialCBox_add_writer.DataSource = bk.GetWriters();
            }
            if (materialRadioBtn_publisher.Checked == true)
            {
                bk_entity.book_publisher = materialTxt_plus.Text;

                if (materialTxt_plus.Text.Length == 0 || materialTxt_plus.Text == "Add Publisher")
                {
                    MessageBox.Show("Please fill the area.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    bk.AddPublisher(bk_entity);
                }
                materialCBox_add_publisher.DataSource = bk.GetPublishers();
            }
        }

        //Radyo butonu seçimi kontrolü
        private void materialRadiobtn_category_CheckedChanged(object sender, EventArgs e)
        {
            materialTxt_plus.Text = "Add Category";
        }

        private void materialRadioBtn_writer_CheckedChanged(object sender, EventArgs e)
        {
            materialTxt_plus.Text = "Add Writer";
        }

        private void materialRadioBtn_publisher_CheckedChanged(object sender, EventArgs e)
        {
            materialTxt_plus.Text = "Add Publisher";
        }

        //Değişiklik yapıldıktan sonra tabloların güncellenmesi sağlanır
        private void UpdateTable()
        {
            dgv_books_list.DataSource = bk.GetBooks();
            dgv_books_upd.DataSource = bk.GetBooks();
            dgv_books_rmv.DataSource = bk.GetBooks();
        }

        private void UpdateComboBox()
        {
            materialCBox_add_category.DataSource = bk.GetCategories();
            materialCBox_add_writer.DataSource = bk.GetWriters();
            materialCBox_add_publisher.DataSource = bk.GetPublishers();

            materialCbox_UpdCategory.DataSource = bk.GetCategories();
            materialCBox_UpdWriter.DataSource = bk.GetWriters();
            materialCBox_UpdPublisher.DataSource = bk.GetPublishers();
        }

        //Formdaki bilgiler Entity objesine atanır ve ekleme sağlanır
        private void materialBtn_add_submit_Click(object sender, EventArgs e)
        {
            try
            {
                bk_entity.book_ISBN = materialTxt_add_ISBN.Text;
                bk_entity.book_name = materialTxt_add_name.Text;
                bk_entity.book_category = materialCBox_add_category.Text;
                bk_entity.book_page = Int32.Parse(materialTxt_add_page.Text);
                bk_entity.book_year = Int32.Parse(materialTxt_add_year.Text);
                bk_entity.book_writer = materialCBox_add_writer.Text;
                bk_entity.book_publisher = materialCBox_add_publisher.Text;
                bk.AddBook(bk_entity);
                MessageBox.Show("Book has successfully added.");
                UpdateTable();
            }
            catch (OleDbException)
            {
                MessageBox.Show("Please fill all the areas accurately.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //Silme ekranında tıklanan hücredeki kitap ISBN bilgisini textboxa geçirir
        private void dataGridView_Remove_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgv_books_rmv.Rows[e.RowIndex];
                materialTxt_delete.Text = row.Cells[0].Value.ToString();
            }
        }

        //Tıklanan hücredeki kitap bilgilerini textboxlara geçirir
        private void dataGridView_update_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgv_books_upd.Rows[e.RowIndex];
                materialTxt_uISBN.Text = row.Cells[0].Value.ToString();
                materialTxt_uname.Text = row.Cells[1].Value.ToString();
                materialTxt_upage.Text = row.Cells[3].Value.ToString();
                materialTxt_uyear.Text = row.Cells[4].Value.ToString();
                materialCbox_UpdCategory.Text = row.Cells[2].Value.ToString();
                materialCBox_UpdWriter.Text = row.Cells[5].Value.ToString();
                materialCBox_UpdPublisher.Text = row.Cells[6].Value.ToString();
            }
        }

        //İlgili kitabı ISBN numarasına göre siler
        private void materialBtn_delete_Click(object sender, EventArgs e)
        {
            bk.DeleteBook(materialTxt_delete.Text);
            MessageBox.Show("Book has successfully deleted.");
            UpdateTable();
        }

        //İlgili kitabı sağlanan bilgilerle günceller
        private void materialBtn_update_Click(object sender, EventArgs e)
        {
            try
            {
                bk_entity.book_ISBN = materialTxt_uISBN.Text;
                bk_entity.book_name = materialTxt_uname.Text;
                bk_entity.book_category = materialCbox_UpdCategory.Text;
                bk_entity.book_page = Int32.Parse(materialTxt_upage.Text);
                bk_entity.book_year = Int32.Parse(materialTxt_uyear.Text);
                bk_entity.book_writer = materialCBox_UpdWriter.Text;
                bk_entity.book_publisher = materialCBox_UpdPublisher.Text;
                bk.UpdateBook(bk_entity);
                MessageBox.Show("Book has successfully updated.");
                UpdateTable();
            }
            catch (FormatException)
            {
                MessageBox.Show("Fill the areas accurately.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //Tıklanan hücredeki kitabın öğrenciler ile alakalı geçmiş bilgilerini sağlar
        private void dataGrid_BookHistory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgv_books_hst.Rows[e.RowIndex];
                dgv_books_stdhst.DataSource = lh.GetBookHistory(row.Cells[0].Value.ToString());

                #region DATAGRIDVIEW COLUMN NAMES & FORMATTING
                dgv_books_stdhst.Columns["lh_ID"].Visible = false;
                dgv_books_stdhst.Columns["book_ISBN"].Visible = false;
                dgv_books_stdhst.Columns["book_name"].Visible = false;
                dgv_books_stdhst.Columns[3].HeaderCell.Value = "ID";
                dgv_books_stdhst.Columns[4].HeaderCell.Value = "Name";
                dgv_books_stdhst.Columns[5].HeaderCell.Value = "Surname";
                dgv_books_stdhst.Columns[6].HeaderCell.Value = "Lend Date";
                dgv_books_stdhst.Columns[7].HeaderCell.Value = "Last Date";
                dgv_books_stdhst.Columns[8].HeaderCell.Value = "Hand Date";
                dgv_books_stdhst.Columns[9].HeaderCell.Value = "Late Fee";
                dgv_books_stdhst.Columns[10].HeaderCell.Value = "Hand Status";
                #endregion
            }
        }

        //Arama kutuları fonksiyonları
        private void materialTxt_ListSearch_TextChanged(object sender, EventArgs e)
        {
            dgv_books_list.DataSource = bk.SearchBook(materialCBox_ListSearch.Text, materialTxt_ListSearch.Text);
        }

        private void materialTxt_HstSearch_TextChanged(object sender, EventArgs e)
        {
            dgv_books_hst.DataSource = bk.SearchBook(materialCBox_HstSearch.Text, materialTxt_HstSearch.Text);
        }

        private void materialTxt_UpdSearch_TextChanged(object sender, EventArgs e)
        {
            dgv_books_upd.DataSource = bk.SearchBook(materialCBox_UpdSearch.Text, materialTxt_UpdSearch.Text);
        }

        private void materialTxt_RmvSearch_TextChanged(object sender, EventArgs e)
        {
            dgv_books_rmv.DataSource = bk.SearchBook("book_ISBN", materialTxt_RmvSearch.Text);
        }

        //MaterialSkin2'nin ComboBox kontrollerinde textboxların 
        //DataGridView CellClick olayı ile güncellenmeme sorununa geçici çözüm
        #region TEMP FIX FOR MATERIALSKIN2 COMBOBOX TEXT UPDATE
        private void materialCbox_UpdCategory_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            if (e.Index > -1)
            {
                e.Graphics.FillRectangle(SkinManager.BackgroundBrush, e.Bounds);
                if (e.State.HasFlag(DrawItemState.Focus))
                {
                    e.Graphics.FillRectangle(SkinManager.BackgroundHoverBrush, e.Bounds);
                }
                using (NativeTextRenderer NativeText = new NativeTextRenderer(e.Graphics))
                {
                    NativeText.DrawTransparentText(
                    materialCbox_UpdCategory.Items[e.Index].ToString(),
                    SkinManager.getFontByType(MaterialSkinManager.fontType.Subtitle1),
                    SkinManager.TextHighEmphasisColor,
                    new Point(e.Bounds.Location.X + SkinManager.FORM_PADDING, e.Bounds.Location.Y),
                    new Size(e.Bounds.Size.Width - SkinManager.FORM_PADDING * 2, e.Bounds.Size.Height),
                    NativeTextRenderer.TextAlignFlags.Left | NativeTextRenderer.TextAlignFlags.Middle); ;
                }
            }
        }

        private void materialCBox_UpdPublisher_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            if (e.Index > -1)
            {
                e.Graphics.FillRectangle(SkinManager.BackgroundBrush, e.Bounds);
                if (e.State.HasFlag(DrawItemState.Focus))
                {
                    e.Graphics.FillRectangle(SkinManager.BackgroundHoverBrush, e.Bounds);
                }
                using (NativeTextRenderer NativeText = new NativeTextRenderer(e.Graphics))
                {
                    NativeText.DrawTransparentText(
                    materialCBox_UpdPublisher.Items[e.Index].ToString(),
                    SkinManager.getFontByType(MaterialSkinManager.fontType.Subtitle1),
                    SkinManager.TextHighEmphasisColor,
                    new Point(e.Bounds.Location.X + SkinManager.FORM_PADDING, e.Bounds.Location.Y),
                    new Size(e.Bounds.Size.Width - SkinManager.FORM_PADDING * 2, e.Bounds.Size.Height),
                    NativeTextRenderer.TextAlignFlags.Left | NativeTextRenderer.TextAlignFlags.Middle); ;
                }
            }
        }

        private void materialCBox_UpdWriter_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            if (e.Index > -1)
            {
                e.Graphics.FillRectangle(SkinManager.BackgroundBrush, e.Bounds);
                if (e.State.HasFlag(DrawItemState.Focus))
                {
                    e.Graphics.FillRectangle(SkinManager.BackgroundHoverBrush, e.Bounds);
                }
                using (NativeTextRenderer NativeText = new NativeTextRenderer(e.Graphics))
                {
                    NativeText.DrawTransparentText(
                    materialCBox_UpdWriter.Items[e.Index].ToString(),
                    SkinManager.getFontByType(MaterialSkinManager.fontType.Subtitle1),
                    SkinManager.TextHighEmphasisColor,
                    new Point(e.Bounds.Location.X + SkinManager.FORM_PADDING, e.Bounds.Location.Y),
                    new Size(e.Bounds.Size.Width - SkinManager.FORM_PADDING * 2, e.Bounds.Size.Height),
                    NativeTextRenderer.TextAlignFlags.Left | NativeTextRenderer.TextAlignFlags.Middle); ;
                }
            }
        }
        #endregion
    }
}
