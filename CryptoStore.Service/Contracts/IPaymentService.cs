namespace CryptoStore.Services.Contracts
{
    using System.Threading.Tasks;

    using CryptoStore.Services.ServicesType;
    using CryptoStore.ViewModels.ApiModels.Payment;
    using CryptoStore.ViewModels.BidingViewModels;

    public interface IPaymentService : IService
    { 
        Task CheckOutAsync(CreatePaymentsVeiwModel model);

        Task<Result> PaymentAsync(PaymentRequestModel model, int id, string username);
    }
}
