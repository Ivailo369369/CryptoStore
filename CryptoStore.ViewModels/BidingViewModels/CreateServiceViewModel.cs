namespace CryptoStore.ViewModels.BidingViewModels
{
    using System.ComponentModel.DataAnnotations;

    using static ValidationViewModels.Validation;
    using static ValidationViewModels.Validation.Service; 

    public class CreateServiceViewModel
    { 
        [Required(ErrorMessage = RequiredField)] 
        [StringLength(MaxNameLenght,MinimumLength = MinNameLenght)]
        [Display(Name = Name)]   
        public string ServiceName { get; set; } 

        [Display(Name = Image)]
        public string ServiceImage { get; set; }

        [Display(Name = Video)]  
        public string ServiceVideo { get; set; }

        [Required(ErrorMessage = RequiredField)]  
        [MaxLength(MaxDescriptionLenght)] 
        [Display(Name = Description)]
        public string ServiceDescription { get; set; }

        [Required(ErrorMessage = RequiredField)] 
        [Display(Name = Explain)]
        public string ServiceExplain { get; set; }

        public string Token { get; set; } 

        [Required(ErrorMessage = RequiredField)] 
        [Display(Name = Sum)]   
        public double TotalSum { get; set; }
    } 
}
