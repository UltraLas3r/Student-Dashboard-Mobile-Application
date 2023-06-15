using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace mschreiber_c971MobileApp.Models
{
    public class TermInfo
    { //TERM

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime AnticipatedEndDate { get; set; }
    }
}
