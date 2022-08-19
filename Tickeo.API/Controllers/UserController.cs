using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tickeo.Core.DTOs;
using Tickeo.Service.Interfaces;

namespace Tickeo.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private AppSettings appSettings { get; set; }
        private readonly IUserService _service;
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        //   private readonly Microsoft.Extensions.Logging.ILogger Logger;

        public UserController(IUserService service, IOptions<AppSettings> settings)
        {
            _service = service;
            appSettings = settings.Value;
            //  Logger = logger;
            // baseUrl= appSettings.BaseUrl;
        }


        [HttpPost]
        [Route("ActivateAccount")]
        public async Task<UserResponseModel> ActivateAccount(ActivateUserRequest activateUserRequest)
        {
            SignInRequestModel userDto = new SignInRequestModel();
            userDto.Email = activateUserRequest.ActivationRef;
            var userDetails = await _service.ActivateAccount(userDto);
            return userDetails;
        }

        [HttpGet]
        [Route("DeleteUser")]
        public async Task<bool> DeleteUser(string email)
        {
            var res = await _service.DeleteUser(email);
            return res;
        }

        [HttpPost]
        [Route("SignIn")]
        public async Task<UserResponseModel> SignIn(SignInRequestModel userDto)
        {
            //test commit
            var signUpResponse = await _service.GetUserByEmailAndPassword(userDto);
            return signUpResponse;
        }

        [HttpPost]
        [Route("SignUpWithEmail")]
        public async Task<UserResponseModel> SignUpWithEmail(AddUserWithEmailRequestDto signUpRequestModel)
        {
            UserDto userDto = new UserDto();
            userDto.Email = signUpRequestModel.Email;
            userDto.Password = signUpRequestModel.Password;
            userDto.FirstName = signUpRequestModel.FirstName;
            userDto.LastName = signUpRequestModel.LastName;
            userDto.MiddleName = signUpRequestModel.MiddleName;
            var signUpResponse = await _service.AddUserWithEmail(userDto);
            return signUpResponse;
        }

        [HttpPost]
        [Route("UpdatePassword")]
        public async Task<UserResponseModel> UpdatePassword(RequestPasswordModel userDto)
        {

            UserResponseModel resetResponse = new UserResponseModel();
           
            resetResponse = await _service.UpdatePassword(userDto);
           
            return resetResponse;
        }


        //[HttpPost]
        //[Route("ResetPassword")]
        //public async Task<UserResponseModel> ResetPassword(SignInRequestModel userDto)
        //{
        //    //test commit
        //    var resetResponse = await _service.ResetPassword(userDto);
        //    return resetResponse;
        //}

    }
}
