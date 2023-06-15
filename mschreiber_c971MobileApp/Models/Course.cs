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
        public string Name { get; set; }
        public string Season { get; set; }
        public int Enrolled { get; set; }
        public decimal Price { get; set; }
        public bool StartNotification { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Notes { get; set; }


    }
}
