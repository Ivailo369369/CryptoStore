namespace CryptoStore.Controllers.ApiControllers
{
    using CryptoStore.Services.Contracts;
    using CryptoStore.ViewModels.ApiModels.Newsletter;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class NewsletterController : ApiController
    {
        private readonly INewsletterService newsletter;

        public NewsletterController(INewsletterService newsletter) => this.newsletter = newsletter; 

        [HttpPost]
        public async Task<IActionResult> Add(NewsletterRequestModel model)
        {
            var result = await this.newsletter.AddAsync(model);

            if (result.Failure)
            {
                return BadRequest(result.Error); 
            }

            return StatusCode(201);
        }
    }
}
