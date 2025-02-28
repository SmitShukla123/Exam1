using Exam1.Model;

namespace Exam1.Repo.PurchaseRepoA
{
    public interface IPurchesRepositories<T> where T :class
    {
        Task<Response<string>> InsertPurches(UserPurch purch);

        //Task<Response<List<Produ>>> GetAllPurchaseByUser(int id);
        Task<Response<List<newpr>>> GetAllPurchaseByUser(int id);
    }
}
