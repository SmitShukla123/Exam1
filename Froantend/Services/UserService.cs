using System.Text;
using Exam1.Model;
using Newtonsoft.Json;

namespace Froantend.Services
{
    public class UserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Response<string>> SingU(Register register)
        {
            var response=new Response<string>();

            var jsoncontent= JsonConvert.SerializeObject(register);
            var content=new StringContent(jsoncontent, Encoding.UTF8,"application/json");
            var res = await _httpClient.PostAsync("http://localhost:5091/api/User", content);
            var result = await res.Content.ReadAsStringAsync();
            var apiResponse = JsonConvert.DeserializeObject<Response<string>>(result);
            if (res.IsSuccessStatusCode && apiResponse != null)
            {
                if (apiResponse.IsSuccess)  // ✅ Check the `IsSuccess` flag from API response
                {
                    response.Data = apiResponse.Data;
                    response.IsSuccess = true;
                    response.Success_Message=apiResponse.Success_Message;
                }
                else
                {
                    response.IsSuccess = false;
                    response.Error_Message = apiResponse.Error_Message;
                }
            }
            else
            {
                response.IsSuccess=false;
                response.Error_Message = $"Error: {res.StatusCode}, Message: {await res.Content.ReadAsStringAsync()}";
            }
            return response;
        }

        public async Task<Response<string>> SignIn(Login login)
        {
            var response = new Response<string>();

            var jsonContent = JsonConvert.SerializeObject(login);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var res = await _httpClient.PostAsync("http://localhost:5091/api/User/SingIn", content);
            var result = await res.Content.ReadAsStringAsync();

            // Try to deserialize API response safely
            var apiResponse = JsonConvert.DeserializeObject<Response<string>>(result);

            if (res.IsSuccessStatusCode && apiResponse != null)
            {
                response.IsSuccess = apiResponse.IsSuccess;
                response.Data = apiResponse.Data;
                response.Error_Message = apiResponse.Error_Message;
            }
            else if (apiResponse != null)  // 🛠 Handle API failure responses correctly
            {
                response.IsSuccess = false;
                response.Error_Message = apiResponse.Error_Message ?? "Invalid credentials. Please try again.";
            }
            else
            {
                response.IsSuccess = false;
                response.Error_Message = result; // ⚠️ Show exact backend error instead of generic "Something went wrong"
            }

            return response;
        }


    }
}
