using System;
using System.Collections.Generic;

namespace MEMSail.Models
{
    public partial class Town
    {
        public string TownName { get; set; }
        public string ProvinceCode { get; set; }

        public virtual Province ProvinceCodeNavigation { get; set; }
    }
}
