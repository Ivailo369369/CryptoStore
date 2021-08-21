namespace CryptoStore.ViewModels.BidingViewModels
{
    using System.ComponentModel.DataAnnotations;

    using static ValidationViewModels.Validation;
    using static ValidationViewModels.Validation.Partner;
    public class AddPartnersViewModel
   {
        [Required(ErrorMessage = RequiredField)] 
        [StringLength(MaxNameLenght, MinimumLength = MinNameLenght)]
        [Display(Name = Name)]
        public string CompanyName { get; set; }

        [MaxLength(MaxDescriptionLenght)]
        [Display(Name = CompanyDescription)] 
        public string Description { get; set; }

        [Display(Name = Logo)]
        public string LogoCompany { get; set; }

        [Display(Name= Link)] 
        public string WebsiteLink { get; set; }

        [Display(Name = Financy)] 
        public double Financing { get; set; }
    }
}
