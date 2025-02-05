using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.DTOs.User
{
    public class UserDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }

        public DateTime CreatAt { get; set; }
    }
}
