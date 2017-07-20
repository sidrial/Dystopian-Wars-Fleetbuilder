using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Ship
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }
        public int BasePoints { get; set; }
        public int CurrentPoints { get; set; }
        public bool Active { get; set; }
        public virtual List<Option> Options { get; set; }
    }
}
