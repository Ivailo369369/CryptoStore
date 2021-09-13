namespace CryptoStore.ViewModels.ServiceVeiwModel.Edit
{
    using System.ComponentModel.DataAnnotations;

    using static ValidationViewModels.Validation;
    using static ValidationViewModels.Validation.Service;

    public class EditingViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = RequiredField)]
        [StringLength(MaxNameLenght, MinimumLength = MinNameLenght)]
        public string ServiceName { get; set; }

        public string ServiceImage { get; set; }

        public string ServiceVideo { get; set; }

        [Required(ErrorMessage = RequiredField)]
        [MaxLength(MaxDescriptionLenght)]
        public string ServiceDescription { get; set; }

        [Required(ErrorMessage = RequiredField)]
        public string ServiceExplain { get; set; }

        public string Token { get; set; }

        [Required(ErrorMessage = RequiredField)]
        public double TotalSum { get; set; }
    }
}
