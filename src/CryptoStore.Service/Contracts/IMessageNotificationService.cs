namespace CryptoStore.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using CryptoStore.Services.ServicesType;
    using CryptoStore.ViewModels.ApiModels.Message;
    using CryptoStore.ViewModels.BidingViewModels;
    using CryptoStore.ViewModels.MessageNotification;

    public interface IMessageNotificationService : IService
    {
        Task CreateMessageAsyc(CreateMessageViewModel model);

        IEnumerable<MessageNotificationViewModel> Notification(); 

        Task<IEnumerable<MessageNotificationViewModel>> DetailsAsync(int id);

        Task ClearAsync(int id);

        Task<Result> CreateAsync(MessageRequestModel model, string userId, string username); 
    }
}
