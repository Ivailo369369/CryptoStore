namespace CryptoStore.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static DataValidation.Partner;

    public class Partner
    {   
        public int Id { get; set; }

        [Required]
        [StringLength(MaxNameLenght, MinimumLength = MinNameLenght)]
        public string CompanyName { get; set; }

        [MaxLength(MaxDescriptionLenght)] 
        public string Description { get; set; }

        public string LogoCompany { get; set; }

        public string WebsiteLink { get; set; }

        public double Financing { get; set; } 
    }
}
