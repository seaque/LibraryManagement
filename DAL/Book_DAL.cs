﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.Data.OleDb;

namespace DAL
{
    public class Book_DAL
    {
        private DBConnection DBConn;
        //Yapıcı fonksiyonda DBConnection sınıfından nesne oluşturuluyor
        public Book_DAL()
        {
            DBConn = new DBConnection();
        }

        //Entity tipinden değişken alan listeye sorgu ile veri çekilir
        //ve fonksiyona geri döndürür
        public List<Book_Entity> GetBooks()
        {
            OleDbCommand cmd = DBConn.GetOleDbCommand();
            cmd.CommandText = "select * from Book;";
            List<Book_Entity> book = new List<Book_Entity>();
            OleDbDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                Book_Entity bk = new Book_Entity();
                bk.book_ISBN = rdr["book_ISBN"].ToString();
                bk.book_name = rdr["book_name"].ToString();
                bk.book_category = rdr["book_category"].ToString();
                bk.book_page = Int32.Parse(rdr["book_page"].ToString());
                bk.book_year = Int32.Parse(rdr["book_year"].ToString());
                bk.book_writer = rdr["book_writer"].ToString();
                bk.book_publisher = rdr["book_publisher"].ToString();
                book.Add(bk);
            }
            //İşlem tamamlandıktan sonra veritabanı bağlantısı kapatılıyor
            rdr.Close();
            cmd.Connection.Close();
            return book;
        }

