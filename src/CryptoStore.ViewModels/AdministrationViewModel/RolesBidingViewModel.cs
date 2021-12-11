namespace CryptoStore.ViewModels.AdministrationViewModel 
{
    using System.ComponentModel.DataAnnotations;

    using static ValidationViewModels.Validation;

    public class RolesBidingViewModel
    {
        public string Id { get; set; } 

        [Required(ErrorMessage = RequiredField)] 
        public string RoleName { get; set; } 
    }
}
