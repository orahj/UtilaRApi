using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickeo.Core;
using Tickeo.Core.DTOs;
using Tickeo.Core.Entities;
using Tickeo.Core.ENUMs;
using Tickeo.Repository.Interface;

namespace Tickeo.Repository.Implementation
{
    public class UserRepository : Repository<BaseClass>, IUserRepository
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        public UserRepository(TickeoDbContext context) : base(context)
        {

        }



        public async Task<UserResponseModel> AddUser(UserDto userDto)
        {
            UserResponseModel userCreated = new UserResponseModel();
            User user = new User();
            try
            {

                var existingUser = await GetUserByEmail(userDto.Email);
                if (existingUser.ResponseCode == "40")
                {
                    user.DateOfBirth = userDto.DateOfBirth;
                    user.Email = userDto.Email;
                    user.Password = userDto.Password;
                    user.PhoneNumber = userDto.PhoneNumber;
                    user.Address = userDto.Address;
                    user.Country = userDto.Country;
                    user.State = userDto.State;
                    user.ProgressLevel = ((int)ProgressLevels.NewUser).ToString();
                    user.AddedDate = DateTime.Now;
                    user.ModifiedDate = DateTime.Now;
                    user.ReferralCode = userDto.ReferralCode;
                    //updating user details with bvn response
                    user.FirstName = userDto.FirstName;
                    user.UserName = userDto.UserName;
                    user.MiddleName = userDto.MiddleName;
                    user.LastName = userDto.LastName;
                    
                    user.Gender = userDto.Gender;
                    user.Title = userDto.Title;
                    context.Add(user);
                    await context.SaveChangesAsync();
                    var foundUser = context.User.Where(x => x.Email == userDto.Email
                    && x.Password == userDto.Password
                    && x.IsDeleted == false).FirstOrDefault();
                    userCreated.Id = foundUser.Id;
                    userCreated.DateOfBirth = foundUser.DateOfBirth;
                    userCreated.Email = foundUser.Email;
                    // userCreated.Password = userDto.Password;
                    userCreated.PhoneNumber = foundUser.PhoneNumber;
                    userCreated.Address = foundUser.Address;
                    userCreated.Country = foundUser.Country;
                    userCreated.State = foundUser.State;
                    userCreated.AddedDate = foundUser.AddedDate;
                    userCreated.ModifiedDate = foundUser.ModifiedDate;
                    //userCreated.Password = userDto.Password;
                    userCreated.UserEvents = existingUser.UserEvents;
                    userCreated.ResponseCode = "00";
                    userCreated.ResponseDescription = "Operation Successful";
                }
                else if (existingUser.ResponseCode == "00")
                {
                    
                        userCreated.ResponseCode = "09";
                        userCreated.ResponseDescription = "User with the email already exists";
            


                }
                else
                {
                    userCreated.ResponseCode = "50";
                    userCreated.ResponseDescription = "Operation Unsuccessful.";
                }

            }
            catch (Exception ex)
            {
                userCreated.ResponseCode = "40";
                userCreated.ResponseDescription = "Operation Unsuccessful";
                Logger.Error("Insert Customer failed. Customer email" + userDto.Email + ".Message:" + ex.Message + "StackTrace:" + ex.StackTrace);
            }

            return userCreated;
        }
        public async Task<UserResponseModel> GetUserByEmail(string email)
        {
            UserResponseModel user = new UserResponseModel();
            var foundUser = context.User.Where(x => x.Email == email
            && x.IsDeleted == false).FirstOrDefault();
            if (foundUser != null)
            {
                user.Id = foundUser.Id;
                user.DateOfBirth = foundUser.DateOfBirth;
                user.Email = foundUser.Email;
                user.ProgressLevel = foundUser.ProgressLevel;
                user.PhoneNumber = foundUser.PhoneNumber;
                user.Address = foundUser.Address;
                user.Country = foundUser.Country;
                user.IsActive = foundUser.IsActive;
                user.AddedDate = DateTime.Now;
                user.ModifiedDate = DateTime.Now;
                user.FirstName = foundUser.FirstName;
                user.LastName = foundUser.LastName;
                user.MiddleName = foundUser.MiddleName;
                user.Address = foundUser.Address;
               
                user.Gender = foundUser.Gender;
                user.DateOfBirth = foundUser.DateOfBirth;
                user.Email = foundUser.Email;
                user.State = foundUser.State;
                user.PhoneNumber = foundUser.PhoneNumber;
               
                user.UserEvents = new List<UserEvent>();
            

                user.ResponseCode = "00";
                user.ResponseDescription = "Operation Successful";


            }
            else
            {
                user.ResponseCode = "40";
                user.ResponseDescription = "User Not Found";
            }
            return user;
        }
        public async Task<UserResponseModelWithPassword> GetUserPasswordByEmail(string email)
        {
            UserResponseModelWithPassword user = new UserResponseModelWithPassword();
            var foundUser = context.User.Where(x => x.Email == email
            && x.IsDeleted == false).FirstOrDefault();
            if (foundUser != null)
            {
                user.Id = foundUser.Id;
                user.DateOfBirth = foundUser.DateOfBirth;
                user.Email = foundUser.Email;
                user.ProgressLevel = foundUser.ProgressLevel;
                user.PhoneNumber = foundUser.PhoneNumber;
                user.Address = foundUser.Address;
                user.Country = foundUser.Country;
                user.IsActive = foundUser.IsActive;
                user.AddedDate = DateTime.Now;
                user.ModifiedDate = DateTime.Now;
                user.FirstName = foundUser.FirstName;
                user.LastName = foundUser.LastName;
                user.MiddleName = foundUser.MiddleName;
                user.Address = foundUser.Address;
                user.Password = foundUser.Password;

                user.Gender = foundUser.Gender;
                user.DateOfBirth = foundUser.DateOfBirth;
                user.Email = foundUser.Email;
                user.State = foundUser.State;
                user.PhoneNumber = foundUser.PhoneNumber;

                user.UserEvents = new List<UserEvent>();
               
                user.ResponseCode = "00";
                user.ResponseDescription = "Operation Successful";


            }
            else
            {
                user.ResponseCode = "40";
                user.ResponseDescription = "User Not Found";
            }
            return user;
        }
        public async Task<UserResponseModel> GetUserByEmailAndPassword(SignInRequestModel signInRequestModel, string sessionKey)
        {
            UserResponseModel user = new UserResponseModel();
            var foundUser = context.User.Where(x => x.Email == signInRequestModel.Email
            && x.Password == signInRequestModel.Password
            && x.IsDeleted == false).FirstOrDefault();
            if (foundUser != null)
            {
                foundUser.SessionKey = sessionKey;
                await context.SaveChangesAsync();
                user.Id = foundUser.Id;
                user.DateOfBirth = foundUser.DateOfBirth;
                user.Email = foundUser.Email;
                user.ProgressLevel = foundUser.ProgressLevel;
                user.PhoneNumber = foundUser.PhoneNumber;
                user.Address = foundUser.Address;
                user.Country = foundUser.Country;
                user.FirstName = foundUser.FirstName;
                user.MiddleName = foundUser.MiddleName;
                user.LastName = foundUser.LastName;
                //user.SessionKey = foundUser.SessionKey;
                user.IsActive = foundUser.IsActive;
                user.AddedDate = DateTime.Now;
                user.ModifiedDate = DateTime.Now;
                user.ResponseCode = "00";
                user.ResponseDescription = "Operation Successful";
               
                user.UserEvents = new List<UserEvent>();
               
            }
            else
            {
                user.ResponseCode = "40";
                user.ResponseDescription = "User Not Found";
            }
            return user;
        }
        public async Task<UserResponseModel> UpdateUser(UserDto userDto)
        {
            var postParam = JsonConvert.SerializeObject(userDto);
            Logger.Error("Insert UpdateUser . raw request " + postParam);
            UserResponseModel userCreated = new UserResponseModel();
            User user = new User();
            try
            {


                var foundUser = context.User.Where(x => x.Email == userDto.Email
                // && x.Password == userDto.Password
                && x.IsDeleted == false
                && x.SessionKey == userDto.SessionKey
                ).FirstOrDefault();

                if (foundUser != null)
                {

                    // user.IsActive = userDto.IsActive;
                    //updating user details with bvn response
                    foundUser.FirstName = userDto.FirstName;
                    foundUser.DateOfBirth = userDto.DateOfBirth;
                    foundUser.MiddleName = userDto.MiddleName;
                    foundUser.LastName = userDto.LastName;
                    foundUser.Gender = userDto.Gender;
                    foundUser.Title = userDto.Title;
                  
                    foundUser.UserName = userDto.FirstName;
                    
                    foundUser.Email = userDto.Email;
                    foundUser.PhoneNumber = userDto.PhoneNumber;
                    foundUser.Address = userDto.Address;
                    foundUser.Country = userDto.Country;
                    foundUser.State = userDto.State;
                    foundUser.ProgressLevel = ((int)ProgressLevels.Activated).ToString();
                    // foundUser.EmploymentStatus = Enum.GetName(typeof(EmploymentType), userDto.EmploymentStatus);
                   

                    foundUser.ModifiedDate = DateTime.Now;
                   
                    // context.Update(foundUser);
                    await context.SaveChangesAsync();
                    var updatedUser = context.User.Where(x => x.Email == userDto.Email
                    //&& x.Password == userDto.Password
                    ).FirstOrDefault();
                    userCreated.Id = updatedUser.Id;
                    userCreated.DateOfBirth = updatedUser.DateOfBirth;
                    userCreated.Email = updatedUser.Email;
                    //userCreated.Password = updatedUser.Password;
                    userCreated.FirstName = foundUser.FirstName;
                    userCreated.MiddleName = foundUser.MiddleName;
                    userCreated.LastName = foundUser.LastName;
                    userCreated.PhoneNumber = updatedUser.PhoneNumber;
                    userCreated.Address = updatedUser.Address;
                    userCreated.Country = updatedUser.Country;
                    userCreated.State = updatedUser.State;
                    userCreated.AddedDate = updatedUser.AddedDate;
                    userCreated.ModifiedDate = updatedUser.ModifiedDate;
                    userCreated.ProgressLevel = updatedUser.ProgressLevel;
                    userCreated.IsActive = userCreated.IsActive;
                   


                   

                    userCreated.ResponseCode = "00";
                    userCreated.ResponseDescription = "Operation Successful";
                }
                else
                {
                    userCreated.ResponseCode = "60";
                    userCreated.ResponseDescription = "Operation Unsuccessful. User not found";
                }

            }
            catch (Exception ex)
            {
                Logger.Error("Insert UpdateUser exception. raw request " + postParam + ".Message:" + ex.Message + "StackTrace:" + ex.StackTrace);
                userCreated.ResponseCode = "40";
                userCreated.ResponseDescription = "Operation Unsuccessful";
            }

            return userCreated;
        }
        public async Task<UserResponseModel> ActivateAccount(string email)
        {
            UserResponseModel userCreated = new UserResponseModel();
            try
            {
                var foundUser = context.User.Where(r => r.Email == email
                && r.IsDeleted == false).FirstOrDefault();
                if (foundUser != null)
                {
                    if (!foundUser.IsActive)
                    {
                        foundUser.ProgressLevel = ((int)ProgressLevels.Activated).ToString();
                        foundUser.IsActive = true;
                    }
                   
                    await context.SaveChangesAsync();
                    userCreated.DateOfBirth = foundUser.DateOfBirth;
                    userCreated.Email = foundUser.Email;
                    userCreated.ProgressLevel = foundUser.ProgressLevel;
                    userCreated.PhoneNumber = foundUser.PhoneNumber;
                    userCreated.Address = foundUser.Address;
                    userCreated.FirstName = foundUser.FirstName;
                    userCreated.MiddleName = foundUser.MiddleName;
                    userCreated.LastName = foundUser.LastName;
                    userCreated.Gender = foundUser.Gender;
                   
                    userCreated.State = foundUser.State;
                    userCreated.Country = foundUser.Country;
                    userCreated.IsActive = foundUser.IsActive;
                    userCreated.AddedDate = DateTime.Now;
                    userCreated.ModifiedDate = DateTime.Now;
                    userCreated.Id = foundUser.Id;
                    userCreated.ResponseCode = "00";
                    userCreated.ResponseDescription = "Operation Successful";
                
                  
                }

            }
            catch (Exception ex)
            {
                userCreated.ResponseCode = "40";
                userCreated.ResponseDescription = "Operation Unsuccessful";
            }

            return userCreated;
        }

