using System;
using System.Collections.Generic;

namespace MEMSail.Models
{
    public partial class Province
    {
        public Province()
        {
            Member = new HashSet<Member>();
            Town = new HashSet<Town>();
        }

        public string ProvinceCode { get; set; }
        public string Name { get; set; }
        public string CountryCode { get; set; }
        public string TaxCode { get; set; }
        public double TaxRate { get; set; }
        public string Capital { get; set; }

        public virtual ICollection<Member> Member { get; set; }
        public virtual ICollection<Town> Town { get; set; }
        public virtual Country CountryCodeNavigation { get; set; }
    }
}
