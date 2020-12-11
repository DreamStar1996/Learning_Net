using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using User_Api.Models;

namespace User_Api.Controllers
{
    /// <summary>
    /// 测试获取数据
    /// </summary>
    [ApiController]
    [Route("/api/[Controller]")]
    public class VoteController : ControllerBase
    {

        /// <summary>
        /// 测试数据库连接
        /// </summary>
        /// <returns></returns>
        [HttpGet("/test/get")]
        public OkObjectResult get()
        {
            VoteContext db = new VoteContext();
            List<VoteData> votelist = db.VoteData.ToList();
            return Ok(from vote in votelist
                      select new
                      {
                          vote.Id,
                          vote.UserId,
                          vote.UserName
                      });
        }

        /// <summary>
        /// 测试发送请求
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [HttpPost("/test/post")]
        public JsonResult AAA(int? a, int? b) 
        { 
            if (a == null || b == null) 
                return new JsonResult(
                    new {
                        code = 0, result = "aaaaaaaa" 
                    }); 
            return new JsonResult(
                new { 
                    code = 2000, result = a + "|" + b 
                }); 
        }
    }
}
