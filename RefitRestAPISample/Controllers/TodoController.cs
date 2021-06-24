using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Refit;
using RefitRestAPISample.Abstraction;
using RefitRestAPISample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RefitRestAPISample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        //private readonly ITodoApi _todoApiService;
        private readonly APIConfigModel _config;
        public TodoController(IOptions<APIConfigModel> options)
        {
            //this._todoApiService = todoApiService;
           this._config = options.Value;
        }

        [HttpGet("GetTodos")]
        public async Task<IActionResult> GetTodos()
        {
            var apiResults = RestService.For<ITodoApi>(_config.APIBaseURL);
            return Ok(await apiResults.GetTodos());
        }

        [HttpGet("GetTodo/{Id}")]
        public async Task<IActionResult> GetTodo(int Id)
        {
            var apiResults = RestService.For<ITodoApi>(_config.APIBaseURL);
            return Ok(await apiResults.GetTodo(Id));
        }
    }
}
