using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lab1.Models
{
    public class Notepad
    {
        public string Name { get; set; }
        public string Content { get; set; }
        public Notepad(string name)
        {
            Name = name;
        }

    }
}