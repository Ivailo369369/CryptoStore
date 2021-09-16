namespace CryptoStore.ViewModels.ApiModels.Payment
{
    using System.ComponentModel.DataAnnotations;

    using static ValidationViewModels.Validation;
    using static ValidationViewModels.Validation.Payment;

    public class PaymentRequestModel
    {
        [Required(ErrorMessage = RequiredField)]
        public string Email { get; set; }

        [Required(ErrorMessage = RequiredField)]
        [StringLength(PhoneMaxLenght, MinimumLength = PhoneMinLenght)]
        public string PhonenNumber { get; set; }

        public string QRCode { get; set; }
    }
}
