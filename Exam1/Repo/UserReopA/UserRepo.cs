using Exam1.Model;
using Exam1.Models;
using Microsoft.EntityFrameworkCore;

namespace Exam1.Repo.UserReopA
{
    public class UserRepo : IUserRepositories<User>, IUserRepo
    {
        private readonly string _connctionstring;
        private readonly Exam1Context _exam1Context;

        public UserRepo(Exam1Context exam1Context, string connctionstring)
        {
            _exam1Context = exam1Context;
            _connctionstring = connctionstring;
        }

        public async Task<Response<string>> SingIn(Login login)
            {
            Response<string> res = new();
            try
            {
                if(login == null)
                {
                    res.IsSuccess = false;
                    res.Status = Response_Status.Fail;
                    res.Error_Message = "Please a enter a details";
                    return res;
                }

                var exit = await _exam1Context.Users.Where(x => x.Email == login.email && x.Password == login.password).FirstOrDefaultAsync();
                if (exit == null) 
                {
                    res.IsSuccess = false;
                    res.Status = Response_Status.Fail;
                    res.Error_Message = "Invalid Email and Password";
                    return res;
                }
                res.IsSuccess = true;
                res.Status = Response_Status.Success;
                res.Success_Message = "Login Succefully";
                return res;
            }
            catch (Exception ex)
            {

                res.IsSuccess = false;
                res.Error_Message = "Something Wrong";
                res.Status = Response_Status.Fail;
                return res;

            }

        }

        public async Task<Response<string>> SingUp(Register register)
        {
            Response<string> res = new();

            try
            {
                if (register == null)
                {
                    res.IsSuccess = false;
                    res.Error_Message = "Plese Enter a Details";
                    res.Status = Response_Status.Fail;
                    return res;
                }

                var REmailExits = _exam1Context.Users.Where(x => x.Email == register.email).FirstOrDefault();
                if (REmailExits != null)
                {
                    res.IsSuccess = false;
                    res.Error_Message = "Your Email Id Already Exits";
                    res.Status = Response_Status.Fail;
                    return res;
                }

                User data = new()
                {
                    Name=register.name, 
                    Email = register.email,
                    Cpassword = register.cpassword,
                    Password = register.password,
                };
                _exam1Context.Users.Add(data);
                _exam1Context.SaveChanges();
                res.IsSuccess = true;
                res.Success_Message = "Register Succefully";
                res.Status = Response_Status.Success;
                return res;
            }
            catch (Exception ex)
            {

                res.IsSuccess = false;
                res.Error_Message = "Something Wrong";
                res.Status = Response_Status.Fail;
                return res;

            }
        }
    }
}