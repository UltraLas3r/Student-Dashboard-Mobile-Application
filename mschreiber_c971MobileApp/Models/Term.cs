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
        public string Color { get; set; }
        public int InStock { get; set; }
        public decimal Price { get; set; }
        public DateTime CreateionDate { get; set; }




    }
}
