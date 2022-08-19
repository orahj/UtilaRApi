using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tickeo.Core;
using Tickeo.Core.DTOs;

namespace Tickeo.Repository.Interface
{
    public interface IUserRepository : IRepository<BaseClass>
    {
        Task<UserResponseModel> AddUser(UserDto userDto);
        Task<UserResponseModel> AddUserForMobile(UserDto userDto);
        Task<UserResponseModel> AddUserBeneficiary(UserDto userDto);
        Task<UserResponseModel> GetUserByEmailAndPassword(SignInRequestModel signInRequestModel, string sessionKey);
        Task<UserResponseModel> UpdateUser(UserDto userDto);
        Task<UserResponseModel> DeactivateUser(SignInRequestModel signInRequestModel);
        Task<UserResponseModel> ResetPassword(SignInRequestModel userDto);
        Task<UserResponseModel> GetUserByEmail(string email);
        Task<UserResponseModel> GetUserByEmailAndPhoneNumber(string email, string mobile, string bvn);
        Task<UserResponseModel> ActivateAccount(string email);
      
   
        Task<UserResponseModel> GetUserById(Guid id);
        Task<bool> DeleteUser(string bvn);

        Task<UserResponseModel> UpdatePassword(RequestPasswordModel userDto);
        Task<UserResponseModelWithPassword> GetUserPasswordByEmail(string email);



    }
}
