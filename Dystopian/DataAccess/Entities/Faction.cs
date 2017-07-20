using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public enum Faction
    {
        [Description("Covenant of Antarctica")]
        COA = 1,
        [Description("Federates States of America")]
        FSA = 2,
        [Description("Russian Coalition")]
        RC = 3,
        [Description("Kingdom of Britannia")]
        KOB = 4,
        [Description("Empire of the Blazing Sun")]
        EOTBS = 5,
        [Description("Republique of France")]
        ROF = 6,
        [Description("Prussian Empire")]
        PE = 7
    }
}
