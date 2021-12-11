namespace CryptoStore.Controllers.ApiControllers
{
    using CryptoStore.Infrastructure.Services;
    using CryptoStore.Services.Contracts;
    using CryptoStore.ViewModels.ApiModels.Message;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class MessageController : ApiController
    {
        private readonly IMessageNotificationService message;
        private readonly ICurrentUserService currentUser; 

        public MessageController(
            IMessageNotificationService message,
            ICurrentUserService currentUser)
        {
            this.message = message;
            this.currentUser = currentUser;
        }

        [HttpPost]
        public async Task<IActionResult> Create(MessageRequestModel model)
        {
            var userId = this.currentUser.GetId();
            var username = this.currentUser.GetUsername();

            var result = await this.message.CreateAsync(model, userId, username);

            if (result.Failure)
            {
                return BadRequest(result.Error); 
            }

            return StatusCode(201); 
        }
    }
}
