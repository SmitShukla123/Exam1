using Exam1.Repo.AdminRepoA;
using Exam1.Repo.PurchaseRepoA;
using Exam1.Repo.UserReopA;

namespace Exam1.QH.Unit
{
    public interface IUnitOfWork
    {
        IUserRepo UserWork { get; }
        IAdmin  AdminWork { get; }
        IPurches PurcjesWork { get; }
    }
}
