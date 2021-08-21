namespace CryptoStore.Services.Contracts
{
    using CryptoStore.ViewModels.BidingViewModels;
    using CryptoStore.ViewModels.MessageNotification;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IMessageNotificationService  
    {
        Task CreateMessageAsyc(CreateMessageViewModel model);

        IEnumerable<MessageNotificationViewModel> Notification(); 

        Task<IEnumerable<MessageNotificationViewModel>> DetailsAsync(int id);

        Task ClearAsync(int id); 
    }
}
