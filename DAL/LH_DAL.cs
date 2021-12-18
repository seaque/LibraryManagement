using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.Data.OleDb;
using System.Diagnostics;

namespace DAL
{
    public class LH_DAL
    {
        private DBConnection DBConn;

        //Yapıcı fonksiyonda DBConnection sınıfından nesne oluşturuluyor
        public LH_DAL()
        {
            DBConn = new DBConnection();
        }

        //Kitap ödünç ve iade ile alakalı tablodaki değerleri getirir, alakalı tabloda eksik olan
        //sütunları da yansıtabilmek için tablolar sorguda INNER JOIN ile birleştirilir
        public List<LH_Entity> GetRecords()
        {
            OleDbCommand cmd = DBConn.GetOleDbCommand();
            cmd.CommandText = "select LendHand.lh_ID, Student.student_ID, Student.student_name, Student.student_surname, " +
                              "Book.book_ISBN, Book.book_name, LendHand.lend_date, LendHand.hand_date, LendHand.last_date, LendHand.late_fee, LendHand.hand_status " +
                              "from Student INNER JOIN (Book INNER JOIN LendHand ON Book.book_ISBN = LendHand.book_ISBN) " +
                              "ON Student.student_ID = LendHand.student_ID";

            List<LH_Entity> lendhand = new List<LH_Entity>();
            OleDbDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                LH_Entity lh = new LH_Entity();
                lh.lh_ID = Int32.Parse(rdr["lh_ID"].ToString());
                lh.student_ID = Int32.Parse(rdr["student_ID"].ToString());
                lh.student_name = rdr["student_name"].ToString();
                lh.student_surname = rdr["student_surname"].ToString();
                lh.book_ISBN = rdr["book_ISBN"].ToString();
                lh.book_name = rdr["book_name"].ToString();
                lh.lend_date = rdr["lend_date"].ToString().Substring(0, 10);
                lh.last_date = rdr["last_date"].ToString().Substring(0, 10);
                lh.hand_date = rdr["hand_date"].ToString().Length > 0 ? rdr["hand_date"].ToString().Substring(0,10) : rdr["hand_date"].ToString();
                lh.hand_status = Boolean.Parse(rdr["hand_status"].ToString());
                lh.late_fee = Int32.Parse(rdr["late_fee"].ToString());

                lendhand.Add(lh);
            }
            //Veritabanı bağlantısı kapatılıyor
            rdr.Close();
            cmd.Connection.Close();
            return lendhand;
        }

