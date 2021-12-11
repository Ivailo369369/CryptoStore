namespace CryptoStore.ViewModels.ApiModels.Newsletter
{
    using System.ComponentModel.DataAnnotations;

    using static ValidationViewModels.Validation;

    public class NewsletterRequestModel
    {
        [Required(ErrorMessage = RequiredField)]
        [EmailAddress]
        public string Email { get; set; }
    }
}
