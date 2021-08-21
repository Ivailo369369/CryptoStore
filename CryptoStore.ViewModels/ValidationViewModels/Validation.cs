namespace CryptoStore.ViewModels.ValidationViewModels
{
    public abstract class Validation
    {
        public const string RequiredField = "This field is required.";  

        public class Message 
        {
            public const int MaxNameLenght = 60;
            public const int MinNameLenght = 3;

            public const int MaxPhoneLenght = 10;
            public const int MinPhoneLenght = 10;

            public const int MaxMessagesLenght = 918; 
        }
        public class Service
        { 
            public const int MaxNameLenght = 60;
            public const int MinNameLenght = 4;

            public const int MaxDescriptionLenght = 260;

            public const string Name = "Name"; 
            public const string Image = "Image";
            public const string Video = "Video";
            public const string Description = "Description";
            public const string Sum = "Total Sum";
            public const string Explain = "Explain";
        } 

        public class Payment
        {
            public const int PhoneMaxLenght = 10;
            public const int PhoneMinLenght = 10;

            public const string Name = "Username";
            public const string UserEmail = "Email"; 
            public const string Phone = "Phone Number"; 
        }
        public class Resource
        {
            public const int MaxNameLenght = 60;
            public const int MinNameLenght = 4;

            public const string ResourceName = "Name"; 
            public const string ResourceImage = "Image";  
            public const string Link = "Hyperlink";
            public const string ResourceDescription = "Description"; 
        }

        public class Partner
        {
            public const int MaxNameLenght = 60;
            public const int MinNameLenght = 4;

            public const int MaxDescriptionLenght = 260;

            public const string Name = "Name";
            public const string CompanyDescription = "Description"; 
            public const string Logo = "Logo";
            public const string Link = "Website";
            public const string Financy = "Financing";
        }
    }
}
