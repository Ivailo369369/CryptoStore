namespace CryptoStore.Data.Models
{
    using CryptoStore.Data.Models.Base;
    using System.ComponentModel.DataAnnotations;

    using static DataValidation.Notifications; 

    public class Notification : DeletableEntity 
    {
        public int Id { get; set; }

        [Required]
        [StringLength(MaxNameLenght, MinimumLength = MinNameLenght)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(MaxNameLenght, MinimumLength = MinNameLenght)] 
        public string LastName { get; set; }

        [Required] 
        public string UserId { get; set; }

        public string Username { get; set; } 

        [Required]
        public string Email { get; set; }

        [Required]
        [StringLength(PhoneMaxLenght,MinimumLength = PhoneMinLenght)] 
        public string Phone { get; set; } 

        [Required]
        [MaxLength(MaxMessagesLenght)] 
        public string Message { get; set; }
    }
}
