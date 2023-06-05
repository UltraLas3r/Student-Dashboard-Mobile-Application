using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace mschreiber_c971MobileApp.Models
{
    public class ClassInfo
    { // Course

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int TermId { get; set; } //foreign key
        public string Name { get; set; }
        public string Color { get; set; }
        public int InStock { get; set; }
        public decimal Price { get; set; }
        public bool StartNotification { get; set; }
        public DateTime CreationDate { get; set; }
        public string Notes { get; set; }







    }
}
