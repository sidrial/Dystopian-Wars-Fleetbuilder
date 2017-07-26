using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public enum Size
    {
        [Description("Tiny")]
        Tiny,
        [Description("Small")]
        Small,
        [Description("Medium")]
        Medium,
        [Description("Large")]
        Large,
        [Description("Massive")]
        Massive,
        [Description("Massive +1")]
        MassivePlusOne
    }
}
