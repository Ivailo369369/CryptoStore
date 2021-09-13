namespace CryptoStore.Controllers
{
    using CryptoStore.Infrastructure.Extensions;
    using CryptoStore.Helpers.Messages;
    using CryptoStore.Infrastructure.Services;
    using CryptoStore.Services.Contracts;
    using CryptoStore.ViewModels.BidingViewModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class PaymentController : Controller 
    {
        private readonly IPaymentService payment;
        private readonly ICurrentUserService currentUser;
        private readonly IServicesService serviceDetails;

        public PaymentController(
            IPaymentService payment,
            ICurrentUserService currentUser,
            IServicesService serviceDetails) 
        {
            this.payment = payment;
            this.currentUser = currentUser;
            this.serviceDetails = serviceDetails; 
        }  

        [Authorize]
        [HttpGet]
        public IActionResult CheckOut()
        {
            var userObj = this.currentUser.GetUsername();

            var serviceDetails = this.serviceDetails.GetServiceDetailsForCheckOut();  

            var model = new CreatePaymentsVeiwModel
            {
                Username = userObj,
                TotalSum = serviceDetails.TotalSum,
                CryptoToken = serviceDetails.CryptoTokens,
                ServiceName = serviceDetails.ServiceName
            }; 

            return this.View(model); 
        }

        [Authorize] 
        [HttpPost]
        public async Task<IActionResult> CheckOut(CreatePaymentsVeiwModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View();
            } 

            await this.payment.CheckOutAsync(model); 

            this.TempData.Put("__Message", new MessageModel()
            {
                Type = MessageType.Success,
                Message = "Your payment is succesfull.Please check your email for the service you paid for!"
            }); 

            return RedirectToAction("Index", "Home"); 
        }
    } 

}
