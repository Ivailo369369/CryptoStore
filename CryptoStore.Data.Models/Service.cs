namespace CryptoStore.Data.Models
{
    using CryptoStore.Data.Models.Base;
    using System.ComponentModel.DataAnnotations;

    using static DataValidation.Service;

    public class Service : DeletableEntity 
    {
        public int Id { get; set; }

        [Required]
        [StringLength(MaxNameLenght, MinimumLength = MinNameLenght)]
        public string ServiceName { get; set; }

        [Required] 
        [MaxLength(MaxDescriptionLenght)]
        public string Description { get; set; }

        [Required] 
        public string ServiceExplain { get; set; }  

        [Required]
        public string ServiceImage { get; set; } 

        public string ServiceVideo { get; set; }  

        [Required]
        public string CryptoTokens { get; set; } 

        [Required] 
        public double TotalSum { get; set; }
    } 
}
