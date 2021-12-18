using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;

namespace BLL
{
    public class LH_BLL
    {
        private LH_DAL LH_DAL;
        public LH_BLL()
        {
            LH_DAL = new LH_DAL();
        }
        public List<LH_Entity> GetRecords()
        {
            return LH_DAL.GetRecords();
        }
        public List<LH_Entity> GetBookHistory(string book_ISBN)
        {
            return LH_DAL.GetBookHistory(book_ISBN);
        }
        public List<LH_Entity> GetStudentHistory(int student_ID)
        {
            return LH_DAL.GetStudentHistory(student_ID);
        }
        public void AddRecord(LH_Entity lh)
        {
            LH_DAL.AddRecord(lh);
        }
        public void HandBook(int lh_ID)
        {
            LH_DAL.HandBook(lh_ID);
        }
        public int CountHandedBooks()
        {
            return LH_DAL.CountHandedBooks();
        }
        public void SetLateFee()
        {
            LH_DAL.SetLateFee();
        }
        public List<LH_Entity> SearchRecords(string column, string key)
        {
            return LH_DAL.SearchRecords(column, key);
        }
    }
}
