using BusinessLayer.Interfaces;
using ModelLayer.Services;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class UserBL : IUserBL
    {
        IUserRL userRL;
        public UserBL(IUserRL userRL)
        {
            this.userRL = userRL;
        }

        public bool ForgetPassword(string email)
        {
            try
            {
                return this.userRL.ForgetPassword(email);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string LogInUser(LogInModel logInModel)
        {
            try
            {
                return this.userRL.LogInUser(logInModel);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public void RegisterUser(UserModel userModel)
        {
            try
            {
                this.userRL.RegisterUser(userModel);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void ResetPassword(string EmailId, string Password)
        {
            try
            {
                this.userRL.ResetPassword(EmailId,Password);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
