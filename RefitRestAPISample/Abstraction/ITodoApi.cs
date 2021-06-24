using Refit;
using RefitRestAPISample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RefitRestAPISample.Abstraction
{
    public interface ITodoApi
    {
        [Get("/todos")]
        Task<IEnumerable<TodoModel>> GetTodos();
    }
}
