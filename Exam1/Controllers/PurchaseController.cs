using System.Security.Claims;
using AutoMapper;
using Exam1.Model;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Exam1.QH.AdminQH.AdminQuery;
using static Exam1.QH.PurchesQh.PurchesQuery;

namespace Exam1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public PurchaseController( IMediator mediator, IMapper mapper)
        {
            _mapper=mapper;
            _mediator = mediator;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> InsertPurches(UserPurch punch)
        {
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value; // ✅ Get User ID from Token
            if (userId == null)
            {
                return Unauthorized(new { Message = "Invalid Token" });
            }
            punch.uid = int.Parse(userId);
            var Response = await _mediator.Send(new InsertPurcheQ(punch));
            if (Response == null) 
                return NotFound();

            Response<string> Obj=_mapper.Map<Response<string>>(Response);
            return Ok(Obj);

        }

        [HttpGet]
        [Route("GetOne")]

        public async Task<IActionResult> GetOneById(int id)
        {
            var response = await _mediator.Send(new GetBYIdQ(id));
            if (response == null) return NotFound();

            Response<List<newpr>> obj = _mapper.Map<Response<List<newpr>>>(response);
            if (obj.IsSuccess == false)
            {
                return Ok(new Response<List<newpr>>
                {
                    IsSuccess = obj.IsSuccess,
                    Status = obj.Status,
                    Display_Error_Message = obj.Display_Error_Message,
                    Error_Message = obj.Error_Message,
                });
            }
            return Ok(new Response<List<newpr>>
            {
                IsSuccess = obj.IsSuccess,
                Status = obj.Status,
                Success_Message = obj.Success_Message,
                Data = obj.Data
            });
        }
    }
}
