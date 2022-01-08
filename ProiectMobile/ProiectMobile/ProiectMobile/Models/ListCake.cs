using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace ProiectMobile.Models
{
    public class ListCake
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [ForeignKey(typeof(OrderList))]
        public int OrderListID { get; set; }
        public int MeniuID { get; set; }
    }
}
