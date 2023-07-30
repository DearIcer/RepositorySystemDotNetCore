using CommonLib;
using IBLL;
using Intersoft.Crosslight.Forms;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.DTO;
using RepositorySystemDotNetCore.Filters;

namespace RepositorySystemInterface.Controllers
{
    [Area("Admin")]
    [CustomAttribute]
    public class WorkFlow_ModelController : Controller
    {
        // GET: WorkFlow_Model  GetAllWorkFlow_Model
        private IWorkFlow_ModelBLL _workFlow_ModelBLL;
        public WorkFlow_ModelController(IWorkFlow_ModelBLL workFlow_ModelBLL)
        {
            _workFlow_ModelBLL = workFlow_ModelBLL;
        }

        public IActionResult ListView()
        {
            return View();
        }
        public IActionResult CreatetWorkFlow_ModelView()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetAllWorkFlow_Model(int page, int limit, string id)
        {
            int count;

            List<GetWorkFlow_ModelDTO> list = _workFlow_ModelBLL.GetWorkFlow_Model(page, limit, id , out count);

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

        [HttpPost]
        public IActionResult CreateWorkFlow_Model([Form] WorkFlow_Model infos)
        {
            string msg;

            bool isSuccess = _workFlow_ModelBLL.CreateWorkFlow_Model(infos, out msg);

            ReturnResult result = new ReturnResult();

            result.Msg = msg;

            result.IsSuccess = isSuccess;

            if (isSuccess)
            {
                result.Code = 200;
            }
            return Json(result);
        }


    }
}