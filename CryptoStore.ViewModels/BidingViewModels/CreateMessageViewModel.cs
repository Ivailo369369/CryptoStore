namespace CryptoStore.ViewModels.BidingViewModels
{
    using System.ComponentModel.DataAnnotations;

    using static ValidationViewModels.Validation;
    using static ValidationViewModels.Validation.Message;  

    public class CreateMessageViewModel
    {
        [Required(ErrorMessage = RequiredField)]  
        [StringLength(MaxNameLenght, MinimumLength = MinNameLenght)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = RequiredField)]
        [StringLength(MaxNameLenght, MinimumLength = MinNameLenght)]
        public string LastName { get; set; }

        [Required(ErrorMessage = RequiredField)]
        public string Username { get; set; }

        [Required(ErrorMessage = RequiredField)]
        [EmailAddress] 
        public string Email { get; set; }

        [Required(ErrorMessage = RequiredField)]
        [StringLength(MaxPhoneLenght, MinimumLength = MinPhoneLenght)]
        public string Phone { get; set; }

        [Required(ErrorMessage = RequiredField)] 
        [MaxLength(MaxMessagesLenght)] 
        public string Message { get; set; }
    }
}
