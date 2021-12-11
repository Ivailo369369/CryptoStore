namespace CryptoStore.Data.Models
{
    using CryptoStore.Data.Models.Base;
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;

    public class User : IdentityUser, IEntity
    {
        public User() => Services = new List<Service>();

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public ICollection<Service> Services { get; set; }
    }
}
