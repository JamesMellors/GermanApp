using System;
using SQLite;

namespace GermanApp.Models
{
    [Table("Alphabet")]
    public class Alphabet
    {
        [Column("id")]
        public int id { get; set; }
        [Column("german")]
        public string german { get; set; }


    }
}
