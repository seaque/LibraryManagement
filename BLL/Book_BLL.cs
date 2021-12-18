using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;

namespace BLL
{
    public class Book_BLL
    {
        private Book_DAL Book_DAL;
        public Book_BLL()
        {
            Book_DAL = new Book_DAL();
        }
        public List<Book_Entity> GetBooks()
        {
            return Book_DAL.GetBooks();
        }
        public List<String> GetCategories()
        {
            return Book_DAL.GetCategories();
        }
        public List<String> GetPublishers()
        {
            return Book_DAL.GetPublishers();
        }
        public List<String> GetWriters()
        {
            return Book_DAL.GetWriters();
        }
        public int CountBooks()
        {
            return Book_DAL.CountBooks();
        }
        public void AddBook(Book_Entity book)
        {
            Book_DAL.AddBook(book);
        }
        public void AddCategory(Book_Entity book)
        {
            Book_DAL.AddCategory(book);
        }
        public void AddWriter(Book_Entity book)
        {
            Book_DAL.AddWriter(book);
        }
        public void AddPublisher(Book_Entity book)
        {
            Book_DAL.AddPublisher(book);
        }
        public void UpdateBook(Book_Entity book)
        {
            Book_DAL.UpdateBook(book);
        }
        public void DeleteBook(string book)
        {
            Book_DAL.DeleteBook(book);
        }
        public List<Book_Entity> SearchBook(string column, string key)
        {
            return Book_DAL.SearchBook(column, key);
        }
    }
}
