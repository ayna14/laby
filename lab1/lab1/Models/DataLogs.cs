using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace lab1.Models
{
    public class Logs
    {
        public int id { get; set; }
        public string action { get; set; }
    }

    public class DataLogs : DbContext
    {
        public DataLogs() : base("DataSQL")
        {
        }

        public DbSet<Logs> Logs { get; set; }
    }
}