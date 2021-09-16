namespace CryptoStore.ViewModels.ApiModels.Service
{
    public class ServiceRequestModel
    {
        public int Id { get; set; }

        public string ServiceName { get; set; }

        public string Description { get; set; }

        public string ServiceImage { get; set; }

        public string ServiceVideo { get; set; }

        public string CryptoToken { get; set; }

        public double TotalSum { get; set; }
    }
}