        public Task<UserResponseModel> AddUserForMobile(UserDto userDto)
        {
            throw new NotImplementedException();
        }

        public Task<UserResponseModel> AddUserBeneficiary(UserDto userDto)
        {
            throw new NotImplementedException();
        }

        public Task<UserResponseModel> DeactivateUser(SignInRequestModel signInRequestModel)
        {
            throw new NotImplementedException();
        }

        public async Task<UserResponseModel> ResetPassword(SignInRequestModel userDto)
        {
            UserResponseModel userCreated = new UserResponseModel();
            try
            {
                var foundUser = context.User.Where(r => r.Email == userDto.Email
                && r.IsDeleted == false).FirstOrDefault();
                if (foundUser != null)
                {
                    foundUser.Password = userDto.Password;
                    // context.Update(foundUser);
                    await context.SaveChangesAsync();
                    userCreated.DateOfBirth = foundUser.DateOfBirth;
                    userCreated.Email = foundUser.Email;
                    // userCreated.Password = foundUser.Password;
                    userCreated.PhoneNumber = foundUser.PhoneNumber;
                    userCreated.Address = foundUser.Address;
                    userCreated.Country = foundUser.Country;
                    userCreated.IsActive = foundUser.IsActive;
                    userCreated.Id = foundUser.Id;
                    userCreated.AddedDate = DateTime.Now;
                    userCreated.ModifiedDate = DateTime.Now;
                    userCreated.ResponseCode = "00";
                    userCreated.ResponseDescription = "Operation Successful";
                }

            }
            catch (Exception ex)
            {
                userCreated.ResponseCode = "40";
                userCreated.ResponseDescription = "Operation Unsuccessful";
            }

            return userCreated;
        }


