using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.Data.OleDb;

namespace DAL
{
    public class Student_DAL
    {
        private DBConnection DBConn;
        //Yapıcı fonksiyonda DBConnection sınıfından nesne oluşturuluyor
        public Student_DAL()
        {
            DBConn = new DBConnection();
        }

        //Tüm öğrencileri listeleme
        public List<Student_Entity> GetStudents()
        {
            string query = "select * from Student;";
            OleDbCommand cmd = DBConn.GetOleDbCommand();
            cmd.CommandText = query;

            List<Student_Entity> student = new List<Student_Entity>();
            OleDbDataReader rdr = cmd.ExecuteReader(); //Veritabanına sorgu yollanır ve datareader objesi oluşur

            while (rdr.Read())
            {
                Student_Entity std = new Student_Entity();
                std.student_ID = Int32.Parse(rdr["student_ID"].ToString());
                std.student_name = rdr["student_name"].ToString();
                std.student_surname = rdr["student_surname"].ToString();
                std.student_mail = rdr["student_mail"].ToString();
                student.Add(std);
            }
            //İşlem tamamlandıktan sonra veritabanı bağlantısı kapatılıyor
            rdr.Close();
            cmd.Connection.Close();
            return student;
        }

        //Student_Entity objesine değerler atayarak ekleme
        public void AddStudent (Student_Entity student)
        {
            string query = "Insert into Student (student_ID, student_name, student_surname, student_mail) values (@ID, @NAME, @SURNAME, @MAIL)";
            OleDbCommand cmd = DBConn.GetOleDbCommand();
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@ID", student.student_ID);
            cmd.Parameters.AddWithValue("@NAME", student.student_name);
            cmd.Parameters.AddWithValue("@SURNAME", student.student_surname);
            cmd.Parameters.AddWithValue("@MAIL", student.student_mail);
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        //Student_Entity objesine değerler atayarak öğrenci
        //bilgilerini üzerine yazma yöntemiyle günceller
        public void UpdateStudent(Student_Entity student)
        {
            OleDbCommand cmd = DBConn.GetOleDbCommand();
            string query = "Update Student SET Student.student_ID = @ID, " +
                           "Student.student_name = @NAME, " +
                           "Student.student_surname = @SURNAME, " +
                           "Student.student_mail = @MAIL WHERE Student.student_ID = @ID";
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@ID", student.student_ID);
            cmd.Parameters.AddWithValue("@NAME", student.student_name);
            cmd.Parameters.AddWithValue("@SURNAME", student.student_surname);
            cmd.Parameters.AddWithValue("@MAIL", student.student_mail);
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        //Öğrenci numarası kullanan silme fonksiyonu
        public void DeleteStudent(int student)
        {
            OleDbCommand cmd = DBConn.GetOleDbCommand();
            string query = "Delete from Student WHERE student_ID = @ID";
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@ID", student);
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        //Öğrenci tablosunda seçilen sütuna göre tam veya benzer değerleri arama
        public List<Student_Entity> SearchStudent(string column, string key)
        {
            OleDbCommand cmd = DBConn.GetOleDbCommand();
            cmd.CommandText = String.Format("SELECT * FROM Student WHERE {0} LIKE '%{1}%'", column, key);

            List<Student_Entity> student = new List<Student_Entity>();
            OleDbDataReader rdr = cmd.ExecuteReader(); //Veritabanına sorgu yollanır ve datareader objesi oluşur

            while (rdr.Read()) 
            {
                Student_Entity std = new Student_Entity();
                std.student_ID = Int32.Parse(rdr["student_ID"].ToString());
                std.student_name = rdr["student_name"].ToString();
                std.student_surname = rdr["student_surname"].ToString();
                std.student_mail = rdr["student_mail"].ToString();
                student.Add(std);
            }
            //İşlem tamamlandıktan sonra veritabanı bağlantısı kapatılıyor
            rdr.Close();
            cmd.Connection.Close();
            return student;
        }
    }
}
