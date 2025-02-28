using Exam1.Model;
using MediatR;

namespace Exam1.QH.PurchesQh
{
    public class PurchesQuery
    {
        public record class InsertPurcheQ(UserPurch purch) : IRequest<Response<string>>;
        public record class GetBYIdQ(int id):IRequest<Response<List<newpr>>>;


    }
}
