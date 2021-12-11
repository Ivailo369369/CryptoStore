namespace CryptoStore.Data.Models.Base
{
    using System;
    public interface IEntity
    {
        public DateTime CreatedOn { get; set; } 

        public DateTime? ModifiedOn { get; set; }
    }
}
