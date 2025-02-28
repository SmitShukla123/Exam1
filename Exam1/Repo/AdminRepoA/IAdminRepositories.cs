using Exam1.Model;

namespace Exam1.Repo.AdminRepoA
{
    public interface IAdminRepositories<T> where T : class
    {
        Task<Response<string>> InsertAdmin(Produ produc);
        Task<Response<string>> UpdateAdmin(Produ produc);
        Task<Response<List<Produ>>> GetAllAdmin(int pagenumber, int pagesize);

        Task<Response<Produ>> GetOneAd(int id);

        Task<Response<string>> DeleteA(int id);
        Task<Response<Produ>> GetOneByPname(string pname);
     }
}
