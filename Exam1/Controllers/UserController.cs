using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Exam1.Model;
using Exam1.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using static Exam1.QH.UserQh.UserQuery;

namespace Exam1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public UserController(IMediator mediator, IMapper mapper,IConfiguration configuration)
        {
            _mediator = mediator;
            _mapper = mapper;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> SingUp(Register register)
        {
            var response= await _mediator.Send(new SingUpQ(register));
            if(response==null)
            return NotFound();

            Response<string> obj = _mapper.Map<Response<string>>(response);
            return Ok(obj);

        }
        [Route("SingIn")]
        [HttpPost]
        public async Task<IActionResult> SingIn(Login login)
        {
            var response = await _mediator.Send(new LoginQ(login));
            if (response == null)
                return NotFound();

            Response<string> obj = _mapper.Map<Response<string>>(response);
            if(obj.IsSuccess==false)
            {
                return Unauthorized(new Response<string>
                {
                    IsSuccess = obj.IsSuccess,
                    Status = obj.Status,
                    Error_Message = obj.Error_Message,

                });
            }
          

           
            var token = GeneratedToken(login.email);
            return Ok(new Response<string>
            {
                IsSuccess = obj.IsSuccess,
                Status = obj.Status,
                Success_Message = obj.Success_Message,
                Data = obj.Data,
                Token=token,
            });



        }

        private string GeneratedToken(string email)
        {
            var jwtkey = _configuration["Jwt:Key"];
            var jwtissuser = _configuration["Jwt:Issuer"];
            var jwtaudience = _configuration["Jwt:Audience"];
            //var jwtsubjecct = _configuration["Jwt:Subject"];
            var key=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtkey));
            var creds=new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.Name,email),
                //new Claim(ClaimTypes.NameIdentifier, id.ToString())
            };
            var token=new JwtSecurityToken(jwtissuser, jwtaudience, claims,expires:DateTime.UtcNow.AddDays(1),signingCredentials:creds);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
      
    }
}
