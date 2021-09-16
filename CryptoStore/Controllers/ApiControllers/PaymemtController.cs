namespace CryptoStore.Controllers.ApiControllers
{
    using CryptoStore.Infrastructure.Services;
    using CryptoStore.Services.Contracts;
    using CryptoStore.ViewModels.ApiModels.Payment;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class PaymemtController : ApiController
    {
        private readonly IPaymentService payment;
        private readonly ICurrentUserService currentUser;
        private readonly IServicesService serviceDetails;

        public PaymemtController(
            IPaymentService payment,
            ICurrentUserService currentUser,
            IServicesService serviceDetails) 
        {
            this.payment = payment;
            this.currentUser = currentUser;
            this.serviceDetails = serviceDetails;
        }

        [HttpPost]
        public async Task<IActionResult> CheckOut(PaymentRequestModel model)
        {
            var username = this.currentUser.GetUsername();

            var serviceDetails = this.serviceDetails.GetServiceDetailsForCheckOut();
             
            var result = await this.payment.PaymentAsync(model, serviceDetails.Id, username);

            if (result.Failure)
            {
                return BadRequest(result.Error); 
            }

            return StatusCode(201); 
        } 
    }
}
