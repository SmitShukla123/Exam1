using System.Collections.Generic;
using AutoMapper;
using Exam1.Model;
using Exam1.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Exam1.QH.AdminQH.AdminQuery;

namespace Exam1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class AdminController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        public AdminController(IMediator mediator, IMapper mapper ,IConfiguration configuration)
        {
            _mediator = mediator;
            _mapper = mapper;
            _configuration = configuration;
        }

        [Route("Save")]
        [HttpPost]
        public async Task<IActionResult> InsertAdminP(Produ produc)
        {
            var response=await _mediator.Send(new InsertAQ(produc));

            if(response==null)
                return NotFound();

            Response<string> obj= _mapper.Map<Response<string>>(response);
            return Ok(obj);
        }

        [Route("ALL")]
        [HttpGet]
        public async Task<IActionResult> GetAllA(int pagenuber ,int pagesize)
        {
            var response = await _mediator.Send(new GetAllAQ(pagenuber,pagesize));

            if (response == null)
                return NotFound();

            Response<List<Produ>> obj=_mapper.Map<Response<List<Produ>>>(response);
            if(obj.IsSuccess==false)
            {
                return Ok(new Response<List<Produ>>
                {

                    IsSuccess = obj.IsSuccess,
                    Status = obj.Status,
                    Display_Error_Message = obj.Display_Error_Message,
                    Error_Message = obj.Error_Message,
                });
            }
            return Ok(new Response<List<Produ>>
            {
                IsSuccess = obj.IsSuccess,
                Status = obj.Status,
                Success_Message = obj.Success_Message,
                Data = obj.Data,
                PageNumber=obj.PageNumber,
                PageSize=obj.PageSize,
                TotalRecords=obj.TotalRecords
            });

        }

        [HttpGet]
        [Route("GetOne")]

        public async Task<IActionResult> GetOneById(int id)
        {
            var response=await _mediator.Send(new GetOneAQ(id));
            if (response == null) return NotFound();

            Response<Produ> obj=_mapper.Map<Response<Produ>>(response);
            if (obj.IsSuccess == false)
            {
                return Ok(new Response<Produ>
                {
                    IsSuccess = obj.IsSuccess,
                    Status = obj.Status,
                    Display_Error_Message = obj.Display_Error_Message,
                    Error_Message = obj.Error_Message,
                });
            }
            return Ok(new Response<Produ>
            {
                IsSuccess = obj.IsSuccess,
                Status = obj.Status,
                Success_Message = obj.Success_Message,
                Data = obj.Data
            });
        }


        [HttpGet]
        [Route("GetName")]

        public async Task<IActionResult> GetName(string pname)
        {
            var response = await _mediator.Send(new GetOneByNameAQ(pname));
            if (response == null) return NotFound();

            Response<Produ> obj = _mapper.Map<Response<Produ>>(response);
            if (obj.IsSuccess == false)
            {
                return Ok(new Response<Produ>
                {
                    IsSuccess = obj.IsSuccess,
                    Status = obj.Status,
                    Display_Error_Message = obj.Display_Error_Message,
                    Error_Message = obj.Error_Message,
                });
            }
            return Ok(new Response<Produ>
            {
                IsSuccess = obj.IsSuccess,
                Status = obj.Status,
                Success_Message = obj.Success_Message,
                Data = obj.Data
            });
        }

        [HttpDelete]
        [Route("delete")]

        public async Task<IActionResult> Delete(int id)
        {
            var response = await _mediator.Send(new DeleteAQ(id));
            if (response == null) return NotFound();

            Response<string> obj = _mapper.Map<Response<string>>(response);
            return Ok(obj);

        }

        [HttpPost]
        [Route("Update")]
        public async Task<IActionResult> Update(Produ produc)
        {
            var response = await _mediator.Send(new UpdateAQ(produc));
            if (response == null) return NotFound();

            Response<string> obj = _mapper.Map<Response<string>>(response);
            return Ok(obj);
        }
    }
}
