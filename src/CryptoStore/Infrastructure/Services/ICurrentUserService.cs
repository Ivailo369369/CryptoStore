namespace CryptoStore.Infrastructure.Services  
{
    using CryptoStore.Services.ServicesType;

    public interface ICurrentUserService : IScopedService
    {
        string GetUsername();

        string GetId(); 
    }
}
