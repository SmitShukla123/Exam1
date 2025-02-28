using Exam1.Model;

namespace Exam1.Repo.UserReopA
{
    public interface IUserRepositories<T> where T : class
    {
        Task<Response<string>> SingUp(Register register);
        Task<Response<string>> SingIn(Login login);
    }
}
