using CommonLib;
using IBLL;
using Microsoft.AspNetCore.Mvc;
using Models.DTO;
using RepositorySystemDotNetCore.Filters;
using System.Collections.Generic;

namespace RepositorySystemInterface.Controllers
{
    [Area("Admin")]
    [CustomAttribute]
    public class ConsumableRecordController : Controller
    {
        private IConsumableRecordBLL _consumableRecordBLL;
        public ConsumableRecordController(IConsumableRecordBLL consumableRecordBL)
        {
            _consumableRecordBLL = consumableRecordBL;
        }
        // GET: ConsumableRecord
        public IActionResult ListView()
        {
            return View();
        }
        public IActionResult CreatetConsumableRecordView()
        {
            return View();
        }
        public IActionResult GetConsumableRecord(int page, int limit, string id, string name)
        {
            int count;

            List<GetConsumableRecordDTO> list = _consumableRecordBLL.GetConsumableRecordes(page, limit, id, name, out count);

            ReturnResult result = new ReturnResult()
            {
                Code = 0,
                Msg = "获取成功",
                Data = list,
                IsSuccess = true,
                Count = count
            };

            return Json(result);
        }
    }
}