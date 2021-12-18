using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class LH_Entity
    {
        public string book_ISBN { get; set; }
        public string book_name { get; set; }
        public int lh_ID { get; set; }
        public int student_ID { get; set; }
        public string student_name { get; set; }
        public string student_surname { get; set; }
        public string lend_date { get; set; }
        public string last_date { get; set; }
        public string hand_date { get; set; }
        public int late_fee { get; set; }
        public bool hand_status { get; set; }
    }
}
