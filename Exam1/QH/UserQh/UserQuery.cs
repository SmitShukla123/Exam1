using Exam1.Model;
using MediatR;

namespace Exam1.QH.UserQh
{
    public class UserQuery
    {
        public record class SingUpQ(Register register):IRequest<Response<string>>;
        public record class LoginQ(Login login):IRequest<Response<string>>;
    }
}
