namespace CryptoStore.ViewModels.BidingViewModels
{
    using System.ComponentModel.DataAnnotations;

    using static ValidationViewModels.Validation;  

    public class AddUserForNewsletterViewModel 
    { 
        [Required(ErrorMessage = RequiredField)]   
        [EmailAddress] 
        public string Email { get; set; }
    }
}
