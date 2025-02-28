using Exam1.Model;
using MediatR;

namespace Exam1.QH.AdminQH
{
    public class AdminQuery
    {
        public record  class InsertAQ(Produ produc) :IRequest<Response<string>>;
        public record  class UpdateAQ(Produ produc) :IRequest<Response<string>>;
        public record class GetAllAQ(int PageNumber, int PageSize) : IRequest<Response<List<Produ>>>;

        public record class GetOneAQ(int id):IRequest<Response<Produ>>;
        public record class GetOneByNameAQ(string pname) :IRequest<Response<Produ>>;
       
        public record class DeleteAQ(int id):IRequest<Response<string>>;

       
    }
}
