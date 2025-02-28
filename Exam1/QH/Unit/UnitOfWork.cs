using Exam1.Models;
using Exam1.Repo.AdminRepoA;
using Exam1.Repo.PurchaseRepoA;
using Exam1.Repo.UserReopA;

namespace Exam1.QH.Unit
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly string _connectionstring;

        private readonly Exam1Context _exam1Context;
        private readonly IConfiguration _configuration;
        public IUserRepo UserWork { get; }
        public  IAdmin AdminWork { get; }
     public IPurches PurcjesWork {  get; }
        public UnitOfWork(Exam1Context exam1Context , IConfiguration configuration)
        {
            _configuration = configuration;
            _exam1Context = exam1Context;
            _connectionstring = _configuration.GetConnectionString("MyConnectionString");
            UserWork=new UserRepo(exam1Context, _connectionstring);
            AdminWork = new Admin(exam1Context, _connectionstring);
            PurcjesWork = new Purches(exam1Context, _connectionstring);
        }
    }
}
