using System;
using SQLite;
using System.Collections.Generic;
using System.Text;

namespace mschreiber_c971MobileApp.Models
{
    
    public class Assessment
    {
       [PrimaryKey, AutoIncrement]
        public int CourseId { get; set; }

        //public int AssessmentID { get; set; } << Possibly use this for test creations

        public string AssessmentType { get; set; }
        public int TestId { get; set; }
        public string AssessmentName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime AnticipatedEndDate { get; set; }
        public bool StartDateNotify { get; set; }
        public bool EndDateNotify { get; set; }

    }
}
