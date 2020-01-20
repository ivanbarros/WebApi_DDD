using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Entities
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            
        }
        public BaseEntity(Guid id) => this.Id = id;

        [Key]
        public Guid Id { get; set; }

        private DateTime? _creatAt;
        public DateTime? CreateAt
        {
            get { return _creatAt; }
            set { _creatAt = (value == null ? DateTime.UtcNow : value); }
        }

        public DateTime? UpdateAt { get; set; }
        
    
    }
}
