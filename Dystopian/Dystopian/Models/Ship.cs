using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dystopian.Models
{
    public class Ship
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }
        public int BasePoints { get; set; }
        public int CurrentPoints { get; set; }
        public int SquadronSize { get; set; }
        public int MinSquadronSize { get; set; }
        public int MaxSquadronSize { get; set; }
    
        public bool Active { get; set; }

        public List<Option> Options { get; set; }

        public Ship()
        {
        }
    }   
}