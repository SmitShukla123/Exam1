using System.Net;
using System.Text;
using Exam1.Model;
using Exam1.Models;
using Newtonsoft.Json;

namespace Froantend.Services
{
    public class AdminService
    {
        private readonly HttpClient _httpClient;
        public AdminService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Response<string>> InsertAd(Produ produc)
        {
            Response<string> response = new Response<string>();

            var jsoncontent=JsonConvert.SerializeObject(produc);
            var content = new StringContent(jsoncontent, Encoding.UTF8, "application/json");
            var res = await _httpClient.PostAsync("http://localhost:5091/api/Admin/Save", content);
            var result=await res.Content.ReadAsStringAsync();
            var apiresponse=JsonConvert.DeserializeObject<Response<string>>(result);


            if (res.IsSuccessStatusCode && apiresponse != null)
            {
                response.IsSuccess = apiresponse.IsSuccess;
                response.Data = apiresponse.Data;
                response.Error_Message = apiresponse.Error_Message;
            }
            else if (apiresponse != null)
            {
                response.IsSuccess = false;
                response.Error_Message= apiresponse.Error_Message;
            }
            else
            {
                response.IsSuccess = false;
                response.Error_Message = result;
            }
            return response;

        }

        public async Task<Response<string>> Delete(int id)
        {
            Response<string> response = new Response<string>();
            var res = await _httpClient.DeleteAsync($"http://localhost:5091/api/Admin/delete?id={id}");
            var result = await res.Content.ReadAsStringAsync();
            var apiresponse = JsonConvert.DeserializeObject<Response<string>>(result);
            if (res.IsSuccessStatusCode && apiresponse != null)
            {
                response.IsSuccess = apiresponse.IsSuccess;
                response.Data = apiresponse.Data;
                response.Success_Message = apiresponse.Success_Message;
            }
            else if(apiresponse != null)
            {
                response.IsSuccess = false;
                response.Error_Message=apiresponse.Error_Message;
            }
            else
            {
                response.IsSuccess = false;
                response.Error_Message = result;
            }
            return response;

        }

        public async Task<Response<string>> UpdateAdmmin(Produ produ)
        {
            Response<string> res=new Response<string>();
            var jsoncontent=JsonConvert.SerializeObject(produ);
            var content=new StringContent(jsoncontent,Encoding.UTF8,"application/json");
            var response=await _httpClient.PutAsync("http://localhost:5091/api/Admin/Update", content);
            var result= await response.Content.ReadAsStringAsync();
            var apiresponse=JsonConvert.DeserializeObject<Response<string>>(result);

            if (response.IsSuccessStatusCode && apiresponse != null)
            {
                res.IsSuccess = apiresponse.IsSuccess;
                res.Data = apiresponse.Data;
                res.Success_Message = apiresponse.Success_Message;
            }
            else if (apiresponse != null)
            {
                res.IsSuccess = false;
                res.Error_Message = apiresponse.Error_Message;

            }
            else
            {
                res.IsSuccess = false;
                res.Error_Message = result; 
            }
            return res;
        }

        public async Task<Response<Produ>> GetOneBy(int id)
        {
            Response<Produ> res=new Response<Produ>();
            var response = await _httpClient.GetAsync($"http://localhost:5091/api/Admin/GetOne?id={id}");
            var result=await response.Content.ReadAsStringAsync();
            var apiresponse=JsonConvert.DeserializeObject<Response<Produ>>(result);
            if (response.IsSuccessStatusCode && apiresponse != null)
            {
                res.IsSuccess = apiresponse.IsSuccess;
                res.Data = apiresponse.Data;
                res.Success_Message = apiresponse.Success_Message;
            }
            else if (apiresponse != null)
            {
                res.IsSuccess = false;
                res.Error_Message = apiresponse.Error_Message;

            }
            else
            {
                res.IsSuccess = false;
                res.Error_Message = result;
            }
            return res;

        }

        public async Task<Response<List<Produ>>> GetALLP(int pageNumber, int pageSize)
        {
            Response<List<Produ>> res = new Response<List<Produ>>();

            var response = await _httpClient.GetAsync($"http://localhost:5091/api/Admin/ALL?pagenuber={pageNumber}&pagesize={pageSize}");
            var result = await response.Content.ReadAsStringAsync();
            var apiResponse = JsonConvert.DeserializeObject<Response<List<Produ>>>(result);

            if (response.IsSuccessStatusCode && apiResponse != null)
            {
                res.IsSuccess = apiResponse.IsSuccess;
                res.Data = apiResponse.Data;
                res.Success_Message = apiResponse.Success_Message; // ✅ Success message on success
            }
            else if (apiResponse != null)
            {
                res.IsSuccess = false;
                res.Error_Message = apiResponse.Error_Message;
            }
            else
            {
                res.IsSuccess = false;
                res.Error_Message = "Something went wrong while fetching products.";
            }

            return res;
        }

    }
}
