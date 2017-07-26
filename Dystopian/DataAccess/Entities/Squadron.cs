using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Squadron
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get;set;}
        public virtual List<SquadronEntry> Entries { get; set; }
        public string Name { get; set; }
        public Faction FactionID { get; set; }
    }

    public class SquadronEntry
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }
        public virtual List<Ship> Ships { get; set; }
        public int Minimum { get; set; }
        public int Maximum { get; set; }
        public int CurrentNumber { get; set; }
        public bool IsAttachment { get; set; }
    }
}
