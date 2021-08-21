namespace CryptoStore.Services.Contracts
{
    using CryptoStore.ViewModels.BidingViewModels;
    using System.Threading.Tasks;


    public interface IPaymentService
    { 
        Task CheckOutAsync(CreatePaymentsVeiwModel model);  
    }
}
