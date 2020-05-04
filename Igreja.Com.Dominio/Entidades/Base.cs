using System;
using System.Collections.Generic;
using System.Text;

namespace Igreja.Com.Dominio.Entidades
{
    public class Base
    {
        public int Id { get; set; }
        DateTime _dateTime;
        public DateTime dateTime
        {
            get=> _dateTime;
            set => _dateTime = DateTime.Now;
        }
    }
}
