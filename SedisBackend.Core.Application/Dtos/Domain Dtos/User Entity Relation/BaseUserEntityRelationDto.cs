﻿namespace SedisBackend.Core.Application.Dtos.Domain_Dtos.User_Entity_Relation
{
    public class BaseUserEntityRelationDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int EntityId { get; set; }
    }
}