        //İlgili kitaba ait geçmişi, kitabı almış kişileri gösterir
        public List<LH_Entity> GetBookHistory(string book_ISBN)
        {
            string query = "SELECT Book.book_ISBN, Book.book_name, Student.student_ID, Student.student_name, Student.student_surname, " +
                           "LendHand.lend_date, LendHand.last_date, LendHand.hand_date, LendHand.hand_status " +
                           "FROM Student INNER JOIN(Book INNER JOIN LendHand ON Book.book_ISBN = LendHand.book_ISBN) " +
                           "ON Student.student_ID = LendHand.student_ID WHERE Book.book_ISBN = @ISBN";
            OleDbCommand cmd = DBConn.GetOleDbCommand();
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@ISBN", book_ISBN);

            List<LH_Entity> lendhand = new List<LH_Entity>();
            OleDbDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                LH_Entity lh = new LH_Entity();
                lh.book_ISBN = rdr["book_ISBN"].ToString();
                lh.book_name = rdr["book_name"].ToString();
                lh.student_ID = Int32.Parse(rdr["student_ID"].ToString());
                lh.student_name = rdr["student_name"].ToString();
                lh.student_surname = rdr["student_surname"].ToString();
                lh.lend_date = rdr["lend_date"].ToString().Substring(0, 10);
                lh.last_date = rdr["last_date"].ToString().Substring(0, 10);
                lh.hand_date = rdr["hand_date"].ToString().Length > 0 ? rdr["hand_date"].ToString().Substring(0, 10) : rdr["hand_date"].ToString();
                lh.hand_status = Boolean.Parse(rdr["hand_status"].ToString());
                lendhand.Add(lh);
            }
            //İşlem tamamlandıktan sonra db bağlantısı kapatılıyor
            rdr.Close();
            cmd.Connection.Close();
            return lendhand;
        }

        //İlgili öğrencinin aldığı veya verdiği kitapları gösterir
        public List<LH_Entity> GetStudentHistory(int student_ID)
        {
            string query = "SELECT Student.student_ID, Book.book_ISBN, Book.book_name, " +
                           "LendHand.lend_date, LendHand.last_date, LendHand.hand_date, LendHand.late_fee, LendHand.hand_status " +
                           "FROM Student INNER JOIN(Book INNER JOIN LendHand ON Book.book_ISBN = LendHand.book_ISBN) " +
                           "ON Student.student_ID = LendHand.student_ID WHERE LendHand.student_ID = @ID; ";
            OleDbCommand cmd = DBConn.GetOleDbCommand();
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@ID", student_ID);

            List<LH_Entity> lendhand = new List<LH_Entity>();
            OleDbDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                LH_Entity lh = new LH_Entity();
                lh.student_ID = Int32.Parse(rdr["student_ID"].ToString());
                lh.book_ISBN = rdr["book_ISBN"].ToString();
                lh.book_name = rdr["book_name"].ToString();
                lh.lend_date = rdr["lend_date"].ToString().Substring(0, 10);
                lh.last_date = rdr["last_date"].ToString().Substring(0, 10);
                lh.hand_date = rdr["hand_date"].ToString().Length > 0 ? rdr["hand_date"].ToString().Substring(0, 10) : rdr["hand_date"].ToString();
                lh.late_fee = Int32.Parse(rdr["late_fee"].ToString());
                lh.hand_status = Boolean.Parse(rdr["hand_status"].ToString());
                lendhand.Add(lh);
            }
            //İşlem tamamlandıktan sonra db bağlantısı kapatılıyor
            rdr.Close();
            cmd.Connection.Close();
            return lendhand;
        }

        //Kitabı öğrenciye ödünç verir
        public void AddRecord(LH_Entity lh)
        {
            string query = "Insert into LendHand (book_ISBN, student_ID) values" +
                           "(@ISBN, @STDID)";
            OleDbCommand cmd = DBConn.GetOleDbCommand();
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@ISBN", lh.book_ISBN);
            cmd.Parameters.AddWithValue("@STDID", lh.student_ID);
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        //Kitap öğrenciden geri alınır
        public void HandBook(int lh_ID)
        {
            string query = "UPDATE Book INNER JOIN LendHand ON Book.book_ISBN = LendHand.book_ISBN " +
                           "SET LendHand.hand_date = Date(), LendHand.hand_status = True " +
                           "WHERE(((LendHand.lh_ID) = @ID));";
            OleDbCommand cmd = DBConn.GetOleDbCommand();
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@ID", lh_ID);
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        //Önceden verilmiş olup alınan kitapların toplamını döndürür
        public int CountHandedBooks()
        {
            int handed_books = 0;
            OleDbCommand cmd = DBConn.GetOleDbCommand();
            cmd.CommandText = "SELECT Count(*) FROM LendHand WHERE hand_status = True";
            OleDbDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                handed_books = Int32.Parse(rdr[0].ToString());
            }
            return handed_books;
        }

        //Ödünç verme son tarihini geçirmiş öğrenciler için ilgili tabloda
        //sütunu güncelleyerek her gün 1₺ ceza parası ekler
        public void SetLateFee()
        {
            string query = "UPDATE LendHand SET LendHand.late_Fee = IIf ([LendHand]![lend_date] > [LendHand]![last_date], " +
                           "[LendHand]![hand_date] -[LendHand]![last_date], IIf(Now() >[LendHand]![last_date], Now() -[LendHand]![last_date] - 1, 0))";
            OleDbCommand cmd = DBConn.GetOleDbCommand();
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        //Ödünç alınmış ve verilmiş kitapların listesini döndürür
        public List<LH_Entity> SearchRecords(string column, string key)
        {
            OleDbCommand cmd = DBConn.GetOleDbCommand();
            if (column == "hand_status" && key == null)
            {
                cmd.CommandText = String.Format("select LendHand.lh_ID, Student.student_ID, Student.student_name, Student.student_surname, " +
                            "Book.book_ISBN, Book.book_name, LendHand.lend_date, LendHand.hand_date, LendHand.last_date, LendHand.late_fee, LendHand.hand_status " +
                            "from Student INNER JOIN (Book INNER JOIN LendHand ON Book.book_ISBN = LendHand.book_ISBN) " +
                            "ON Student.student_ID = LendHand.student_ID WHERE LendHand.hand_status", column, key);
            }
            //Alanlar foreign key içerdiğinden sorguda seçilecek tablo kod kısmında belirlenir
            else if (column == "book_ISBN" || column == "student_ID")
            {
                cmd.CommandText = String.Format("select LendHand.lh_ID, Student.student_ID, Student.student_name, Student.student_surname, " +
                            "Book.book_ISBN, Book.book_name, LendHand.lend_date, LendHand.hand_date, LendHand.last_date, LendHand.late_fee, LendHand.hand_status " +
                            "from Student INNER JOIN (Book INNER JOIN LendHand ON Book.book_ISBN = LendHand.book_ISBN) " +
                            "ON Student.student_ID = LendHand.student_ID WHERE LendHand.{0} LIKE '%{1}%'", column, key);
            }
            else
            {
                cmd.CommandText = String.Format("select LendHand.lh_ID, Student.student_ID, Student.student_name, Student.student_surname, " +
                            "Book.book_ISBN, Book.book_name, LendHand.lend_date, LendHand.hand_date, LendHand.last_date, LendHand.late_fee, LendHand.hand_status " +
                            "from Student INNER JOIN (Book INNER JOIN LendHand ON Book.book_ISBN = LendHand.book_ISBN) " +
                            "ON Student.student_ID = LendHand.student_ID WHERE {0} LIKE '%{1}%'", column, key);
            }
            List<LH_Entity> lendhand = new List<LH_Entity>();
            OleDbDataReader rdr = cmd.ExecuteReader();
            Debug.WriteLine(column);
            Debug.WriteLine(key);
            Debug.WriteLine(cmd.CommandText);


            while (rdr.Read())
            {
                LH_Entity lh = new LH_Entity();
                lh.lh_ID = Int32.Parse(rdr["lh_ID"].ToString());
                lh.student_ID = Int32.Parse(rdr["student_ID"].ToString());
                lh.student_name = rdr["student_name"].ToString();
                lh.student_surname = rdr["student_surname"].ToString();
                lh.book_ISBN = rdr["book_ISBN"].ToString();
                lh.book_name = rdr["book_name"].ToString();
                lh.lend_date = rdr["lend_date"].ToString().Substring(0, 10);
                lh.last_date = rdr["last_date"].ToString().Substring(0, 10);
                lh.hand_date = rdr["hand_date"].ToString().Length > 0 ? rdr["hand_date"].ToString().Substring(0, 10) : rdr["hand_date"].ToString();
                lh.hand_status = Boolean.Parse(rdr["hand_status"].ToString());
                lh.late_fee = Int32.Parse(rdr["late_fee"].ToString());

                lendhand.Add(lh);
            }
            //İşlem tamamlandıktan sonra veritabanı bağlantısı kapatılıyor
            rdr.Close();
            cmd.Connection.Close();
            return lendhand;
        }
    }
}
