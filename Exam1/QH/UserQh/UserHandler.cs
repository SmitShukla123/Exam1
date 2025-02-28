using Exam1.Model;
using Exam1.QH.Unit;
using MediatR;
using static Exam1.QH.UserQh.UserQuery;

namespace Exam1.QH.UserQh
{
    public class UserHandler : IRequestHandler<SingUpQ, Response<string>>,
         IRequestHandler<LoginQ, Response<string>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Response<string>> Handle(SingUpQ request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.UserWork.SingUp(request.register);
        }

        public async Task<Response<string>> Handle(LoginQ request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.UserWork.SingIn(request.login);
        }
    }
}
