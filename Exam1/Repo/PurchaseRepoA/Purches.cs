using Exam1.Model;
using Exam1.Models;
using Microsoft.EntityFrameworkCore;

namespace Exam1.Repo.PurchaseRepoA
{
    public class Purches : IPurchesRepositories<UserPurch>, IPurches
    {

        private readonly Exam1Context _exam1Context;
        private readonly string _connectionstring;

        public Purches(Exam1Context exam1Context,string connectionstring)
        {
            _exam1Context = exam1Context;
            _connectionstring = connectionstring;

        }

        public async Task<Response<List<newpr>>> GetAllPurchaseByUser(int id)
        {
            Response<List<newpr>> res = new();
            try
            {
                // Check if the user exists
                bool userExists = await _exam1Context.Users.AnyAsync(x => x.Uid == id);
                if (!userExists)
                {
                    res.IsSuccess = false;
                    res.Status = Response_Status.Fail;
                    res.Error_Message = "User does not exist.";
                    return res;
                }

                // Fetch all purchases for the given user ID with Product details
                //var product = await (
                //    from up in _exam1Context.UserProducts
                //    join p in _exam1Context.Products on up.Pid equals p.Pid
                //    where up.Uid == id
                //    select new newpr
                //    {
                //        pid = p.Pid,
                //        pname = p.Pname,
                //        cid = p.Cid,
                //        pimage = p.Pimage,
                //        pcost = p.Pcost,
                //        istock = p.Istock,
                //        astock = p.Astock,
                //        quntity = up.Quntity,
                //        peCost = up.PeCost,
                //        totalCost = up.TotalCost,
                //        date = up.Date
                //    }
                //).ToListAsync();
                var product = await (
    from up in _exam1Context.UserProducts
    join p in _exam1Context.Products on up.Pid equals p.Pid
    join c in _exam1Context.Categories on p.Cid equals c.Cid into categoryJoin
    from cat in categoryJoin.DefaultIfEmpty()  // Left Join (to handle null categories)
    where up.Uid == id
    select new newpr
    {
        pid = p.Pid,
        pname = p.Pname,
        cid = p.Cid,
        categoryName = cat != null ? cat.Cname : null,  // Add category name
        pimage = p.Pimage,
        pcost = p.Pcost,
        istock = p.Istock,
        astock = p.Astock,
        quntity = up.Quntity,
        peCost = up.PeCost,
        totalCost = up.TotalCost,
        date = up.Date
    }
).ToListAsync();


                // If no purchases are found
                if (product.Count == 0)
                {
                    res.IsSuccess = false;
                    res.Status = Response_Status.Fail;
                    res.Error_Message = "No purchases found for this user.";
                    return res;
                }

                res.IsSuccess = true;
                res.Status = Response_Status.Success;
                res.Data = product;
            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.Status = Response_Status.Fail;
                res.Error_Message = "Something went wrong: " + ex.Message;
            }
            return res; // ✅ Ensure all paths return a value
        }



        public async Task<Response<string>> InsertPurches(UserPurch purch)
        {
            Response<string> res = new();
            try
            {
                if (purch == null)
                {
                    res.IsSuccess = false;
                    res.Status = Response_Status.Fail;
                    res.Error_Message = "Please a Enter a details";
                    return res;
                }
                var user = await _exam1Context.Users.Where(x => x.Uid == purch.uid).FirstOrDefaultAsync();
                if (user == null)
                {
                    res.IsSuccess = false;
                    res.Status = Response_Status.Fail;
                    res.Error_Message = "User Not a Exits";
                    return res;
                }

                var product = await _exam1Context.Products.Where(x => x.Pid == purch.pid).FirstOrDefaultAsync();
                if (product == null)
                {
                    res.IsSuccess = false;
                    res.Status = Response_Status.Fail;
                    res.Error_Message = "Product Name is already exits";
                    return res;
                }
                if (product.Astock < purch.quntity)
                {
                    res.IsSuccess = false;
                    res.Status = Response_Status.Fail;
                    res.Error_Message = "Not enough stock available!";
                    return res;
                }

                product.Astock -= purch.quntity;

                UserProduct pro = new()
                {
                    Pid = purch.pid,
                    Uid = purch.uid,
                    Quntity = purch.quntity,
                    PeCost=purch.peCost,
                    TotalCost = purch.totalCost,
                    Date=DateTime.Now,
                    CreateAt = DateTime.Now,
                    Isdeleted = false
                };
                _exam1Context.UserProducts.Add(pro);
                _exam1Context.Products.Update(product);
               await _exam1Context.SaveChangesAsync();
                res.IsSuccess = true;
                res.Status = Response_Status.Success;
                res.Error_Message = "Product Add Succefully";
                return res;


            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.Status = Response_Status.Fail;
                res.Error_Message = "Something Wrong";
                return res;
            }
        }



    }
}
