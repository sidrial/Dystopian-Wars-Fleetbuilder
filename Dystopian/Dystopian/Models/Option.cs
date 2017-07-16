using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dystopian.Models
{
    public class Option
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public int Points { get; set; }
        public int? OptionGroup { get; set; }
        public bool Active { get; set; }

    }   
}