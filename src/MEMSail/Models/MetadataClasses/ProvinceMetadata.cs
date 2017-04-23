using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MEMSail.Models
{

    [ModelMetadataTypeAttribute(typeof(ProvinceMetadata))]
    public partial class Province:IValidatableObject
    {
        SailContext _context = SailContextSingleton.Context();
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            ProvinceCode = ProvinceCode.Trim().ToUpper();
            CountryCode = CountryCode.ToUpper();
            yield return ValidationResult.Success;

        }
    }
    public class ProvinceMetadata
    {
        [Remote("ProvinceCodeValidation", "Provinces")]
        [Required]
        public string ProvinceCode { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"^(CA|FR|JA|US)$",
                ErrorMessage = "the {0} is not a valid .Country Codes should be US,JA,FR or CA")]
        [Display(Name = "Country Code")]
        public string CountryCode { get; set; }
        [Required]
        public string TaxCode { get; set; }
        [Required]
        public double TaxRate { get; set; }
        public string Capital { get; set; }

        public virtual ICollection<Member> Member { get; set; }
        public virtual ICollection<Town> Town { get; set; }
        public virtual Country CountryCodeNavigation { get; set; }
        
    }
    
}
