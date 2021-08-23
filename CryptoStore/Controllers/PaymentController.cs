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
        private readonly IPaymentService paymentServiceAsync;
        private readonly ICurrentUserService currentUserService;
        private readonly IServicesService serviceDetailsService;
        public PaymentController(IPaymentService paymentServiceAsync,
            ICurrentUserService currentUserService,
            IServicesService serviceDetailsService) 
        {
            this.paymentServiceAsync = paymentServiceAsync;
            this.currentUserService = currentUserService;
            this.serviceDetailsService = serviceDetailsService;
        }  

        [Authorize]
        [HttpGet]
        public IActionResult CheckOut()
        {
            var userObj = this.currentUserService.GetUsername();
            var serviceDetails = this.serviceDetailsService.GetServiceDetailsForCheckOut();  
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

            await this.paymentServiceAsync.CheckOutAsync(model); 

            this.TempData.Put("__Message", new MessageModel()
            {
                Type = MessageType.Success,
                Message = "Your payment is succesfull.Please check your email for the service you paid for!"
            }); 

            return RedirectToAction("Index", "Home"); 
        }
    } 

}
