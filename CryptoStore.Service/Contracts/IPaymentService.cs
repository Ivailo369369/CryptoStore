namespace CryptoStore.Services.Contracts
{
    using CryptoStore.ViewModels.ApiModels.Payment;
    using CryptoStore.ViewModels.BidingViewModels;
    using System.Threading.Tasks;

    public interface IPaymentService
    { 
        Task CheckOutAsync(CreatePaymentsVeiwModel model);

        Task<Result> PaymentAsync(PaymentRequestModel model, int id, string username);
    }
}
