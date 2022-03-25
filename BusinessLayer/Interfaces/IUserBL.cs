using ModelLayer.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface IUserBL
    {
        void RegisterUser(UserModel userModel);
        string LogInUser(LogInModel logInModel);
        bool ForgetPassword(string email);
        void ResetPassword(string EmailId, string Password);
    }
}
