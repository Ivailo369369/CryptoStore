namespace CryptoStore.Data.Models.Base
{
    using System;

    public abstract class Entity : IEntity
    {
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; } 
    }
}
