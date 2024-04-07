﻿using Microsoft.AspNetCore.Http;

namespace SedisBackend.Core.Application.Dtos.Identity_Dtos.Account
{
    public class RegisterRequest
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string IdCard { get; set; }
        public IFormFile? FormFile { get; set; }
        public string? ImageUrl { get; set; }
        public bool IsActive { get; set; }
        public string PhoneNumber { get; set; }
    }
}