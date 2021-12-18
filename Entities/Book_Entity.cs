using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Book_Entity
    {
        public string book_ISBN { get; set; }
        public string book_name { get; set; }
        public string book_category { get; set; }
        public int book_page { get; set; }
        public int book_year { get; set; }
        public string book_writer { get; set; }
        public string book_publisher { get; set; }
    }
}
