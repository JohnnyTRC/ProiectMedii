using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace ProiectMobile.Models
{
    public class OrderList
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string TitluComanda { get; set; }
        public DateTime Date { get; set; }
        public string NumeClient { get; set; }
        public string AdresaClient { get; set; }
        public string NumarTelefon { get; set; }
        public DateTime DataComanda { get; set; }
        public int Cantitate { get; set; }
    }
}
