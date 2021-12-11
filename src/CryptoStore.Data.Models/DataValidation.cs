namespace CryptoStore.Data.Models
{
    public static class DataValidation
    { 
        public class Service
        {
            public const int MaxNameLenght = 60;
            public const int MinNameLenght = 4; 

            public const int MaxDescriptionLenght = 260;
        } 

        public class Resource
        {
            public const int MaxNameLenght = 60;
            public const int MinNameLenght = 4; 
        }

        public class Payment
        {
            public const int PhoneMaxLenght = 10;
            public const int PhoneMinLenght = 10;
        } 

        public class Notifications
        { 
            public const int MaxNameLenght = 40;
            public const int MinNameLenght = 3;  

            public const int MaxMessagesLenght = 918; 

            public const int PhoneMaxLenght = 10;
            public const int PhoneMinLenght = 10;
        }

        public class Partner
        {
            public const int MaxNameLenght = 60;
            public const int MinNameLenght = 4;

            public const int MaxDescriptionLenght = 260;
        }
    }
}
