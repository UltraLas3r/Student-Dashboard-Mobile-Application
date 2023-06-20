using System;
using SQLite;
using System.Collections.Generic;
using System.Text;

namespace mschreiber_c971MobileApp.Models
{
   public class Assessment
    {
        public int CourseId { get; set; }

        public int TestId { get; set; }

        public string AssessmentName { get; set; }
        public string AssessmentType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime AnticipatedEndDate { get; set; }
        public bool StartDateNotify { get; set; }
        public bool EndDateNotify { get; set; }




    }
}
