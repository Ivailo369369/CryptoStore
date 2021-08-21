namespace CryptoStore.ViewModels.AdministrationViewModel 
{
    public class UserRolesViewModel
    {
        public string Id { get; set; } 

        public string Username { get; set; } 

        public string Email { get; set; }

        public bool EmailConfirmed { get; set; } 

        public string RoleName { get; set; }

        public bool IsLocked { get; set; } 
    }
}
