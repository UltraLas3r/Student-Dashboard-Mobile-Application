using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace mschreiber_c971MobileApp.Models
{
    public class CourseInfo
    { // Course

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int TermId { get; set; } //foreign key
        public string CourseName { get; set; }
        public string CourseStatus { get; set; }
        public string Instructor { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool StartNotification { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime AnticipatedEndDate { get; set; }
        public string Notes { get; set; }


    }
}
