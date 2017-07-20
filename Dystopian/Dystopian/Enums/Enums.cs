using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Dystopian
{
    public class Enums
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

        public enum Core
        {
            [Description("NAVAL")]
            NAVAL = 1,
            [Description("AERIAL")]
            AERIAL = 2,
            [Description("ARMOURED")]
            ARMOURED = 3          
        }



    }

    public static class ExtensionMethod
    {
        public static string GetDescription(this Enum value)
        {
            Type type = value.GetType();
            string name = Enum.GetName(type, value);
            if (name != null)
            {
                FieldInfo field = type.GetField(name);
                if (field != null)
                {
                    DescriptionAttribute attr =
                           Attribute.GetCustomAttribute(field,
                             typeof(DescriptionAttribute)) as DescriptionAttribute;
                    if (attr != null)
                    {
                        return attr.Description;
                    }
                }
            }
            return null;
        }
    }
  
}