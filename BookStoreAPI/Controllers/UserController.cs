using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BookStoreAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserBL userBL;
        public UserController(IUserBL userBL)
        {
            this.userBL = userBL;
        }

        [HttpPost]
        public ActionResult RegisterUser(UserModel usermodel)
        {
            try
            {
                this.userBL.RegisterUser(usermodel);
                return this.Ok(new { success = true, message = $"Registration Successful  {usermodel.EmailId}" });
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        public ActionResult LogInUser(LogInModel logInModel)
        {
            try
            {
                var result = this.userBL.LogInUser(logInModel);
                if (result != null)
                {
                    return this.Ok(new { success = true, message = $"Login Successful : {logInModel.EmailId}", response = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Login Unsuccesful" });
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPut]
        public ActionResult ForgetPassword(string email)
        {
            try
            {
                var result = this.userBL.ForgetPassword(email);
                if(result == true)
                {
                    return this.Ok(new { success = true, message = "Token sent succesfully to email for password reset. Please check your Email" });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Email is invalid" });
                }
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        [AllowAnonymous]
        [HttpPut]
        public ActionResult ResetPassword(string Password)
        {
            try
            {
                var identity = User.Identity as ClaimsIdentity;
                if (identity != null)
                {
                    IEnumerable<Claim> claims = identity.Claims;
                    var UserEmailObject = claims.FirstOrDefault()?.Value;
                    if (UserEmailObject != null)
                    {
                        this.userBL.ResetPassword(UserEmailObject, Password);
                        return Ok(new { success = true, message = "Password Changed Sucessfully" });
                    }
                    else
                    {
                        return this.BadRequest(new { success = false, message = $"Email is not Authorized" });
                    }
                }
                return this.BadRequest(new { success = false, message = $"Password not changed Successfully" });
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
