﻿namespace CryptoStore.ViewModels.ApiModels.Identity
{
    using System.ComponentModel.DataAnnotations;

    public class LoginRequestModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
