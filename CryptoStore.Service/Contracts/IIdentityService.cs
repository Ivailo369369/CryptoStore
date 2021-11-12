namespace CryptoStore.Services.Contracts
{
    using CryptoStore.Services.ServicesType;
    using CryptoStore.ViewModels.ApiModels.Identity;
    using System.Threading.Tasks;

    public interface IIdentityService : IService
    {
        string GenerateJwtToken(string userId, string userName, string secret);

        Task RegisterAsync(RegisterRequestModel model);

        Task<LoginResponseModel> LoginAsync(LoginRequestModel model);
    }
}
