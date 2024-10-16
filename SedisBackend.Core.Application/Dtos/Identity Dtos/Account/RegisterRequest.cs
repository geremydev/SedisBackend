using Microsoft.AspNetCore.Http;
using System.Text.Json.Serialization;

namespace SedisBackend.Core.Application.Dtos.Identity_Dtos.Account
{
    public class RegisterRequest
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string IdCard { get; set; }

        [JsonIgnore]
        public IFormFile? FormFile { get; set; }
        public string? ImageUrl { get; set; }
        public bool IsActive { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Birthdate { get; set; }
        public char Sex { get; set; }
        public string BloodType { get; set; }
        public string? EmergencyContactName { get; set; }
        public string? EmergencyContactPhone { get; set; }
        public Guid? PrimaryCarePhysicianId { get; set; }
    }
}
