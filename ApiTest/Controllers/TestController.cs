using ApiTest.Worker;
using Microsoft.AspNetCore.Mvc;

namespace ApiTest.Controllers
{
    [ApiController]
    [Route("test")]
    public class TestController(TaskWorker taskWorker) : ControllerBase
    {
        [HttpGet]
        public Task<int> Index()
        {
            return  Task.FromResult(taskWorker.Count);
        }

        [HttpGet("pool")]
        public async Task<IActionResult> GetPool()
        {
            ThreadPool.GetAvailableThreads(out int wt, out int ct);
            await Task.Delay(1);
            return Ok(new { wt, ct });
        }
    }
}
