using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tickeo.Core;
using Tickeo.Core.DTOs;
using Tickeo.Repository.Interface;

namespace Tickeo.Service.Interfaces
{
    public interface IUserService : IRepository<BaseClass>
    {

        Task<UserResponseModel> AddUserWithEmail(UserDto userDto);
        Task<UserResponseModel> ActivateAccount(SignInRequestModel userDto);
        Task<UserResponseModel> GetUserByEmailAndPassword(SignInRequestModel signInRequestModel);
        Task<UserResponseModel> ResetPassword(SignInRequestModel userDto);
        Task<UserResponseModel> UpdatePassword(RequestPasswordModel userDto);
        Task<bool> DeleteUser(string email);
    }
}
