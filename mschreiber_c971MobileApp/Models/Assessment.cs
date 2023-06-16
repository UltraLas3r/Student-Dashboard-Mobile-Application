using System;
using SQLite;
using System.Collections.Generic;
using System.Text;

namespace mschreiber_c971MobileApp.Models
{
   public class Assessment
    {
        public int CourseId { get; set; }
        public string TestName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime AnticipatedEndDate { get; set; }

    }
}
