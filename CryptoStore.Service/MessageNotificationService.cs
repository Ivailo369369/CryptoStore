namespace CryptoStore.Services
{
    using CryptoStore.Data;
    using CryptoStore.Data.Models;
    using CryptoStore.Services.Contracts;
    using CryptoStore.ViewModels.ApiModels.Message;
    using CryptoStore.ViewModels.BidingViewModels;
    using CryptoStore.ViewModels.MessageNotification;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks; 

    public class MessageNotificationService : IMessageNotificationService
    {
        private readonly CryptoStoreDb context;

        public MessageNotificationService(CryptoStoreDb context) => this.context = context; 

        public async Task CreateMessageAsyc(CreateMessageViewModel model) 
        {
            var userObj = this.context
                .Users
                .FirstOrDefault(); 

            var messageNotification = new Notification() 
            {
                FirstName = model.FirstName, 
                LastName = model.LastName,
                UserId = userObj.Id, 
                Username = model.Username, 
                Email = model.Email,
                Phone = model.Phone, 
                Message = model.Message
            };

            await this.context.AddAsync(messageNotification);
            await this.context.SaveChangesAsync(); 
        }

        public IEnumerable<MessageNotificationViewModel> Notification()
           => this.context
            .Notifications
            .Where(m => m.IsDeleted == false)
            .Select(m => new MessageNotificationViewModel()
            {
                Id = m.Id,
                Username = m.Username,
                FirstName = m.FirstName,
                LastName = m.LastName, 
                Email = m.Email,
            })
            .ToList();

        public async Task<IEnumerable<MessageNotificationViewModel>> DetailsAsync(int id)
           => await this.context
            .Notifications
            .Where(n => n.Id == id)
            .Select(n => new MessageNotificationViewModel()
            {
                Id = n.Id, 
                Username = n.Username,
                FirstName = n.FirstName,
                LastName = n.LastName,
                Email = n.Email,
                Phone = n.Phone,
                Message = n.Message
            })
            .ToListAsync();

        public async Task ClearAsync(int id)  
        {
            var message = await this.context
                .Notifications
                .FindAsync(id);

            message.IsDeleted = true; 
            await this.context.SaveChangesAsync(); 
        }

        public async Task<Result> CreateAsync(MessageRequestModel model, string userId, string username)
        {
            var message = new Notification()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserId = userId,
                Username = username,
                Email = model.Email,
                Phone = model.Phone,
                Message = model.Message
            };

            if (message == null)
            {
                return "You can't send a message";
            }

            await this.context.AddAsync(message);
            await this.context.SaveChangesAsync();

            return true;
        }
    }
}
