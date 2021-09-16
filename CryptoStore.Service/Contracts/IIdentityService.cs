namespace CryptoStore.Services.Contracts
{
    using CryptoStore.ViewModels.ApiModels.Identity;
    using System.Threading.Tasks;

    public interface IIdentityService
    {
        string GenerateJwtToken(string userId, string userName, string secret);

        Task RegisterAsync(RegisterRequestModel model);

        Task<LoginResponseModel> LoginAsync(LoginRequestModel model);
    }
}