        //Kitap tablosundaki Kategori sütununda bulunan değerleri
        //String listesi biçiminde geri döndürür
        public List<String> GetCategories()
        {
            var category_list = new List<String>();
            OleDbCommand cmd = DBConn.GetOleDbCommand();
            cmd.CommandText = "select book_category from Category";
            OleDbDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                category_list.Add(rdr["book_category"].ToString());
            }
            return category_list;
        }

        //Kitap tablosundaki Yayıncı sütununda bulunan değerleri
        //String listesi biçiminde geri döndürür
        public List<String> GetPublishers()
        {
            var publisher_list = new List<String>();
            OleDbCommand cmd = DBConn.GetOleDbCommand();
            cmd.CommandText = "select publisher_name from Publisher";
            OleDbDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                publisher_list.Add(rdr["publisher_name"].ToString());
            }
            return publisher_list;
        }

        //Kitap tablosundaki Yazar sütununda bulunan değerleri
        //String listesi biçiminde geri döndürür
        public List<String> GetWriters()
        {
            var writer_list = new List<String>();
            OleDbCommand cmd = DBConn.GetOleDbCommand();
            cmd.CommandText = "select writer_name from Writer";
            OleDbDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                writer_list.Add(rdr["writer_name"].ToString());
            }
            return writer_list;
        }

        //Tüm kitapları sayar
        public int CountBooks()
        {
            int book_count = 0;
            OleDbCommand cmd = DBConn.GetOleDbCommand();
            cmd.CommandText = "SELECT COUNT(*) FROM Book";
            OleDbDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                book_count = Int32.Parse(rdr[0].ToString());
            }
            return book_count;
        }

        //Book_Entity tipinden değer alan ekleme fonksiyonunda
        //sorgu aracılığıyla değişkenlere değerler atanarak ekleme sağlanır
        public void AddBook(Book_Entity book)
        {
            string query = "Insert into Book (book_ISBN, book_name, book_category, book_page, book_year, book_writer, book_publisher) values" +
                           "(@ISBN, @NAME, @CATEGORY, @PAGE, @YEAR, @WRITER, @PUBLISHER)";
            OleDbCommand cmd = DBConn.GetOleDbCommand();
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@ISBN", book.book_ISBN);
            cmd.Parameters.AddWithValue("@NAME", book.book_name);
            cmd.Parameters.AddWithValue("@CATEGORY", book.book_category);
            cmd.Parameters.AddWithValue("@PAGE", book.book_page);
            cmd.Parameters.AddWithValue("@YEAR", book.book_year);
            cmd.Parameters.AddWithValue("@WRITER", book.book_writer);
            cmd.Parameters.AddWithValue("@PUBLISHER", book.book_publisher);
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        //Book_Entity tipinden değer alan fonksiyonda sorgu aracılığıyla
        //değişkenlere değerler atanarak Kategori eklemesi sağlanır
        public void AddCategory(Book_Entity book)
        {
            string query = "Insert into Category (book_category) values (@CATEGORY)";
            OleDbCommand cmd = DBConn.GetOleDbCommand();
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@CATEGORY", book.book_category);
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        //Book_Entity tipinden değer alan fonksiyonda sorgu aracılığıyla
        //değişkenlere değerler atanarak Yazar eklemesi sağlanır
        public void AddWriter(Book_Entity book)
        {
            string query = "Insert into Writer (writer_name) values (@NAME)";
            OleDbCommand cmd = DBConn.GetOleDbCommand();
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@NAME", book.book_writer);
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        //Book_Entity tipinden değer alan fonksiyonda sorgu aracılığıyla
        //değişkenlere değerler atanarak Yayıncı eklemesi sağlanır
        public void AddPublisher(Book_Entity book)
        {
            string query = "Insert into Publisher (publisher_name) values (@NAME)";
            OleDbCommand cmd = DBConn.GetOleDbCommand();
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@NAME", book.book_publisher);
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        //Book_Entity tipinden değer alan güncelleme fonksiyonunda
        //sorgu aracılığıyla değişkenlere değerler atanarak güncelleme sağlanır
        public void UpdateBook(Book_Entity book)
        {
            OleDbCommand cmd = DBConn.GetOleDbCommand();
            string query = "Update Book SET Book.book_ISBN = @ISBN, " +
                           "Book.book_name = @NAME, " +
                           "Book.book_page = @PAGE, " +
                           "Book.book_year = @YEAR, " +
                           "Book.book_category = @CATEGORY, " +
                           "Book.book_writer = @WRITER, " +
                           "Book.book_publisher = @PUBLISHER " +
                           "WHERE Book.book_ISBN = @ISBN";
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@ISBN", book.book_ISBN);
            cmd.Parameters.AddWithValue("@NAME", book.book_name);
            cmd.Parameters.AddWithValue("@PAGE", book.book_page);
            cmd.Parameters.AddWithValue("@YEAR", book.book_year);
            cmd.Parameters.AddWithValue("@CATEGORY", book.book_category);
            cmd.Parameters.AddWithValue("@WRITER", book.book_writer);
            cmd.Parameters.AddWithValue("@PUBLISHER", book.book_publisher);
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        //Kitap ISBN parametresi alan silme fonksiyonu
        public void DeleteBook(string book)
        {
            OleDbCommand cmd = DBConn.GetOleDbCommand();
            string query = "Delete from Book WHERE book_ISBN = @ISBN";
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@ISBN", book);
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        //Kitap tablosundaki sütunların seçimine göre arama yapmayı sağlar
        //ve aranan değere benzer değerleri entity listesi tipinde geri döndürür
        public List<Book_Entity> SearchBook(string column, string key)
        {
            OleDbCommand cmd = DBConn.GetOleDbCommand();
            cmd.CommandText = String.Format("SELECT * FROM Book WHERE {0} LIKE '%{1}%'", column, key);

            List<Book_Entity> book = new List<Book_Entity>();
            OleDbDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                Book_Entity bk = new Book_Entity();
                bk.book_ISBN = rdr["book_ISBN"].ToString();
                bk.book_name = rdr["book_name"].ToString();
                bk.book_category = rdr["book_category"].ToString();
                bk.book_page = Int32.Parse(rdr["book_page"].ToString());
                bk.book_year = Int32.Parse(rdr["book_year"].ToString());
                bk.book_writer = rdr["book_writer"].ToString();
                bk.book_publisher = rdr["book_publisher"].ToString();
                book.Add(bk);
            }
            //İşlem tamamlandıktan sonra veritabanı bağlantısı kapatılıyor
            rdr.Close();
            cmd.Connection.Close();
            return book;
        }
    }
}
