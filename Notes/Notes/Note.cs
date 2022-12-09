using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notes
{
    public class Note
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string taskName { get; set; }
        public string taskDescription { get; set; }
        public DateTime Date { get; set; }
       
    }
}
