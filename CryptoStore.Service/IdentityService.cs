namespace CryptoStore.Services
{
    using CryptoStore.Data;
    using CryptoStore.Data.Models;
    using CryptoStore.Services.Contracts;
    using CryptoStore.ViewModels.ApiModels.Identity;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Options;
    using Microsoft.IdentityModel.Tokens;
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;

    using static Constants.ServiceConstant; 

    public class IdentityService : IIdentityService
    {
        private readonly UserManager<User> userManager;
        private readonly AppSettings appSettings;
        private readonly CryptoStoreDb dbContext;
        private readonly RoleManager<IdentityRole> roleManager;

        public IdentityService(
            UserManager<User> userManager,
            IOptions<AppSettings> appSettings,
            CryptoStoreDb dbContext,
            RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.appSettings = appSettings.Value;
            this.dbContext = dbContext;
            this.roleManager = roleManager;
        }

        public string GenerateJwtToken(string userId, string userName, string secret)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, userId),
                    new Claim(ClaimTypes.Name, userName)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var encryptedToken = tokenHandler.WriteToken(token);

            return encryptedToken;
        }

        //Better logic needs to be made to add a role to users 
        public async Task RegisterAsync(RegisterRequestModel model)
        {
            var user = new User()
            {
                UserName = model.Username,
                Email = model.Email
            };

            if (await this.roleManager.RoleExistsAsync(RoleName))
            {
                await this.userManager.CreateAsync(user, model.Password);
                await this.userManager.AddToRoleAsync(user, RoleName);
            }

            var role = new IdentityRole()
            {
                Name = RoleName
            };

            await this.roleManager.CreateAsync(role);

            await this.userManager.CreateAsync(user, model.Password);
            await this.userManager.AddToRoleAsync(user, role.Name);
        }

        public async Task<LoginResponseModel> LoginAsync(LoginRequestModel model)
        {
            var user = await this.userManager.FindByNameAsync(model.Username);

            if (user == null)
            {
                throw new ArgumentException("There is no such user");
            }

            var passwordValid = await this.userManager.CheckPasswordAsync(user, model.Password);

            if (!passwordValid)
            {
                throw new ArgumentException("Username or password is incorrect.");
            }

            var token = GenerateJwtToken(
                user.Id,
                user.UserName,
                this.appSettings.Secret);

            return new LoginResponseModel()
            {
                Token = token
            };
        }
    }
}
