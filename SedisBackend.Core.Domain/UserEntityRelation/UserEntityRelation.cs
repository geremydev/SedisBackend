﻿namespace SedisBackend.Core.Domain.UserEntityRelation
{
    public class UserEntityRelation
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int EntityId { get; set; }
        public string EntityRole { get; set; } //Usando el enum de UserRole en Application
    }
}
