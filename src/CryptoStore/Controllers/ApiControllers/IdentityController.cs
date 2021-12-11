namespace CryptoStore.Controllers.ApiControllers
{
    using CryptoStore.Services.Contracts;
    using CryptoStore.ViewModels.ApiModels.Identity;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class IdentityController : ApiController
    {
        private readonly IIdentityService identity;

        public IdentityController(IIdentityService identity) => this.identity = identity;

        [HttpPost]
        [AllowAnonymous]
        [Route(nameof(Register))]
        public async Task<IActionResult> Register(RegisterRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await this.identity.RegisterAsync(model);

            return StatusCode(201);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route(nameof(Login))]
        public async Task<ActionResult<LoginResponseModel>> Login(LoginRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var token = await this.identity.LoginAsync(model);

            return token;
        }
    }
}
