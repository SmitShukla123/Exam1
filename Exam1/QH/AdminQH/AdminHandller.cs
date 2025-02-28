using Exam1.Model;
using Exam1.QH.Unit;
using MediatR;
using static Exam1.QH.AdminQH.AdminQuery;

namespace Exam1.QH.AdminQH
{
    public class AdminHandller : IRequestHandler<InsertAQ, Response<string>>,
        IRequestHandler<UpdateAQ, Response<string>>,
                                  IRequestHandler<GetAllAQ, Response<List<Produ>>>,
        IRequestHandler<DeleteAQ, Response<string>>,
        IRequestHandler<GetOneAQ, Response<Produ>>,
        IRequestHandler<GetOneByNameAQ, Response<Produ>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AdminHandller(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<Response<string>> Handle(InsertAQ request, CancellationToken cancellationToken)
        {
            return _unitOfWork.AdminWork.InsertAdmin(request.produc);
        }

        public Task<Response<List<Produ>>> Handle(GetAllAQ request, CancellationToken cancellationToken)
        {
            return _unitOfWork.AdminWork.GetAllAdmin(request.PageNumber,request.PageSize);
        }

        public Task<Response<Produ>> Handle(GetOneAQ request, CancellationToken cancellationToken)
        {
            return _unitOfWork.AdminWork.GetOneAd(request.id);
        }

        public Task<Response<string>> Handle(DeleteAQ request, CancellationToken cancellationToken)
        {
            return _unitOfWork.AdminWork.DeleteA(request.id);
        }

        public Task<Response<string>> Handle(UpdateAQ request, CancellationToken cancellationToken)
        {
            return _unitOfWork.AdminWork.UpdateAdmin(request.produc);
        }

        public Task<Response<Produ>> Handle(GetOneByNameAQ request, CancellationToken cancellationToken)
        {
            return _unitOfWork.AdminWork.GetOneByPname(request.pname);
        }
    }
}


