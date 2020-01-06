using System;
using System.Collections.Generic;
using System.Text;

namespace J3Week.Models
{
    public static class FilterPreferences
    {
        public static Nullable<DateTime> Date = null;
        public static Dictionary<IMultiSelectModel, bool> Locations;
        public static Dictionary<IMultiSelectModel, bool> ActiveUsers;
    }
}
