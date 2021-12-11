namespace CryptoStore.Data.Models
{
    using CryptoStore.Data.Models.Base;
    using System.ComponentModel.DataAnnotations;

    public class Newsletter : DeletableEntity 
    {
        public int Id { get; set; } 

        [Required] 
        public string Email { get; set; }
    }
}
