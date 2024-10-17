﻿namespace SedisBackend.Core.Application.Dtos.Identity_Dtos.Account
{
    public class RefreshToken
    {
        public int Id { get; set; }
        public string? Token { get; set; }
        public DateTime Expires { get; set; }
        public bool IsExpired => DateTime.UtcNow >= Expires;
        public DateTime? Created { get; set; }
        public DateTime? Revoked { get; set; }
        public string? ReplaceByToken { get; set; }
        public bool IsActive => Revoked == null && !IsExpired;
    }
}
