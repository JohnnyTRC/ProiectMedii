using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace ProiectMobile.Models
{
    public class Meniu
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string NumeProdus { get; set; }
        public string Pret { get; set; }
        public string ImageURL { get; set; }
        public string Descriere { get; set; }
        [OneToMany]
        public List<ListCake> ListCakes { get; set; }
    }
}
