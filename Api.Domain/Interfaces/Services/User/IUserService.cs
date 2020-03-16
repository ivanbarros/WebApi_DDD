using Api.Domain.DTOs.User;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Domain.Interfaces.Services.User
{
    public interface IUserService
    {
        Task<UserDTO> Get (Guid id);

        Task<IEnumerable<UserDTO>> GetAll ();

        Task<UserDTOCreateResult> Post (UserDtoCreate user);

        Task<UserDTOUpdateResult> Put (UserDtoUpdate user);

        Task<bool> Delete (Guid id);
    }
}
