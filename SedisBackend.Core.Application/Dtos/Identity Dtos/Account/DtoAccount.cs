namespace SedisBackend.Core.Application.Dtos.Identity_Dtos.Account
{
    public class DtoAccount
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string ImageUrl { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public List<int> AssignedUsersIds { get; set; }
        public List<string> AssignedUsersRoles { get; set; } //Filled with RolesEnum.ToString()
        public List<string> Roles { get; set; }
        public bool IsVerified { get; set; }
        public bool IsActive { get; set; }
        public bool HasError { get; set; }
        public string? Error { get; set; }
    }
}