namespace CryptoStore.Data.Models
{
    using CryptoStore.Data.Models.Base;
    using System.ComponentModel.DataAnnotations;

    using static DataValidation.Payment; 

    public class Payment : Entity 
    {
        public int Id { get; set; }

        [Required]
        public string ServiceName { get; set; }

        [Required]
        public string CryptoToken { get; set; }

        [Required]
        public double TotalSum { get; set; } 

        [Required] 
        [StringLength(PhoneMaxLenght,MinimumLength=PhoneMinLenght)] 
        public string PhoneNumber { get; set; }  

        public string QRCode { get; set; }

        [Required] 
        public string UsernameClient { get; set; }

        [Required]
        public string Email { get; set; }

        public User Client { get; set; }
    }
}
