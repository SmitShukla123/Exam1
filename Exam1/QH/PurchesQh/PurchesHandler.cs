using Exam1.Model;
using Exam1.QH.Unit;
using MediatR;
using static Exam1.QH.PurchesQh.PurchesQuery;

namespace Exam1.QH.PurchesQh
{
    public class PurchesHandler : IRequestHandler<InsertPurcheQ, Response<string>>,
        IRequestHandler<GetBYIdQ, Response<List<newpr>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public PurchesHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Task<Response<string>> Handle(InsertPurcheQ request, CancellationToken cancellationToken)
        {
            return _unitOfWork.PurcjesWork.InsertPurches(request.purch);
        }

        public Task<Response<List<newpr>>> Handle(GetBYIdQ request, CancellationToken cancellationToken)
        {
            return _unitOfWork.PurcjesWork.GetAllPurchaseByUser(request.id);
           
        }
    }
}
