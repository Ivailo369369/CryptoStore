namespace CryptoStore.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static DataValidation.Resource; 

    public class Resource
    {
        public int Id { get; set; } 

        [Required]
        [StringLength(MaxNameLenght,MinimumLength = MinNameLenght)]
        public string Name { get; set; } 

        [Required]
        public string Image { get; set; }

        public string Description { get; set; } 

        [Required]
        public string Hyperlink { get; set; } 
    }
}
