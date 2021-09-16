namespace CryptoStore.Services
{
    using CryptoStore.Data;
    using CryptoStore.Data.Models;
    using CryptoStore.Services.Contracts;
    using CryptoStore.ViewModels.ApiModels.Payment;
    using CryptoStore.ViewModels.BidingViewModels;
    using System.Linq;
    using System.Threading.Tasks;

    public class PaymentService : IPaymentService
    {
        private readonly CryptoStoreDb context;

        public PaymentService(CryptoStoreDb context) => this.context = context;

        public async Task CheckOutAsync(CreatePaymentsVeiwModel model)
        {
            var serviceDetails = this.context
                .Services
                .FirstOrDefault();

            var payment = new Payment()
            {
                ServiceName = serviceDetails.ServiceName,
                UsernameClient = model.Username,  
                Email = model.Email,
                PhoneNumber = model.PhonenNumber, 
                TotalSum = model.TotalSum,
                CryptoToken = model.CryptoToken, 
                QRCode = model.QRCode 
            };

            await this.context.Payments.AddAsync(payment);
            await this.context.SaveChangesAsync();
        }

        public async Task<Result> PaymentAsync(PaymentRequestModel model, int id, string username)
        {
            var serviceDetails = this.context
               .Services
               .Where(s => s.Id == id)
               .FirstOrDefault();

            var payment = new Payment()
            {
                ServiceName = serviceDetails.ServiceName,
                UsernameClient = username,
                Email = model.Email,
                PhoneNumber = model.PhonenNumber,
                TotalSum = serviceDetails.TotalSum,
                CryptoToken = serviceDetails.CryptoTokens,
                QRCode = model.QRCode
            }; 

            if (payment == null)
            {
                return "You can't pay. There are some problems.";
            }

            await this.context.Payments.AddAsync(payment);
            await this.context.SaveChangesAsync();

            return true;
        }
    }
}
