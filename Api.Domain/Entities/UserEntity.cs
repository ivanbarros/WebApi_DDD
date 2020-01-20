using System;

namespace Api.Domain.Entities
{
    public class UserEntity : BaseEntity
    {
        public UserEntity()
        {
            
        }
        public UserEntity(Guid id) : base(id)
        {
        }

        public string Name { get; set; }
        public string Email { get; set; }
    }
    
}