        public Task<UserResponseModel> GetUserByEmailAndPhoneNumber(string email, string mobile, string bvn)
        {
            throw new NotImplementedException();
        }

        public Task<UserResponseModel> GetUserById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteUser(string email)
        {
            UserResponseModel userCreated = new UserResponseModel();
            try
            {
                var deleteUserDetails =
                from users in context.User
                where users.Email == email
                select users;

                foreach (var user in deleteUserDetails)
                {

                   
                    context.Remove(user);
                }
                await context.SaveChangesAsync();
               

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

            //return userCreated;
        }


        public async Task<UserResponseModel> UpdatePassword(RequestPasswordModel userDto)
        {
            UserResponseModel userCreated = new UserResponseModel();
            try
            {
                var foundUser = context.User.Where(r => r.Email == userDto.Email
                   && r.AccountNumber != null
                   && r.Password == userDto.OldPassword
                && r.IsDeleted == false).FirstOrDefault();
                if (foundUser != null)
                {
                    foundUser.Password = userDto.Password;
                    foundUser.ModifiedDate = DateTime.Now;
                    // context.Update(foundUser);
                    await context.SaveChangesAsync();
                    userCreated.DateOfBirth = foundUser.DateOfBirth;
                    userCreated.Email = foundUser.Email;
                    // userCreated.Password = foundUser.Password;
                    userCreated.PhoneNumber = foundUser.PhoneNumber;
                    userCreated.Address = foundUser.Address;
                    userCreated.Country = foundUser.Country;
                    userCreated.IsActive = foundUser.IsActive;
                    userCreated.Id = foundUser.Id;
                    userCreated.AddedDate = DateTime.Now;
                    userCreated.ModifiedDate = DateTime.Now;
                    userCreated.ResponseCode = "00";
                    userCreated.ResponseDescription = "Operation Successful";
                }

            }
            catch (Exception ex)
            {
                userCreated.ResponseCode = "40";
                userCreated.ResponseDescription = "Operation Unsuccessful";
            }

            return userCreated;
        }

    }
}
