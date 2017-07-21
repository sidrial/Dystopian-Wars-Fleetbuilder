using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Faction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid FactionID { get; set; }
        public string Name { get; set; }
        public SuperBlock SuperBlock { get; set; }
        public string Acronym { get; set; }
        public bool MajorFaction { get; set; }
    }
}
