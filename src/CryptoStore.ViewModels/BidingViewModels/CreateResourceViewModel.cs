namespace CryptoStore.ViewModels.BidingViewModels
{
    using System.ComponentModel.DataAnnotations;

    using static ValidationViewModels.Validation;
    using static ValidationViewModels.Validation.Resource;

    public class CreateResourceViewModel
    {
        [Required(ErrorMessage = RequiredField)] 
        [StringLength(MaxNameLenght, MinimumLength = MinNameLenght)] 
        [Display(Name = ResourceName)] 
        public string Name { get; set; } 

        [Display(Name = ResourceImage)] 
        public string Image { get; set; }

        [Required(ErrorMessage = RequiredField)]
        [Display(Name = ResourceDescription)] 
        public string Description { get; set; } 

        [Required(ErrorMessage = RequiredField)]  
        [Display(Name = Link)]  
        public string Hyperlink { get; set; }  
    }
}
