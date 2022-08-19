using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Tickeo.Core;
using Tickeo.Core.DTOs;
using Tickeo.Repository.Interface;
using Tickeo.Service.Interfaces;

namespace Tickeo.Service.Implementation
{
    public class UserService : IUserService
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        private AppSettings appSettings { get; set; }
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;

        public UserService(IOptions<AppSettings> settings, IUserRepository userRepository, IConfiguration configuration)
        {
            appSettings = settings.Value;
            _userRepository = userRepository;
            _configuration = configuration;
        


        }

        public async Task<UserResponseModel> AddUserWithEmail(UserDto userDto)
        {
            var serializedBVNResponse = JsonConvert.SerializeObject(userDto);
            Logger.Info("Method: AddUser Implementation. AddUser "  + " Request DOB: " + userDto.DateOfBirth + ".email:" + userDto.Email);
            
            UserResponseModel userDetails = new UserResponseModel();
            try
            {
                Logger.Info("Method: AddUserWithEmail Implementation. AddUserWithEmail "  + " bvn dob matched");
                userDto.Password = await EncryptAlt(userDto.Password);
                userDetails = await _userRepository.AddUser(userDto);
                if (userDetails.ResponseCode == "00")
                {
                   var encryptedEmailAddress = await EncryptAlt(userDto.Email);
                   var Url = appSettings.EmailUrl;
                    userDetails.TempTestRef = encryptedEmailAddress;
                    try
                    {
                        SendEmail(appSettings.FromEmail,
                       userDto.Email,
                       "Verification Email",
                       Url + "?ref=" + encryptedEmailAddress,
                       appSettings.SMTP,
                       appSettings.Port,
                      appSettings.FromPassword, true);
                    }
                    catch(Exception ex)
                    {
                        Logger.Info("Method: AddUserWithEmail Send email Exception. AddUserWithEmail: " + "Request :   DOB: " + userDto.DateOfBirth + ".email:" + userDto.Email + "ErrorMessage: " + ex.Message + "StackTrace: " + ex.StackTrace);

                    }

                }
                else
                {
                    userDetails.ResponseCode = "50";
                }
            }
            catch (Exception ex)
            {
                
                Logger.Info("Method: AddUserWithEmail Exception. AddUserWithEmail: " + "Request :   DOB: " + userDto.DateOfBirth + ".email:" + userDto.Email + "ErrorMessage: " + ex.Message + "StackTrace: " + ex.StackTrace);
                userDetails.ResponseCode = "90";
                userDetails.ResponseDescription = "Operation Unsuccessful." + ex.Message;
            }

            return userDetails;
        }

        public async Task<UserResponseModel> ActivateAccount(SignInRequestModel userDto)
        {
            var userDetails = new UserResponseModel();
            try
            {
                Logger.Info("Method: ActivateAccount Implementation. ActivateAccount " + "Request email: " + userDto.Email);
                var email = await DecryptAlt(userDto.Email);
                userDetails = await _userRepository.ActivateAccount(email);
                
            }
            catch (Exception ex)
            {
                Logger.Info("Method: ActivateAccount Exception. ActivateAccount " + "Request email: " + userDto.Email + " .ErrorMessage: " + ex.Message + "StackTrace: " + ex.StackTrace);
            }

            return userDetails;
        }


        public async Task<UserResponseModel> GetUserByEmailAndPassword(SignInRequestModel signInRequestModel)
        {
            var userDetails = new UserResponseModel();

            try
            {
                Logger.Info("Method: GetUserByEmailAndPassword Implementation. GetUserByEmailAndPassword " + "Request email: " + signInRequestModel.Email);
                signInRequestModel.Password = await EncryptAlt(signInRequestModel.Password);
                var currentDateTime = DateTime.Now;
                var SessionKey = await EncryptAlt(currentDateTime.ToString());
                userDetails = await _userRepository.GetUserByEmailAndPassword(signInRequestModel, SessionKey);

            }
            catch (Exception ex)
            {
                Logger.Info("Method: GetUserByEmailAndPassword Exception. GetUserByEmailAndPassword " + "Request email: " + signInRequestModel.Email + "ErrorMessage: " + ex.Message + "StackTrace: " + ex.StackTrace);
            }
            return userDetails;
        }
        public void SendEmail(string emailFromAddress
            ,string emailToAddress
            ,string subject
            ,string body
            ,string smtpAddress
            ,int portNumber
            ,string password
            ,bool enableSSL
            )
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(emailFromAddress);
                mail.To.Add(emailToAddress);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = false;
                 
                using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                {
                    smtp.Credentials = new NetworkCredential(emailFromAddress, password);
                    smtp.EnableSsl = enableSSL;
                    smtp.Send(mail);
                }
            }
        }

        public async Task<string> EncryptAlt(String plainText)
        {
            //update encryption mode
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }


       

        public async Task<string> DecryptAlt(String val)
        {
           
            string rsp = "";
            try
            {
                var base64EncodedBytes = System.Convert.FromBase64String(val);
                rsp = Encoding.UTF8.GetString(base64EncodedBytes);
            }
            catch (Exception ex)
            {
               
            }
            return rsp;
        }

        public async Task<UserResponseModel> ResetPassword(SignInRequestModel userDto)
        {
            var userDetails = new UserResponseModel();
            try
            {
                Logger.Info("Method: ResetPassword Implementation. ResetPassword " + "Request email: " + userDto.Email);

                userDto.Password = await EncryptAlt(userDto.Password);
                userDetails = await _userRepository.ResetPassword(userDto);
            }
            catch (Exception ex)
            {
                Logger.Info("Method: ResetPassword Exception. ResetPassword " + "Request email: " + userDto.Email + " .ErrorMessage: " + ex.Message + "StackTrace: " + ex.StackTrace);

            }

            return userDetails;
        }

        public async Task<UserResponseModel> UpdatePassword(RequestPasswordModel userDto)
        {
            var userDetails = new UserResponseModel();
            try
            {
                Logger.Info("Method: UpdatePassword Implementation. ResetPassword " + "Request email: " + userDto.Email);
                userDto.Password = await EncryptAlt(userDto.Password);
                userDto.OldPassword = await EncryptAlt(userDto.OldPassword);
                var user = await _userRepository.GetUserPasswordByEmail(userDto.Email);
                if (user.ResponseCode == "00" && user.Password == userDto.OldPassword)
                {
                   
                        userDetails = await _userRepository.UpdatePassword(userDto);
                   
                }
                else
                {
                    userDetails.ResponseCode = "66";
                    userDetails.ResponseDescription = "User with email/password not found";
                }
            }
            catch (Exception ex)
            {

                userDetails.ResponseCode = "76";
                userDetails.ResponseDescription = "An error occured";
                Logger.Info("Method: UpdatePassword Exception. ResetPassword " + "Request email: " + userDto.Email + " .ErrorMessage: " + ex.Message + "StackTrace: " + ex.StackTrace);

            }

            return userDetails;
        }


        public async Task<bool> DeleteUser(string email)
        {
            var res = await _userRepository.DeleteUser(email);
            return res;
        }

        public IEnumerable<BaseClass> GetAll()
        {
            throw new NotImplementedException();
        }

        public BaseClass Get(long id)
        {
            throw new NotImplementedException();
        }

        public void Insert(BaseClass entity)
        {
            throw new NotImplementedException();
        }

        public void Update(BaseClass entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(BaseClass entity)
        {
            throw new NotImplementedException();
        }
    }
}
