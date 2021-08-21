namespace CryptoStore.ViewModels.BidingViewModels
{
    using System.ComponentModel.DataAnnotations;

    using static ValidationViewModels.Validation;
    using static ValidationViewModels.Validation.Payment;

    public class CreatePaymentsVeiwModel
    {
        [Required(ErrorMessage = RequiredField)] 
        [Display(Name = Name)]
        public string Username { get; set; } 

        [Required(ErrorMessage = RequiredField)]
        [Display(Name = UserEmail)]
        public string Email { get; set; }

        [Required(ErrorMessage = RequiredField)] 
        [StringLength(PhoneMaxLenght, MinimumLength = PhoneMinLenght)]  
        [Display(Name = Phone)] 
        public string PhonenNumber { get; set; }

        public double TotalSum { get; set; }

        [Required(ErrorMessage = RequiredField)]
        public string CryptoToken { get; set; }

        [Required(ErrorMessage = RequiredField)]
        public string ServiceName { get; set; }

        public string QRCode { get; set; }  
    }
}
